/*=============================================================================================================
Open Dental GPL license Copyright (C) 2003  Jordan Sparks, DMD.  http://www.open-dent.com,  www.docsparks.com
See header in FormOpenDental.cs for complete text.  Redistributions must retain this text.
===============================================================================================================*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using OpenDental.UI;
using OpenDentBusiness;

namespace OpenDental{
///<summary></summary>
	public class FormConfirmList : System.Windows.Forms.Form{
		private OpenDental.UI.Button butClose;
		private OpenDental.UI.Button butRefresh;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.ComponentModel.Container components = null;
		///<summary>Will be set to true when form closes if user click Send to Pinboard.</summary>
		public bool PinClicked=false;
		private OpenDental.UI.Button butReport;
		private int pagesPrinted;
		private DataTable AddrTable;
		private int patientsPrinted;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox comboStatus;
		private OpenDental.UI.Button butLabels;
		private OpenDental.UI.Button butPostcards;
		private OpenDental.ValidDate textDateFrom;
		private OpenDental.ValidDate textDateTo;
		private OpenDental.UI.ODGrid grid;
		///<summary>When this form closes, this will be the patNum of the last patient viewed.  The calling form should then make use of this to refresh to that patient.  If 0, then calling form should not refresh.</summary>
		public long SelectedPatNum;
		///<summary>This list of appointments displayed</summary>
		private DataTable table;
		private PrintDocument pd;
		private OpenDental.UI.Button butPrint;
		private OpenDental.UI.PrintPreview printPreview;
		private bool headingPrinted;
		private int headingPrintH;
		private ComboBox comboProv;
		private Label label4;
		private OpenDental.UI.Button butEmail;
		private ComboBox comboClinic;
		private Label labelClinic;
		///<summary>Only used if PinClicked=true</summary>
		public long AptSelected;

		///<summary></summary>
		public FormConfirmList(){
			InitializeComponent();// Required for Windows Form Designer support
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

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfirmList));
			this.butClose = new OpenDental.UI.Button();
			this.butRefresh = new OpenDental.UI.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.comboProv = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textDateTo = new OpenDental.ValidDate();
			this.textDateFrom = new OpenDental.ValidDate();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.butReport = new OpenDental.UI.Button();
			this.butLabels = new OpenDental.UI.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.comboStatus = new System.Windows.Forms.ComboBox();
			this.butPostcards = new OpenDental.UI.Button();
			this.grid = new OpenDental.UI.ODGrid();
			this.butPrint = new OpenDental.UI.Button();
			this.butEmail = new OpenDental.UI.Button();
			this.comboClinic = new System.Windows.Forms.ComboBox();
			this.labelClinic = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// butClose
			// 
			this.butClose.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butClose.Autosize = true;
			this.butClose.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butClose.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butClose.CornerRadius = 4F;
			this.butClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.butClose.Location = new System.Drawing.Point(895, 659);
			this.butClose.Name = "butClose";
			this.butClose.Size = new System.Drawing.Size(75, 24);
			this.butClose.TabIndex = 2;
			this.butClose.Text = "&Close";
			this.butClose.Click += new System.EventHandler(this.butClose_Click);
			// 
			// butRefresh
			// 
			this.butRefresh.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butRefresh.Autosize = true;
			this.butRefresh.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butRefresh.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butRefresh.CornerRadius = 4F;
			this.butRefresh.Location = new System.Drawing.Point(20, 34);
			this.butRefresh.Name = "butRefresh";
			this.butRefresh.Size = new System.Drawing.Size(84, 24);
			this.butRefresh.TabIndex = 2;
			this.butRefresh.Text = "&Refresh";
			this.butRefresh.Click += new System.EventHandler(this.butRefresh_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.comboClinic);
			this.groupBox1.Controls.Add(this.labelClinic);
			this.groupBox1.Controls.Add(this.comboProv);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.textDateTo);
			this.groupBox1.Controls.Add(this.textDateFrom);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.butRefresh);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(5, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(632, 63);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "View";
			// 
			// comboProv
			// 
			this.comboProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboProv.Location = new System.Drawing.Point(439, 12);
			this.comboProv.MaxDropDownItems = 40;
			this.comboProv.Name = "comboProv";
			this.comboProv.Size = new System.Drawing.Size(181, 21);
			this.comboProv.TabIndex = 23;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(346, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 14);
			this.label4.TabIndex = 22;
			this.label4.Text = "Provider";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textDateTo
			// 
			this.textDateTo.Location = new System.Drawing.Point(232, 38);
			this.textDateTo.Name = "textDateTo";
			this.textDateTo.Size = new System.Drawing.Size(94, 20);
			this.textDateTo.TabIndex = 14;
			// 
			// textDateFrom
			// 
			this.textDateFrom.Location = new System.Drawing.Point(232, 16);
			this.textDateFrom.Name = "textDateFrom";
			this.textDateFrom.Size = new System.Drawing.Size(94, 20);
			this.textDateFrom.TabIndex = 13;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(152, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 14);
			this.label2.TabIndex = 12;
			this.label2.Text = "To Date";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(152, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 14);
			this.label1.TabIndex = 11;
			this.label1.Text = "From Date";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butReport
			// 
			this.butReport.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butReport.Autosize = true;
			this.butReport.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butReport.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butReport.CornerRadius = 4F;
			this.butReport.Location = new System.Drawing.Point(445, 659);
			this.butReport.Name = "butReport";
			this.butReport.Size = new System.Drawing.Size(87, 24);
			this.butReport.TabIndex = 13;
			this.butReport.Text = "R&un Report";
			this.butReport.Click += new System.EventHandler(this.butReport_Click);
			// 
			// butLabels
			// 
			this.butLabels.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butLabels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butLabels.Autosize = true;
			this.butLabels.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butLabels.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butLabels.CornerRadius = 4F;
			this.butLabels.Image = global::OpenDental.Properties.Resources.butLabel;
			this.butLabels.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLabels.Location = new System.Drawing.Point(129, 659);
			this.butLabels.Name = "butLabels";
			this.butLabels.Size = new System.Drawing.Size(102, 24);
			this.butLabels.TabIndex = 14;
			this.butLabels.Text = "Label Preview";
			this.butLabels.Click += new System.EventHandler(this.butLabels_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.comboStatus);
			this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox3.Location = new System.Drawing.Point(643, 4);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(143, 63);
			this.groupBox3.TabIndex = 15;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Set Status";
			// 
			// comboStatus
			// 
			this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboStatus.Location = new System.Drawing.Point(7, 22);
			this.comboStatus.MaxDropDownItems = 40;
			this.comboStatus.Name = "comboStatus";
			this.comboStatus.Size = new System.Drawing.Size(128, 21);
			this.comboStatus.TabIndex = 15;
			this.comboStatus.SelectedIndexChanged += new System.EventHandler(this.comboStatus_SelectedIndexChanged);
			this.comboStatus.SelectionChangeCommitted += new System.EventHandler(this.comboStatus_SelectionChangeCommitted);
			// 
			// butPostcards
			// 
			this.butPostcards.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butPostcards.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butPostcards.Autosize = true;
			this.butPostcards.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butPostcards.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butPostcards.CornerRadius = 4F;
			this.butPostcards.Image = global::OpenDental.Properties.Resources.butPrintSmall;
			this.butPostcards.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butPostcards.Location = new System.Drawing.Point(4, 659);
			this.butPostcards.Name = "butPostcards";
			this.butPostcards.Size = new System.Drawing.Size(119, 24);
			this.butPostcards.TabIndex = 16;
			this.butPostcards.Text = "Postcard Preview";
			this.butPostcards.Click += new System.EventHandler(this.butPostcards_Click);
			// 
			// grid
			// 
			this.grid.HScrollVisible = false;
			this.grid.Location = new System.Drawing.Point(4, 69);
			this.grid.Name = "grid";
			this.grid.ScrollValue = 0;
			this.grid.SelectionMode = OpenDental.UI.GridSelectionMode.MultiExtended;
			this.grid.Size = new System.Drawing.Size(963, 585);
			this.grid.TabIndex = 0;
			this.grid.Title = "Confirmation List";
			this.grid.TranslationName = "TableConfirmList";
			this.grid.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.grid_CellDoubleClick);
			this.grid.CellClick += new OpenDental.UI.ODGridClickEventHandler(this.grid_CellClick);
			this.grid.Click += new System.EventHandler(this.grid_Click);
			// 
			// butPrint
			// 
			this.butPrint.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butPrint.Autosize = true;
			this.butPrint.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butPrint.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butPrint.CornerRadius = 4F;
			this.butPrint.Image = global::OpenDental.Properties.Resources.butPrintSmall;
			this.butPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butPrint.Location = new System.Drawing.Point(538, 659);
			this.butPrint.Name = "butPrint";
			this.butPrint.Size = new System.Drawing.Size(87, 24);
			this.butPrint.TabIndex = 20;
			this.butPrint.Text = "Print List";
			this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
			// 
			// butEmail
			// 
			this.butEmail.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butEmail.Autosize = true;
			this.butEmail.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butEmail.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butEmail.CornerRadius = 4F;
			this.butEmail.Image = global::OpenDental.Properties.Resources.email1;
			this.butEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butEmail.Location = new System.Drawing.Point(348, 659);
			this.butEmail.Name = "butEmail";
			this.butEmail.Size = new System.Drawing.Size(91, 24);
			this.butEmail.TabIndex = 61;
			this.butEmail.Text = "E-Mail";
			this.butEmail.Click += new System.EventHandler(this.butEmail_Click);
			// 
			// comboClinic
			// 
			this.comboClinic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboClinic.Location = new System.Drawing.Point(439, 36);
			this.comboClinic.MaxDropDownItems = 40;
			this.comboClinic.Name = "comboClinic";
			this.comboClinic.Size = new System.Drawing.Size(181, 21);
			this.comboClinic.TabIndex = 25;
			// 
			// labelClinic
			// 
			this.labelClinic.Location = new System.Drawing.Point(346, 40);
			this.labelClinic.Name = "labelClinic";
			this.labelClinic.Size = new System.Drawing.Size(91, 14);
			this.labelClinic.TabIndex = 24;
			this.labelClinic.Text = "Clinic";
			this.labelClinic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FormConfirmList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.butClose;
			this.ClientSize = new System.Drawing.Size(975, 688);
			this.Controls.Add(this.butEmail);
			this.Controls.Add(this.butPrint);
			this.Controls.Add(this.butPostcards);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.butLabels);
			this.Controls.Add(this.butReport);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.butClose);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormConfirmList";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Confirmation List";
			this.Load += new System.EventHandler(this.FormConfirmList_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormConfirmList_Load(object sender, System.EventArgs e) {
			textDateFrom.Text=AddWorkDays(1,DateTime.Today).ToShortDateString();
			textDateTo.Text=AddWorkDays(2,DateTime.Today).ToShortDateString();
			comboProv.Items.Add(Lan.g(this,"All"));
			comboProv.SelectedIndex=0;
			for(int i=0;i<ProviderC.ListShort.Count;i++) {
				comboProv.Items.Add(ProviderC.ListShort[i].GetLongDesc());
			}
			//textPostcardMessage.Text=PrefC.GetString(PrefName.ConfirmPostcardMessage");
			comboStatus.Items.Clear();
			for(int i=0;i<DefC.Short[(int)DefCat.ApptConfirmed].Length;i++){
				comboStatus.Items.Add(DefC.Short[(int)DefCat.ApptConfirmed][i].ItemName);
			}
			if(PrefC.GetBool(PrefName.EasyNoClinics)) {
				comboClinic.Visible=false;
				labelClinic.Visible=false;
			}
			else {
				comboClinic.Items.Add(Lan.g(this,"All"));
				comboClinic.SelectedIndex=0;
				for(int i=0;i<Clinics.List.Length;i++) {
					comboClinic.Items.Add(Clinics.List[i].Description);
				}
			}
			FillMain();
		}

		///<summary>Adds the specified number of work days, skipping saturday and sunday.</summary>
		private DateTime AddWorkDays(int days,DateTime date){
			DateTime retVal=date;
			for(int i=0;i<days;i++){
				retVal=retVal.AddDays(1);
				//then, this part jumps to monday if on a sat or sun
				while(retVal.DayOfWeek==DayOfWeek.Saturday || retVal.DayOfWeek==DayOfWeek.Sunday){
					retVal=retVal.AddDays(1);
				}
			}
			return retVal;
		}

		private void FillMain(){
			DateTime dateFrom=PIn.Date(textDateFrom.Text);
			DateTime dateTo=PIn.Date(textDateTo.Text);
			long provNum=0;
			if(comboProv.SelectedIndex!=0) {
				provNum=ProviderC.ListShort[comboProv.SelectedIndex-1].ProvNum;
			}
			long clinicNum=0;
			if(comboClinic.SelectedIndex > 0) {
				clinicNum=Clinics.List[comboClinic.SelectedIndex-1].ClinicNum;
			}
			table=Appointments.GetConfirmList(dateFrom,dateTo,provNum,clinicNum);
			int scrollVal=grid.ScrollValue;
			grid.BeginUpdate();
			grid.Columns.Clear();
			ODGridColumn col=new ODGridColumn(Lan.g("TableConfirmList","Date Time"),70);
			grid.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableConfirmList","Patient"),80);
			grid.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableConfirmList","Age"),30);
			grid.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableConfirmList","Contact"),150);
			grid.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableConfirmList","Addr/Ph Note"),100);
			grid.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableConfirmList","Status"),80);//confirmed
			grid.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableConfirmList","Procs"),110);
			grid.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableConfirmList","Medical"),80);
			grid.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableConfirmList","Appt Note"),204);
			grid.Columns.Add(col);
			grid.Rows.Clear();
			ODGridRow row;
			ODGridCell cell;
			for(int i=0;i<table.Rows.Count;i++){
				row=new ODGridRow();
				//aptDateTime=PIn.PDateT(table.Rows[i][4].ToString());
				row.Cells.Add(table.Rows[i]["aptDateTime"].ToString());
				//aptDateTime.ToShortDateString()+"\r\n"+aptDateTime.ToShortTimeString());
				row.Cells.Add(table.Rows[i]["patientName"].ToString());
				row.Cells.Add(table.Rows[i]["age"].ToString());
				row.Cells.Add(table.Rows[i]["contactMethod"].ToString());
				row.Cells.Add(table.Rows[i]["AddrNote"].ToString());
				row.Cells.Add(table.Rows[i]["confirmed"].ToString());
				row.Cells.Add(table.Rows[i]["ProcDescript"].ToString());
				cell=new ODGridCell(table.Rows[i]["medNotes"].ToString());
				cell.ColorText=Color.Red;
				row.Cells.Add(cell);
				row.Cells.Add(table.Rows[i]["Note"].ToString());
				grid.Rows.Add(row);
			}
			grid.EndUpdate();
			grid.ScrollValue=scrollVal;
		}

		private void grid_CellClick(object sender, OpenDental.UI.ODGridClickEventArgs e) {
			//row selected before this event triggered
			SelectedPatNum=PIn.Long(table.Rows[e.Row]["PatNum"].ToString());
			SetFamilyColors();
			comboStatus.SelectedIndex=-1;
		}

		private void SetFamilyColors(){
			if(grid.SelectedIndices.Length!=1){
				for(int i=0;i<grid.Rows.Count;i++){
					grid.Rows[i].ColorText=Color.Black;
				}
				grid.Invalidate();
				return;
			}
			long guar=PIn.Long(table.Rows[grid.SelectedIndices[0]]["Guarantor"].ToString());
			int famCount=0;
			for(int i=0;i<grid.Rows.Count;i++){
				if(PIn.Long(table.Rows[i]["Guarantor"].ToString())==guar){
					famCount++;
					grid.Rows[i].ColorText=Color.Red;
				}
				else{
					grid.Rows[i].ColorText=Color.Black;
				}
			}
			if(famCount==1){//only the highlighted patient is red at this point
				grid.Rows[grid.SelectedIndices[0]].ColorText=Color.Black;
			}
			grid.Invalidate();
		}

		private void grid_Click(object sender,EventArgs e) {
			
		}

		private void grid_CellDoubleClick(object sender, OpenDental.UI.ODGridClickEventArgs e) {
			SelectedPatNum=PIn.Long(table.Rows[e.Row]["PatNum"].ToString());
			Cursor=Cursors.WaitCursor;
			long selectedApt=PIn.Long(table.Rows[e.Row]["AptNum"].ToString());
			//Appointment apt=Appointments.GetOneApt(selectedApt);
			FormApptEdit FormA=new FormApptEdit(selectedApt);
			FormA.PinIsVisible=true;
			FormA.ShowDialog();
			if(FormA.PinClicked) {
				PinClicked=true;
				AptSelected=selectedApt;
				DialogResult=DialogResult.OK;
				return;
			}
			else {
				FillMain();
			}
			for(int i=0;i<table.Rows.Count;i++){
				if(PIn.Long(table.Rows[i]["AptNum"].ToString())==selectedApt){
					grid.SetSelected(i,true);
				}
			}
			SetFamilyColors();
			Cursor=Cursors.Default;
		}

		private void comboStatus_SelectionChangeCommitted(object sender, System.EventArgs e) {
			if(grid.SelectedIndices.Length==0){
				return;//because user could never initiate this action.
			}
			Appointment apt;
			Cursor=Cursors.WaitCursor;
			long[] selectedApts=new long[grid.SelectedIndices.Length];
			for(int i=0;i<grid.SelectedIndices.Length;i++){
				selectedApts[i]=PIn.Long(table.Rows[grid.SelectedIndices[i]]["AptNum"].ToString());
			}
			for(int i=0;i<grid.SelectedIndices.Length;i++){
				apt=Appointments.GetOneApt(PIn.Long(table.Rows[grid.SelectedIndices[i]]["AptNum"].ToString()));
				Appointment aptOld=apt.Clone();
				int selectedI=comboStatus.SelectedIndex;
				apt.Confirmed=DefC.Short[(int)DefCat.ApptConfirmed][selectedI].DefNum;
				try{
					Appointments.Update(apt,aptOld);
				}
				catch(ApplicationException ex){
					Cursor=Cursors.Default;
					MessageBox.Show(ex.Message);
					return;
				}
			}
			FillMain();
			//reselect all the apts
			for(int i=0;i<table.Rows.Count;i++){
				for(int j=0;j<selectedApts.Length;j++){
					if(PIn.Long(table.Rows[i]["AptNum"].ToString())==selectedApts[j]){
						grid.SetSelected(i,true);
					}
				}
			}
			SetFamilyColors();
			comboStatus.SelectedIndex=-1;
			Cursor=Cursors.Default;
		}

		private void comboStatus_SelectedIndexChanged(object sender, System.EventArgs e) {
			//?
		}

		private void butReport_Click(object sender, System.EventArgs e) {
		  if(table.Rows.Count==0){
        MessageBox.Show(Lan.g(this,"There are no appointments in the list.  Must have at least one to run report."));    
        return;
      }
			long[] aptNums;
      if(grid.SelectedIndices.Length==0){
				aptNums=new long[table.Rows.Count];
        for(int i=0;i<aptNums.Length;i++){
          aptNums[i]=PIn.Long(table.Rows[i]["AptNum"].ToString());
        }
      }
      else{
				aptNums=new long[grid.SelectedIndices.Length];
        for(int i=0;i<aptNums.Length;i++){
          aptNums[i]=PIn.Long(table.Rows[grid.SelectedIndices[i]]["AptNum"].ToString());
        }
      }
      FormRpConfirm FormC=new FormRpConfirm(aptNums);
      FormC.ShowDialog(); 
		}

		private void butLabels_Click(object sender, System.EventArgs e) {
			if(table.Rows.Count==0){
        MessageBox.Show(Lan.g(this,"There are no appointments in the list.  Must have at least one to print."));    
        return;
      }
			if(grid.SelectedIndices.Length==0){
				for(int i=0;i<table.Rows.Count;i++){
					grid.SetSelected(i,true);
				}
			}
			List<long> aptNums=new List<long>();
			for(int i=0;i<grid.SelectedIndices.Length;i++) {
        aptNums.Add(PIn.Long(table.Rows[grid.SelectedIndices[i]]["AptNum"].ToString()));
      }
			AddrTable=Appointments.GetAddrTable(aptNums);
			pagesPrinted=0;
			patientsPrinted=0;
			pd=new PrintDocument();
			pd.PrintPage+=new PrintPageEventHandler(this.pdLabels_PrintPage);
			pd.OriginAtMargins=true;
			pd.DefaultPageSettings.Margins=new Margins(0,0,0,0);
			printPreview=new OpenDental.UI.PrintPreview(PrintSituation.LabelSheet
				,pd,(int)Math.Ceiling((double)AddrTable.Rows.Count/30));
			printPreview.ShowDialog();
		}

		///<summary>Changes made to printing confirmation postcards need to be made in FormRecallList.butPostcards_Click() as well.</summary>
		private void butPostcards_Click(object sender,System.EventArgs e) {
			if(table.Rows.Count==0) {
				MessageBox.Show(Lan.g(this,"There are no appointments in the list.  Must have at least one to print."));
				return;
			}
			if(grid.SelectedIndices.Length==0) {
				for(int i=0;i<table.Rows.Count;i++) {
					grid.SetSelected(i,true);
				}
			}
			List<long> aptNums=new List<long>();
			for(int i=0;i<grid.SelectedIndices.Length;i++) {
				aptNums.Add(PIn.Long(table.Rows[grid.SelectedIndices[i]]["AptNum"].ToString()));
			}
			AddrTable=Appointments.GetAddrTable(aptNums);
			pagesPrinted=0;
			patientsPrinted=0;
			pd=new PrintDocument();
			pd.PrintPage+=new PrintPageEventHandler(this.pdCards_PrintPage);
			pd.OriginAtMargins=true;
			pd.DefaultPageSettings.Margins=new Margins(0,0,0,0);
			if(PrefC.GetLong(PrefName.RecallPostcardsPerSheet)==1) {
				pd.DefaultPageSettings.PaperSize=new PaperSize("Postcard",500,700);
				pd.DefaultPageSettings.Landscape=true;
			}
			else if(PrefC.GetLong(PrefName.RecallPostcardsPerSheet)==3) {
				pd.DefaultPageSettings.PaperSize=new PaperSize("Postcard",850,1100);
			}
			else {//4
				pd.DefaultPageSettings.PaperSize=new PaperSize("Postcard",850,1100);
				pd.DefaultPageSettings.Landscape=true;
			}
			printPreview=new OpenDental.UI.PrintPreview(PrintSituation.Postcard,pd,
				(int)Math.Ceiling((double)AddrTable.Rows.Count/(double)PrefC.GetLong(PrefName.RecallPostcardsPerSheet)));
			printPreview.ShowDialog();
		}

		///<summary>raised for each page to be printed.</summary>
		private void pdLabels_PrintPage(object sender, PrintPageEventArgs ev){
			int totalPages=(int)Math.Ceiling((double)AddrTable.Rows.Count/30);
			Graphics g=ev.Graphics;
			float yPos=75;
			float xPos=50;
			string text="";
			while(yPos<1000 && patientsPrinted<AddrTable.Rows.Count){
				text=AddrTable.Rows[patientsPrinted]["FName"].ToString()+" "
					+AddrTable.Rows[patientsPrinted]["MiddleI"].ToString()+" "
					+AddrTable.Rows[patientsPrinted]["LName"].ToString()+"\r\n"
					+AddrTable.Rows[patientsPrinted]["Address"].ToString()+"\r\n";
				if(AddrTable.Rows[patientsPrinted]["Address2"].ToString()!=""){
					text+=AddrTable.Rows[patientsPrinted]["Address2"].ToString()+"\r\n";
				}
				text+=AddrTable.Rows[patientsPrinted]["City"].ToString()+", "
					+AddrTable.Rows[patientsPrinted]["State"].ToString()+"   "
					+AddrTable.Rows[patientsPrinted]["Zip"].ToString()+"\r\n";
				g.DrawString(text,new Font(FontFamily.GenericSansSerif,11),Brushes.Black,xPos,yPos);
				//reposition for next label
				xPos+=275;
				if(xPos>850){//drop a line
					xPos=50;
					yPos+=100;
				}
				patientsPrinted++;
			}
			pagesPrinted++;
			if(pagesPrinted>=totalPages){
				ev.HasMorePages=false;
				pagesPrinted=0;//because it has to print again from the print preview
				patientsPrinted=0;
			}
			else{
				ev.HasMorePages=true;
			}
		}

		///<summary>raised for each page to be printed.</summary>
		private void pdCards_PrintPage(object sender, PrintPageEventArgs ev){
			int totalPages=(int)Math.Ceiling((double)AddrTable.Rows.Count/(double)PrefC.GetLong(PrefName.RecallPostcardsPerSheet));
			Graphics g=ev.Graphics;
			int yAdj=(int)(PrefC.GetDouble(PrefName.RecallAdjustDown)*100);
			int xAdj=(int)(PrefC.GetDouble(PrefName.RecallAdjustRight)*100);
			float yPos=0+yAdj;//these refer to the upper left origin of each postcard
			float xPos=0+xAdj;
			string str;
			while(yPos<ev.PageBounds.Height-100 && patientsPrinted<AddrTable.Rows.Count){
				//Return Address--------------------------------------------------------------------------
				if(PrefC.GetBool(PrefName.RecallCardsShowReturnAdd)){
					if(PrefC.GetBool(PrefName.EasyNoClinics) || PIn.Long(AddrTable.Rows[patientsPrinted]["ClinicNum"].ToString())==0) {//No clinics or no clinic selected for this appt
						str=PrefC.GetString(PrefName.PracticeTitle)+"\r\n";
						g.DrawString(str,new Font(FontFamily.GenericSansSerif,9,FontStyle.Bold),Brushes.Black,xPos+45,yPos+60);
						str=PrefC.GetString(PrefName.PracticeAddress)+"\r\n";
						if(PrefC.GetString(PrefName.PracticeAddress2)!="") {
							str+=PrefC.GetString(PrefName.PracticeAddress2)+"\r\n";
						}
						str+=PrefC.GetString(PrefName.PracticeCity)+",  "+PrefC.GetString(PrefName.PracticeST)+"  "+PrefC.GetString(PrefName.PracticeZip)+"\r\n";
						string phone=PrefC.GetString(PrefName.PracticePhone);
						if(CultureInfo.CurrentCulture.Name=="en-US"&& phone.Length==10) {
							str+="("+phone.Substring(0,3)+")"+phone.Substring(3,3)+"-"+phone.Substring(6);
						}
						else {//any other phone format
							str+=phone;
						}
					}
					else {//Clinics enabled and clinic selected
						Clinic clinic=Clinics.GetClinic(PIn.Long(AddrTable.Rows[patientsPrinted]["ClinicNum"].ToString()));
						str=clinic.Description+"\r\n";
						g.DrawString(str,new Font(FontFamily.GenericSansSerif,9,FontStyle.Bold),Brushes.Black,xPos+45,yPos+60);
						str=clinic.Address+"\r\n";
						if(clinic.Address2!="") {
							str+=clinic.Address2+"\r\n";
						}
						str+=clinic.City+",  "+clinic.State+"  "+clinic.Zip+"\r\n";
						string phone=clinic.Phone;
						if(CultureInfo.CurrentCulture.Name=="en-US"&& phone.Length==10) {
							str+="("+phone.Substring(0,3)+")"+phone.Substring(3,3)+"-"+phone.Substring(6);
						}
						else {//any other phone format
							str+=phone;
						}
					}
					g.DrawString(str,new Font(FontFamily.GenericSansSerif,8),Brushes.Black,xPos+45,yPos+75);
				}
				//Body text-------------------------------------------------------------------------------
				str=PrefC.GetString(PrefName.ConfirmPostcardMessage);
					//textPostcardMessage.Text;
				str=str.Replace("[date]",PIn.Date(AddrTable.Rows[patientsPrinted]["AptDateTime"].ToString()).ToShortDateString());
				str=str.Replace("[time]",PIn.Date(AddrTable.Rows[patientsPrinted]["AptDateTime"].ToString()).ToShortTimeString());
				g.DrawString(str,new Font(FontFamily.GenericSansSerif,10),Brushes.Black,new RectangleF(xPos+45,yPos+180,250,190));
				//Patient's Address-----------------------------------------------------------------------
				str=AddrTable.Rows[patientsPrinted]["FName"].ToString()+" "
						+AddrTable.Rows[patientsPrinted]["MiddleI"].ToString()+" "
						+AddrTable.Rows[patientsPrinted]["LName"].ToString()+"\r\n"
						+AddrTable.Rows[patientsPrinted]["Address"].ToString()+"\r\n";
					if(AddrTable.Rows[patientsPrinted]["Address2"].ToString()!=""){
						str+=AddrTable.Rows[patientsPrinted]["Address2"].ToString()+"\r\n";
					}
					str+=AddrTable.Rows[patientsPrinted]["City"].ToString()+", "
						+AddrTable.Rows[patientsPrinted]["State"].ToString()+"   "
						+AddrTable.Rows[patientsPrinted]["Zip"].ToString()+"\r\n";
				g.DrawString(str,new Font(FontFamily.GenericSansSerif,11),Brushes.Black,xPos+320,yPos+240);
				if(PrefC.GetLong(PrefName.RecallPostcardsPerSheet)==1){
					yPos+=400;
				}
				else if(PrefC.GetLong(PrefName.RecallPostcardsPerSheet)==3){
					yPos+=366;
				}
				else{//4
					xPos+=550;
					if(xPos>1000){
						xPos=0+xAdj;
						yPos+=425;
					}
				}
				patientsPrinted++;
			}//while
			pagesPrinted++;
			if(pagesPrinted==totalPages){
				ev.HasMorePages=false;
				pagesPrinted=0;
				patientsPrinted=0;
			}
			else{
				ev.HasMorePages=true;
			}
		}

		private void butRefresh_Click(object sender, System.EventArgs e) {
			FillMain();
		}

		private void butSetStatus_Click(object sender, System.EventArgs e) {
			/*if(comboStatus.SelectedIndex==-1){
				return;
			}
			int[] originalRecalls=new int[tbMain.SelectedIndices.Length];
			for(int i=0;i<tbMain.SelectedIndices.Length;i++){
				originalRecalls[i]=((RecallItem)MainAL[tbMain.SelectedIndices[i]]).RecallNum;
				Recalls.UpdateStatus(
					((RecallItem)MainAL[tbMain.SelectedIndices[i]]).RecallNum,
					DefC.Short[(int)DefCat.RecallUnschedStatus][comboStatus.SelectedIndex].DefNum);
				//((RecallItem)MainAL[tbMain.SelectedIndices[i]]).up
			}
			FillMain();
			for(int i=0;i<tbMain.MaxRows;i++){
				for(int j=0;j<originalRecalls.Length;j++){
					if(originalRecalls[j]==((RecallItem)MainAL[i]).RecallNum){
						tbMain.SetSelected(i,true);
					}
				}
			}*/
		}

		private void butEmail_Click(object sender,EventArgs e) {
			if(grid.Rows.Count==0) {
				MsgBox.Show(this,"There are no Patients in the table.  Must have at least one.");
				return;
			}
			if(PrefC.GetString(PrefName.EmailSMTPserver)=="") {
				MsgBox.Show(this,"You need to enter an SMTP server name in e-mail setup before you can send e-mail.");
				return;
			}
			if(PrefC.GetLong(PrefName.ConfirmStatusEmailed)==0) {
				MsgBox.Show(this,"You need to set a status first for confirmation e-mails in the Recall Setup window.");
				return;
			}
			if(grid.SelectedIndices.Length==0) {
				ContactMethod cmeth;
				for(int i=0;i<table.Rows.Count;i++) {
					cmeth=(ContactMethod)PIn.Int(table.Rows[i]["PreferConfirmMethod"].ToString());
					if(cmeth!=ContactMethod.Email) {
						continue;
					}
					grid.SetSelected(i,true);
				}
				if(grid.SelectedIndices.Length==0) {
					MsgBox.Show(this,"No patients of email type.");
					return;
				}
			}
			else {//deselect the ones that do not have email addresses specified
				int skipped=0;
				for(int i=grid.SelectedIndices.Length-1;i>=0;i--) {
					if(table.Rows[grid.SelectedIndices[i]]["email"].ToString()=="") {
						skipped++;
						grid.SetSelected(grid.SelectedIndices[i],false);
					}
				}
				if(grid.SelectedIndices.Length==0) {
					MsgBox.Show(this,"None of the selected patients had email addresses entered.");
					return;
				}
				if(skipped>0) {
					MessageBox.Show(Lan.g(this,"Selected patients skipped due to missing email addresses: ")+skipped.ToString());
				}
			}
			if(!MsgBox.Show(this,MsgBoxButtons.YesNo,"Send email to all of the selected patients?")) {
				return;
			}
			Cursor=Cursors.WaitCursor;
			EmailMessage message;
			string str="";
			//Appointment apt;
			for(int i=0;i<grid.SelectedIndices.Length;i++){
				message=new EmailMessage();
				message.PatNum=PIn.Long(table.Rows[grid.SelectedIndices[i]]["PatNum"].ToString());
				message.ToAddress=table.Rows[grid.SelectedIndices[i]]["email"].ToString();//Could be guarantor email.
				message.FromAddress=PrefC.GetString(PrefName.EmailSenderAddress);
				message.Subject=PrefC.GetString(PrefName.ConfirmEmailSubject);
				str=PrefC.GetString(PrefName.ConfirmEmailMessage);
				str=str.Replace("[NameF]",table.Rows[grid.SelectedIndices[i]]["nameF"].ToString());
				str=str.Replace("[NameFL]",table.Rows[grid.SelectedIndices[i]]["nameFL"].ToString());
				str=str.Replace("[date]",((DateTime)table.Rows[grid.SelectedIndices[i]]["AptDateTime"]).ToShortDateString());
				str=str.Replace("[time]",((DateTime)table.Rows[grid.SelectedIndices[i]]["AptDateTime"]).ToShortTimeString());
				message.BodyText=str;
				try {
					FormEmailMessageEdit.SendEmail(message);
				}
				catch(Exception ex) {
					Cursor=Cursors.Default;
					MessageBox.Show(ex.Message+"\r\nPatient:"+table.Rows[grid.SelectedIndices[i]]["nameFL"].ToString());
					break;
				}
				message.MsgDateTime=DateTime.Now;
				message.SentOrReceived=CommSentOrReceived.Sent;
				EmailMessages.Insert(message);
				Appointments.SetConfirmed(PIn.Long(table.Rows[grid.SelectedIndices[i]]["AptNum"].ToString()),PrefC.GetLong(PrefName.ConfirmStatusEmailed));
			}
			FillMain();
			Cursor=Cursors.Default;
		}

		private void butSave_Click(object sender, System.EventArgs e) {
			/*if(  textDaysPast.errorProvider1.GetError(textDaysPast)!=""
				|| textDaysFuture.errorProvider1.GetError(textDaysFuture)!="")
			{
				MessageBox.Show(Lan.g(this,"Please fix data entry errors first."));
				return;
			}
			Prefs.Cur.PrefName="RecallDaysPast";
			Prefs.Cur.ValueString=textDaysPast.Text;
			Prefs.UpdateCur();
			Prefs.Cur.PrefName="RecallDaysFuture";
			Prefs.Cur.ValueString=textDaysFuture.Text;
			Prefs.UpdateCur();
			DataValid.SetInvalid(InvalidTypes.Prefs);*/
		}

		private void butPrint_Click(object sender,EventArgs e) {
			pagesPrinted=0;
			pd=new PrintDocument();
			pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
			pd.DefaultPageSettings.Margins=new Margins(25,25,40,40);
			pd.DefaultPageSettings.Landscape=true;
			//pd.OriginAtMargins=true;
			if(pd.DefaultPageSettings.PrintableArea.Height==0) {
				pd.DefaultPageSettings.PaperSize=new PaperSize("default",850,1100);
			}
			headingPrinted=false;
			try {
				#if DEBUG
				FormRpPrintPreview pView = new FormRpPrintPreview();
				pView.printPreviewControl2.Document=pd;
				pView.ShowDialog();
				#else
					if(PrinterL.SetPrinter(pd,PrintSituation.Default)) {
						pd.Print();
					}
				#endif
			}
			catch {
				MessageBox.Show(Lan.g(this,"Printer not available"));
			}
		}

		private void pd_PrintPage(object sender,System.Drawing.Printing.PrintPageEventArgs e) {
			Rectangle bounds=e.MarginBounds;
			//new Rectangle(50,40,800,1035);//Some printers can handle up to 1042
			Graphics g=e.Graphics;
			string text;
			Font headingFont=new Font("Arial",13,FontStyle.Bold);
			Font subHeadingFont=new Font("Arial",10,FontStyle.Bold);
			int yPos=bounds.Top;
			int center=bounds.X+bounds.Width/2;
			#region printHeading
			if(!headingPrinted) {
				text=Lan.g(this,"Confirmation List");
				g.DrawString(text,headingFont,Brushes.Black,center-g.MeasureString(text,headingFont).Width/2,yPos);
				yPos+=(int)g.MeasureString(text,headingFont).Height;
				text=textDateFrom.Text+" "+Lan.g(this,"to")+" "+textDateTo.Text;
				g.DrawString(text,subHeadingFont,Brushes.Black,center-g.MeasureString(text,subHeadingFont).Width/2,yPos);
				yPos+=20;
				headingPrinted=true;
				headingPrintH=yPos;
			}
			#endregion
			yPos=grid.PrintPage(g,pagesPrinted,bounds,headingPrintH);
			pagesPrinted++;
			if(yPos==-1) {
				e.HasMorePages=true;
			}
			else {
				e.HasMorePages=false;
			}
			g.Dispose();
		}

		private void butClose_Click(object sender, System.EventArgs e) {
			Close();
		}

		

	

		

	

		

		

		

		

		
	}

}
