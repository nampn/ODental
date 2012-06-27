namespace OpenDental{
	partial class FormSheetFillEdit {
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
			this.components = new System.ComponentModel.Container();
			this.textNote = new System.Windows.Forms.TextBox();
			this.labelNote = new System.Windows.Forms.Label();
			this.labelDateTime = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panelMain = new System.Windows.Forms.Panel();
			this.checkErase = new System.Windows.Forms.CheckBox();
			this.textDescription = new System.Windows.Forms.TextBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.labelShowInTerminal = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.textDateTime = new System.Windows.Forms.TextBox();
			this.butUnlock = new OpenDental.UI.Button();
			this.textShowInTerminal = new OpenDental.ValidNumber();
			this.butPDF = new OpenDental.UI.Button();
			this.butDelete = new OpenDental.UI.Button();
			this.butPrint = new OpenDental.UI.Button();
			this.butOK = new OpenDental.UI.Button();
			this.butCancel = new OpenDental.UI.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textNote
			// 
			this.textNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textNote.Location = new System.Drawing.Point(633,107);
			this.textNote.Multiline = true;
			this.textNote.Name = "textNote";
			this.textNote.Size = new System.Drawing.Size(146,90);
			this.textNote.TabIndex = 6;
			this.textNote.TabStop = false;
			// 
			// labelNote
			// 
			this.labelNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNote.Location = new System.Drawing.Point(632,88);
			this.labelNote.Name = "labelNote";
			this.labelNote.Size = new System.Drawing.Size(147,16);
			this.labelNote.TabIndex = 7;
			this.labelNote.Text = "Internal Note";
			this.labelNote.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// labelDateTime
			// 
			this.labelDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDateTime.Location = new System.Drawing.Point(632,6);
			this.labelDateTime.Name = "labelDateTime";
			this.labelDateTime.Size = new System.Drawing.Size(84,16);
			this.labelDateTime.TabIndex = 76;
			this.labelDateTime.Text = "Date time";
			this.labelDateTime.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.panelMain);
			this.panel1.Location = new System.Drawing.Point(3,3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(617,657);
			this.panel1.TabIndex = 78;
			// 
			// panelMain
			// 
			this.panelMain.BackColor = System.Drawing.SystemColors.Window;
			this.panelMain.Location = new System.Drawing.Point(0,0);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(549,513);
			this.panelMain.TabIndex = 0;
			// 
			// checkErase
			// 
			this.checkErase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkErase.Location = new System.Drawing.Point(698,342);
			this.checkErase.Name = "checkErase";
			this.checkErase.Size = new System.Drawing.Size(89,20);
			this.checkErase.TabIndex = 81;
			this.checkErase.TabStop = false;
			this.checkErase.Text = "Eraser Tool";
			this.checkErase.UseVisualStyleBackColor = true;
			this.checkErase.Click += new System.EventHandler(this.checkErase_Click);
			// 
			// textDescription
			// 
			this.textDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textDescription.Location = new System.Drawing.Point(633,66);
			this.textDescription.Name = "textDescription";
			this.textDescription.Size = new System.Drawing.Size(146,20);
			this.textDescription.TabIndex = 84;
			this.textDescription.TabStop = false;
			// 
			// labelDescription
			// 
			this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDescription.Location = new System.Drawing.Point(632,47);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(147,16);
			this.labelDescription.TabIndex = 85;
			this.labelDescription.Text = "Description";
			this.labelDescription.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// labelShowInTerminal
			// 
			this.labelShowInTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelShowInTerminal.Location = new System.Drawing.Point(632,204);
			this.labelShowInTerminal.Name = "labelShowInTerminal";
			this.labelShowInTerminal.Size = new System.Drawing.Size(120,16);
			this.labelShowInTerminal.TabIndex = 86;
			this.labelShowInTerminal.Text = "Show Order In Kiosk";
			this.labelShowInTerminal.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// timer1
			// 
			this.timer1.Interval = 4000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// textDateTime
			// 
			this.textDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textDateTime.Location = new System.Drawing.Point(635,25);
			this.textDateTime.Name = "textDateTime";
			this.textDateTime.Size = new System.Drawing.Size(144,20);
			this.textDateTime.TabIndex = 88;
			this.textDateTime.TabStop = false;
			// 
			// butUnlock
			// 
			this.butUnlock.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butUnlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butUnlock.Autosize = true;
			this.butUnlock.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butUnlock.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butUnlock.CornerRadius = 4F;
			this.butUnlock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butUnlock.Location = new System.Drawing.Point(697,492);
			this.butUnlock.Name = "butUnlock";
			this.butUnlock.Size = new System.Drawing.Size(81,24);
			this.butUnlock.TabIndex = 89;
			this.butUnlock.TabStop = false;
			this.butUnlock.Text = "Unlock";
			this.butUnlock.Visible = false;
			this.butUnlock.Click += new System.EventHandler(this.butUnlock_Click);
			// 
			// textShowInTerminal
			// 
			this.textShowInTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textShowInTerminal.Location = new System.Drawing.Point(750,203);
			this.textShowInTerminal.MaxVal = 127;
			this.textShowInTerminal.MinVal = 1;
			this.textShowInTerminal.Name = "textShowInTerminal";
			this.textShowInTerminal.Size = new System.Drawing.Size(29,20);
			this.textShowInTerminal.TabIndex = 87;
			this.textShowInTerminal.TabStop = false;
			// 
			// butPDF
			// 
			this.butPDF.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butPDF.Autosize = true;
			this.butPDF.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butPDF.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butPDF.CornerRadius = 4F;
			this.butPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butPDF.Location = new System.Drawing.Point(698,425);
			this.butPDF.Name = "butPDF";
			this.butPDF.Size = new System.Drawing.Size(81,24);
			this.butPDF.TabIndex = 83;
			this.butPDF.TabStop = false;
			this.butPDF.Text = "Create PDF";
			this.butPDF.Click += new System.EventHandler(this.butPDF_Click);
			// 
			// butDelete
			// 
			this.butDelete.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butDelete.Autosize = true;
			this.butDelete.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butDelete.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butDelete.CornerRadius = 4F;
			this.butDelete.Image = global::OpenDental.Properties.Resources.deleteX;
			this.butDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butDelete.Location = new System.Drawing.Point(698,550);
			this.butDelete.Name = "butDelete";
			this.butDelete.Size = new System.Drawing.Size(81,24);
			this.butDelete.TabIndex = 79;
			this.butDelete.TabStop = false;
			this.butDelete.Text = "Delete";
			this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
			// 
			// butPrint
			// 
			this.butPrint.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butPrint.Autosize = true;
			this.butPrint.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butPrint.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butPrint.CornerRadius = 4F;
			this.butPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butPrint.Location = new System.Drawing.Point(698,395);
			this.butPrint.Name = "butPrint";
			this.butPrint.Size = new System.Drawing.Size(81,24);
			this.butPrint.TabIndex = 80;
			this.butPrint.TabStop = false;
			this.butPrint.Text = "Print/Email";
			this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
			// 
			// butOK
			// 
			this.butOK.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butOK.Autosize = true;
			this.butOK.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butOK.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butOK.CornerRadius = 4F;
			this.butOK.Location = new System.Drawing.Point(698,606);
			this.butOK.Name = "butOK";
			this.butOK.Size = new System.Drawing.Size(81,24);
			this.butOK.TabIndex = 3;
			this.butOK.TabStop = false;
			this.butOK.Text = "OK";
			this.butOK.Click += new System.EventHandler(this.butOK_Click);
			// 
			// butCancel
			// 
			this.butCancel.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butCancel.Autosize = true;
			this.butCancel.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butCancel.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butCancel.CornerRadius = 4F;
			this.butCancel.Location = new System.Drawing.Point(698,636);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new System.Drawing.Size(81,24);
			this.butCancel.TabIndex = 2;
			this.butCancel.TabStop = false;
			this.butCancel.Text = "&Cancel";
			this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
			// 
			// FormSheetFillEdit
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(790,672);
			this.Controls.Add(this.butUnlock);
			this.Controls.Add(this.textDateTime);
			this.Controls.Add(this.textShowInTerminal);
			this.Controls.Add(this.labelShowInTerminal);
			this.Controls.Add(this.textDescription);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.butPDF);
			this.Controls.Add(this.butDelete);
			this.Controls.Add(this.checkErase);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.butPrint);
			this.Controls.Add(this.labelDateTime);
			this.Controls.Add(this.textNote);
			this.Controls.Add(this.labelNote);
			this.Controls.Add(this.butOK);
			this.Controls.Add(this.butCancel);
			this.Name = "FormSheetFillEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Fill Sheet";
			this.Load += new System.EventHandler(this.FormSheetFillEdit_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private OpenDental.UI.Button butOK;
		private OpenDental.UI.Button butCancel;
		private System.Windows.Forms.TextBox textNote;
		private System.Windows.Forms.Label labelNote;
		private System.Windows.Forms.Label labelDateTime;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panelMain;
		private OpenDental.UI.Button butDelete;
		private OpenDental.UI.Button butPrint;
		private System.Windows.Forms.CheckBox checkErase;
		private OpenDental.UI.Button butPDF;
		private System.Windows.Forms.TextBox textDescription;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.Label labelShowInTerminal;
		private ValidNumber textShowInTerminal;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TextBox textDateTime;
		private UI.Button butUnlock;
	}
}