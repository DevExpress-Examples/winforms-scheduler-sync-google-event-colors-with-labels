Imports System
Imports System.Windows.Forms
Imports Google.Apis.Calendar.v3

Namespace SchedulerGSync

    Public Partial Class SyncOptionsForm
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Property Service As CalendarService

        Public Sub New(ByVal service As CalendarService)
            Me.New()
            Me.Service = service
            lookUpEdit1.Properties.NullValuePromptShowForEmptyValue = False
            lookUpEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
            lookUpEdit1.Properties.NullText = String.Empty
            lookUpEdit1.Properties.ShowHeader = False
        End Sub

        Public Property CalendarId As String

        Async Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            Dim listRequest As CalendarListResource.ListRequest = Service.CalendarList.List()
            Dim calendarList = Await listRequest.ExecuteAsync()
            lookUpEdit1.Properties.DataSource = calendarList.Items
            lookUpEdit1.Properties.DisplayMember = "Summary"
            lookUpEdit1.Properties.ValueMember = "Id"
            lookUpEdit1.Properties.Columns.Clear()
            lookUpEdit1.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Summary"))
            lookUpEdit1.EditValue = CalendarId
            AddHandler lookUpEdit1.EditValueChanged, AddressOf OnLookUpEdit1EditValueChanged
        End Sub

        Private Sub OnLookUpEdit1EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            CalendarId = CStr(lookUpEdit1.EditValue)
        End Sub
    End Class
End Namespace
