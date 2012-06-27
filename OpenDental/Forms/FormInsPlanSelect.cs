using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using OpenDental.UI;
using OpenDentBusiness;

namespace OpenDental{
///<summary>Lists all insurance plans for which the supplied patient is the subscriber. Lets you select an insurance plan based on a patNum. SelectedPlan will contain the plan selected.</summary>
	public class FormInsPlanSelect : System.Windows.Forms.Form{
		private OpenDental.UI.Button butCancel;
		private OpenDental.UI.Button butOK;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ListBox listRelat;
		//private OpenDental.TableInsPlans tbPlans;
		///<summary></summary>
		public Relat PatRelat;
		private System.Windows.Forms.Label labelRelat;
		///<summary>Set to true to view the relationship selection</summary>
		public bool ViewRelat;
		private Patient PatCur;
		private Family FamCur;
		///<summary>After closing this form, this will contain the selected plan.  May be null to indicate none.</summary>
		public InsPlan SelectedPlan;
		private List <InsPlan> PlanList;
		private OpenDental.UI.ODGrid gridMain;
		private OpenDental.UI.Button butNone;
		private long PatNum;
		public bool ShowNoneButton;
		private List<InsSub> SubList;
		public InsSub SelectedSub;

		///<summary></summary>
		public FormInsPlanSelect(long patNum) {
			InitializeComponent();
			PatNum=patNum;
			//tbPlans.CellDoubleClicked += new OpenDental.ContrTable.CellEventHandler(tbPlans_CellDoubleClicked);
			Lan.F(this);
		}

		///<summary></summary>
		protected override void Dispose(bool disposing){
			if(disposing){
				if(components!=null){
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		private void InitializeComponent(){
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInsPlanSelect));
			this.butCancel = new OpenDental.UI.Button();
			this.butOK = new OpenDental.UI.Button();
			this.labelRelat = new System.Windows.Forms.Label();
			this.listRelat = new System.Windows.Forms.ListBox();
			this.gridMain = new OpenDental.UI.ODGrid();
			this.butNone = new OpenDental.UI.Button();
			this.SuspendLayout();
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
			this.butCancel.Location = new System.Drawing.Point(686,330);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new System.Drawing.Size(76,24);
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
			this.butOK.Location = new System.Drawing.Point(686,294);
			this.butOK.Name = "butOK";
			this.butOK.Size = new System.Drawing.Size(76,24);
			this.butOK.TabIndex = 5;
			this.butOK.Text = "&OK";
			this.butOK.Click += new System.EventHandler(this.butOK_Click);
			// 
			// labelRelat
			// 
			this.labelRelat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelRelat.Location = new System.Drawing.Point(580,16);
			this.labelRelat.Name = "labelRelat";
			this.labelRelat.Size = new System.Drawing.Size(206,20);
			this.labelRelat.TabIndex = 8;
			this.labelRelat.Text = "Relationship to Subscriber";
			// 
			// listRelat
			// 
			this.listRelat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.listRelat.Location = new System.Drawing.Point(582,38);
			this.listRelat.Name = "listRelat";
			this.listRelat.Size = new System.Drawing.Size(180,186);
			this.listRelat.TabIndex = 9;
			// 
			// gridMain
			// 
			this.gridMain.HScrollVisible = false;
			this.gridMain.Location = new System.Drawing.Point(22,38);
			this.gridMain.Name = "gridMain";
			this.gridMain.ScrollValue = 0;
			this.gridMain.Size = new System.Drawing.Size(527,186);
			this.gridMain.TabIndex = 10;
			this.gridMain.Title = "Insurance Plans for Family";
			this.gridMain.TranslationName = "TableInsPlans";
			this.gridMain.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.gridMain_CellDoubleClick);
			// 
			// butNone
			// 
			this.butNone.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butNone.Autosize = true;
			this.butNone.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butNone.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butNone.CornerRadius = 4F;
			this.butNone.Location = new System.Drawing.Point(22,330);
			this.butNone.Name = "butNone";
			this.butNone.Size = new System.Drawing.Size(76,24);
			this.butNone.TabIndex = 11;
			this.butNone.Text = "None";
			this.butNone.Click += new System.EventHandler(this.butNone_Click);
			// 
			// FormInsPlanSelect
			// 
			this.AcceptButton = this.butOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5,13);
			this.CancelButton = this.butCancel;
			this.ClientSize = new System.Drawing.Size(792,374);
			this.Controls.Add(this.butNone);
			this.Controls.Add(this.gridMain);
			this.Controls.Add(this.listRelat);
			this.Controls.Add(this.labelRelat);
			this.Controls.Add(this.butCancel);
			this.Controls.Add(this.butOK);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormInsPlanSelect";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select Insurance Plan";
			this.Load += new System.EventHandler(this.FormInsPlansSelect_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormInsPlansSelect_Load(object sender, System.EventArgs e) {
			if(!ViewRelat){
				labelRelat.Visible=false;
				listRelat.Visible=false;
			}
			//usage: eg. from coverage.  Since can be totally new subscriber, get all plans for them.
			FamCur=Patients.GetFamily(PatNum);
			PatCur=FamCur.GetPatient(PatNum);
			SubList=InsSubs.RefreshForFam(FamCur);
			PlanList=InsPlans.RefreshForSubList(SubList);
			FillPlanData();
			if(!ShowNoneButton) {
				butNone.Visible=false;
			}
    }

		private void FillPlanData(){
			gridMain.BeginUpdate();
			gridMain.Columns.Clear();
			ODGridColumn col;
			//col=new ODGridColumn(Lan.g("TableInsPlans","#"),20);
			//gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableInsPlans","Subscriber"),140);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableInsPlans","Ins Carrier"),100);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableInsPlans","Date Effect."),90);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableInsPlans","Date Term."),90);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableInsPlans","Used By"),90);
			gridMain.Columns.Add(col);
			gridMain.Rows.Clear();
			ODGridRow row;
			//PatPlan[] patPlanArray;
			InsPlan plan;
			for(int i=0;i<SubList.Count;i++) {
				row=new ODGridRow();
				//row.Cells.Add((i+1).ToString());
				row.Cells.Add(FamCur.GetNameInFamLF(SubList[i].Subscriber));
				plan=InsPlans.GetPlan(SubList[i].PlanNum,PlanList);
				row.Cells.Add(Carriers.GetName(plan.CarrierNum));
				if(SubList[i].DateEffective.Year<1880)
					row.Cells.Add("");
				else
					row.Cells.Add(SubList[i].DateEffective.ToString("d"));
				if(SubList[i].DateTerm.Year<1880) {
					row.Cells.Add("");
				}
				else {
					row.Cells.Add(SubList[i].DateTerm.ToString("d"));
				}
				int countPatPlans=PatPlans.GetCountBySubNum(SubList[i].InsSubNum);
				row.Cells.Add(countPatPlans.ToString());
				gridMain.Rows.Add(row);
			}
			gridMain.EndUpdate();
			listRelat.Items.Clear();
			for(int i=0;i<Enum.GetNames(typeof(Relat)).Length;i++){
				listRelat.Items.Add(Lan.g("enumRelat",Enum.GetNames(typeof(Relat))[i]));
			}
		}

		private void gridMain_CellDoubleClick(object sender,OpenDental.UI.ODGridClickEventArgs e) {
			if(ViewRelat && listRelat.SelectedIndex==-1) {
				MessageBox.Show(Lan.g(this,"Please select a relationship first."));
				return;
			}
			if(ViewRelat) {
				PatRelat=(Relat)listRelat.SelectedIndex;
			}
			SelectedSub=SubList[e.Row];
			SelectedPlan=InsPlans.GetPlan(SubList[e.Row].PlanNum,PlanList);
			DialogResult=DialogResult.OK;
		}

		private void butNone_Click(object sender,EventArgs e) {
			SelectedPlan=null;
			DialogResult=DialogResult.OK;
		}

		private void butOK_Click(object sender, System.EventArgs e) {
			if(gridMain.GetSelectedIndex()==-1){
				MessageBox.Show(Lan.g(this,"Please select a plan first."));
				return;
			}
			if(ViewRelat && listRelat.SelectedIndex==-1){
				MessageBox.Show(Lan.g(this,"Please select a relationship first."));
				return;
			}
			if(ViewRelat){
				PatRelat=(Relat)listRelat.SelectedIndex;
			}
			SelectedSub=SubList[gridMain.GetSelectedIndex()];
			SelectedPlan=InsPlans.GetPlan(SubList[gridMain.GetSelectedIndex()].PlanNum,PlanList);
      DialogResult=DialogResult.OK;		
		}

		private void butCancel_Click(object sender, System.EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}

		

		

		//cancel already handled
	}
}