namespace SchedulerGSync {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerDataStorage1 = new DevExpress.XtraScheduler.SchedulerDataStorage(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.newAppointmentItem1 = new DevExpress.XtraScheduler.UI.NewAppointmentItem();
            this.newRecurringAppointmentItem1 = new DevExpress.XtraScheduler.UI.NewRecurringAppointmentItem();
            this.navigateViewBackwardItem1 = new DevExpress.XtraScheduler.UI.NavigateViewBackwardItem();
            this.navigateViewForwardItem1 = new DevExpress.XtraScheduler.UI.NavigateViewForwardItem();
            this.gotoTodayItem1 = new DevExpress.XtraScheduler.UI.GotoTodayItem();
            this.switchToDayViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToDayViewItem();
            this.switchToWorkWeekViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToWorkWeekViewItem();
            this.switchToWeekViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToWeekViewItem();
            this.switchToFullWeekViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToFullWeekViewItem();
            this.switchToMonthViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToMonthViewItem();
            this.switchToAgendaViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToAgendaViewItem();
            this.groupByNoneItem1 = new DevExpress.XtraScheduler.UI.GroupByNoneItem();
            this.groupByDateItem1 = new DevExpress.XtraScheduler.UI.GroupByDateItem();
            this.groupByResourceItem1 = new DevExpress.XtraScheduler.UI.GroupByResourceItem();
            this.bbiSync = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOptions = new DevExpress.XtraBars.BarButtonItem();
            this.homeRibbonPage1 = new DevExpress.XtraScheduler.UI.HomeRibbonPage();
            this.navigatorRibbonPageGroup1 = new DevExpress.XtraScheduler.UI.NavigatorRibbonPageGroup();
            this.arrangeRibbonPageGroup1 = new DevExpress.XtraScheduler.UI.ArrangeRibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.schedulerBarController1 = new DevExpress.XtraScheduler.UI.SchedulerBarController(this.components);
            this.dxGoogleCalendarSync1 = new DevExpress.XtraScheduler.GoogleCalendar.DXGoogleCalendarSync(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.skinDropDownButtonItem1 = new DevExpress.XtraBars.SkinDropDownButtonItem();
            this.skinPaletteRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerBarController1)).BeginInit();
            this.SuspendLayout();
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            this.schedulerControl1.DataStorage = this.schedulerDataStorage1;
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.Location = new System.Drawing.Point(0, 158);
            this.schedulerControl1.MenuManager = this.ribbonControl1;
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.Size = new System.Drawing.Size(938, 511);
            this.schedulerControl1.Start = new System.DateTime(2018, 9, 30, 0, 0, 0, 0);
            this.schedulerControl1.TabIndex = 0;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.FullWeekView.Enabled = true;
            this.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.Views.WeekView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            // 
            // schedulerDataStorage1
            // 
            this.schedulerDataStorage1.AppointmentDependencies.AutoReload = false;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.newAppointmentItem1,
            this.newRecurringAppointmentItem1,
            this.navigateViewBackwardItem1,
            this.navigateViewForwardItem1,
            this.gotoTodayItem1,
            this.switchToDayViewItem1,
            this.switchToWorkWeekViewItem1,
            this.switchToWeekViewItem1,
            this.switchToFullWeekViewItem1,
            this.switchToMonthViewItem1,
            this.switchToAgendaViewItem1,
            this.groupByNoneItem1,
            this.groupByDateItem1,
            this.groupByResourceItem1,
            this.bbiSync,
            this.bbiOptions,
            this.skinDropDownButtonItem1,
            this.skinPaletteRibbonGalleryBarItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 26;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.homeRibbonPage1,
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(938, 158);
            // 
            // newAppointmentItem1
            // 
            this.newAppointmentItem1.Id = 2;
            this.newAppointmentItem1.Name = "newAppointmentItem1";
            // 
            // newRecurringAppointmentItem1
            // 
            this.newRecurringAppointmentItem1.Id = 3;
            this.newRecurringAppointmentItem1.Name = "newRecurringAppointmentItem1";
            // 
            // navigateViewBackwardItem1
            // 
            this.navigateViewBackwardItem1.Id = 4;
            this.navigateViewBackwardItem1.Name = "navigateViewBackwardItem1";
            // 
            // navigateViewForwardItem1
            // 
            this.navigateViewForwardItem1.Id = 5;
            this.navigateViewForwardItem1.Name = "navigateViewForwardItem1";
            // 
            // gotoTodayItem1
            // 
            this.gotoTodayItem1.Id = 6;
            this.gotoTodayItem1.Name = "gotoTodayItem1";
            // 
            // switchToDayViewItem1
            // 
            this.switchToDayViewItem1.Id = 9;
            this.switchToDayViewItem1.Name = "switchToDayViewItem1";
            // 
            // switchToWorkWeekViewItem1
            // 
            this.switchToWorkWeekViewItem1.Id = 10;
            this.switchToWorkWeekViewItem1.Name = "switchToWorkWeekViewItem1";
            // 
            // switchToWeekViewItem1
            // 
            this.switchToWeekViewItem1.Id = 11;
            this.switchToWeekViewItem1.Name = "switchToWeekViewItem1";
            // 
            // switchToFullWeekViewItem1
            // 
            this.switchToFullWeekViewItem1.Id = 12;
            this.switchToFullWeekViewItem1.Name = "switchToFullWeekViewItem1";
            // 
            // switchToMonthViewItem1
            // 
            this.switchToMonthViewItem1.Id = 13;
            this.switchToMonthViewItem1.Name = "switchToMonthViewItem1";
            // 
            // switchToAgendaViewItem1
            // 
            this.switchToAgendaViewItem1.Id = 15;
            this.switchToAgendaViewItem1.Name = "switchToAgendaViewItem1";
            // 
            // groupByNoneItem1
            // 
            this.groupByNoneItem1.Id = 16;
            this.groupByNoneItem1.Name = "groupByNoneItem1";
            // 
            // groupByDateItem1
            // 
            this.groupByDateItem1.Id = 17;
            this.groupByDateItem1.Name = "groupByDateItem1";
            // 
            // groupByResourceItem1
            // 
            this.groupByResourceItem1.Id = 18;
            this.groupByResourceItem1.Name = "groupByResourceItem1";
            // 
            // bbiSync
            // 
            this.bbiSync.Caption = "Sync";
            this.bbiSync.Id = 21;
            this.bbiSync.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiSync.ImageOptions.SvgImage")));
            this.bbiSync.Name = "bbiSync";
            this.bbiSync.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnBbiSyncItemClick);
            // 
            // bbiOptions
            // 
            this.bbiOptions.Caption = "Options";
            this.bbiOptions.Hint = "asfd";
            this.bbiOptions.Id = 22;
            this.bbiOptions.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiOptions.ImageOptions.SvgImage")));
            this.bbiOptions.Name = "bbiOptions";
            this.bbiOptions.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnBbiOptionsItemClick);
            // 
            // homeRibbonPage1
            // 
            this.homeRibbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.navigatorRibbonPageGroup1,
            this.arrangeRibbonPageGroup1,
            this.ribbonPageGroup1});
            this.homeRibbonPage1.Name = "homeRibbonPage1";
            // 
            // navigatorRibbonPageGroup1
            // 
            this.navigatorRibbonPageGroup1.ItemLinks.Add(this.navigateViewBackwardItem1);
            this.navigatorRibbonPageGroup1.ItemLinks.Add(this.navigateViewForwardItem1);
            this.navigatorRibbonPageGroup1.ItemLinks.Add(this.gotoTodayItem1);
            this.navigatorRibbonPageGroup1.Name = "navigatorRibbonPageGroup1";
            // 
            // arrangeRibbonPageGroup1
            // 
            this.arrangeRibbonPageGroup1.ItemLinks.Add(this.switchToDayViewItem1);
            this.arrangeRibbonPageGroup1.ItemLinks.Add(this.switchToWorkWeekViewItem1);
            this.arrangeRibbonPageGroup1.ItemLinks.Add(this.switchToWeekViewItem1);
            this.arrangeRibbonPageGroup1.ItemLinks.Add(this.switchToFullWeekViewItem1);
            this.arrangeRibbonPageGroup1.ItemLinks.Add(this.switchToMonthViewItem1);
            this.arrangeRibbonPageGroup1.ItemLinks.Add(this.switchToAgendaViewItem1);
            this.arrangeRibbonPageGroup1.Name = "arrangeRibbonPageGroup1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSync);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiOptions);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Synchronization";
            // 
            // schedulerBarController1
            // 
            this.schedulerBarController1.BarItems.Add(this.newAppointmentItem1);
            this.schedulerBarController1.BarItems.Add(this.newRecurringAppointmentItem1);
            this.schedulerBarController1.BarItems.Add(this.navigateViewBackwardItem1);
            this.schedulerBarController1.BarItems.Add(this.navigateViewForwardItem1);
            this.schedulerBarController1.BarItems.Add(this.gotoTodayItem1);
            this.schedulerBarController1.BarItems.Add(this.switchToDayViewItem1);
            this.schedulerBarController1.BarItems.Add(this.switchToWorkWeekViewItem1);
            this.schedulerBarController1.BarItems.Add(this.switchToWeekViewItem1);
            this.schedulerBarController1.BarItems.Add(this.switchToFullWeekViewItem1);
            this.schedulerBarController1.BarItems.Add(this.switchToMonthViewItem1);
            this.schedulerBarController1.BarItems.Add(this.switchToAgendaViewItem1);
            this.schedulerBarController1.BarItems.Add(this.groupByNoneItem1);
            this.schedulerBarController1.BarItems.Add(this.groupByDateItem1);
            this.schedulerBarController1.BarItems.Add(this.groupByResourceItem1);
            this.schedulerBarController1.Control = this.schedulerControl1;
            // 
            // dxGoogleCalendarSync1
            // 
            this.dxGoogleCalendarSync1.CalendarId = null;
            this.dxGoogleCalendarSync1.CalendarService = null;
            this.dxGoogleCalendarSync1.Storage = this.schedulerDataStorage1;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Skin";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.skinDropDownButtonItem1);
            this.ribbonPageGroup2.ItemLinks.Add(this.skinPaletteRibbonGalleryBarItem1);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Skin";
            // 
            // skinDropDownButtonItem1
            // 
            this.skinDropDownButtonItem1.Id = 24;
            this.skinDropDownButtonItem1.Name = "skinDropDownButtonItem1";
            // 
            // skinPaletteRibbonGalleryBarItem1
            // 
            this.skinPaletteRibbonGalleryBarItem1.Caption = "skinPaletteRibbonGalleryBarItem1";
            this.skinPaletteRibbonGalleryBarItem1.Id = 25;
            this.skinPaletteRibbonGalleryBarItem1.Name = "skinPaletteRibbonGalleryBarItem1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 669);
            this.Controls.Add(this.schedulerControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerBarController1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraScheduler.SchedulerDataStorage schedulerDataStorage1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraScheduler.UI.NewAppointmentItem newAppointmentItem1;
        private DevExpress.XtraScheduler.UI.NewRecurringAppointmentItem newRecurringAppointmentItem1;
        private DevExpress.XtraScheduler.UI.NavigateViewBackwardItem navigateViewBackwardItem1;
        private DevExpress.XtraScheduler.UI.NavigateViewForwardItem navigateViewForwardItem1;
        private DevExpress.XtraScheduler.UI.GotoTodayItem gotoTodayItem1;
        private DevExpress.XtraScheduler.UI.SwitchToDayViewItem switchToDayViewItem1;
        private DevExpress.XtraScheduler.UI.SwitchToWorkWeekViewItem switchToWorkWeekViewItem1;
        private DevExpress.XtraScheduler.UI.SwitchToWeekViewItem switchToWeekViewItem1;
        private DevExpress.XtraScheduler.UI.SwitchToFullWeekViewItem switchToFullWeekViewItem1;
        private DevExpress.XtraScheduler.UI.SwitchToMonthViewItem switchToMonthViewItem1;
        private DevExpress.XtraScheduler.UI.SwitchToAgendaViewItem switchToAgendaViewItem1;
        private DevExpress.XtraScheduler.UI.GroupByNoneItem groupByNoneItem1;
        private DevExpress.XtraScheduler.UI.GroupByDateItem groupByDateItem1;
        private DevExpress.XtraScheduler.UI.GroupByResourceItem groupByResourceItem1;
        private DevExpress.XtraScheduler.UI.HomeRibbonPage homeRibbonPage1;
        private DevExpress.XtraScheduler.UI.ArrangeRibbonPageGroup arrangeRibbonPageGroup1;
        private DevExpress.XtraScheduler.UI.SchedulerBarController schedulerBarController1;
        private DevExpress.XtraScheduler.GoogleCalendar.DXGoogleCalendarSync dxGoogleCalendarSync1;
        private DevExpress.XtraBars.BarButtonItem bbiSync;
        private DevExpress.XtraBars.BarButtonItem bbiOptions;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraScheduler.UI.NavigatorRibbonPageGroup navigatorRibbonPageGroup1;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem1;
        private DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem skinPaletteRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
    }
}

