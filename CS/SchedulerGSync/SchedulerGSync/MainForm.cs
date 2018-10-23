using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.EntityFrameworkCore;
using SchedulerGSync.DAL;
using System.Linq;
using DevExpress.XtraEditors;

namespace SchedulerGSync {
    public partial class MainForm : XtraForm {
        SchedulerGSyncDbContext dbContext;
        readonly string[] scopes = { CalendarService.Scope.Calendar };
        UserCredential credential;
        CalendarService service;
        string defaultLabelKey = String.Empty;

        public MainForm() {
            InitializeComponent();
            Text = $"{nameof(SchedulerGSync)}";
            this.dbContext = new SchedulerGSyncDbContext();            
        }

        void InitScheduler() {
            this.schedulerControl1.DayView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Never;
            this.schedulerControl1.DayView.AppointmentDisplayOptions.AllDayAppointmentsStatusDisplayType = AppointmentStatusDisplayType.Never;
            this.schedulerControl1.WorkWeekView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Never;
            this.schedulerControl1.WorkWeekView.AppointmentDisplayOptions.AllDayAppointmentsStatusDisplayType = AppointmentStatusDisplayType.Never;
            this.schedulerControl1.FullWeekView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Never;
            this.schedulerControl1.FullWeekView.AppointmentDisplayOptions.AllDayAppointmentsStatusDisplayType = AppointmentStatusDisplayType.Never;
            this.schedulerControl1.MonthView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Never;
            this.schedulerControl1.AgendaView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Never;

            this.dbContext.Database.EnsureCreated();
            this.dbContext.AppointmentObjects.Load();
            BindingList<AppointmentObject> bindingList = this.dbContext.AppointmentObjects.Local.ToBindingList();
            BindDataToStorage(bindingList);
            this.dxGoogleCalendarSync1.EventValuesRequested += OnEventValuesRequested;
            this.dxGoogleCalendarSync1.AppointmentValuesRequested += OnAppointmentValuesRequested;
            this.dxGoogleCalendarSync1.CompareEventAndAppointment += OnCompareEventAndAppointment;
        }

        void OnCompareEventAndAppointment(object sender, DevExpress.XtraScheduler.GoogleCalendar.CompareEventAndAppointmentEventArgs e) {
            if (!e.IsEqual)
                return;
            var eventColorId = e.Event.ColorId ?? this.defaultLabelKey;
            e.IsEqual = eventColorId == (string)e.Appointment.LabelKey;
        }

        void OnAppointmentValuesRequested(object sender, DevExpress.XtraScheduler.GoogleCalendar.ObjectValuesRequestedEventArgs e) {
            if ((string)e.Appointment.LabelKey == this.defaultLabelKey)
                e.Event.ColorId = null;
            else
                e.Event.ColorId = (string)e.Appointment.LabelKey;
        }

        void OnEventValuesRequested(object sender, DevExpress.XtraScheduler.GoogleCalendar.ObjectValuesRequestedEventArgs e) {
            e.Appointment.LabelKey = e.Event.ColorId ?? this.defaultLabelKey;
        }

        void OnBbiSyncItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.dxGoogleCalendarSync1.CalendarId = ApplicationConfig.Instance.CalendarId;
            this.dxGoogleCalendarSync1.CalendarService = this.service;
            this.dxGoogleCalendarSync1.Synchronize();
        }

        async protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            try {
                this.credential = await AuthorizeToGoogle();
                this.service = new CalendarService(new BaseClientService.Initializer() {
                    HttpClientInitializer = this.credential,
                    ApplicationName = nameof(SchedulerGSync)
                });
                await UpdateCalendarRelatedData();
                InitScheduler();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        
        async Task UpdateLabels() {
            this.schedulerDataStorage1.Labels.Clear();
            this.schedulerDataStorage1.Statuses.Clear();
            string calendarId = ApplicationConfig.Instance.CalendarId;
            this.defaultLabelKey = String.Empty;
            if (String.IsNullOrEmpty(calendarId))
                return;
            var colors = await this.service.Colors.Get().ExecuteAsync();
            var calendar = await this.service.CalendarList.Get(calendarId).ExecuteAsync();
            Color defaultColor = ColorHelper.FromString(colors.Calendar[calendar.ColorId].Background);
            foreach (var colorDefinition in colors.Event__) {
                Color color = ColorHelper.FromString(colorDefinition.Value.Background);
                var label = this.schedulerDataStorage1.Labels.Items.CreateNewLabel(colorDefinition.Key, $"Color {colorDefinition.Key}", $"Color {colorDefinition.Key}", color);
                this.schedulerDataStorage1.Labels.Items.Add(label);
                if (color == defaultColor)
                    this.defaultLabelKey = colorDefinition.Key;
            }
            if (String.IsNullOrEmpty(defaultLabelKey)) {
                this.defaultLabelKey = "Calendar";
                var defaultLabel = this.schedulerDataStorage1.Labels.Items.CreateNewLabel(defaultLabelKey, $"Default", $"Default", defaultColor);
                this.schedulerDataStorage1.Labels.Items.Add(defaultLabel);
            }
        }
                
        async Task<UserCredential> AuthorizeToGoogle() {
            using (FileStream stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read)) {
                string credPath = Environment.GetFolderPath(
                    Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, $".credentials/{nameof(SchedulerGSync)}.json");

                return await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    this.scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true));
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            this.dbContext.SaveChanges();
            ApplicationConfig.Instance.Save();
        }

        void BindDataToStorage(BindingList<AppointmentObject> bindingList) {
            var mappings = this.schedulerDataStorage1.Appointments.Mappings;
            mappings.Start = "Start";
            mappings.End = "End";
            mappings.Subject = "Subject";
            mappings.Type = "AppointmentType";
            mappings.RecurrenceInfo = "RecurrenceInfo";
            mappings.ReminderInfo = "ReminderInfo";
            mappings.Location = "Location";
            mappings.Label = "Label";
            this.schedulerDataStorage1.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("gId", "GId"));
            this.schedulerDataStorage1.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("etag", "ETag"));
            this.schedulerDataStorage1.Appointments.DataSource = bindingList;
        }

        async void OnBbiOptionsItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            SyncOptionsForm form = new SyncOptionsForm(this.service);
            form.CalendarId = ApplicationConfig.Instance.CalendarId;
            if (form.ShowDialog(this) == DialogResult.OK) {
                if (ApplicationConfig.Instance.CalendarId != form.CalendarId) {
                    ClearSchedulerData();
                    ApplicationConfig.Instance.CalendarId = form.CalendarId;
                    await UpdateCalendarRelatedData();
                }
            }
        }

        async Task UpdateCalendarRelatedData() {
            await UpdateLabels();
            await UpdateCaption();
        }

        void ClearSchedulerData() {
            this.schedulerDataStorage1.Appointments.DataSource = null;

            this.dbContext.Dispose();
            File.Delete(SchedulerGSyncDbContext.DBFileName);
            this.dbContext = new SchedulerGSyncDbContext();
            this.dbContext.Database.EnsureCreated();
            this.dbContext.AppointmentObjects.Load();

            this.schedulerDataStorage1.Appointments.DataSource = this.dbContext.AppointmentObjects.Local.ToBindingList();
            this.dxGoogleCalendarSync1.Save();
        }

        async Task UpdateCaption() {
            string calendarId = ApplicationConfig.Instance.CalendarId;
            if (String.IsNullOrEmpty(calendarId))
                return;
            var calendar = await this.service.Calendars.Get(calendarId).ExecuteAsync();
            Text = $"{nameof(SchedulerGSync)} - {calendar.Summary}";
        }
    }
}
