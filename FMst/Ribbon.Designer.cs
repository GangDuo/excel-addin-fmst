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
            this.Skeleton = this.Factory.CreateRibbonButton();
            this.Booking = this.Factory.CreateRibbonButton();
            this.AsSoonAsPossible = this.Factory.CreateRibbonButton();
            this.Twitter = this.Factory.CreateRibbonButton();
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
            this.group1.Items.Add(this.Skeleton);
            this.group1.Items.Add(this.Booking);
            this.group1.Items.Add(this.AsSoonAsPossible);
            this.group1.Items.Add(this.Twitter);
            this.group1.Label = "HT取込ﾂｰﾙ";
            this.group1.Name = "group1";
            // 
            // Skeleton
            // 
            this.Skeleton.Label = "スケルトン";
            this.Skeleton.Name = "Skeleton";
            this.Skeleton.OfficeImageId = "PlusSign";
            this.Skeleton.ShowImage = true;
            this.Skeleton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Skeleton_Click);
            // 
            // Booking
            // 
            this.Booking.Label = "当日予約";
            this.Booking.Name = "Booking";
            this.Booking.OfficeImageId = "Schedule";
            this.Booking.ShowImage = true;
            this.Booking.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Booking_Click);
            // 
            // AsSoonAsPossible
            // 
            this.AsSoonAsPossible.Label = "即時実行";
            this.AsSoonAsPossible.Name = "AsSoonAsPossible";
            this.AsSoonAsPossible.OfficeImageId = "QueryRunQuery";
            this.AsSoonAsPossible.ShowImage = true;
            this.AsSoonAsPossible.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AsSoonAsPossible_Click);
            // 
            // Twitter
            // 
            this.Twitter.Label = "twitter";
            this.Twitter.Name = "Twitter";
            this.Twitter.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Twitter_Click);
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
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Skeleton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Booking;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AsSoonAsPossible;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Twitter;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
