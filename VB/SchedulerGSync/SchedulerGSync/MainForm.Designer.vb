Namespace SchedulerGSync
	Partial Public Class MainForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim timeRuler1 As New DevExpress.XtraScheduler.TimeRuler()
			Dim timeRuler2 As New DevExpress.XtraScheduler.TimeRuler()
			Dim timeRuler3 As New DevExpress.XtraScheduler.TimeRuler()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
			Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
			Me.schedulerDataStorage1 = New DevExpress.XtraScheduler.SchedulerDataStorage(Me.components)
			Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
			Me.newAppointmentItem1 = New DevExpress.XtraScheduler.UI.NewAppointmentItem()
			Me.newRecurringAppointmentItem1 = New DevExpress.XtraScheduler.UI.NewRecurringAppointmentItem()
			Me.navigateViewBackwardItem1 = New DevExpress.XtraScheduler.UI.NavigateViewBackwardItem()
			Me.navigateViewForwardItem1 = New DevExpress.XtraScheduler.UI.NavigateViewForwardItem()
			Me.gotoTodayItem1 = New DevExpress.XtraScheduler.UI.GotoTodayItem()
			Me.switchToDayViewItem1 = New DevExpress.XtraScheduler.UI.SwitchToDayViewItem()
			Me.switchToWorkWeekViewItem1 = New DevExpress.XtraScheduler.UI.SwitchToWorkWeekViewItem()
			Me.switchToWeekViewItem1 = New DevExpress.XtraScheduler.UI.SwitchToWeekViewItem()
			Me.switchToFullWeekViewItem1 = New DevExpress.XtraScheduler.UI.SwitchToFullWeekViewItem()
			Me.switchToMonthViewItem1 = New DevExpress.XtraScheduler.UI.SwitchToMonthViewItem()
			Me.switchToAgendaViewItem1 = New DevExpress.XtraScheduler.UI.SwitchToAgendaViewItem()
			Me.groupByNoneItem1 = New DevExpress.XtraScheduler.UI.GroupByNoneItem()
			Me.groupByDateItem1 = New DevExpress.XtraScheduler.UI.GroupByDateItem()
			Me.groupByResourceItem1 = New DevExpress.XtraScheduler.UI.GroupByResourceItem()
			Me.bbiSync = New DevExpress.XtraBars.BarButtonItem()
			Me.bbiOptions = New DevExpress.XtraBars.BarButtonItem()
			Me.homeRibbonPage1 = New DevExpress.XtraScheduler.UI.HomeRibbonPage()
			Me.navigatorRibbonPageGroup1 = New DevExpress.XtraScheduler.UI.NavigatorRibbonPageGroup()
			Me.arrangeRibbonPageGroup1 = New DevExpress.XtraScheduler.UI.ArrangeRibbonPageGroup()
			Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
			Me.schedulerBarController1 = New DevExpress.XtraScheduler.UI.SchedulerBarController(Me.components)
			Me.dxGoogleCalendarSync1 = New DevExpress.XtraScheduler.GoogleCalendar.DXGoogleCalendarSync(Me.components)
			Me.ribbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
			Me.ribbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
			Me.skinDropDownButtonItem1 = New DevExpress.XtraBars.SkinDropDownButtonItem()
			Me.skinPaletteRibbonGalleryBarItem1 = New DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem()
			CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.schedulerDataStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.schedulerBarController1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' schedulerControl1
			' 
			Me.schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month
			Me.schedulerControl1.DataStorage = Me.schedulerDataStorage1
			Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.schedulerControl1.Location = New System.Drawing.Point(0, 158)
			Me.schedulerControl1.MenuManager = Me.ribbonControl1
			Me.schedulerControl1.Name = "schedulerControl1"
			Me.schedulerControl1.Size = New System.Drawing.Size(938, 511)
			Me.schedulerControl1.Start = New DateTime(2018, 9, 30, 0, 0, 0, 0)
			Me.schedulerControl1.TabIndex = 0
			Me.schedulerControl1.Text = "schedulerControl1"
			Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
			Me.schedulerControl1.Views.FullWeekView.Enabled = True
			Me.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler2)
			Me.schedulerControl1.Views.WeekView.Enabled = False
			Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3)
			' 
			' schedulerDataStorage1
			' 
			Me.schedulerDataStorage1.AppointmentDependencies.AutoReload = False
			' 
			' ribbonControl1
			' 
			Me.ribbonControl1.ExpandCollapseItem.Id = 0
			Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() { Me.ribbonControl1.ExpandCollapseItem, Me.newAppointmentItem1, Me.newRecurringAppointmentItem1, Me.navigateViewBackwardItem1, Me.navigateViewForwardItem1, Me.gotoTodayItem1, Me.switchToDayViewItem1, Me.switchToWorkWeekViewItem1, Me.switchToWeekViewItem1, Me.switchToFullWeekViewItem1, Me.switchToMonthViewItem1, Me.switchToAgendaViewItem1, Me.groupByNoneItem1, Me.groupByDateItem1, Me.groupByResourceItem1, Me.bbiSync, Me.bbiOptions, Me.skinDropDownButtonItem1, Me.skinPaletteRibbonGalleryBarItem1})
			Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
			Me.ribbonControl1.MaxItemId = 26
			Me.ribbonControl1.Name = "ribbonControl1"
			Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() { Me.homeRibbonPage1, Me.ribbonPage1})
			Me.ribbonControl1.Size = New System.Drawing.Size(938, 158)
			' 
			' newAppointmentItem1
			' 
			Me.newAppointmentItem1.Id = 2
			Me.newAppointmentItem1.Name = "newAppointmentItem1"
			' 
			' newRecurringAppointmentItem1
			' 
			Me.newRecurringAppointmentItem1.Id = 3
			Me.newRecurringAppointmentItem1.Name = "newRecurringAppointmentItem1"
			' 
			' navigateViewBackwardItem1
			' 
			Me.navigateViewBackwardItem1.Id = 4
			Me.navigateViewBackwardItem1.Name = "navigateViewBackwardItem1"
			' 
			' navigateViewForwardItem1
			' 
			Me.navigateViewForwardItem1.Id = 5
			Me.navigateViewForwardItem1.Name = "navigateViewForwardItem1"
			' 
			' gotoTodayItem1
			' 
			Me.gotoTodayItem1.Id = 6
			Me.gotoTodayItem1.Name = "gotoTodayItem1"
			' 
			' switchToDayViewItem1
			' 
			Me.switchToDayViewItem1.Id = 9
			Me.switchToDayViewItem1.Name = "switchToDayViewItem1"
			' 
			' switchToWorkWeekViewItem1
			' 
			Me.switchToWorkWeekViewItem1.Id = 10
			Me.switchToWorkWeekViewItem1.Name = "switchToWorkWeekViewItem1"
			' 
			' switchToWeekViewItem1
			' 
			Me.switchToWeekViewItem1.Id = 11
			Me.switchToWeekViewItem1.Name = "switchToWeekViewItem1"
			' 
			' switchToFullWeekViewItem1
			' 
			Me.switchToFullWeekViewItem1.Id = 12
			Me.switchToFullWeekViewItem1.Name = "switchToFullWeekViewItem1"
			' 
			' switchToMonthViewItem1
			' 
			Me.switchToMonthViewItem1.Id = 13
			Me.switchToMonthViewItem1.Name = "switchToMonthViewItem1"
			' 
			' switchToAgendaViewItem1
			' 
			Me.switchToAgendaViewItem1.Id = 15
			Me.switchToAgendaViewItem1.Name = "switchToAgendaViewItem1"
			' 
			' groupByNoneItem1
			' 
			Me.groupByNoneItem1.Id = 16
			Me.groupByNoneItem1.Name = "groupByNoneItem1"
			' 
			' groupByDateItem1
			' 
			Me.groupByDateItem1.Id = 17
			Me.groupByDateItem1.Name = "groupByDateItem1"
			' 
			' groupByResourceItem1
			' 
			Me.groupByResourceItem1.Id = 18
			Me.groupByResourceItem1.Name = "groupByResourceItem1"
			' 
			' bbiSync
			' 
			Me.bbiSync.Caption = "Sync"
			Me.bbiSync.Id = 21
			Me.bbiSync.ImageOptions.SvgImage = (CType(resources.GetObject("bbiSync.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage))
			Me.bbiSync.Name = "bbiSync"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.bbiSync.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnBbiSyncItemClick);
			' 
			' bbiOptions
			' 
			Me.bbiOptions.Caption = "Options"
			Me.bbiOptions.Hint = "asfd"
			Me.bbiOptions.Id = 22
			Me.bbiOptions.ImageOptions.SvgImage = (CType(resources.GetObject("bbiOptions.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage))
			Me.bbiOptions.Name = "bbiOptions"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.bbiOptions.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnBbiOptionsItemClick);
			' 
			' homeRibbonPage1
			' 
			Me.homeRibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() { Me.navigatorRibbonPageGroup1, Me.arrangeRibbonPageGroup1, Me.ribbonPageGroup1})
			Me.homeRibbonPage1.Name = "homeRibbonPage1"
			' 
			' navigatorRibbonPageGroup1
			' 
			Me.navigatorRibbonPageGroup1.ItemLinks.Add(Me.navigateViewBackwardItem1)
			Me.navigatorRibbonPageGroup1.ItemLinks.Add(Me.navigateViewForwardItem1)
			Me.navigatorRibbonPageGroup1.ItemLinks.Add(Me.gotoTodayItem1)
			Me.navigatorRibbonPageGroup1.Name = "navigatorRibbonPageGroup1"
			' 
			' arrangeRibbonPageGroup1
			' 
			Me.arrangeRibbonPageGroup1.ItemLinks.Add(Me.switchToDayViewItem1)
			Me.arrangeRibbonPageGroup1.ItemLinks.Add(Me.switchToWorkWeekViewItem1)
			Me.arrangeRibbonPageGroup1.ItemLinks.Add(Me.switchToWeekViewItem1)
			Me.arrangeRibbonPageGroup1.ItemLinks.Add(Me.switchToFullWeekViewItem1)
			Me.arrangeRibbonPageGroup1.ItemLinks.Add(Me.switchToMonthViewItem1)
			Me.arrangeRibbonPageGroup1.ItemLinks.Add(Me.switchToAgendaViewItem1)
			Me.arrangeRibbonPageGroup1.Name = "arrangeRibbonPageGroup1"
			' 
			' ribbonPageGroup1
			' 
			Me.ribbonPageGroup1.ItemLinks.Add(Me.bbiSync)
			Me.ribbonPageGroup1.ItemLinks.Add(Me.bbiOptions)
			Me.ribbonPageGroup1.Name = "ribbonPageGroup1"
			Me.ribbonPageGroup1.ShowCaptionButton = False
			Me.ribbonPageGroup1.Text = "Synchronization"
			' 
			' schedulerBarController1
			' 
			Me.schedulerBarController1.BarItems.Add(Me.newAppointmentItem1)
			Me.schedulerBarController1.BarItems.Add(Me.newRecurringAppointmentItem1)
			Me.schedulerBarController1.BarItems.Add(Me.navigateViewBackwardItem1)
			Me.schedulerBarController1.BarItems.Add(Me.navigateViewForwardItem1)
			Me.schedulerBarController1.BarItems.Add(Me.gotoTodayItem1)
			Me.schedulerBarController1.BarItems.Add(Me.switchToDayViewItem1)
			Me.schedulerBarController1.BarItems.Add(Me.switchToWorkWeekViewItem1)
			Me.schedulerBarController1.BarItems.Add(Me.switchToWeekViewItem1)
			Me.schedulerBarController1.BarItems.Add(Me.switchToFullWeekViewItem1)
			Me.schedulerBarController1.BarItems.Add(Me.switchToMonthViewItem1)
			Me.schedulerBarController1.BarItems.Add(Me.switchToAgendaViewItem1)
			Me.schedulerBarController1.BarItems.Add(Me.groupByNoneItem1)
			Me.schedulerBarController1.BarItems.Add(Me.groupByDateItem1)
			Me.schedulerBarController1.BarItems.Add(Me.groupByResourceItem1)
			Me.schedulerBarController1.Control = Me.schedulerControl1
			' 
			' dxGoogleCalendarSync1
			' 
			Me.dxGoogleCalendarSync1.CalendarId = Nothing
			Me.dxGoogleCalendarSync1.CalendarService = Nothing
			Me.dxGoogleCalendarSync1.Storage = Me.schedulerDataStorage1
			' 
			' ribbonPage1
			' 
			Me.ribbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() { Me.ribbonPageGroup2})
			Me.ribbonPage1.Name = "ribbonPage1"
			Me.ribbonPage1.Text = "Skin"
			' 
			' ribbonPageGroup2
			' 
			Me.ribbonPageGroup2.ItemLinks.Add(Me.skinDropDownButtonItem1)
			Me.ribbonPageGroup2.ItemLinks.Add(Me.skinPaletteRibbonGalleryBarItem1)
			Me.ribbonPageGroup2.Name = "ribbonPageGroup2"
			Me.ribbonPageGroup2.Text = "Skin"
			' 
			' skinDropDownButtonItem1
			' 
			Me.skinDropDownButtonItem1.Id = 24
			Me.skinDropDownButtonItem1.Name = "skinDropDownButtonItem1"
			' 
			' skinPaletteRibbonGalleryBarItem1
			' 
			Me.skinPaletteRibbonGalleryBarItem1.Caption = "skinPaletteRibbonGalleryBarItem1"
			Me.skinPaletteRibbonGalleryBarItem1.Id = 25
			Me.skinPaletteRibbonGalleryBarItem1.Name = "skinPaletteRibbonGalleryBarItem1"
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(938, 669)
			Me.Controls.Add(Me.schedulerControl1)
			Me.Controls.Add(Me.ribbonControl1)
			Me.Name = "MainForm"
			Me.Text = "Form1"
			CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.schedulerDataStorage1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.schedulerBarController1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
		Private schedulerDataStorage1 As DevExpress.XtraScheduler.SchedulerDataStorage
		Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
		Private newAppointmentItem1 As DevExpress.XtraScheduler.UI.NewAppointmentItem
		Private newRecurringAppointmentItem1 As DevExpress.XtraScheduler.UI.NewRecurringAppointmentItem
		Private navigateViewBackwardItem1 As DevExpress.XtraScheduler.UI.NavigateViewBackwardItem
		Private navigateViewForwardItem1 As DevExpress.XtraScheduler.UI.NavigateViewForwardItem
		Private gotoTodayItem1 As DevExpress.XtraScheduler.UI.GotoTodayItem
		Private switchToDayViewItem1 As DevExpress.XtraScheduler.UI.SwitchToDayViewItem
		Private switchToWorkWeekViewItem1 As DevExpress.XtraScheduler.UI.SwitchToWorkWeekViewItem
		Private switchToWeekViewItem1 As DevExpress.XtraScheduler.UI.SwitchToWeekViewItem
		Private switchToFullWeekViewItem1 As DevExpress.XtraScheduler.UI.SwitchToFullWeekViewItem
		Private switchToMonthViewItem1 As DevExpress.XtraScheduler.UI.SwitchToMonthViewItem
		Private switchToAgendaViewItem1 As DevExpress.XtraScheduler.UI.SwitchToAgendaViewItem
		Private groupByNoneItem1 As DevExpress.XtraScheduler.UI.GroupByNoneItem
		Private groupByDateItem1 As DevExpress.XtraScheduler.UI.GroupByDateItem
		Private groupByResourceItem1 As DevExpress.XtraScheduler.UI.GroupByResourceItem
		Private homeRibbonPage1 As DevExpress.XtraScheduler.UI.HomeRibbonPage
		Private arrangeRibbonPageGroup1 As DevExpress.XtraScheduler.UI.ArrangeRibbonPageGroup
		Private schedulerBarController1 As DevExpress.XtraScheduler.UI.SchedulerBarController
		Private dxGoogleCalendarSync1 As DevExpress.XtraScheduler.GoogleCalendar.DXGoogleCalendarSync
		Private WithEvents bbiSync As DevExpress.XtraBars.BarButtonItem
		Private WithEvents bbiOptions As DevExpress.XtraBars.BarButtonItem
		Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
		Private navigatorRibbonPageGroup1 As DevExpress.XtraScheduler.UI.NavigatorRibbonPageGroup
		Private skinDropDownButtonItem1 As DevExpress.XtraBars.SkinDropDownButtonItem
		Private skinPaletteRibbonGalleryBarItem1 As DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem
		Private ribbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
		Private ribbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
	End Class
End Namespace

