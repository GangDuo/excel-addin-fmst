namespace FMst
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary>
        /// デザイナーのサポートに必要なメソッドです。
        /// このメソッドの内容をコード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher ribbonDialogLauncherImpl1 = this.Factory.CreateRibbonDialogLauncher();
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.skeleton = this.Factory.CreateRibbonButton();
            this.booking = this.Factory.CreateRibbonButton();
            this.button3 = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabData";
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabData";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.DialogLauncher = ribbonDialogLauncherImpl1;
            this.group1.Items.Add(this.skeleton);
            this.group1.Items.Add(this.booking);
            this.group1.Items.Add(this.button3);
            this.group1.Label = "HT取込ﾂｰﾙ";
            this.group1.Name = "group1";
            // 
            // skeleton
            // 
            this.skeleton.Label = "スケルトン";
            this.skeleton.Name = "skeleton";
            this.skeleton.OfficeImageId = "PlusSign";
            this.skeleton.ShowImage = true;
            this.skeleton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.skeleton_Click);
            // 
            // booking
            // 
            this.booking.Label = "当日予約";
            this.booking.Name = "booking";
            this.booking.OfficeImageId = "Schedule";
            this.booking.ShowImage = true;
            this.booking.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.booking_Click);
            // 
            // button3
            // 
            this.button3.Label = "即時実行";
            this.button3.Name = "button3";
            this.button3.OfficeImageId = "QueryRunQuery";
            this.button3.ShowImage = true;
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton skeleton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton booking;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
