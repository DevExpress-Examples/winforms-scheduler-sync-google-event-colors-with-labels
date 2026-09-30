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
Imports DevExpress.XtraEditors

Namespace SchedulerGSync

    Public Partial Class MainForm
        Inherits XtraForm

        Private dbContext As SchedulerGSyncDbContext

        Private ReadOnly scopes As String() = {CalendarService.Scope.Calendar}

        Private credential As UserCredential

        Private service As CalendarService

        Private defaultLabelKey As String = String.Empty

        Public Sub New()
            InitializeComponent()
            Text = $"{NameOf(SchedulerGSync)}"
            dbContext = New SchedulerGSyncDbContext()
        End Sub

        Private Sub InitScheduler()
            schedulerControl1.DayView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Never
            schedulerControl1.DayView.AppointmentDisplayOptions.AllDayAppointmentsStatusDisplayType = AppointmentStatusDisplayType.Never
            schedulerControl1.WorkWeekView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Never
            schedulerControl1.WorkWeekView.AppointmentDisplayOptions.AllDayAppointmentsStatusDisplayType = AppointmentStatusDisplayType.Never
            schedulerControl1.FullWeekView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Never
            schedulerControl1.FullWeekView.AppointmentDisplayOptions.AllDayAppointmentsStatusDisplayType = AppointmentStatusDisplayType.Never
            schedulerControl1.MonthView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Never
            schedulerControl1.AgendaView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Never
            dbContext.Database.EnsureCreated()
            dbContext.AppointmentObjects.Load()
            Dim bindingList As BindingList(Of AppointmentObject) = dbContext.AppointmentObjects.Local.ToBindingList()
            BindDataToStorage(bindingList)
            AddHandler dxGoogleCalendarSync1.EventValuesRequested, AddressOf OnEventValuesRequested
            AddHandler dxGoogleCalendarSync1.AppointmentValuesRequested, AddressOf OnAppointmentValuesRequested
            AddHandler dxGoogleCalendarSync1.CompareEventAndAppointment, AddressOf OnCompareEventAndAppointment
        End Sub

        Private Sub OnCompareEventAndAppointment(ByVal sender As Object, ByVal e As GoogleCalendar.CompareEventAndAppointmentEventArgs)
            If Not e.IsEqual Then Return
            Dim eventColorId = If(e.Event.ColorId, defaultLabelKey)
            e.IsEqual = Equals(eventColorId, CStr(e.Appointment.LabelKey))
        End Sub

        Private Sub OnAppointmentValuesRequested(ByVal sender As Object, ByVal e As GoogleCalendar.ObjectValuesRequestedEventArgs)
            If Equals(CStr(e.Appointment.LabelKey), defaultLabelKey) Then
                e.Event.ColorId = Nothing
            Else
                e.Event.ColorId = CStr(e.Appointment.LabelKey)
            End If
        End Sub

        Private Sub OnEventValuesRequested(ByVal sender As Object, ByVal e As GoogleCalendar.ObjectValuesRequestedEventArgs)
            e.Appointment.LabelKey = If(e.Event.ColorId, defaultLabelKey)
        End Sub

        Private Sub OnBbiSyncItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
            dxGoogleCalendarSync1.CalendarId = ApplicationConfig.Instance.CalendarId
            dxGoogleCalendarSync1.CalendarService = service
            dxGoogleCalendarSync1.Synchronize()
        End Sub

        Async Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            Try
                credential = Await AuthorizeToGoogle()
                service = New CalendarService(New BaseClientService.Initializer() With {.HttpClientInitializer = credential, .ApplicationName = NameOf(SchedulerGSync)})
                Await UpdateCalendarRelatedData()
                InitScheduler()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub

        Private Async Function UpdateLabels() As Task
            schedulerDataStorage1.Labels.Clear()
            schedulerDataStorage1.Statuses.Clear()
            Dim calendarId As String = ApplicationConfig.Instance.CalendarId
            defaultLabelKey = String.Empty
            If String.IsNullOrEmpty(calendarId) Then Return
            Dim colors = Await service.Colors.Get().ExecuteAsync()
            Dim calendar = Await service.CalendarList.Get(calendarId).ExecuteAsync()
            Dim defaultColor As Color = FromString(colors.Calendar(calendar.ColorId).Background)
            For Each colorDefinition In colors.Event__
                Dim color As Color = FromString(colorDefinition.Value.Background)
                Dim label = schedulerDataStorage1.Labels.Items.CreateNewLabel(colorDefinition.Key, $"Color {colorDefinition.Key}", $"Color {colorDefinition.Key}", color)
                schedulerDataStorage1.Labels.Items.Add(label)
                If color = defaultColor Then defaultLabelKey = colorDefinition.Key
            Next

            If String.IsNullOrEmpty(defaultLabelKey) Then
                defaultLabelKey = "Calendar"
                Dim defaultLabel = schedulerDataStorage1.Labels.Items.CreateNewLabel(defaultLabelKey, $"Default", $"Default", defaultColor)
                schedulerDataStorage1.Labels.Items.Add(defaultLabel)
            End If
        End Function

        Private Async Function AuthorizeToGoogle() As Task(Of UserCredential)
            Dim secretsPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "client_secret.json")
            If Not File.Exists(secretsPath) Then Throw New FileNotFoundException("Google OAuth client secrets file was not found. Place a valid client_secret.json next to the executable.", secretsPath)
            Using stream As FileStream = New FileStream(secretsPath, FileMode.Open, FileAccess.Read)
                Dim credPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                credPath = Path.Combine(credPath, $".credentials/{NameOf(SchedulerGSync)}.json")
                Dim clientSecrets = GoogleClientSecrets.FromStream(stream)
                If clientSecrets?.Secrets Is Nothing Then Throw New InvalidOperationException("The client_secret.json file is invalid. Place a valid client_secret.json next to the executable.")
                Return Await GoogleWebAuthorizationBroker.AuthorizeAsync(clientSecrets.Secrets, scopes, "user", CancellationToken.None, New FileDataStore(credPath, True))
            End Using
        End Function

        Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
            MyBase.OnFormClosing(e)
            dbContext.SaveChanges()
            ApplicationConfig.Instance.Save()
        End Sub

        Private Sub BindDataToStorage(ByVal bindingList As BindingList(Of AppointmentObject))
            Dim mappings = schedulerDataStorage1.Appointments.Mappings
            mappings.Start = "Start"
            mappings.End = "End"
            mappings.Subject = "Subject"
            mappings.Type = "AppointmentType"
            mappings.RecurrenceInfo = "RecurrenceInfo"
            mappings.ReminderInfo = "ReminderInfo"
            mappings.Location = "Location"
            mappings.Label = "Label"
            schedulerDataStorage1.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("gId", "GId"))
            schedulerDataStorage1.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("etag", "ETag"))
            schedulerDataStorage1.Appointments.DataSource = bindingList
        End Sub

        Private Async Sub OnBbiOptionsItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
            Dim form As SyncOptionsForm = New SyncOptionsForm(service)
            form.CalendarId = ApplicationConfig.Instance.CalendarId
            If form.ShowDialog(Me) = DialogResult.OK Then
                If Not Equals(ApplicationConfig.Instance.CalendarId, form.CalendarId) Then
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
            schedulerDataStorage1.Appointments.DataSource = Nothing
            dbContext.Dispose()
            File.Delete(SchedulerGSyncDbContext.DBFileName)
            dbContext = New SchedulerGSyncDbContext()
            dbContext.Database.EnsureCreated()
            dbContext.AppointmentObjects.Load()
            schedulerDataStorage1.Appointments.DataSource = dbContext.AppointmentObjects.Local.ToBindingList()
            dxGoogleCalendarSync1.Save()
        End Sub

        Private Async Function UpdateCaption() As Task
            Dim calendarId As String = ApplicationConfig.Instance.CalendarId
            If String.IsNullOrEmpty(calendarId) Then Return
            Dim calendar = Await service.Calendars.Get(calendarId).ExecuteAsync()
            Text = $"{NameOf(SchedulerGSync)} - {calendar.Summary}"
        End Function
    End Class
End Namespace
