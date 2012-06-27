using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using OpenDental.UI;
using OpenDentBusiness;

namespace OpenDental {
	///<summary></summary>
	public class FormReferralSelect:System.Windows.Forms.Form {
		private OpenDental.UI.Button butCancel;
		private OpenDental.UI.Button butOK;
		private System.Windows.Forms.CheckBox checkHidden;
		private System.ComponentModel.Container components = null;
		///<summary></summary>
		public bool IsSelectionMode;
		private OpenDental.UI.Button butAdd;
		private List<Referral> listRef;
		private UI.ODGrid gridMain;
		private TextBox textSearch;
		private Label label1;
		private Label labelResultCount;
		///<summary>This will contain the referral that was selected.</summary>
		public Referral SelectedReferral;

		///<summary></summary>
		public FormReferralSelect() {
			InitializeComponent();
			Lan.F(this);
		}

		///<summary></summary>
		protected override void Dispose(bool disposing) {
			if(disposing) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReferralSelect));
			this.checkHidden = new System.Windows.Forms.CheckBox();
			this.gridMain = new OpenDental.UI.ODGrid();
			this.textSearch = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.labelResultCount = new System.Windows.Forms.Label();
			this.butAdd = new OpenDental.UI.Button();
			this.butCancel = new OpenDental.UI.Button();
			this.butOK = new OpenDental.UI.Button();
			this.SuspendLayout();
			// 
			// checkHidden
			// 
			this.checkHidden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkHidden.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkHidden.Location = new System.Drawing.Point(844,6);
			this.checkHidden.Name = "checkHidden";
			this.checkHidden.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.checkHidden.Size = new System.Drawing.Size(104,24);
			this.checkHidden.TabIndex = 11;
			this.checkHidden.Text = "Show Hidden  ";
			this.checkHidden.Click += new System.EventHandler(this.checkHidden_Click);
			// 
			// gridMain
			// 
			this.gridMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridMain.HScrollVisible = false;
			this.gridMain.Location = new System.Drawing.Point(8,34);
			this.gridMain.Name = "gridMain";
			this.gridMain.ScrollValue = 0;
			this.gridMain.Size = new System.Drawing.Size(940,618);
			this.gridMain.TabIndex = 15;
			this.gridMain.Title = "Select Referral";
			this.gridMain.TranslationName = "TableSelectReferral";
			this.gridMain.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.gridMain_CellDoubleClick);
			// 
			// textSearch
			// 
			this.textSearch.Location = new System.Drawing.Point(106,8);
			this.textSearch.Name = "textSearch";
			this.textSearch.Size = new System.Drawing.Size(201,20);
			this.textSearch.TabIndex = 0;
			this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5,10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100,17);
			this.label1.TabIndex = 17;
			this.label1.Text = "Search";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelResultCount
			// 
			this.labelResultCount.Location = new System.Drawing.Point(313,10);
			this.labelResultCount.Name = "labelResultCount";
			this.labelResultCount.Size = new System.Drawing.Size(129,17);
			this.labelResultCount.TabIndex = 18;
			this.labelResultCount.Text = "# results found";
			this.labelResultCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// butAdd
			// 
			this.butAdd.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butAdd.Autosize = true;
			this.butAdd.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butAdd.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butAdd.CornerRadius = 4F;
			this.butAdd.Image = global::OpenDental.Properties.Resources.Add;
			this.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAdd.Location = new System.Drawing.Point(8,661);
			this.butAdd.Name = "butAdd";
			this.butAdd.Size = new System.Drawing.Size(80,24);
			this.butAdd.TabIndex = 12;
			this.butAdd.Text = "&Add";
			this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
			// 
			// butCancel
			// 
			this.butCancel.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butCancel.Autosize = true;
			this.butCancel.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butCancel.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butCancel.CornerRadius = 4F;
			this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.butCancel.ImageAlign = System.Drawing.ContentAlignment.TopRight;
			this.butCancel.Location = new System.Drawing.Point(873,661);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new System.Drawing.Size(75,24);
			this.butCancel.TabIndex = 6;
			this.butCancel.Text = "&Cancel";
			this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
			// 
			// butOK
			// 
			this.butOK.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butOK.Autosize = true;
			this.butOK.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butOK.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butOK.CornerRadius = 4F;
			this.butOK.Location = new System.Drawing.Point(785,661);
			this.butOK.Name = "butOK";
			this.butOK.Size = new System.Drawing.Size(75,24);
			this.butOK.TabIndex = 1;
			this.butOK.Text = "&OK";
			this.butOK.Click += new System.EventHandler(this.butOK_Click);
			// 
			// FormReferralSelect
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5,13);
			this.ClientSize = new System.Drawing.Size(962,696);
			this.Controls.Add(this.labelResultCount);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textSearch);
			this.Controls.Add(this.gridMain);
			this.Controls.Add(this.butAdd);
			this.Controls.Add(this.checkHidden);
			this.Controls.Add(this.butCancel);
			this.Controls.Add(this.butOK);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormReferralSelect";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Referrals";
			this.Load += new System.EventHandler(this.FormReferralSelect_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void FormReferralSelect_Load(object sender,System.EventArgs e) {
			if(!Security.IsAuthorized(Permissions.ReferralAdd,true)) {
				butAdd.Enabled=false;
			}
			FillTable();
			//labelResultCount.Text="";
		}

		private void FillTable() {
			Referrals.RefreshCache(); 
			listRef=new List<Referral>();
			for(int i=0;i<Referrals.List.Length;i++) {
				if(!checkHidden.Checked) {//don't include hidden
					if(Referrals.List[i].IsHidden) {//if hidden
						continue;
					}
				}
				if(textSearch.Text != "") {
					if(!Referrals.List[i].LName.ToLower().StartsWith(textSearch.Text.ToLower())) {//no match
						continue;
					}
				}
				listRef.Add(Referrals.List[i]);
			}
			int scrollValue=gridMain.ScrollValue;
			long selectedRefNum=-1;
			if(gridMain.GetSelectedIndex()!=-1) {
				selectedRefNum=((Referral)gridMain.Rows[gridMain.GetSelectedIndex()].Tag).ReferralNum;
			}
			gridMain.BeginUpdate();
			gridMain.Columns.Clear();
			ODGridColumn col=new ODGridColumn(Lans.g("TableSelectRefferal","LastName"),150);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lans.g("TableSelectRefferal","FirstName"),80);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lans.g("TableSelectRefferal","MI"),30);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lans.g("TableSelectRefferal","Title"),70);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lans.g("TableSelectRefferal","Specialty"),60);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lans.g("TableSelectRefferal","Patient"),45);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lans.g("TableSelectRefferal","Note"),250);
			gridMain.Columns.Add(col);
			gridMain.Rows.Clear();
			ODGridRow row;
			for(int i=0;i<listRef.Count;i++) {
				row=new ODGridRow();
				row.Cells.Add(listRef[i].LName);
				row.Cells.Add(listRef[i].FName);
				if(listRef[i].MName!="") {
					row.Cells.Add(listRef[i].MName.Substring(0,1).ToUpper());
				}
				else {
					row.Cells.Add("");
				}
				row.Cells.Add(listRef[i].Title);
				if(listRef[i].IsDoctor){
					row.Cells.Add(Lan.g("enumDentalSpecialty",((DentalSpecialty)(listRef[i].Specialty)).ToString()));
				}
				else {
					row.Cells.Add("");
				}
				if(listRef[i].PatNum>0) {
					row.Cells.Add("X");
				}
				else {
					row.Cells.Add("");
				}
				row.Cells.Add(listRef[i].Note);
				if(listRef[i].IsHidden) {
					row.ColorText=Color.Gray;
				}
				row.Tag=listRef[i];
				gridMain.Rows.Add(row);
			}
			gridMain.EndUpdate();
			labelResultCount.Text=gridMain.Rows.Count.ToString()+" results found.";
			gridMain.ScrollValue=scrollValue;
			for(int i=0;i<gridMain.Rows.Count;i++) {
				if(((Referral)gridMain.Rows[i].Tag).ReferralNum==selectedRefNum) {
					gridMain.SetSelected(i,true);
					break;
				}
			}
		}

		private void gridMain_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			//This does not automatically select a referral when in selection mode; it just lets user edit.
			if(gridMain.GetSelectedIndex()==-1) {
				MsgBox.Show(this,"Please select a referral first");
				return;
			}
			FormReferralEdit FormRE = new FormReferralEdit(listRef[e.Row]);
			FormRE.ShowDialog();
			if(FormRE.DialogResult!=DialogResult.OK) {
				return;
			}
			//int selectedIndex=gridMain.GetSelectedIndex();
			FillTable();
			//gridMain.SetSelected(selectedIndex,true);
		}

		private void butAdd_Click(object sender,System.EventArgs e) {
			Referral refCur=new Referral();
			bool referralIsNew=true;
			if(MessageBox.Show(Lan.g(this,"Is the referral source an existing patient?"),""
				,MessageBoxButtons.YesNo)==DialogResult.Yes) {
				FormPatientSelect FormPS=new FormPatientSelect();
				FormPS.SelectionModeOnly=true;
				FormPS.ShowDialog();
				if(FormPS.DialogResult!=DialogResult.OK) {
					return;
				}
				refCur.PatNum=FormPS.SelectedPatNum;
				for(int i=0;i<Referrals.List.Length;i++) {
					if(Referrals.List[i].PatNum==FormPS.SelectedPatNum) {//referral already existed
						refCur=Referrals.List[i];
						referralIsNew=false;
						break;
					}
				}
			}
			FormReferralEdit FormRE2=new FormReferralEdit(refCur);//the ReferralNum must be added here
			FormRE2.IsNew=referralIsNew;
			FormRE2.ShowDialog();
			if(FormRE2.DialogResult==DialogResult.Cancel) {
				return;
			}
			if(IsSelectionMode) {
				SelectedReferral=FormRE2.RefCur;
				DialogResult=DialogResult.OK;
				return;
			}
			else {
				FillTable();
				for(int i=0;i<listRef.Count;i++) {
					if(listRef[i].ReferralNum==FormRE2.RefCur.ReferralNum) {
						gridMain.SetSelected(i,true);
					}
				}
			}
		}

		private void checkHidden_Click(object sender,System.EventArgs e) {
			FillTable();
		}

		private void textSearch_TextChanged(object sender,EventArgs e) {
			FillTable();
		}

		private void butOK_Click(object sender,System.EventArgs e) {
			if(IsSelectionMode) {
				if(gridMain.GetSelectedIndex()==-1) {
					MsgBox.Show(this,"Please select a referral first");
					return;
				}
				SelectedReferral=(Referral)listRef[gridMain.GetSelectedIndex()];
			}
			DialogResult=DialogResult.OK;
		}

		private void butCancel_Click(object sender,System.EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}



	}
}
