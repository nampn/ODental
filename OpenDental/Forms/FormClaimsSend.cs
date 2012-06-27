using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using OpenDental.UI;
using OpenDentBusiness;
using OpenDental.Eclaims;
using CodeBase;

namespace OpenDental{
///<summary></summary>
	public class FormClaimsSend:System.Windows.Forms.Form {
		private System.Windows.Forms.Label label6;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ContextMenu contextMenuStatus;
		private OpenDental.UI.ODToolBar ToolBarMain;
		///<summary>final list of eclaims(as Claim.ClaimNum) to send</summary>
		public static ArrayList eClaimList;
		private ODGrid gridMain;
		private ClaimSendQueueItem[] listQueue;
		///<summary></summary>
		public long GotoPatNum;
		private ODGrid gridHistory;
		private MonthCalendar calendarTo;
		private OpenDental.UI.Button butDropTo;
		private OpenDental.UI.Button butDropFrom;
		private MonthCalendar calendarFrom;
		private ValidDate textDateTo;
		private Label label2;
		private ValidDate textDateFrom;
		private Label label1;
		///<summary></summary>
		public long GotoClaimNum;
		private ODToolBar ToolBarHistory;
		private DataTable tableHistory;
		private int pagesPrinted;
		private Panel panelSplitter;
		private Panel panelHistory;
		private Panel panel1;
		private PrintDocument pd2;
		bool MouseIsDownOnSplitter;
		int SplitterOriginalY;
		int OriginalMouseY;
		bool headingPrinted;
		int headingPrintH;
		private ComboBox comboClinic;
		private Label labelClinic;
		private ComboBox comboCustomTracking;
		private Label labelCustomTracking;
		private ContextMenu contextMenuEclaims;
		//private ContextMenu contextMenuHist;

		///<summary></summary>
		public FormClaimsSend(){
			InitializeComponent();
			//tbQueue.CellDoubleClicked += new OpenDental.ContrTable.CellEventHandler(tbQueue_CellDoubleClicked);
			Lan.F(this);
		}

		///<summary></summary>
		protected override void Dispose( bool disposing ){
			if( disposing ){
				if(components != null){
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		private void InitializeComponent(){
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClaimsSend));
			this.label6 = new System.Windows.Forms.Label();
			this.contextMenuStatus = new System.Windows.Forms.ContextMenu();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.calendarTo = new System.Windows.Forms.MonthCalendar();
			this.calendarFrom = new System.Windows.Forms.MonthCalendar();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panelSplitter = new System.Windows.Forms.Panel();
			this.panelHistory = new System.Windows.Forms.Panel();
			this.gridHistory = new OpenDental.UI.ODGrid();
			this.panel1 = new System.Windows.Forms.Panel();
			this.ToolBarHistory = new OpenDental.UI.ODToolBar();
			this.butDropTo = new OpenDental.UI.Button();
			this.butDropFrom = new OpenDental.UI.Button();
			this.textDateFrom = new OpenDental.ValidDate();
			this.textDateTo = new OpenDental.ValidDate();
			this.comboClinic = new System.Windows.Forms.ComboBox();
			this.labelClinic = new System.Windows.Forms.Label();
			this.gridMain = new OpenDental.UI.ODGrid();
			this.ToolBarMain = new OpenDental.UI.ODToolBar();
			this.contextMenuEclaims = new System.Windows.Forms.ContextMenu();
			this.comboCustomTracking = new System.Windows.Forms.ComboBox();
			this.labelCustomTracking = new System.Windows.Forms.Label();
			this.panelHistory.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(107, -44);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 44);
			this.label6.TabIndex = 21;
			this.label6.Text = "Insurance Claims";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			this.imageList1.Images.SetKeyName(1, "");
			this.imageList1.Images.SetKeyName(2, "");
			this.imageList1.Images.SetKeyName(3, "");
			this.imageList1.Images.SetKeyName(4, "");
			this.imageList1.Images.SetKeyName(5, "");
			this.imageList1.Images.SetKeyName(6, "");
			// 
			// calendarTo
			// 
			this.calendarTo.Location = new System.Drawing.Point(196, 29);
			this.calendarTo.MaxSelectionCount = 1;
			this.calendarTo.Name = "calendarTo";
			this.calendarTo.TabIndex = 42;
			this.calendarTo.Visible = false;
			this.calendarTo.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calendarTo_DateSelected);
			// 
			// calendarFrom
			// 
			this.calendarFrom.Location = new System.Drawing.Point(6, 29);
			this.calendarFrom.MaxSelectionCount = 1;
			this.calendarFrom.Name = "calendarFrom";
			this.calendarFrom.TabIndex = 39;
			this.calendarFrom.Visible = false;
			this.calendarFrom.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calendarFrom_DateSelected);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(196, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 18);
			this.label2.TabIndex = 36;
			this.label2.Text = "To";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(1, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 18);
			this.label1.TabIndex = 34;
			this.label1.Text = "From";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// panelSplitter
			// 
			this.panelSplitter.Cursor = System.Windows.Forms.Cursors.SizeNS;
			this.panelSplitter.Location = new System.Drawing.Point(2, 398);
			this.panelSplitter.Name = "panelSplitter";
			this.panelSplitter.Size = new System.Drawing.Size(961, 6);
			this.panelSplitter.TabIndex = 50;
			this.panelSplitter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSplitter_MouseDown);
			this.panelSplitter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelSplitter_MouseMove);
			this.panelSplitter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelSplitter_MouseUp);
			// 
			// panelHistory
			// 
			this.panelHistory.Controls.Add(this.calendarFrom);
			this.panelHistory.Controls.Add(this.label1);
			this.panelHistory.Controls.Add(this.calendarTo);
			this.panelHistory.Controls.Add(this.gridHistory);
			this.panelHistory.Controls.Add(this.panel1);
			this.panelHistory.Controls.Add(this.butDropTo);
			this.panelHistory.Controls.Add(this.butDropFrom);
			this.panelHistory.Controls.Add(this.textDateFrom);
			this.panelHistory.Controls.Add(this.label2);
			this.panelHistory.Controls.Add(this.textDateTo);
			this.panelHistory.Location = new System.Drawing.Point(0, 403);
			this.panelHistory.Name = "panelHistory";
			this.panelHistory.Size = new System.Drawing.Size(972, 286);
			this.panelHistory.TabIndex = 51;
			// 
			// gridHistory
			// 
			this.gridHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.gridHistory.HScrollVisible = false;
			this.gridHistory.Location = new System.Drawing.Point(4, 31);
			this.gridHistory.Name = "gridHistory";
			this.gridHistory.ScrollValue = 0;
			this.gridHistory.SelectionMode = OpenDental.UI.GridSelectionMode.MultiExtended;
			this.gridHistory.Size = new System.Drawing.Size(959, 252);
			this.gridHistory.TabIndex = 33;
			this.gridHistory.Title = "History";
			this.gridHistory.TranslationName = "TableClaimHistory";
			this.gridHistory.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.gridHistory_CellDoubleClick);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel1.Controls.Add(this.ToolBarHistory);
			this.panel1.Location = new System.Drawing.Point(387, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(576, 27);
			this.panel1.TabIndex = 44;
			// 
			// ToolBarHistory
			// 
			this.ToolBarHistory.BackColor = System.Drawing.SystemColors.Control;
			this.ToolBarHistory.ImageList = this.imageList1;
			this.ToolBarHistory.Location = new System.Drawing.Point(1, 1);
			this.ToolBarHistory.Name = "ToolBarHistory";
			this.ToolBarHistory.Size = new System.Drawing.Size(575, 25);
			this.ToolBarHistory.TabIndex = 43;
			this.ToolBarHistory.ButtonClick += new OpenDental.UI.ODToolBarButtonClickEventHandler(this.ToolBarHistory_ButtonClick);
			// 
			// butDropTo
			// 
			this.butDropTo.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butDropTo.Autosize = true;
			this.butDropTo.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butDropTo.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butDropTo.CornerRadius = 4F;
			this.butDropTo.Location = new System.Drawing.Point(352, 4);
			this.butDropTo.Name = "butDropTo";
			this.butDropTo.Size = new System.Drawing.Size(22, 23);
			this.butDropTo.TabIndex = 41;
			this.butDropTo.Text = "V";
			this.butDropTo.UseVisualStyleBackColor = true;
			this.butDropTo.Click += new System.EventHandler(this.butDropTo_Click);
			// 
			// butDropFrom
			// 
			this.butDropFrom.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butDropFrom.Autosize = true;
			this.butDropFrom.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butDropFrom.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butDropFrom.CornerRadius = 4F;
			this.butDropFrom.Location = new System.Drawing.Point(162, 4);
			this.butDropFrom.Name = "butDropFrom";
			this.butDropFrom.Size = new System.Drawing.Size(22, 23);
			this.butDropFrom.TabIndex = 40;
			this.butDropFrom.Text = "V";
			this.butDropFrom.UseVisualStyleBackColor = true;
			this.butDropFrom.Click += new System.EventHandler(this.butDropFrom_Click);
			// 
			// textDateFrom
			// 
			this.textDateFrom.Location = new System.Drawing.Point(79, 6);
			this.textDateFrom.Name = "textDateFrom";
			this.textDateFrom.Size = new System.Drawing.Size(81, 20);
			this.textDateFrom.TabIndex = 35;
			// 
			// textDateTo
			// 
			this.textDateTo.Location = new System.Drawing.Point(269, 6);
			this.textDateTo.Name = "textDateTo";
			this.textDateTo.Size = new System.Drawing.Size(81, 20);
			this.textDateTo.TabIndex = 37;
			// 
			// comboClinic
			// 
			this.comboClinic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboClinic.Location = new System.Drawing.Point(74, 26);
			this.comboClinic.MaxDropDownItems = 40;
			this.comboClinic.Name = "comboClinic";
			this.comboClinic.Size = new System.Drawing.Size(160, 21);
			this.comboClinic.TabIndex = 53;
			this.comboClinic.SelectionChangeCommitted += new System.EventHandler(this.comboClinic_SelectionChangeCommitted);
			// 
			// labelClinic
			// 
			this.labelClinic.Location = new System.Drawing.Point(7, 29);
			this.labelClinic.Name = "labelClinic";
			this.labelClinic.Size = new System.Drawing.Size(65, 14);
			this.labelClinic.TabIndex = 52;
			this.labelClinic.Text = "Clinic Filter";
			this.labelClinic.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// gridMain
			// 
			this.gridMain.HScrollVisible = false;
			this.gridMain.Location = new System.Drawing.Point(4, 49);
			this.gridMain.Name = "gridMain";
			this.gridMain.ScrollValue = 0;
			this.gridMain.SelectionMode = OpenDental.UI.GridSelectionMode.MultiExtended;
			this.gridMain.Size = new System.Drawing.Size(959, 350);
			this.gridMain.TabIndex = 32;
			this.gridMain.Title = "Claims Waiting to Send";
			this.gridMain.TranslationName = "TableQueue";
			this.gridMain.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.gridMain_CellDoubleClick);
			// 
			// ToolBarMain
			// 
			this.ToolBarMain.Dock = System.Windows.Forms.DockStyle.Top;
			this.ToolBarMain.ImageList = this.imageList1;
			this.ToolBarMain.Location = new System.Drawing.Point(0, 0);
			this.ToolBarMain.Name = "ToolBarMain";
			this.ToolBarMain.Size = new System.Drawing.Size(971, 25);
			this.ToolBarMain.TabIndex = 31;
			this.ToolBarMain.ButtonClick += new OpenDental.UI.ODToolBarButtonClickEventHandler(this.ToolBarMain_ButtonClick);
			// 
			// comboCustomTracking
			// 
			this.comboCustomTracking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboCustomTracking.Location = new System.Drawing.Point(384, 26);
			this.comboCustomTracking.MaxDropDownItems = 40;
			this.comboCustomTracking.Name = "comboCustomTracking";
			this.comboCustomTracking.Size = new System.Drawing.Size(160, 21);
			this.comboCustomTracking.TabIndex = 57;
			this.comboCustomTracking.SelectionChangeCommitted += new System.EventHandler(this.comboCustomTracking_SelectionChangeCommitted);
			// 
			// labelCustomTracking
			// 
			this.labelCustomTracking.Location = new System.Drawing.Point(240, 29);
			this.labelCustomTracking.Name = "labelCustomTracking";
			this.labelCustomTracking.Size = new System.Drawing.Size(142, 14);
			this.labelCustomTracking.TabIndex = 56;
			this.labelCustomTracking.Text = "Custom Tracking Filter";
			this.labelCustomTracking.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// FormClaimsSend
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(971, 691);
			this.Controls.Add(this.comboCustomTracking);
			this.Controls.Add(this.labelCustomTracking);
			this.Controls.Add(this.comboClinic);
			this.Controls.Add(this.labelClinic);
			this.Controls.Add(this.gridMain);
			this.Controls.Add(this.panelHistory);
			this.Controls.Add(this.panelSplitter);
			this.Controls.Add(this.ToolBarMain);
			this.Controls.Add(this.label6);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormClaimsSend";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Send Claims";
			this.Load += new System.EventHandler(this.FormClaimsSend_Load);
			this.panelHistory.ResumeLayout(false);
			this.panelHistory.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormClaimsSend_Load(object sender, System.EventArgs e) {
			AdjustPanelSplit();
			contextMenuStatus.MenuItems.Add(Lan.g(this,"Go to Account"),new EventHandler(GotoAccount_Clicked));
			gridMain.ContextMenu=contextMenuStatus;
			for(int i=0;i<Clearinghouses.Listt.Length;i++){
				contextMenuEclaims.MenuItems.Add(Clearinghouses.Listt[i].Description,new EventHandler(menuItemClearinghouse_Click));
			}
			LayoutToolBars();
			if(PrefC.GetBool(PrefName.EasyNoClinics)) {
				comboClinic.Visible=false;
				labelClinic.Visible=false;
			}
			else {
				comboClinic.Items.Add(Lan.g(this,"all"));
				comboClinic.SelectedIndex=0;
				for(int i=0;i<Clinics.List.Length;i++) {
					comboClinic.Items.Add(Clinics.List[i].Description);
				}
			}
			comboCustomTracking.Items.Add(Lan.g(this,"all"));
			comboCustomTracking.SelectedIndex=0;
			if(DefC.Long[(int)DefCat.ClaimCustomTracking].Length==0){
				labelCustomTracking.Visible=false;
				comboCustomTracking.Visible=false;
			}
			else{
				for(int i=0;i<DefC.Long[(int)DefCat.ClaimCustomTracking].Length;i++) {
					comboCustomTracking.Items.Add(DefC.Long[(int)DefCat.ClaimCustomTracking][i].ItemName);
				}
			}
			if(PrefC.RandomKeys && !PrefC.GetBool(PrefName.EasyNoClinics)){//using random keys and clinics
				//Does not pull in reports automatically, because they could easily get assigned to the wrong clearinghouse
			}
			else{
				FormClaimReports FormC=new FormClaimReports();
				FormC.AutomaticMode=true;
				FormC.ShowDialog();
			}
			FillGrid();
			textDateFrom.Text=DateTime.Today.AddDays(-7).ToShortDateString();
			textDateTo.Text=DateTime.Today.ToShortDateString();
			FillHistory();
		}

		///<summary></summary>
		public void LayoutToolBars(){
			ToolBarMain.Buttons.Clear();
			ToolBarMain.Buttons.Add(new ODToolBarButton(Lan.g(this,"Preview"),0,Lan.g(this,"Preview the Selected Claim"),"Preview"));
			ToolBarMain.Buttons.Add(new ODToolBarButton(Lan.g(this,"Blank"),1,Lan.g(this,"Print a Blank Claim Form"),"Blank"));
			ToolBarMain.Buttons.Add(new ODToolBarButton(Lan.g(this,"Print"),2,Lan.g(this,"Print Selected Claims"),"Print"));
			ToolBarMain.Buttons.Add(new ODToolBarButton(Lan.g(this,"Labels"),6,Lan.g(this,"Print Single Labels"),"Labels"));
			/*ToolBarMain.Buttons.Add(new ODToolBarButton(ODToolBarButtonStyle.Separator));
			ODToolBarButton button=new ODToolBarButton(Lan.g(this,"Change Status"),-1,Lan.g(this,"Changes Status of Selected Claims"),"Status");
			button.Style=ODToolBarButtonStyle.DropDownButton;
			button.DropDownMenu=contextMenuStatus;
			ToolBarMain.Buttons.Add(button);*/
			ToolBarMain.Buttons.Add(new ODToolBarButton(ODToolBarButtonStyle.Separator));
			ODToolBarButton button=new ODToolBarButton(Lan.g(this,"Send E-Claims"),4,Lan.g(this,"Send claims Electronically"),"Eclaims");
			button.Style=ODToolBarButtonStyle.DropDownButton;
			button.DropDownMenu=contextMenuEclaims;
			ToolBarMain.Buttons.Add(button);
			if(CultureInfo.CurrentCulture.Name.EndsWith("CA")) {//Canadian. en-CA or fr-CA
				ToolBarMain.Buttons.Add(new ODToolBarButton(Lan.g(this,"Outstanding"),-1,Lan.g(this,"Get Outstanding Transactions"),"Outstanding"));
				ToolBarMain.Buttons.Add(new ODToolBarButton(Lan.g(this,"Payment Rec"),-1,Lan.g(this,"Get Payment Reconciliation Transactions"),"PayRec"));
				//ToolBarMain.Buttons.Add(new ODToolBarButton(Lan.g(this,"Summary Rec"),-1,Lan.g(this,"Get Summary Reconciliation Transactions"),"SummaryRec"));
			}
			else {
				ToolBarMain.Buttons.Add(new ODToolBarButton(Lan.g(this,"Get Reports"),5,Lan.g(this,"Get Reports from Other Clearinghouses"),"Reports"));
			}
			ToolBarMain.Buttons.Add(new ODToolBarButton(ODToolBarButtonStyle.Separator));
			ToolBarMain.Buttons.Add(new ODToolBarButton(Lan.g(this,"Close"),-1,"","Close"));
			/*ArrayList toolButItems=ToolButItems.GetForToolBar(ToolBarsAvail.ClaimsSend);
			for(int i=0;i<toolButItems.Count;i++){
				ToolBarMain.Buttons.Add(new ODToolBarButton(ODToolBarButtonStyle.Separator));
				ToolBarMain.Buttons.Add(new ODToolBarButton(((ToolButItem)toolButItems[i]).ButtonText
					,-1,"",((ToolButItem)toolButItems[i]).ProgramNum));
			}*/
			ToolBarMain.Invalidate();
			ToolBarHistory.Buttons.Clear();
			ToolBarHistory.Buttons.Add(new ODToolBarButton(Lan.g(this,"Refresh"),-1,Lan.g(this,"Refresh this list."),"Refresh"));
			ToolBarHistory.Buttons.Add(new ODToolBarButton(ODToolBarButtonStyle.Separator));
			ToolBarHistory.Buttons.Add(new ODToolBarButton(Lan.g(this,"Undo"),-1,
				Lan.g(this,"Change the status of claims back to 'Waiting'."),"Undo"));
			ToolBarHistory.Buttons.Add(new ODToolBarButton(ODToolBarButtonStyle.Separator));
			ToolBarHistory.Buttons.Add(new ODToolBarButton(Lan.g(this,"Print List"),2,
				Lan.g(this,"Print history list."),"PrintList"));
			/*#if DEBUG
			ToolBarHistory.Buttons.Add(new ODToolBarButton(Lan.g(this,"Print Item"),2,
				Lan.g(this,"For debugging, this will simply display the first item in the list."),"PrintItem"));
			#else
			ToolBarHistory.Buttons.Add(new ODToolBarButton(Lan.g(this,"Print Item"),2,
				Lan.g(this,"Print one item from the list."),"PrintItem"));
			#endif*/
			ToolBarHistory.Invalidate();
		}

		private void GotoAccount_Clicked(object sender, System.EventArgs e){
			//accessed by right clicking
			if(gridMain.SelectedIndices.Length!=1) {
				MsgBox.Show(this,"Please select exactly one item first.");
				return;
			}
			GotoPatNum=listQueue[gridMain.SelectedIndices[0]].PatNum;
			GotoClaimNum=listQueue[gridMain.SelectedIndices[0]].ClaimNum;
			DialogResult=DialogResult.OK;
		}

		private void menuItemClearinghouse_Click(object sender, System.EventArgs e){
			MenuItem menuitem=(MenuItem)sender;
			SendEclaimsToClearinghouse(Clearinghouses.Listt[menuitem.Index].ClearinghouseNum);
		}

		private void FillGrid(){
			long clinicNum=0;
			long customTracking=0;
			if(!PrefC.GetBool(PrefName.EasyNoClinics) && comboClinic.SelectedIndex!=0) {
				clinicNum=Clinics.List[comboClinic.SelectedIndex-1].ClinicNum;
			}
			if(comboCustomTracking.SelectedIndex!=0) {
				customTracking=DefC.Long[(int)DefCat.ClaimCustomTracking][comboCustomTracking.SelectedIndex-1].DefNum;
			}
			listQueue=Claims.GetQueueList(0,clinicNum,customTracking);
			for(int i=0;i<listQueue.Length;i++) {
				Eclaims.Eclaims.GetMissingData(listQueue[i]);
			}
			gridMain.BeginUpdate();
			gridMain.Columns.Clear();
			ODGridColumn col=new ODGridColumn(Lan.g("TableQueue","Patient Name"),190);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableQueue","Carrier Name"),100);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableQueue","Clinic"),80);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableQueue","M/D"),40);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableQueue","Clearinghouse"),80);//4. This is position critical. See line 696.
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableQueue","Warnings"),120);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableQueue","Missing Info"),400);
			gridMain.Columns.Add(col);			 
			gridMain.Rows.Clear();
			ODGridRow row;
			for(int i=0;i<listQueue.Length;i++){
				row=new ODGridRow();
				row.Cells.Add(listQueue[i].PatName);
				row.Cells.Add(listQueue[i].Carrier);
				row.Cells.Add(Clinics.GetDesc(listQueue[i].ClinicNum));
				switch(listQueue[i].MedType){
					case EnumClaimMedType.Dental:
						row.Cells.Add("Dent");
						break;
					case EnumClaimMedType.Medical:
						row.Cells.Add("Med");
						break;
					case EnumClaimMedType.Institutional:
						row.Cells.Add("Inst");
						break;
				}
				if(listQueue[i].NoSendElect){
					row.Cells.Add("Paper");
					row.Cells.Add("");
					row.Cells.Add("");
				}
				else{
					row.Cells.Add(ClearinghouseL.GetDescript(listQueue[i].ClearinghouseNum));
					row.Cells.Add(listQueue[i].Warnings);
					row.Cells.Add(listQueue[i].MissingData);
				}
				gridMain.Rows.Add(row);
			}
			gridMain.EndUpdate();
		}

		private void gridMain_CellDoubleClick(object sender, ODGridClickEventArgs e){
			int selected=e.Row;
			FormClaimPrint FormCP;
			FormCP=new FormClaimPrint();
			FormCP.PatNumCur=listQueue[e.Row].PatNum;
			FormCP.ClaimNumCur=listQueue[e.Row].ClaimNum;
			FormCP.PrintImmediately=false;
			FormCP.ShowDialog();				
			FillGrid();	
			gridMain.SetSelected(selected,true);
			FillHistory();
		}

		private void ToolBarMain_ButtonClick(object sender, OpenDental.UI.ODToolBarButtonClickEventArgs e) {
			switch(e.Button.Tag.ToString()){
				case "Preview":
					toolBarButPreview_Click();
					break;
				case "Blank":
					toolBarButBlank_Click();
					break;
				case "Print":
					toolBarButPrint_Click();
					break;
				case "Labels":
					toolBarButLabels_Click();
					break;
				case "Eclaims":
					SendEclaimsToClearinghouse(0);
					break;
				case "Reports":
					toolBarButReports_Click();
					break;
				case "Outstanding":
					toolBarButOutstanding_Click();
					break;
				case "PayRec":
					toolBarButPayRec_Click();
					break;
				case "SummaryRec":
					toolBarButSummaryRec_Click();
					break;
				case "Close":
					Close();
					break;
			}
		}

		private void toolBarButPreview_Click(){
			FormClaimPrint FormCP;
			FormCP=new FormClaimPrint();
			if(gridMain.SelectedIndices.Length==0){
				MessageBox.Show(Lan.g(this,"Please select a claim first."));
				return;
			}
			if(gridMain.SelectedIndices.Length > 1){
				MessageBox.Show(Lan.g(this,"Please select only one claim."));
				return;
			}
			FormCP.PatNumCur=listQueue[gridMain.GetSelectedIndex()].PatNum;
			FormCP.ClaimNumCur=listQueue[gridMain.GetSelectedIndex()].ClaimNum;
			FormCP.PrintImmediately=false;
			FormCP.ShowDialog();				
			FillGrid();
			FillHistory();
		}

		private void toolBarButBlank_Click(){
			PrintDocument pd=new PrintDocument();
			if(!PrinterL.SetPrinter(pd,PrintSituation.Claim)){
				return;
			}
			FormClaimPrint FormCP=new FormClaimPrint();
			FormCP.PrintBlank=true;
			FormCP.PrintImmediate(pd.PrinterSettings.PrinterName,pd.PrinterSettings.Copies);
		}

		private void toolBarButPrint_Click(){
			FormClaimPrint FormCP=new FormClaimPrint();
			if(gridMain.SelectedIndices.Length==0){
				for(int i=0;i<listQueue.Length;i++){
					if((listQueue[i].ClaimStatus=="W" || listQueue[i].ClaimStatus=="P")
						&& listQueue[i].NoSendElect)
					{
						gridMain.SetSelected(i,true);		
					}	
				}
				if(!MsgBox.Show(this,true,"No claims were selected.  Print all selected paper claims?")){
					return;
				}
			}
			PrintDocument pd=new PrintDocument();
			if(!PrinterL.SetPrinter(pd,PrintSituation.Claim)){
				return;
			}
			for(int i=0;i<gridMain.SelectedIndices.Length;i++){
				FormCP.PatNumCur=listQueue[gridMain.SelectedIndices[i]].PatNum;
				FormCP.ClaimNumCur=listQueue[gridMain.SelectedIndices[i]].ClaimNum;
				FormCP.ClaimFormCur=null;//so that it will pull from the individual claim or plan.
				if(!FormCP.PrintImmediate(pd.PrinterSettings.PrinterName,1)){
					return;
				}
				Etranss.SetClaimSentOrPrinted(listQueue[gridMain.SelectedIndices[i]].ClaimNum,listQueue[gridMain.SelectedIndices[i]].PatNum,0,EtransType.ClaimPrinted,0);
			}
			FillGrid();
			FillHistory();
		}

		private void toolBarButLabels_Click(){
			if(gridMain.SelectedIndices.Length==0){
				MessageBox.Show(Lan.g(this,"Please select a claim first."));
				return;
			}
			//PrintDocument pd=new PrintDocument();//only used to pass printerName
			//if(!PrinterL.SetPrinter(pd,PrintSituation.LabelSingle)){
			//	return;
			//}
			//Carrier carrier;
			Claim claim;
			InsPlan plan;
			List<long> carrierNums=new List<long>();
			for(int i=0;i<gridMain.SelectedIndices.Length;i++){
				claim=Claims.GetClaim(listQueue[gridMain.SelectedIndices[i]].ClaimNum);
				plan=InsPlans.GetPlan(claim.PlanNum,new List <InsPlan> ());
				carrierNums.Add(plan.CarrierNum);
			}
			//carrier=Carriers.GetCarrier(plan.CarrierNum);
			//LabelSingle label=new LabelSingle();
			LabelSingle.PrintCarriers(carrierNums);//,pd.PrinterSettings.PrinterName)){
			//	return;
			//}
		}

		///<Summary>Use clearinghouseNum of 0 to indicate automatic calculation of clearinghouses.</Summary>
		private void SendEclaimsToClearinghouse(long clearinghouseNum) {
			if(!PrefC.GetBool(PrefName.EasyNoClinics)) {//Clinics is in use
				if(clearinghouseNum==0){
					MsgBox.Show(this,"When the Clinics option is enabled, you must use the dropdown list to select the clearinghouse to send to.");
					return;
				}
			}
			Clearinghouse clearDefault;
			if(clearinghouseNum==0){
				clearDefault=Clearinghouses.GetDefaultDental();
			}
			else{
				clearDefault=ClearinghouseL.GetClearinghouse(clearinghouseNum);
			}
			if(clearDefault!=null && clearDefault.ISA08=="113504607" && Process.GetProcessesByName("TesiaLink").Length==0){
				#if DEBUG
					if(!MsgBox.Show(this,true,"TesiaLink is not started.  Create file anyway?")){
						return;
					}
				#else
					MsgBox.Show(this,"Please start TesiaLink first.");
					return;
				#endif
			}
			if(gridMain.SelectedIndices.Length==0){//if none are selected
				for(int i=0;i<listQueue.Length;i++){//loop through all rows
					if(!listQueue[i].NoSendElect && listQueue[i].MissingData==""){
						if(clearinghouseNum==0) {//they did not use the dropdown list for specific clearinghouse
							//If clearinghouse is zero because they just pushed the button instead of using the dropdown list,
							//then don't check the clearinghouse of each claim.  Just select them if they are electronic.
							gridMain.SetSelected(i,true);
						}
						else{//if they used the dropdown list,
							//then first, try to only select items in the list that match the clearinghouse.
							if(listQueue[i].ClearinghouseNum==clearinghouseNum) {
								gridMain.SetSelected(i,true);
							}
						}
					}	
				}
				//If they used the dropdown list, and there still aren't any in the list that match the selected clearinghouse
				//then ask user if they want to send all of the electronic ones through this clearinghouse.
				if(clearinghouseNum !=0 && gridMain.SelectedIndices.Length==0) {
					if(comboClinic.SelectedIndex==0) {
						MsgBox.Show(this,"Please filter by clinic first.");
						return;
					}
					if(!MsgBox.Show(this,MsgBoxButtons.YesNo,"Send all e-claims through selected clearinghouse?")) {
						return;
					}
					for(int i=0;i<listQueue.Length;i++) {
						if(!listQueue[i].NoSendElect && listQueue[i].MissingData=="") {//no Missing Info
							gridMain.SetSelected(i,true);//this will include other clearinghouses
						}
					}
				}
				if(gridMain.SelectedIndices.Length==0){
					MsgBox.Show(this,"No claims to send.");
					return;
				}
				if(clearinghouseNum!=0){//if they used the dropdown list to specify clearinghouse
					int[] selectedindices=(int[])gridMain.SelectedIndices.Clone();
					for(int i=0;i<selectedindices.Length;i++) {
						gridMain.Rows[selectedindices[i]].Cells[4].Text=clearDefault.Description;//show the changed clearinghouse
					}
					gridMain.Invalidate();
				}
				if(!MsgBox.Show(this,true,"Send all selected e-claims?")){
					FillGrid();//this changes back any clearinghouse descriptions that we changed manually.
					return;
				}
			}
			if(!PrefC.GetBool(PrefName.EasyNoClinics)) {//Clinics is in use
				long clinicNum0=Claims.GetClaim(listQueue[gridMain.SelectedIndices[0]].ClaimNum).ClinicNum;
				for(int i=1;i<gridMain.SelectedIndices.Length;i++){
					long clinicNum=Claims.GetClaim(listQueue[gridMain.SelectedIndices[i]].ClaimNum).ClinicNum;
					if(clinicNum0!=clinicNum){
						MsgBox.Show(this,"All claims must be for the same clinic.  You can use the combobox at the top to filter.");
						return;
					}
				}
			}
			long clearinghouseNum0=listQueue[gridMain.SelectedIndices[0]].ClearinghouseNum;
			EnumClaimMedType medType0=Claims.GetClaim(listQueue[gridMain.SelectedIndices[0]].ClaimNum).MedType;
			for(int i=0;i<gridMain.SelectedIndices.Length;i++) {//we start with 0 so that we can check medtype match on the first claim
				long clearinghouseNumI=listQueue[gridMain.SelectedIndices[i]].ClearinghouseNum;
				if(clearinghouseNum0!=clearinghouseNumI) {
					MsgBox.Show(this,"All claims must be for the same clearinghouse.");
					return;
				}
				EnumClaimMedType medTypeI=Claims.GetClaim(listQueue[gridMain.SelectedIndices[i]].ClaimNum).MedType;
				if(medType0!=medTypeI) {
					MsgBox.Show(this,"All claims must have the same MedType.");
					return;
				}
				Clearinghouse clearh=Clearinghouses.GetClearinghouse(clearinghouseNumI);
				if(clearh.Eformat==ElectronicClaimFormat.x837D_4010 || clearh.Eformat==ElectronicClaimFormat.x837D_5010_dental) {
					if(medTypeI!=EnumClaimMedType.Dental) {
						MessageBox.Show("On claim "+i.ToString()+", the MedType does not match the clearinghouse e-format.");
						return;
					}
				}
				if(clearh.Eformat==ElectronicClaimFormat.x837_5010_med_inst) {
					if(medTypeI!=EnumClaimMedType.Medical && medTypeI!=EnumClaimMedType.Institutional) {
						MessageBox.Show("On claim "+i.ToString()+", the MedType does not match the clearinghouse e-format.");
						return;
					}
				}
			}
			for(int i=0;i<gridMain.SelectedIndices.Length;i++){
				if(listQueue[gridMain.SelectedIndices[i]].MissingData!=""){
					MsgBox.Show(this,"Not allowed to send e-claims with missing information.");
					return;
				}
				if(listQueue[gridMain.SelectedIndices[i]].NoSendElect) {
					MsgBox.Show(this,"Not allowed to send paper claims electronically.");
					return;
				}
			}
			List<ClaimSendQueueItem> queueItems=new List<ClaimSendQueueItem>();//a list of queue items to send
			ClaimSendQueueItem queueitem;
			for(int i=0;i<gridMain.SelectedIndices.Length;i++) {
				queueitem=listQueue[gridMain.SelectedIndices[i]].Copy();
				if(clearinghouseNum!=0) {
					queueitem.ClearinghouseNum=clearinghouseNum;
				}
				queueItems.Add(queueitem);
			}
			Clearinghouse clearhouse=ClearinghouseL.GetClearinghouse(queueItems[0].ClearinghouseNum);
			EnumClaimMedType medType=Claims.GetClaim(listQueue[gridMain.SelectedIndices[0]].ClaimNum).MedType;
			//Already validated that all claims are for the same clearinghouse, clinic, and medType.
			//Validated that medtype matches clearinghouse e-format
			Cursor=Cursors.WaitCursor;
			Eclaims.Eclaims.SendBatch(queueItems,clearhouse,medType);
			Cursor=Cursors.Default;
			//statuses changed to S in SendBatches
			FillGrid();
			FillHistory();
			//Now, the cool part.  Highlight all the claims that were just sent in the history grid
			for(int i=0;i<queueItems.Count;i++){
				for(int j=0;j<tableHistory.Rows.Count;j++){
					long claimNum=PIn.Long(tableHistory.Rows[j]["ClaimNum"].ToString());
					if(claimNum==queueItems[i].ClaimNum){
						gridHistory.SetSelected(j,true);
						break;
					}
				}
			}
		}

		private void toolBarButReports_Click(){
			FormClaimReports FormC=new FormClaimReports();
			FormC.ShowDialog();
		}

		private void toolBarButOutstanding_Click() {
			FormCanadaOutstandingTransactions fcot=new FormCanadaOutstandingTransactions();
			fcot.ShowDialog();
		}

		private void toolBarButPayRec_Click() {
			FormCanadaPaymentReconciliation fcpr=new FormCanadaPaymentReconciliation();
			fcpr.ShowDialog();
		}

		private void toolBarButSummaryRec_Click() {
			FormCanadaSummaryReconciliation fcsr=new FormCanadaSummaryReconciliation();
			fcsr.ShowDialog();
		}

		private void comboClinic_SelectionChangeCommitted(object sender,EventArgs e) {
			FillGrid();
		}

		private void comboCustomTracking_SelectionChangeCommitted(object sender,EventArgs e) {
			FillGrid();
		}

		private void FillHistory(){
			if(textDateFrom.errorProvider1.GetError(textDateFrom)!=""
				|| textDateTo.errorProvider1.GetError(textDateTo)!=""
				) {
				return;
			}
			DateTime dateFrom=PIn.Date(textDateFrom.Text);
			DateTime dateTo;
			if(textDateTo.Text=="") {
				dateTo=DateTime.MaxValue;
			}
			else {
				dateTo=PIn.Date(textDateTo.Text);
			}
			tableHistory=Etranss.RefreshHistory(dateFrom,dateTo);
			//listQueue=Claims.GetQueueList();
			gridHistory.BeginUpdate();
			gridHistory.Columns.Clear();
			if(CultureInfo.CurrentCulture.Name.EndsWith("CA")) {//Canadian. en-CA or fr-CA
				ODGridColumn col;
				col=new ODGridColumn(Lan.g("TableClaimHistory","Patient Name"),130);
				gridHistory.Columns.Add(col);
				col=new ODGridColumn(Lan.g("TableClaimHistory","Carrier Name"),170);
				gridHistory.Columns.Add(col);
				col=new ODGridColumn(Lan.g("TableClaimHistory","Clearinghouse"),90);
				gridHistory.Columns.Add(col);
				col=new ODGridColumn(Lan.g("TableClaimHistory","Date"),70);
				gridHistory.Columns.Add(col);
				col=new ODGridColumn(Lan.g("TableClaimHistory","Type"),100);
				gridHistory.Columns.Add(col);
				col=new ODGridColumn(Lan.g("TableClaimHistory","AckCode"),100);
				gridHistory.Columns.Add(col);
				col=new ODGridColumn(Lan.g("TableClaimHistory","Note"),100);
				gridHistory.Columns.Add(col);
				col=new ODGridColumn(Lan.g("TableClaimHistory","Office#"),100);
				gridHistory.Columns.Add(col);
				col=new ODGridColumn(Lan.g("TableClaimHistory","CarrierCount"),0);
				gridHistory.Columns.Add(col);
				gridHistory.Rows.Clear();
				ODGridRow row;
				for(int i=0;i<tableHistory.Rows.Count;i++) {
					row=new ODGridRow();
					row.Cells.Add(tableHistory.Rows[i]["patName"].ToString());
					row.Cells.Add(tableHistory.Rows[i]["CarrierName"].ToString());
					row.Cells.Add(tableHistory.Rows[i]["Clearinghouse"].ToString());
					row.Cells.Add(tableHistory.Rows[i]["dateTimeTrans"].ToString());
					//((DateTime)tableHistory.Rows[i]["DateTimeTrans"]).ToShortDateString());
					//still need to trim the _CA
					row.Cells.Add(tableHistory.Rows[i]["etype"].ToString());
					row.Cells.Add(tableHistory.Rows[i]["ack"].ToString());
					row.Cells.Add(tableHistory.Rows[i]["Note"].ToString());
					row.Cells.Add(tableHistory.Rows[i]["OfficeSequenceNumber"].ToString());
					row.Cells.Add(tableHistory.Rows[i]["CarrierTransCounter"].ToString());
					gridHistory.Rows.Add(row);
				}
			}
			else {
				ODGridColumn col;
				col=new ODGridColumn(Lan.g("TableClaimHistory","Patient Name"),130);
				gridHistory.Columns.Add(col);
				col=new ODGridColumn(Lan.g("TableClaimHistory","Carrier Name"),170);
				gridHistory.Columns.Add(col);
				col=new ODGridColumn(Lan.g("TableClaimHistory","Clearinghouse"),90);
				gridHistory.Columns.Add(col);
				col=new ODGridColumn(Lan.g("TableClaimHistory","Date"),70);
				gridHistory.Columns.Add(col);
				col=new ODGridColumn(Lan.g("TableClaimHistory","Type"),100);
				gridHistory.Columns.Add(col);
				col=new ODGridColumn(Lan.g("TableClaimHistory","AckCode"),100);
				gridHistory.Columns.Add(col);
				col=new ODGridColumn(Lan.g("TableClaimHistory","Note"),0);
				gridHistory.Columns.Add(col);
				gridHistory.Rows.Clear();
				ODGridRow row;
				for(int i=0;i<tableHistory.Rows.Count;i++) {
					row=new ODGridRow();
					row.Cells.Add(tableHistory.Rows[i]["patName"].ToString());
					row.Cells.Add(tableHistory.Rows[i]["CarrierName"].ToString());
					row.Cells.Add(tableHistory.Rows[i]["Clearinghouse"].ToString());
					row.Cells.Add(tableHistory.Rows[i]["dateTimeTrans"].ToString());
					row.Cells.Add(tableHistory.Rows[i]["etype"].ToString());
					row.Cells.Add(tableHistory.Rows[i]["ack"].ToString());
					row.Cells.Add(tableHistory.Rows[i]["Note"].ToString());
					gridHistory.Rows.Add(row);
				}
			}
			gridHistory.EndUpdate();
			gridHistory.ScrollToEnd();
		}

		private void panelSplitter_MouseDown(object sender,System.Windows.Forms.MouseEventArgs e) {
			MouseIsDownOnSplitter=true;
			SplitterOriginalY=panelSplitter.Top;
			OriginalMouseY=panelSplitter.Top+e.Y;
		}

		private void panelSplitter_MouseMove(object sender,System.Windows.Forms.MouseEventArgs e) {
			if(!MouseIsDownOnSplitter)
				return;
			int splitterNewY=SplitterOriginalY+(panelSplitter.Top+e.Y)-OriginalMouseY;
			if(splitterNewY<130)//keeps it from going too high
				splitterNewY=130;
			if(splitterNewY>Height-130)//keeps it from going off the bottom edge
				splitterNewY=Height-130;
			panelSplitter.Top=splitterNewY;
			AdjustPanelSplit();
		}

		private void AdjustPanelSplit(){
			gridMain.Height=panelSplitter.Top-gridMain.Top;
			panelHistory.Top=panelSplitter.Bottom;
			panelHistory.Height=this.ClientSize.Height-panelHistory.Top-1;
		}

		private void panelSplitter_MouseUp(object sender,System.Windows.Forms.MouseEventArgs e) {
			MouseIsDownOnSplitter=false;
		}

		private void butDropFrom_Click(object sender,EventArgs e) {
			ToggleCalendars();
		}

		private void butDropTo_Click(object sender,EventArgs e) {
			ToggleCalendars();
		}

		private void ToggleCalendars() {
			if(calendarFrom.Visible) {
				//hide the calendars
				calendarFrom.Visible=false;
				calendarTo.Visible=false;
			}
			else {
				//set the date on the calendars to match what's showing in the boxes
				if(textDateFrom.errorProvider1.GetError(textDateFrom)==""
					&& textDateTo.errorProvider1.GetError(textDateTo)=="") {//if no date errors
					if(textDateFrom.Text=="") {
						calendarFrom.SetDate(DateTime.Today);
					}
					else {
						calendarFrom.SetDate(PIn.Date(textDateFrom.Text));
					}
					if(textDateTo.Text=="") {
						calendarTo.SetDate(DateTime.Today);
					}
					else {
						calendarTo.SetDate(PIn.Date(textDateTo.Text));
					}
				}
				//show the calendars
				calendarFrom.Visible=true;
				calendarTo.Visible=true;
			}
		}

		private void calendarFrom_DateSelected(object sender,DateRangeEventArgs e) {
			textDateFrom.Text=calendarFrom.SelectionStart.ToShortDateString();
		}

		private void calendarTo_DateSelected(object sender,DateRangeEventArgs e) {
			textDateTo.Text=calendarTo.SelectionStart.ToShortDateString();
		}

		private void ToolBarHistory_ButtonClick(object sender,ODToolBarButtonClickEventArgs e) {
			switch(e.Button.Tag.ToString()){
				case "Refresh":
					RefreshHistory_Click();
					break;
				case "Undo":
					Undo_Click();
					break;
				case "PrintList":
					PrintHistory_Click();
					break;
				case "PrintItem":
					PrintItem_Click();
					break;
			}
		}

		private void RefreshHistory_Click() {
			if(textDateFrom.errorProvider1.GetError(textDateFrom)!=""
				|| textDateTo.errorProvider1.GetError(textDateTo)!=""
				) {
				MsgBox.Show(this,"Please fix data entry errors first.");
				return;
			}
			calendarFrom.Visible=false;
			calendarTo.Visible=false;
			FillHistory();
		}

		private void Undo_Click(){
			if(gridHistory.SelectedIndices.Length==0){
				MsgBox.Show(this,"Please select at least one item first.");
				return;
			}
			if(gridHistory.SelectedIndices.Length>1){//if there are multiple items selected.
				//then they must all be Claim_Ren, ClaimSent, or ClaimPrinted
				EtransType etype;
				for(int i=0;i<gridHistory.SelectedIndices.Length;i++) {
					etype=(EtransType)PIn.Long(tableHistory.Rows[gridHistory.SelectedIndices[i]]["Etype"].ToString());
					if(etype!=EtransType.Claim_Ren && etype!=EtransType.ClaimSent && etype!=EtransType.ClaimPrinted){
						MsgBox.Show(this,"That type of transaction cannot be undone as a group.  Please undo one at a time.");
						return;
					}
				}
			}
			//loop through each selected item, and see if they are allowed to be "undone".
			//at this point, 
			for(int i=0;i<gridHistory.SelectedIndices.Length;i++) {
				if((EtransType)PIn.Long(tableHistory.Rows[gridHistory.SelectedIndices[i]]["Etype"].ToString())==EtransType.Claim_CA){
					//if a 
				}
				//else if(){
				
				//}
				
			}
			if(!MsgBox.Show(this,true,"Remove the selected claims from the history list, and change the claim status from 'Sent' back to 'Waiting to Send'?")){
				return;
			}
			for(int i=0;i<gridHistory.SelectedIndices.Length;i++){
				Etranss.Undo(PIn.Long(tableHistory.Rows[gridHistory.SelectedIndices[i]]["EtransNum"].ToString()));
			}
			FillGrid();
			FillHistory();
		}

		private void PrintHistory_Click() {
			pagesPrinted=0;
			//headingPrinted=false;
#if DEBUG
			PrintReport(true);
#else
			PrintReport(false);	
#endif
		}

		private void gridHistory_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			Etrans et=Etranss.GetEtrans(PIn.Long(tableHistory.Rows[e.Row]["EtransNum"].ToString()));
			FormEtransEdit FormE=new FormEtransEdit();
			FormE.EtransCur=et;
			FormE.ShowDialog();
			if(FormE.DialogResult!=DialogResult.OK){
				return;
			}
			int scroll=gridHistory.ScrollValue;
			FillHistory();
			for(int i=0;i<tableHistory.Rows.Count;i++){
				if(tableHistory.Rows[i]["EtransNum"].ToString()==et.EtransNum.ToString()){
					gridHistory.SetSelected(i,true);
				}
			}
			gridHistory.ScrollValue=scroll;
		}

		private void ShowRawMessage_Clicked(object sender,System.EventArgs e) {
			//accessed by right clicking on history
			
		}

		///<summary>Preview is only used for debugging.</summary>
		public void PrintReport(bool justPreview) {
			pd2=new PrintDocument();
			pd2.PrintPage += new PrintPageEventHandler(this.pd2_PrintPage);
			pd2.DefaultPageSettings.Margins=new Margins(0,0,0,0);
			pd2.OriginAtMargins=true;
			if(pd2.DefaultPageSettings.PrintableArea.Height==0) {
				pd2.DefaultPageSettings.PaperSize=new PaperSize("default",850,1100);
			}
			headingPrinted=false;
			//isPrinting=true;
			//FillGrid();
			try {
				if(justPreview) {
					FormRpPrintPreview pView = new FormRpPrintPreview();
					pView.printPreviewControl2.Document=pd2;
					pView.ShowDialog();
				}
				else {
					if(PrinterL.SetPrinter(pd2,PrintSituation.Default)) {
						pd2.Print();
					}
				}
			}
			catch {
				MessageBox.Show(Lan.g(this,"Printer not available"));
			}
			//isPrinting=false;
		}

		private void pd2_PrintPage(object sender,System.Drawing.Printing.PrintPageEventArgs e) {
			Rectangle bounds=new Rectangle(50,40,800,1035);//Some printers can handle up to 1042
			Graphics g=e.Graphics;
			string text;
			Font headingFont=new Font("Arial",13,FontStyle.Bold);
			Font subHeadingFont=new Font("Arial",10,FontStyle.Bold);
			int yPos=bounds.Top;
			int center=bounds.X+bounds.Width/2;
			#region printHeading
			if(!headingPrinted) {
				text=Lan.g(this,"Claim History");
				g.DrawString(text,headingFont,Brushes.Black,center-g.MeasureString(text,headingFont).Width/2,yPos);
				yPos+=(int)g.MeasureString(text,headingFont).Height;
				text=textDateFrom.Text+" "+Lan.g(this,"to")+" "+textDateTo.Text;
				g.DrawString(text,subHeadingFont,Brushes.Black,center-g.MeasureString(text,subHeadingFont).Width/2,yPos);
				yPos+=20;
				headingPrinted=true;
				headingPrintH=yPos;
			}
			#endregion
			yPos=gridHistory.PrintPage(g,pagesPrinted,bounds,headingPrintH);
			pagesPrinted++;
			if(yPos==-1) {
				e.HasMorePages=true;
			}
			else {
				e.HasMorePages=false;
			}
			g.Dispose();
		}

		private void PrintItem_Click(){
			//not currently accessible
			if(gridHistory.Rows.Count==0){
				MsgBox.Show(this,"There are no items to print.");
				return;
			}
			if(gridHistory.SelectedIndices.Length==0){
				#if DEBUG
				gridHistory.SetSelected(0,true);//saves you a click when testing
				#else
				MsgBox.Show(this,"Please select at least one item first.");
				return;
				#endif
			}
			//does not yet handle multiple selections
			Etrans etrans=Etranss.GetEtrans(PIn.Long(tableHistory.Rows[gridHistory.SelectedIndices[0]]["EtransNum"].ToString()));
			new FormCCDPrint(etrans,EtransMessageTexts.GetMessageText(etrans.EtransMessageTextNum),false);//Print the form.
			//MessageBox.Show(etrans.MessageText);
		}

		
		

	
		

		

		

		

		

					
				

	}
}







