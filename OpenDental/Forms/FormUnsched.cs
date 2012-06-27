using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using OpenDentBusiness;
using OpenDental.UI;

namespace OpenDental{
///<summary></summary>
	public class FormUnsched:System.Windows.Forms.Form {
		private IContainer components;
		private OpenDental.UI.Button butClose;
		///<summary></summary>
		public bool PinClicked=false;		
		///<summary></summary>
		public static string procsForCur;
		private OpenDental.UI.ODGrid grid;
		private OpenDental.UI.Button butPrint;
		private Appointment[] ListUn;
		private PrintDocument pd;
		private bool headingPrinted;
		private int headingPrintH;
		private int pagesPrinted;
		///<summary>Only used if PinClicked=true</summary>
		public long AptSelected;
		private ComboBox comboOrder;
		private Label label1;
		private ComboBox comboProv;
		private Label label4;
		private OpenDental.UI.Button butRefresh;
		private ComboBox comboSite;
		private Label labelSite;
		///<summary>When this form closes, this will be the patNum of the last patient viewed.  The calling form should then make use of this to refresh to that patient.  If 0, then calling form should not refresh.</summary>
		public long SelectedPatNum;
		private CheckBox checkBrokenAppts;
		private ContextMenuStrip menuDelete;
		private ComboBox comboClinic;
		private Label labelClinic;
		private Dictionary<long,string> patientNames;

		///<summary></summary>
		public FormUnsched(){
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
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUnsched));
			this.butClose = new OpenDental.UI.Button();
			this.grid = new OpenDental.UI.ODGrid();
			this.butPrint = new OpenDental.UI.Button();
			this.comboOrder = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboProv = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.butRefresh = new OpenDental.UI.Button();
			this.comboSite = new System.Windows.Forms.ComboBox();
			this.labelSite = new System.Windows.Forms.Label();
			this.checkBrokenAppts = new System.Windows.Forms.CheckBox();
			this.menuDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.comboClinic = new System.Windows.Forms.ComboBox();
			this.labelClinic = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// butClose
			// 
			this.butClose.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butClose.Autosize = true;
			this.butClose.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butClose.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butClose.CornerRadius = 4F;
			this.butClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.butClose.Location = new System.Drawing.Point(761, 631);
			this.butClose.Name = "butClose";
			this.butClose.Size = new System.Drawing.Size(87, 24);
			this.butClose.TabIndex = 7;
			this.butClose.Text = "&Close";
			this.butClose.Click += new System.EventHandler(this.butClose_Click);
			// 
			// grid
			// 
			this.grid.HScrollVisible = false;
			this.grid.Location = new System.Drawing.Point(10, 56);
			this.grid.Name = "grid";
			this.grid.ScrollValue = 0;
			this.grid.SelectionMode = OpenDental.UI.GridSelectionMode.MultiExtended;
			this.grid.Size = new System.Drawing.Size(734, 599);
			this.grid.TabIndex = 8;
			this.grid.Title = "Unscheduled List";
			this.grid.TranslationName = "TableUnsched";
			this.grid.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.grid_CellDoubleClick);
			this.grid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grid_MouseDown);
			this.grid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grid_MouseUp);
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
			this.butPrint.Location = new System.Drawing.Point(761, 583);
			this.butPrint.Name = "butPrint";
			this.butPrint.Size = new System.Drawing.Size(87, 24);
			this.butPrint.TabIndex = 21;
			this.butPrint.Text = "Print List";
			this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
			// 
			// comboOrder
			// 
			this.comboOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboOrder.Location = new System.Drawing.Point(97, 6);
			this.comboOrder.MaxDropDownItems = 40;
			this.comboOrder.Name = "comboOrder";
			this.comboOrder.Size = new System.Drawing.Size(133, 21);
			this.comboOrder.TabIndex = 35;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(23, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 14);
			this.label1.TabIndex = 34;
			this.label1.Text = "Order by";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboProv
			// 
			this.comboProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboProv.Location = new System.Drawing.Point(319, 6);
			this.comboProv.MaxDropDownItems = 40;
			this.comboProv.Name = "comboProv";
			this.comboProv.Size = new System.Drawing.Size(181, 21);
			this.comboProv.TabIndex = 33;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(248, 10);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 14);
			this.label4.TabIndex = 32;
			this.label4.Text = "Provider";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butRefresh
			// 
			this.butRefresh.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butRefresh.Autosize = true;
			this.butRefresh.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butRefresh.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butRefresh.CornerRadius = 4F;
			this.butRefresh.Location = new System.Drawing.Point(762, 6);
			this.butRefresh.Name = "butRefresh";
			this.butRefresh.Size = new System.Drawing.Size(86, 24);
			this.butRefresh.TabIndex = 31;
			this.butRefresh.Text = "&Refresh";
			this.butRefresh.Click += new System.EventHandler(this.butRefresh_Click);
			// 
			// comboSite
			// 
			this.comboSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboSite.Location = new System.Drawing.Point(584, 31);
			this.comboSite.MaxDropDownItems = 40;
			this.comboSite.Name = "comboSite";
			this.comboSite.Size = new System.Drawing.Size(160, 21);
			this.comboSite.TabIndex = 37;
			// 
			// labelSite
			// 
			this.labelSite.Location = new System.Drawing.Point(506, 35);
			this.labelSite.Name = "labelSite";
			this.labelSite.Size = new System.Drawing.Size(77, 14);
			this.labelSite.TabIndex = 36;
			this.labelSite.Text = "Site";
			this.labelSite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkBrokenAppts
			// 
			this.checkBrokenAppts.AutoSize = true;
			this.checkBrokenAppts.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBrokenAppts.Location = new System.Drawing.Point(65, 33);
			this.checkBrokenAppts.Name = "checkBrokenAppts";
			this.checkBrokenAppts.Size = new System.Drawing.Size(165, 17);
			this.checkBrokenAppts.TabIndex = 38;
			this.checkBrokenAppts.Text = "Include Broken Appointments";
			this.checkBrokenAppts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBrokenAppts.UseVisualStyleBackColor = true;
			// 
			// menuDelete
			// 
			this.menuDelete.Name = "menuDelete";
			this.menuDelete.Size = new System.Drawing.Size(61, 4);
			// 
			// comboClinic
			// 
			this.comboClinic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboClinic.Location = new System.Drawing.Point(584, 6);
			this.comboClinic.MaxDropDownItems = 40;
			this.comboClinic.Name = "comboClinic";
			this.comboClinic.Size = new System.Drawing.Size(160, 21);
			this.comboClinic.TabIndex = 40;
			// 
			// labelClinic
			// 
			this.labelClinic.Location = new System.Drawing.Point(506, 10);
			this.labelClinic.Name = "labelClinic";
			this.labelClinic.Size = new System.Drawing.Size(77, 14);
			this.labelClinic.TabIndex = 39;
			this.labelClinic.Text = "Clinic";
			this.labelClinic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FormUnsched
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.butClose;
			this.ClientSize = new System.Drawing.Size(858, 672);
			this.Controls.Add(this.comboClinic);
			this.Controls.Add(this.labelClinic);
			this.Controls.Add(this.checkBrokenAppts);
			this.Controls.Add(this.comboOrder);
			this.Controls.Add(this.comboSite);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelSite);
			this.Controls.Add(this.comboProv);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.butRefresh);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.butPrint);
			this.Controls.Add(this.butClose);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormUnsched";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Unscheduled List";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormUnsched_Closing);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUnsched_FormClosing);
			this.Load += new System.EventHandler(this.FormUnsched_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void FormUnsched_Load(object sender, System.EventArgs e) {
			patientNames=Patients.GetAllPatientNames();
			comboOrder.Items.Add(Lan.g(this,"Status"));
			comboOrder.Items.Add(Lan.g(this,"Alphabetical"));
			comboOrder.Items.Add(Lan.g(this,"Date"));
			comboOrder.SelectedIndex=0;
			comboProv.Items.Add(Lan.g(this,"All"));
			comboProv.SelectedIndex=0;
			for(int i=0;i<ProviderC.ListShort.Count;i++) {
				comboProv.Items.Add(ProviderC.ListShort[i].GetLongDesc());
			}
			if(PrefC.GetBool(PrefName.EasyHidePublicHealth)){
				comboSite.Visible=false;
				labelSite.Visible=false;
			}
			else{
				comboSite.Items.Add(Lan.g(this,"All"));
				comboSite.SelectedIndex=0;
				for(int i=0;i<SiteC.List.Length;i++) {
					comboSite.Items.Add(SiteC.List[i].Description);
				}
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
			FillGrid();
			menuDelete.Items.Clear();
			menuDelete.Items.Add(Lan.g(this,"Delete"),null,new EventHandler(menuDelete_click));
		}

		private void menuDelete_click(object sender,System.EventArgs e) {
			switch(menuDelete.Items.IndexOf((ToolStripMenuItem)sender)) {
				case 0:
					Delete_Click();
					break;
			}
		}

		private void grid_MouseDown(object sender,MouseEventArgs e) {
			
		}

		private void grid_MouseUp(object sender,MouseEventArgs e) {
			if(e.Button==MouseButtons.Right) {
				if(grid.SelectedIndices.Length>0) {
					menuDelete.Show(grid,new Point(e.X,e.Y));
				}
			}
		}

		private void Delete_Click() {
			if(!MsgBox.Show(this,MsgBoxButtons.OKCancel,"Delete appointments?")) {
				return;
			}
			for(int i=0;i<grid.SelectedIndices.Length;i++) {
				Appointments.Delete(ListUn[grid.SelectedIndices[i]].AptNum);
			}
			FillGrid();
		}

		private void FillGrid() {
			this.Cursor=Cursors.WaitCursor;
			string order="";
			switch(comboOrder.SelectedIndex) {
				case 0:
					order="status";
					break;
				case 1:
					order="alph";
					break;
				case 2:
					order="date";
					break;
			}
			long provNum=0;
			if(comboProv.SelectedIndex!=0) {
				provNum=ProviderC.ListShort[comboProv.SelectedIndex-1].ProvNum;
			}
			long siteNum=0;
			if(!PrefC.GetBool(PrefName.EasyHidePublicHealth) && comboSite.SelectedIndex!=0) {
				siteNum=SiteC.List[comboSite.SelectedIndex-1].SiteNum;
			}
			long clinicNum=0;
			if(comboClinic.SelectedIndex > 0) {
				clinicNum=Clinics.List[comboClinic.SelectedIndex-1].ClinicNum;
			}
			bool showBrokenAppts;
			showBrokenAppts=checkBrokenAppts.Checked;
			ListUn=Appointments.RefreshUnsched(order,provNum,siteNum,showBrokenAppts,clinicNum);
			int scrollVal=grid.ScrollValue;
			grid.BeginUpdate();
			grid.Columns.Clear();
			ODGridColumn col=new ODGridColumn(Lan.g("TableUnsched","Patient"),140);
			grid.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableUnsched","Date"),65);
			grid.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableUnsched","Status"),110);
			grid.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableUnsched","Prov"),50);
			grid.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableUnsched","Procedures"),150);
			grid.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableUnsched","Notes"),200);
			grid.Columns.Add(col);
			grid.Rows.Clear();
			ODGridRow row;
			for(int i=0;i<ListUn.Length;i++) {
				row=new ODGridRow();
				row.Cells.Add(patientNames[ListUn[i].PatNum]);
				if(ListUn[i].AptDateTime.Year < 1880)
					row.Cells.Add("");
				else
					row.Cells.Add(ListUn[i].AptDateTime.ToShortDateString());
				row.Cells.Add(DefC.GetName(DefCat.RecallUnschedStatus,ListUn[i].UnschedStatus));
				row.Cells.Add(Providers.GetAbbr(ListUn[i].ProvNum));
				row.Cells.Add(ListUn[i].ProcDescript);
				row.Cells.Add(ListUn[i].Note);
				grid.Rows.Add(row);
			}
			grid.EndUpdate();
			grid.ScrollValue=scrollVal;
			Cursor=Cursors.Default;
		}

		private void grid_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			int currentSelection=e.Row;//tbApts.SelectedRow;
			int currentScroll=grid.ScrollValue;//tbApts.ScrollValue;
			SelectedPatNum=ListUn[e.Row].PatNum;
			FormApptEdit FormAE=new FormApptEdit(ListUn[e.Row].AptNum);
			FormAE.PinIsVisible=true;
			FormAE.ShowDialog();
			if(FormAE.DialogResult!=DialogResult.OK)
				return;
			if(FormAE.PinClicked) {
				PinClicked=true;
				AptSelected=ListUn[e.Row].AptNum;
				DialogResult=DialogResult.OK;
			}
			else {
				FillGrid();
				grid.SetSelected(currentSelection,true);
				grid.ScrollValue=currentScroll;
			}
		}

		private void butRefresh_Click(object sender,EventArgs e) {
			FillGrid();
		}

		private void butPrint_Click(object sender,EventArgs e) {
			pagesPrinted=0;
			pd=new PrintDocument();
			pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
			pd.DefaultPageSettings.Margins=new Margins(25,25,40,40);
			//pd.OriginAtMargins=true;
			if(pd.DefaultPageSettings.PrintableArea.Height==0) {
				pd.DefaultPageSettings.PaperSize=new PaperSize("default",850,1100);
			}
			headingPrinted=false;
			#if DEBUG
				FormRpPrintPreview pView = new FormRpPrintPreview();
				pView.printPreviewControl2.Document=pd;
				pView.ShowDialog();
			#else
				if(!PrinterL.SetPrinter(pd,PrintSituation.Default)) {
					return;
				}
				try{
					pd.Print();
				}
				catch {
					MsgBox.Show(this,"Printer not available");
				}
			#endif			
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
				text=Lan.g(this,"Unscheduled List");
				g.DrawString(text,headingFont,Brushes.Black,center-g.MeasureString(text,headingFont).Width/2,yPos);
				//yPos+=(int)g.MeasureString(text,headingFont).Height;
				//text=textDateFrom.Text+" "+Lan.g(this,"to")+" "+textDateTo.Text;
				//g.DrawString(text,subHeadingFont,Brushes.Black,center-g.MeasureString(text,subHeadingFont).Width/2,yPos);
				yPos+=25;
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

		private void FormUnsched_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			//Patients.HList=null;
		}

		private void FormUnsched_FormClosing(object sender,FormClosingEventArgs e) {
			if(grid.SelectedIndices.Length==1) {
				SelectedPatNum=ListUn[grid.SelectedIndices[0]].PatNum;
			}
		}

		

		

		

		

		

	}
}
