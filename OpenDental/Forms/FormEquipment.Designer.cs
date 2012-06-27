namespace OpenDental{
	partial class FormEquipment {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
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
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.butRefresh = new OpenDental.UI.Button();
			this.textDateStart = new OpenDental.ValidDate();
			this.textDateEnd = new OpenDental.ValidDate();
			this.radioPurchased = new System.Windows.Forms.RadioButton();
			this.radioSold = new System.Windows.Forms.RadioButton();
			this.radioAll = new System.Windows.Forms.RadioButton();
			this.butPrint = new OpenDental.UI.Button();
			this.butAdd = new OpenDental.UI.Button();
			this.gridMain = new OpenDental.UI.ODGrid();
			this.butClose = new OpenDental.UI.Button();
			this.textSnDesc = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(25,6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(183,39);
			this.label1.TabIndex = 7;
			this.label1.Text = "This list tracks equipment for payment of property taxes.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.butRefresh);
			this.groupBox1.Controls.Add(this.textDateStart);
			this.groupBox1.Controls.Add(this.textDateEnd);
			this.groupBox1.Location = new System.Drawing.Point(420,3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(257,41);
			this.groupBox1.TabIndex = 23;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Date Range";
			// 
			// butRefresh
			// 
			this.butRefresh.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butRefresh.Autosize = true;
			this.butRefresh.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butRefresh.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butRefresh.CornerRadius = 4F;
			this.butRefresh.Location = new System.Drawing.Point(172,12);
			this.butRefresh.Name = "butRefresh";
			this.butRefresh.Size = new System.Drawing.Size(78,24);
			this.butRefresh.TabIndex = 23;
			this.butRefresh.Text = "Refresh";
			this.butRefresh.Click += new System.EventHandler(this.butRefresh_Click);
			// 
			// textDateStart
			// 
			this.textDateStart.Location = new System.Drawing.Point(6,15);
			this.textDateStart.Name = "textDateStart";
			this.textDateStart.Size = new System.Drawing.Size(77,20);
			this.textDateStart.TabIndex = 21;
			this.textDateStart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textDateStart_KeyDown);
			// 
			// textDateEnd
			// 
			this.textDateEnd.Location = new System.Drawing.Point(89,15);
			this.textDateEnd.Name = "textDateEnd";
			this.textDateEnd.Size = new System.Drawing.Size(77,20);
			this.textDateEnd.TabIndex = 22;
			this.textDateEnd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textDateEnd_KeyDown);
			// 
			// radioPurchased
			// 
			this.radioPurchased.Location = new System.Drawing.Point(696,0);
			this.radioPurchased.Name = "radioPurchased";
			this.radioPurchased.Size = new System.Drawing.Size(93,18);
			this.radioPurchased.TabIndex = 23;
			this.radioPurchased.Text = "Purchased";
			this.radioPurchased.UseVisualStyleBackColor = true;
			this.radioPurchased.Click += new System.EventHandler(this.radioPurchased_Click);
			// 
			// radioSold
			// 
			this.radioSold.Location = new System.Drawing.Point(696,15);
			this.radioSold.Name = "radioSold";
			this.radioSold.Size = new System.Drawing.Size(93,18);
			this.radioSold.TabIndex = 24;
			this.radioSold.Text = "Sold";
			this.radioSold.UseVisualStyleBackColor = true;
			this.radioSold.Click += new System.EventHandler(this.radioSold_Click);
			// 
			// radioAll
			// 
			this.radioAll.Checked = true;
			this.radioAll.Location = new System.Drawing.Point(696,30);
			this.radioAll.Name = "radioAll";
			this.radioAll.Size = new System.Drawing.Size(93,18);
			this.radioAll.TabIndex = 25;
			this.radioAll.TabStop = true;
			this.radioAll.Text = "All";
			this.radioAll.UseVisualStyleBackColor = true;
			this.radioAll.Click += new System.EventHandler(this.radioAll_Click);
			// 
			// butPrint
			// 
			this.butPrint.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butPrint.Autosize = true;
			this.butPrint.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butPrint.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butPrint.CornerRadius = 4F;
			this.butPrint.Image = global::OpenDental.Properties.Resources.butPrint;
			this.butPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butPrint.Location = new System.Drawing.Point(385,550);
			this.butPrint.Name = "butPrint";
			this.butPrint.Size = new System.Drawing.Size(75,24);
			this.butPrint.TabIndex = 8;
			this.butPrint.Text = "Print";
			this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
			// 
			// butAdd
			// 
			this.butAdd.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butAdd.Autosize = true;
			this.butAdd.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butAdd.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butAdd.CornerRadius = 4F;
			this.butAdd.Image = global::OpenDental.Properties.Resources.Add;
			this.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAdd.Location = new System.Drawing.Point(141,550);
			this.butAdd.Name = "butAdd";
			this.butAdd.Size = new System.Drawing.Size(75,24);
			this.butAdd.TabIndex = 6;
			this.butAdd.Text = "Add";
			this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
			// 
			// gridMain
			// 
			this.gridMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridMain.HScrollVisible = false;
			this.gridMain.Location = new System.Drawing.Point(12,48);
			this.gridMain.Name = "gridMain";
			this.gridMain.ScrollValue = 0;
			this.gridMain.Size = new System.Drawing.Size(777,493);
			this.gridMain.TabIndex = 5;
			this.gridMain.Title = "Equipment";
			this.gridMain.TranslationName = null;
			this.gridMain.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.gridMain_CellDoubleClick);
			// 
			// butClose
			// 
			this.butClose.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butClose.Autosize = true;
			this.butClose.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butClose.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butClose.CornerRadius = 4F;
			this.butClose.Location = new System.Drawing.Point(714,550);
			this.butClose.Name = "butClose";
			this.butClose.Size = new System.Drawing.Size(75,24);
			this.butClose.TabIndex = 2;
			this.butClose.Text = "&Close";
			this.butClose.Click += new System.EventHandler(this.butClose_Click);
			// 
			// textSnDesc
			// 
			this.textSnDesc.Location = new System.Drawing.Point(281,18);
			this.textSnDesc.Name = "textSnDesc";
			this.textSnDesc.Size = new System.Drawing.Size(133,20);
			this.textSnDesc.TabIndex = 41;
			this.textSnDesc.TextChanged += new System.EventHandler(this.textSnDesc_TextChanged);
			// 
			// label7
			// 
			this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label7.Location = new System.Drawing.Point(170,18);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(105,20);
			this.label7.TabIndex = 40;
			this.label7.Text = "SN/Description";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FormEquipment
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(801,585);
			this.Controls.Add(this.textSnDesc);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.radioAll);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.radioSold);
			this.Controls.Add(this.radioPurchased);
			this.Controls.Add(this.butPrint);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.butAdd);
			this.Controls.Add(this.gridMain);
			this.Controls.Add(this.butClose);
			this.Name = "FormEquipment";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Equipment";
			this.Load += new System.EventHandler(this.FormEquipment_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private OpenDental.UI.Button butClose;
		private OpenDental.UI.ODGrid gridMain;
		private OpenDental.UI.Button butAdd;
		private System.Windows.Forms.Label label1;
		private OpenDental.UI.Button butPrint;
		private ValidDate textDateEnd;
		private ValidDate textDateStart;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioPurchased;
		private System.Windows.Forms.RadioButton radioSold;
		private System.Windows.Forms.RadioButton radioAll;
		private OpenDental.UI.Button butRefresh;
		private System.Windows.Forms.TextBox textSnDesc;
		private System.Windows.Forms.Label label7;
	}
}