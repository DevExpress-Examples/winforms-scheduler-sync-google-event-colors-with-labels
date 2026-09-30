using System;
using System.Linq;
using System.Windows.Forms;
using Google.Apis.Calendar.v3;

namespace SchedulerGSync {
    public partial class SyncOptionsForm : Form {        
        public SyncOptionsForm() {
            InitializeComponent();
        }
        CalendarService Service { get; set; }
        
        public SyncOptionsForm(CalendarService service) : this() {
            Service = service;
            this.lookUpEdit1.Properties.NullValuePromptShowForEmptyValue = false;
            this.lookUpEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.lookUpEdit1.Properties.NullText = String.Empty;
            this.lookUpEdit1.Properties.ShowHeader = false;
        }

        public string CalendarId { get; set; }

        async protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            CalendarListResource.ListRequest listRequest = Service.CalendarList.List();
            var calendarList = await listRequest.ExecuteAsync();
            this.lookUpEdit1.Properties.DataSource = calendarList.Items;
            this.lookUpEdit1.Properties.DisplayMember = "Summary";
            this.lookUpEdit1.Properties.ValueMember = "Id";
            this.lookUpEdit1.Properties.Columns.Clear();
            this.lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Summary"));
            this.lookUpEdit1.EditValue = CalendarId;
            this.lookUpEdit1.EditValueChanged += OnLookUpEdit1EditValueChanged;
        }

        void OnLookUpEdit1EditValueChanged(object sender, EventArgs e) {
            CalendarId = (string)this.lookUpEdit1.EditValue;
        }
    }
}
