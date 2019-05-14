Imports System
Imports System.Linq
Imports System.Windows.Forms
Imports Google.Apis.Calendar.v3

Namespace SchedulerGSync
	Partial Public Class SyncOptionsForm
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub
		Private Property Service() As CalendarService

		Public Sub New(ByVal service As CalendarService)
			Me.New()
			Me.Service = service
			Me.lookUpEdit1.Properties.NullValuePromptShowForEmptyValue = False
			Me.lookUpEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
			Me.lookUpEdit1.Properties.NullText = String.Empty
			Me.lookUpEdit1.Properties.ShowHeader = False
		End Sub

		Public Property CalendarId() As String

		Async Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad(e)
			Dim listRequest As CalendarListResource.ListRequest = Service.CalendarList.List()
			Dim calendarList = Await listRequest.ExecuteAsync()
			Me.lookUpEdit1.Properties.DataSource = calendarList.Items
			Me.lookUpEdit1.Properties.DisplayMember = "Summary"
			Me.lookUpEdit1.Properties.ValueMember = "Id"
			Me.lookUpEdit1.Properties.Columns.Clear()
			Me.lookUpEdit1.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Summary"))
			Me.lookUpEdit1.EditValue = CalendarId
			AddHandler lookUpEdit1.EditValueChanged, AddressOf OnLookUpEdit1EditValueChanged
		End Sub

		Private Sub OnLookUpEdit1EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			CalendarId = DirectCast(Me.lookUpEdit1.EditValue, String)
		End Sub
	End Class
End Namespace
