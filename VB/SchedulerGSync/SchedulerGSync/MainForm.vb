Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Calendar.v3
Imports Google.Apis.Services
Imports Google.Apis.Util.Store
Imports Microsoft.EntityFrameworkCore
Imports SchedulerGSync.DAL
Imports System.Linq
Imports DevExpress.XtraEditors

Namespace SchedulerGSync
	Partial Public Class MainForm
		Inherits XtraForm

		Private dbContext As SchedulerGSyncDbContext
		Private ReadOnly scopes() As String = { CalendarService.Scope.Calendar }
		Private credential As UserCredential
		Private service As CalendarService
		Private defaultLabelKey As String = String.Empty

		Public Sub New()
			InitializeComponent()
			Text = $"{NameOf(SchedulerGSync)}"
			Me.dbContext = New SchedulerGSyncDbContext()
		End Sub

		Private Sub InitScheduler()
			Me.schedulerControl1.DayView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Never
			Me.schedulerControl1.DayView.AppointmentDisplayOptions.AllDayAppointmentsStatusDisplayType = AppointmentStatusDisplayType.Never
			Me.schedulerControl1.WorkWeekView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Never
			Me.schedulerControl1.WorkWeekView.AppointmentDisplayOptions.AllDayAppointmentsStatusDisplayType = AppointmentStatusDisplayType.Never
			Me.schedulerControl1.FullWeekView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Never
			Me.schedulerControl1.FullWeekView.AppointmentDisplayOptions.AllDayAppointmentsStatusDisplayType = AppointmentStatusDisplayType.Never
			Me.schedulerControl1.MonthView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Never
			Me.schedulerControl1.AgendaView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Never

			Me.dbContext.Database.EnsureCreated()
			Me.dbContext.AppointmentObjects.Load()
			Dim bindingList As BindingList(Of AppointmentObject) = Me.dbContext.AppointmentObjects.Local.ToBindingList()
			BindDataToStorage(bindingList)
			AddHandler dxGoogleCalendarSync1.EventValuesRequested, AddressOf OnEventValuesRequested
			AddHandler dxGoogleCalendarSync1.AppointmentValuesRequested, AddressOf OnAppointmentValuesRequested
			AddHandler dxGoogleCalendarSync1.CompareEventAndAppointment, AddressOf OnCompareEventAndAppointment
		End Sub

		Private Sub OnCompareEventAndAppointment(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.GoogleCalendar.CompareEventAndAppointmentEventArgs)
			If Not e.IsEqual Then
				Return
			End If
			Dim eventColorId = If(e.Event.ColorId, Me.defaultLabelKey)
			e.IsEqual = eventColorId = DirectCast(e.Appointment.LabelKey, String)
		End Sub

		Private Sub OnAppointmentValuesRequested(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.GoogleCalendar.ObjectValuesRequestedEventArgs)
			If CStr(e.Appointment.LabelKey) = Me.defaultLabelKey Then
				e.Event.ColorId = Nothing
			Else
				e.Event.ColorId = CStr(e.Appointment.LabelKey)
			End If
		End Sub

		Private Sub OnEventValuesRequested(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.GoogleCalendar.ObjectValuesRequestedEventArgs)
			e.Appointment.LabelKey = If(e.Event.ColorId, Me.defaultLabelKey)
		End Sub

		Private Sub OnBbiSyncItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiSync.ItemClick
			Me.dxGoogleCalendarSync1.CalendarId = ApplicationConfig.Instance.CalendarId
			Me.dxGoogleCalendarSync1.CalendarService = Me.service
			Me.dxGoogleCalendarSync1.Synchronize()
		End Sub

		Async Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad(e)
			Try
				Me.credential = Await AuthorizeToGoogle()
				Me.service = New CalendarService(New BaseClientService.Initializer() With {
					.HttpClientInitializer = Me.credential,
					.ApplicationName = NameOf(SchedulerGSync)
				})
				Await UpdateCalendarRelatedData()
				InitScheduler()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Async Function UpdateLabels() As Task
			Me.schedulerDataStorage1.Labels.Clear()
			Me.schedulerDataStorage1.Statuses.Clear()
			Dim calendarId As String = ApplicationConfig.Instance.CalendarId
			Me.defaultLabelKey = String.Empty
			If String.IsNullOrEmpty(calendarId) Then
				Return
			End If
			Dim colors = Await Me.service.Colors.Get().ExecuteAsync()
			Dim calendar = Await Me.service.CalendarList.Get(calendarId).ExecuteAsync()
			Dim defaultColor As Color = ColorHelper.FromString(colors.Calendar(calendar.ColorId).Background)
			For Each colorDefinition In colors.Event__
				Dim color As Color = ColorHelper.FromString(colorDefinition.Value.Background)
				Dim label = Me.schedulerDataStorage1.Labels.Items.CreateNewLabel(colorDefinition.Key, $"Color {colorDefinition.Key}", $"Color {colorDefinition.Key}", color)
				Me.schedulerDataStorage1.Labels.Items.Add(label)
				If color = defaultColor Then
					Me.defaultLabelKey = colorDefinition.Key
				End If
			Next colorDefinition
			If String.IsNullOrEmpty(defaultLabelKey) Then
				Me.defaultLabelKey = "Calendar"
				Dim defaultLabel = Me.schedulerDataStorage1.Labels.Items.CreateNewLabel(defaultLabelKey, $"Default", $"Default", defaultColor)
				Me.schedulerDataStorage1.Labels.Items.Add(defaultLabel)
			End If
		End Function

		Private Async Function AuthorizeToGoogle() As Task(Of UserCredential)
			Using stream As New FileStream("client_secret.json", FileMode.Open, FileAccess.Read)
				Dim credPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
				credPath = Path.Combine(credPath, $".credentials/{NameOf(SchedulerGSync)}.json")

				Return Await GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Me.scopes, "user", CancellationToken.None, New FileDataStore(credPath, True))
			End Using
		End Function

		Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
			MyBase.OnFormClosing(e)
			Me.dbContext.SaveChanges()
			ApplicationConfig.Instance.Save()
		End Sub

		Private Sub BindDataToStorage(ByVal bindingList As BindingList(Of AppointmentObject))
			Dim mappings = Me.schedulerDataStorage1.Appointments.Mappings
			mappings.Start = "Start"
			mappings.End = "End"
			mappings.Subject = "Subject"
			mappings.Type = "AppointmentType"
			mappings.RecurrenceInfo = "RecurrenceInfo"
			mappings.ReminderInfo = "ReminderInfo"
			mappings.Location = "Location"
			mappings.Label = "Label"
			Me.schedulerDataStorage1.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("gId", "GId"))
			Me.schedulerDataStorage1.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("etag", "ETag"))
			Me.schedulerDataStorage1.Appointments.DataSource = bindingList
		End Sub

		Private Async Sub OnBbiOptionsItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiOptions.ItemClick
			Dim form As New SyncOptionsForm(Me.service)
			form.CalendarId = ApplicationConfig.Instance.CalendarId
			If form.ShowDialog(Me) = DialogResult.OK Then
				If ApplicationConfig.Instance.CalendarId <> form.CalendarId Then
					ClearSchedulerData()
					ApplicationConfig.Instance.CalendarId = form.CalendarId
					Await UpdateCalendarRelatedData()
				End If
			End If
		End Sub

		Private Async Function UpdateCalendarRelatedData() As Task
			Await UpdateLabels()
			Await UpdateCaption()
		End Function

		Private Sub ClearSchedulerData()
			Me.schedulerDataStorage1.Appointments.DataSource = Nothing

			Me.dbContext.Dispose()
			File.Delete(SchedulerGSyncDbContext.DBFileName)
			Me.dbContext = New SchedulerGSyncDbContext()
			Me.dbContext.Database.EnsureCreated()
			Me.dbContext.AppointmentObjects.Load()

			Me.schedulerDataStorage1.Appointments.DataSource = Me.dbContext.AppointmentObjects.Local.ToBindingList()
			Me.dxGoogleCalendarSync1.Save()
		End Sub

		Private Async Function UpdateCaption() As Task
			Dim calendarId As String = ApplicationConfig.Instance.CalendarId
			If String.IsNullOrEmpty(calendarId) Then
				Return
			End If
			Dim calendar = Await Me.service.Calendars.Get(calendarId).ExecuteAsync()
			Text = $"{NameOf(SchedulerGSync)} - {calendar.Summary}"
		End Function
	End Class
End Namespace
