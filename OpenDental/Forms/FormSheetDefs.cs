using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using OpenDentBusiness;
using OpenDental.UI;

namespace OpenDental{
	/// <summary></summary>
	public class FormSheetDefs:System.Windows.Forms.Form {
		private OpenDental.UI.Button butNew;
		private OpenDental.UI.Button butClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private OpenDental.UI.ODGrid grid2;
		private ODGrid grid1;
		private OpenDental.UI.Button butCopy;
		//private bool changed;
		//public bool IsSelectionMode;
		//<summary>Only used if IsSelectionMode.  On OK, contains selected siteNum.  Can be 0.  Can also be set ahead of time externally.</summary>
		//public int SelectedSiteNum;
		private List<SheetDef> internalList;
		private Label label1;
		private ComboBox comboLabel;
		private bool changed;
		private Label label2;
		private OpenDental.UI.Button butCopy2;
		private OpenDental.UI.Button butImport;
		private OpenDental.UI.Button butExportCustom;
		List<SheetDef> LabelList;

		///<summary></summary>
		public FormSheetDefs()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			Lan.F(this);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSheetDefs));
			this.label1 = new System.Windows.Forms.Label();
			this.comboLabel = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.butExportCustom = new OpenDental.UI.Button();
			this.butImport = new OpenDental.UI.Button();
			this.butCopy2 = new OpenDental.UI.Button();
			this.butCopy = new OpenDental.UI.Button();
			this.grid1 = new OpenDental.UI.ODGrid();
			this.grid2 = new OpenDental.UI.ODGrid();
			this.butNew = new OpenDental.UI.Button();
			this.butClose = new OpenDental.UI.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12,10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(205,15);
			this.label1.TabIndex = 16;
			this.label1.Text = "Label assigned to patient button";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboLabel
			// 
			this.comboLabel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboLabel.FormattingEnabled = true;
			this.comboLabel.Location = new System.Drawing.Point(223,8);
			this.comboLabel.MaxDropDownItems = 20;
			this.comboLabel.Name = "comboLabel";
			this.comboLabel.Size = new System.Drawing.Size(185,21);
			this.comboLabel.TabIndex = 17;
			this.comboLabel.DropDown += new System.EventHandler(this.comboLabel_DropDown);
			this.comboLabel.SelectionChangeCommitted += new System.EventHandler(this.comboLabel_SelectionChangeCommitted);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(414,6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(428,33);
			this.label2.TabIndex = 18;
			this.label2.Text = "Most other sheet types are assigned simply by creating custom sheets of the same " +
    "type.  Referral slips are set in the referral edit window of each referral.";
			// 
			// butExportCustom
			// 
			this.butExportCustom.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butExportCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butExportCustom.Autosize = true;
			this.butExportCustom.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butExportCustom.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butExportCustom.CornerRadius = 4F;
			this.butExportCustom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butExportCustom.Location = new System.Drawing.Point(530,635);
			this.butExportCustom.Name = "butExportCustom";
			this.butExportCustom.Size = new System.Drawing.Size(80,24);
			this.butExportCustom.TabIndex = 25;
			this.butExportCustom.Text = "Export";
			this.butExportCustom.Click += new System.EventHandler(this.butExportCustom_Click);
			// 
			// butImport
			// 
			this.butImport.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butImport.Autosize = true;
			this.butImport.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butImport.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butImport.CornerRadius = 4F;
			this.butImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butImport.Location = new System.Drawing.Point(445,635);
			this.butImport.Name = "butImport";
			this.butImport.Size = new System.Drawing.Size(80,24);
			this.butImport.TabIndex = 24;
			this.butImport.Text = "Import";
			this.butImport.Click += new System.EventHandler(this.butImport_Click);
			// 
			// butCopy2
			// 
			this.butCopy2.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butCopy2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butCopy2.Autosize = true;
			this.butCopy2.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butCopy2.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butCopy2.CornerRadius = 4F;
			this.butCopy2.Image = global::OpenDental.Properties.Resources.Add;
			this.butCopy2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butCopy2.Location = new System.Drawing.Point(700,635);
			this.butCopy2.Name = "butCopy2";
			this.butCopy2.Size = new System.Drawing.Size(89,24);
			this.butCopy2.TabIndex = 19;
			this.butCopy2.Text = "Duplicate";
			this.butCopy2.Click += new System.EventHandler(this.butCopy2_Click);
			// 
			// butCopy
			// 
			this.butCopy.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butCopy.Autosize = true;
			this.butCopy.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butCopy.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butCopy.CornerRadius = 4F;
			this.butCopy.Image = global::OpenDental.Properties.Resources.Right;
			this.butCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butCopy.Location = new System.Drawing.Point(333,635);
			this.butCopy.Name = "butCopy";
			this.butCopy.Size = new System.Drawing.Size(75,24);
			this.butCopy.TabIndex = 15;
			this.butCopy.Text = "Copy";
			this.butCopy.Click += new System.EventHandler(this.butCopy_Click);
			// 
			// grid1
			// 
			this.grid1.HScrollVisible = false;
			this.grid1.Location = new System.Drawing.Point(12,42);
			this.grid1.Name = "grid1";
			this.grid1.ScrollValue = 0;
			this.grid1.Size = new System.Drawing.Size(424,583);
			this.grid1.TabIndex = 14;
			this.grid1.Title = "Internal";
			this.grid1.TranslationName = null;
			this.grid1.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.grid1_CellDoubleClick);
			this.grid1.Click += new System.EventHandler(this.grid1_Click);
			// 
			// grid2
			// 
			this.grid2.HScrollVisible = false;
			this.grid2.Location = new System.Drawing.Point(445,42);
			this.grid2.Name = "grid2";
			this.grid2.ScrollValue = 0;
			this.grid2.Size = new System.Drawing.Size(424,583);
			this.grid2.TabIndex = 12;
			this.grid2.Title = "Custom";
			this.grid2.TranslationName = null;
			this.grid2.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.grid2_CellDoubleClick);
			this.grid2.Click += new System.EventHandler(this.grid2_Click);
			// 
			// butNew
			// 
			this.butNew.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butNew.Autosize = true;
			this.butNew.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butNew.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butNew.CornerRadius = 4F;
			this.butNew.Image = global::OpenDental.Properties.Resources.Add;
			this.butNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butNew.Location = new System.Drawing.Point(615,635);
			this.butNew.Name = "butNew";
			this.butNew.Size = new System.Drawing.Size(80,24);
			this.butNew.TabIndex = 10;
			this.butNew.Text = "New";
			this.butNew.Click += new System.EventHandler(this.butNew_Click);
			// 
			// butClose
			// 
			this.butClose.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butClose.Autosize = true;
			this.butClose.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butClose.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butClose.CornerRadius = 4F;
			this.butClose.Location = new System.Drawing.Point(794,635);
			this.butClose.Name = "butClose";
			this.butClose.Size = new System.Drawing.Size(75,24);
			this.butClose.TabIndex = 0;
			this.butClose.Text = "&Close";
			this.butClose.Click += new System.EventHandler(this.butClose_Click);
			// 
			// FormSheetDefs
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5,13);
			this.ClientSize = new System.Drawing.Size(881,669);
			this.Controls.Add(this.butExportCustom);
			this.Controls.Add(this.butImport);
			this.Controls.Add(this.butCopy2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboLabel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.butCopy);
			this.Controls.Add(this.grid1);
			this.Controls.Add(this.grid2);
			this.Controls.Add(this.butNew);
			this.Controls.Add(this.butClose);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSheetDefs";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sheet Defs";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSheetDefs_FormClosing);
			this.Load += new System.EventHandler(this.FormSheetDefs_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormSheetDefs_Load(object sender, System.EventArgs e) {
			if(!Security.IsAuthorized(Permissions.Setup,true)){
				butNew.Enabled=false;
				butCopy.Enabled=false;
				butCopy2.Enabled=false;
				grid2.Enabled=false;
			}
			FillGrid1();
			FillGrid2();
			comboLabel.Items.Clear();
			comboLabel.Items.Add(Lan.g(this,"Default"));
			comboLabel.SelectedIndex=0;
			LabelList=new List<SheetDef>();
			for(int i=0;i<SheetDefC.Listt.Count;i++){
				if(SheetDefC.Listt[i].SheetType==SheetTypeEnum.LabelPatient){
					LabelList.Add(SheetDefC.Listt[i].Copy());
				}
			}
			for(int i=0;i<LabelList.Count;i++){
				comboLabel.Items.Add(LabelList[i].Description);
				if(PrefC.GetLong(PrefName.LabelPatientDefaultSheetDefNum)==LabelList[i].SheetDefNum){
					comboLabel.SelectedIndex=i+1;
				}
			}
		}

		private void FillGrid1(){
			grid1.BeginUpdate();
			grid1.Columns.Clear();
			ODGridColumn col=new ODGridColumn(Lan.g("TableSheetDef","Description"),170);
			grid1.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableSheetDef","Type"),100);
			grid1.Columns.Add(col);
			grid1.Rows.Clear();
			ODGridRow row;
			internalList=SheetsInternal.GetAllInternal();
			for(int i=0;i<internalList.Count;i++){
				row=new ODGridRow();
				row.Cells.Add(internalList[i].Description);//Enum.GetNames(typeof(SheetInternalType))[i]);
				row.Cells.Add(internalList[i].SheetType.ToString());
				grid1.Rows.Add(row);
			}
			grid1.EndUpdate();
		}

		private void FillGrid2(){
			SheetDefs.RefreshCache();
			SheetFieldDefs.RefreshCache();
			grid2.BeginUpdate();
			grid2.Columns.Clear();
			ODGridColumn col=new ODGridColumn(Lan.g("TableSheetDef","Description"),170);
			grid2.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableSheetDef","Type"),100);
			grid2.Columns.Add(col);
			grid2.Rows.Clear();
			ODGridRow row;
			for(int i=0;i<SheetDefC.Listt.Count;i++){
				row=new ODGridRow();
				row.Cells.Add(SheetDefC.Listt[i].Description);
				row.Cells.Add(SheetDefC.Listt[i].SheetType.ToString());
				grid2.Rows.Add(row);
			}
			grid2.EndUpdate();
		}

		private void butNew_Click(object sender, System.EventArgs e) {
			//This button is not enabled unless user has appropriate permission for setup.
			//Not allowed to change sheettype once a sheet is created, so we need to let user pick.
			FormSheetDef FormS=new FormSheetDef();
			FormS.IsInitial=true;
			FormS.IsReadOnly=false;
			SheetDef sheetdef=new SheetDef();
			sheetdef.FontName="Microsoft Sans Serif";
			sheetdef.FontSize=9;
			sheetdef.Height=1100;
			sheetdef.Width=850;
			FormS.SheetDefCur=sheetdef;
			FormS.ShowDialog();
			if(FormS.DialogResult!=DialogResult.OK){
				return;
			}
			//what about parameters?
			sheetdef.SheetFieldDefs=new List<SheetFieldDef>();
			sheetdef.IsNew=true;
			FormSheetDefEdit FormSD=new FormSheetDefEdit(sheetdef);
			FormSD.ShowDialog();//It will be saved to db inside this form.
			FillGrid2();
			for(int i=0;i<SheetDefC.Listt.Count;i++){
				if(SheetDefC.Listt[i].SheetDefNum==sheetdef.SheetDefNum){
					grid2.SetSelected(i,true);
				}
			}
			changed=true;
		}
		
		private void butCopy2_Click(object sender, EventArgs e) {
			//This button is not enabled unless user has appropriate permission for setup.
			if(grid2.GetSelectedIndex()==-1) {
				MsgBox.Show(this,"Please select a sheet from the list above first.");
				return;
			}
			SheetDef sheetdef=SheetDefC.Listt[grid2.GetSelectedIndex()].Copy();
			sheetdef.Description=sheetdef.Description+"2";
			SheetDefs.GetFieldsAndParameters(sheetdef);
			sheetdef.IsNew=true;
			SheetDefs.InsertOrUpdate(sheetdef);
			FillGrid2();
			for(int i=0;i<SheetDefC.Listt.Count;i++){
				if(SheetDefC.Listt[i].SheetDefNum==sheetdef.SheetDefNum) {
					grid2.SetSelected(i,true);
				}
			}
		}

		private void butCopy_Click(object sender,EventArgs e) {
			if(grid1.GetSelectedIndex()==-1){
				MsgBox.Show(this,"Please select an internal sheet from the list above first.");
				return;
			}
			SheetDef sheetdef=internalList[grid1.GetSelectedIndex()].Copy();
			sheetdef.IsNew=true;
			SheetDefs.InsertOrUpdate(sheetdef);
			grid1.SetSelected(false);
			FillGrid2();
			for(int i=0;i<SheetDefC.Listt.Count;i++){
				if(SheetDefC.Listt[i].SheetDefNum==sheetdef.SheetDefNum){
					grid2.SetSelected(i,true);
				}
			}
		}

		private void grid1_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			FormSheetDefEdit FormS=new FormSheetDefEdit(internalList[e.Row]);
			FormS.IsInternal=true;
			FormS.ShowDialog();
		}

		private void grid1_Click(object sender,EventArgs e) {
			if(grid1.GetSelectedIndex()>-1) {
				grid2.SetSelected(false);
			}
		}
		
		private void grid2_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			SheetDef sheetdef=SheetDefC.Listt[e.Row];
			SheetDefs.GetFieldsAndParameters(sheetdef);
			FormSheetDefEdit FormS=new FormSheetDefEdit(sheetdef);
			FormS.ShowDialog();
			FillGrid2();
			for(int i=0;i<SheetDefC.Listt.Count;i++){
				if(SheetDefC.Listt[i].SheetDefNum==sheetdef.SheetDefNum){
					grid2.SetSelected(i,true);
				}
			}
			changed=true;
		}

		private void grid2_Click(object sender,EventArgs e) {
			if(grid2.GetSelectedIndex()>-1) {
				grid1.SetSelected(false);
			}
		}

		private void butImport_Click(object sender,EventArgs e) {
			Cursor=Cursors.WaitCursor;
			OpenFileDialog openDlg=new OpenFileDialog();
			string initDir=PrefC.GetString(PrefName.ExportPath);
			if(Directory.Exists(initDir)) {
				openDlg.InitialDirectory=initDir;
			}
			if(openDlg.ShowDialog()!=DialogResult.OK) {
				Cursor=Cursors.Default;
				return;
			}
			try {
				//ImportCustomSheetDef(openDlg.FileName);
				SheetDef sheetdef=new SheetDef();
				XmlSerializer serializer=new XmlSerializer(typeof(SheetDef));
				if(openDlg.FileName!="") {
					if(!File.Exists(openDlg.FileName)) {
						throw new ApplicationException(Lan.g("FormSheetDefs","File does not exist."));
					}
					try {
						using(TextReader reader=new StreamReader(openDlg.FileName)) {
							sheetdef=(SheetDef)serializer.Deserialize(reader);
						}
					}
					catch {
						throw new ApplicationException(Lan.g("FormSheetDefs","Invalid file format"));
					}
				}
				sheetdef.IsNew=true;
				SheetDefs.InsertOrUpdate(sheetdef);
				FillGrid2();
				for(int i=0;i<SheetDefC.Listt.Count;i++) {
					if(SheetDefC.Listt[i].SheetDefNum==sheetdef.SheetDefNum) {
						grid2.SetSelected(i,true);
					}
				}
			}
			catch(ApplicationException ex) {
				Cursor=Cursors.Default;
				MessageBox.Show(ex.Message);
				FillGrid2();
				return;
			}
			Cursor=Cursors.Default;
			MsgBox.Show(this,"Imported.");
		}

		private void butExportCustom_Click(object sender,EventArgs e) {
			if(grid2.GetSelectedIndex()==-1) {
				MsgBox.Show(this,"Please select a sheet from the list above first.");
				return;
			}
			SheetDef sheetdef=SheetDefs.GetSheetDef(SheetDefC.Listt[grid2.GetSelectedIndex()].SheetDefNum);
			SaveFileDialog saveDlg=new SaveFileDialog();
			string filename="SheetDefCustom.xml";
			saveDlg.InitialDirectory=PrefC.GetString(PrefName.ExportPath);
			saveDlg.FileName=filename;
			if(saveDlg.ShowDialog()!=DialogResult.OK) {
				return;
			}
			XmlSerializer serializer=new XmlSerializer(typeof(SheetDef));
			using(TextWriter writer=new StreamWriter(saveDlg.FileName)) {
				serializer.Serialize(writer,sheetdef);
			}
			MsgBox.Show(this,"Exported");
		}

		private void comboLabel_DropDown(object sender,EventArgs e) {
			comboLabel.Items.Clear();
			comboLabel.Items.Add(Lan.g(this,"Default"));
			comboLabel.SelectedIndex=0;
			LabelList=new List<SheetDef>();
			for(int i=0;i<SheetDefC.Listt.Count;i++){
				if(SheetDefC.Listt[i].SheetType==SheetTypeEnum.LabelPatient){
					LabelList.Add(SheetDefC.Listt[i].Copy());
				}
			}
			for(int i=0;i<LabelList.Count;i++){
				comboLabel.Items.Add(LabelList[i].Description);
				if(PrefC.GetLong(PrefName.LabelPatientDefaultSheetDefNum)==LabelList[i].SheetDefNum){
					comboLabel.SelectedIndex=i+1;
				}
			}
		}

		private void comboLabel_SelectionChangeCommitted(object sender,EventArgs e) {
			if(comboLabel.SelectedIndex==0){
				Prefs.UpdateLong(PrefName.LabelPatientDefaultSheetDefNum,0);
			}
			else{
				Prefs.UpdateLong(PrefName.LabelPatientDefaultSheetDefNum,LabelList[comboLabel.SelectedIndex-1].SheetDefNum);
			}
			DataValid.SetInvalid(InvalidType.Prefs);
		}

		private void butClose_Click(object sender, System.EventArgs e) {
			Close();
		}

		private void FormSheetDefs_FormClosing(object sender,FormClosingEventArgs e) {
			if(changed){
				DataValid.SetInvalid(InvalidType.Sheets);
			}
		}




		

		

		

		

		

		

		

		



		
	}
}





















