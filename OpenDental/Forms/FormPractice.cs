using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using OpenDentBusiness;

namespace OpenDental{
///<summary></summary>
	public class FormPractice : System.Windows.Forms.Form{
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBankNumber;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textZip;
		private System.Windows.Forms.TextBox textST;
		private System.Windows.Forms.TextBox textCity;
		private System.Windows.Forms.TextBox textAddress2;
		private System.Windows.Forms.TextBox textAddress;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textPracticeTitle;
		private System.Windows.Forms.Label label3;
		private OpenDental.UI.Button butOK;
		private OpenDental.UI.Button butCancel;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ListBox listBillType;
		private System.Windows.Forms.ListBox listProvider;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label labelPlaceService;
		private System.Windows.Forms.ListBox listPlaceService;
		private System.Windows.Forms.TextBox textPhone;
		private System.Windows.Forms.RadioButton radioInsBillingProvTreat;
		private System.Windows.Forms.RadioButton radioInsBillingProvDefault;
		private System.Windows.Forms.RadioButton radioInsBillingProvSpecific;
		private System.Windows.Forms.ComboBox comboInsBillingProv;
		private GroupBox groupSwiss;
		private TextBox textBankAddress;
		private Label label2;
		private TextBox textBankRouting;
		private Label label1;
		private GroupBox groupBox1;
		private Label label7;
		private TextBox textBillingZip;
		private TextBox textBillingST;
		private TextBox textBillingCity;
		private TextBox textBillingAddress2;
		private TextBox textBillingAddress;
		private Label label8;
		private Label label11;
		private CheckBox checkUseBillingAddressOnClaims;
		private GroupBox groupBox3;
		private Label label13;
		private TextBox textPayToZip;
		private TextBox textPayToST;
		private TextBox textPayToCity;
		private TextBox textPayToAddress2;
		private TextBox textPayToAddress;
		private Label label14;
		private Label label15;
		private Label label18;
		private Label label17;
		private System.Windows.Forms.GroupBox groupBox4;// Required designer variable.

		///<summary></summary>
		public FormPractice(){
			InitializeComponent();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPractice));
			this.listBillType = new System.Windows.Forms.ListBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.listProvider = new System.Windows.Forms.ListBox();
			this.textBankNumber = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textPhone = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.textZip = new System.Windows.Forms.TextBox();
			this.textST = new System.Windows.Forms.TextBox();
			this.textCity = new System.Windows.Forms.TextBox();
			this.textAddress2 = new System.Windows.Forms.TextBox();
			this.textAddress = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.textPracticeTitle = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.labelPlaceService = new System.Windows.Forms.Label();
			this.listPlaceService = new System.Windows.Forms.ListBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.comboInsBillingProv = new System.Windows.Forms.ComboBox();
			this.radioInsBillingProvSpecific = new System.Windows.Forms.RadioButton();
			this.radioInsBillingProvTreat = new System.Windows.Forms.RadioButton();
			this.radioInsBillingProvDefault = new System.Windows.Forms.RadioButton();
			this.groupSwiss = new System.Windows.Forms.GroupBox();
			this.textBankAddress = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBankRouting = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkUseBillingAddressOnClaims = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBillingZip = new System.Windows.Forms.TextBox();
			this.textBillingST = new System.Windows.Forms.TextBox();
			this.textBillingCity = new System.Windows.Forms.TextBox();
			this.textBillingAddress2 = new System.Windows.Forms.TextBox();
			this.textBillingAddress = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.butCancel = new OpenDental.UI.Button();
			this.butOK = new OpenDental.UI.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label13 = new System.Windows.Forms.Label();
			this.textPayToZip = new System.Windows.Forms.TextBox();
			this.textPayToST = new System.Windows.Forms.TextBox();
			this.textPayToCity = new System.Windows.Forms.TextBox();
			this.textPayToAddress2 = new System.Windows.Forms.TextBox();
			this.textPayToAddress = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupSwiss.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBillType
			// 
			this.listBillType.Items.AddRange(new object[] {
            ""});
			this.listBillType.Location = new System.Drawing.Point(629,29);
			this.listBillType.Name = "listBillType";
			this.listBillType.Size = new System.Drawing.Size(160,147);
			this.listBillType.TabIndex = 5;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(628,9);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(154,17);
			this.label12.TabIndex = 29;
			this.label12.Text = "Default Billing Type";
			this.label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(491,9);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(110,16);
			this.label10.TabIndex = 26;
			this.label10.Text = "Default Provider";
			this.label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// listProvider
			// 
			this.listProvider.Items.AddRange(new object[] {
            ""});
			this.listProvider.Location = new System.Drawing.Point(492,29);
			this.listProvider.Name = "listProvider";
			this.listProvider.Size = new System.Drawing.Size(129,147);
			this.listProvider.TabIndex = 4;
			// 
			// textBankNumber
			// 
			this.textBankNumber.Location = new System.Drawing.Point(144,452);
			this.textBankNumber.Multiline = true;
			this.textBankNumber.Name = "textBankNumber";
			this.textBankNumber.Size = new System.Drawing.Size(317,49);
			this.textBankNumber.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(26,451);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(117,31);
			this.label4.TabIndex = 22;
			this.label4.Text = "Bank Deposit Acct Number and Info";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textPhone);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.textZip);
			this.groupBox2.Controls.Add(this.textST);
			this.groupBox2.Controls.Add(this.textCity);
			this.groupBox2.Controls.Add(this.textAddress2);
			this.groupBox2.Controls.Add(this.textAddress);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox2.Location = new System.Drawing.Point(41,58);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(429,104);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Address";
			// 
			// textPhone
			// 
			this.textPhone.Location = new System.Drawing.Point(103,79);
			this.textPhone.Name = "textPhone";
			this.textPhone.Size = new System.Drawing.Size(121,20);
			this.textPhone.TabIndex = 20;
			this.textPhone.TextChanged += new System.EventHandler(this.textPhone_TextChanged);
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(5,36);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(97,16);
			this.label16.TabIndex = 19;
			this.label16.Text = "Address 2";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textZip
			// 
			this.textZip.Location = new System.Drawing.Point(318,57);
			this.textZip.Name = "textZip";
			this.textZip.Size = new System.Drawing.Size(102,20);
			this.textZip.TabIndex = 4;
			// 
			// textST
			// 
			this.textST.Location = new System.Drawing.Point(264,57);
			this.textST.Name = "textST";
			this.textST.Size = new System.Drawing.Size(52,20);
			this.textST.TabIndex = 3;
			// 
			// textCity
			// 
			this.textCity.Location = new System.Drawing.Point(103,57);
			this.textCity.Name = "textCity";
			this.textCity.Size = new System.Drawing.Size(159,20);
			this.textCity.TabIndex = 2;
			// 
			// textAddress2
			// 
			this.textAddress2.Location = new System.Drawing.Point(103,35);
			this.textAddress2.Name = "textAddress2";
			this.textAddress2.Size = new System.Drawing.Size(317,20);
			this.textAddress2.TabIndex = 1;
			// 
			// textAddress
			// 
			this.textAddress.Location = new System.Drawing.Point(103,13);
			this.textAddress.Name = "textAddress";
			this.textAddress.Size = new System.Drawing.Size(317,20);
			this.textAddress.TabIndex = 0;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(4,15);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(98,14);
			this.label5.TabIndex = 3;
			this.label5.Text = "Address";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(4,59);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(98,15);
			this.label6.TabIndex = 4;
			this.label6.Text = "City, ST, Zip";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(5,80);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(97,17);
			this.label9.TabIndex = 7;
			this.label9.Text = "Phone";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textPracticeTitle
			// 
			this.textPracticeTitle.Location = new System.Drawing.Point(144,29);
			this.textPracticeTitle.Name = "textPracticeTitle";
			this.textPracticeTitle.Size = new System.Drawing.Size(317,20);
			this.textPracticeTitle.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(50,24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96,28);
			this.label3.TabIndex = 19;
			this.label3.Text = "Dentist Name or Practice Title";
			// 
			// labelPlaceService
			// 
			this.labelPlaceService.Location = new System.Drawing.Point(490,185);
			this.labelPlaceService.Name = "labelPlaceService";
			this.labelPlaceService.Size = new System.Drawing.Size(156,18);
			this.labelPlaceService.TabIndex = 44;
			this.labelPlaceService.Text = "Default Proc Place Service";
			this.labelPlaceService.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// listPlaceService
			// 
			this.listPlaceService.Location = new System.Drawing.Point(492,206);
			this.listPlaceService.Name = "listPlaceService";
			this.listPlaceService.Size = new System.Drawing.Size(145,147);
			this.listPlaceService.TabIndex = 45;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.comboInsBillingProv);
			this.groupBox4.Controls.Add(this.radioInsBillingProvSpecific);
			this.groupBox4.Controls.Add(this.radioInsBillingProvTreat);
			this.groupBox4.Controls.Add(this.radioInsBillingProvDefault);
			this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox4.Location = new System.Drawing.Point(649,200);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(235,104);
			this.groupBox4.TabIndex = 50;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Default Insurance Billing Dentist";
			// 
			// comboInsBillingProv
			// 
			this.comboInsBillingProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboInsBillingProv.Location = new System.Drawing.Point(17,73);
			this.comboInsBillingProv.Name = "comboInsBillingProv";
			this.comboInsBillingProv.Size = new System.Drawing.Size(212,21);
			this.comboInsBillingProv.TabIndex = 3;
			// 
			// radioInsBillingProvSpecific
			// 
			this.radioInsBillingProvSpecific.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioInsBillingProvSpecific.Location = new System.Drawing.Point(17,53);
			this.radioInsBillingProvSpecific.Name = "radioInsBillingProvSpecific";
			this.radioInsBillingProvSpecific.Size = new System.Drawing.Size(186,19);
			this.radioInsBillingProvSpecific.TabIndex = 2;
			this.radioInsBillingProvSpecific.Text = "Specific Provider:";
			// 
			// radioInsBillingProvTreat
			// 
			this.radioInsBillingProvTreat.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioInsBillingProvTreat.Location = new System.Drawing.Point(17,34);
			this.radioInsBillingProvTreat.Name = "radioInsBillingProvTreat";
			this.radioInsBillingProvTreat.Size = new System.Drawing.Size(186,19);
			this.radioInsBillingProvTreat.TabIndex = 1;
			this.radioInsBillingProvTreat.Text = "Treating Provider";
			// 
			// radioInsBillingProvDefault
			// 
			this.radioInsBillingProvDefault.Checked = true;
			this.radioInsBillingProvDefault.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioInsBillingProvDefault.Location = new System.Drawing.Point(17,16);
			this.radioInsBillingProvDefault.Name = "radioInsBillingProvDefault";
			this.radioInsBillingProvDefault.Size = new System.Drawing.Size(186,19);
			this.radioInsBillingProvDefault.TabIndex = 0;
			this.radioInsBillingProvDefault.TabStop = true;
			this.radioInsBillingProvDefault.Text = "Default Practice Provider";
			// 
			// groupSwiss
			// 
			this.groupSwiss.Controls.Add(this.textBankAddress);
			this.groupSwiss.Controls.Add(this.label2);
			this.groupSwiss.Controls.Add(this.textBankRouting);
			this.groupSwiss.Controls.Add(this.label1);
			this.groupSwiss.Location = new System.Drawing.Point(492,359);
			this.groupSwiss.Name = "groupSwiss";
			this.groupSwiss.Size = new System.Drawing.Size(392,146);
			this.groupSwiss.TabIndex = 51;
			this.groupSwiss.TabStop = false;
			this.groupSwiss.Text = "Switzerland";
			// 
			// textBankAddress
			// 
			this.textBankAddress.AcceptsReturn = true;
			this.textBankAddress.Location = new System.Drawing.Point(103,43);
			this.textBankAddress.Multiline = true;
			this.textBankAddress.Name = "textBankAddress";
			this.textBankAddress.Size = new System.Drawing.Size(283,95);
			this.textBankAddress.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4,46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98,40);
			this.label2.TabIndex = 7;
			this.label2.Text = "Bank Name and Address";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBankRouting
			// 
			this.textBankRouting.Location = new System.Drawing.Point(103,19);
			this.textBankRouting.Name = "textBankRouting";
			this.textBankRouting.Size = new System.Drawing.Size(283,20);
			this.textBankRouting.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4,22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98,14);
			this.label1.TabIndex = 5;
			this.label1.Text = "Bank Routing";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.checkUseBillingAddressOnClaims);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.textBillingZip);
			this.groupBox1.Controls.Add(this.textBillingST);
			this.groupBox1.Controls.Add(this.textBillingCity);
			this.groupBox1.Controls.Add(this.textBillingAddress2);
			this.groupBox1.Controls.Add(this.textBillingAddress);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(41,168);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(429,140);
			this.groupBox1.TabIndex = 52;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Billing Address";
			// 
			// checkUseBillingAddressOnClaims
			// 
			this.checkUseBillingAddressOnClaims.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkUseBillingAddressOnClaims.Location = new System.Drawing.Point(1,46);
			this.checkUseBillingAddressOnClaims.Name = "checkUseBillingAddressOnClaims";
			this.checkUseBillingAddressOnClaims.Size = new System.Drawing.Size(116,16);
			this.checkUseBillingAddressOnClaims.TabIndex = 53;
			this.checkUseBillingAddressOnClaims.Text = "Use on Claims";
			this.checkUseBillingAddressOnClaims.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkUseBillingAddressOnClaims.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(4,88);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(97,16);
			this.label7.TabIndex = 19;
			this.label7.Text = "Address 2";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBillingZip
			// 
			this.textBillingZip.Location = new System.Drawing.Point(318,109);
			this.textBillingZip.Name = "textBillingZip";
			this.textBillingZip.Size = new System.Drawing.Size(102,20);
			this.textBillingZip.TabIndex = 4;
			// 
			// textBillingST
			// 
			this.textBillingST.Location = new System.Drawing.Point(264,109);
			this.textBillingST.Name = "textBillingST";
			this.textBillingST.Size = new System.Drawing.Size(52,20);
			this.textBillingST.TabIndex = 3;
			// 
			// textBillingCity
			// 
			this.textBillingCity.Location = new System.Drawing.Point(103,109);
			this.textBillingCity.Name = "textBillingCity";
			this.textBillingCity.Size = new System.Drawing.Size(159,20);
			this.textBillingCity.TabIndex = 2;
			// 
			// textBillingAddress2
			// 
			this.textBillingAddress2.Location = new System.Drawing.Point(103,87);
			this.textBillingAddress2.Name = "textBillingAddress2";
			this.textBillingAddress2.Size = new System.Drawing.Size(317,20);
			this.textBillingAddress2.TabIndex = 1;
			// 
			// textBillingAddress
			// 
			this.textBillingAddress.Location = new System.Drawing.Point(103,65);
			this.textBillingAddress.Name = "textBillingAddress";
			this.textBillingAddress.Size = new System.Drawing.Size(317,20);
			this.textBillingAddress.TabIndex = 0;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(3,67);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(98,14);
			this.label8.TabIndex = 3;
			this.label8.Text = "Address";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(3,111);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(98,15);
			this.label11.TabIndex = 4;
			this.label11.Text = "City, ST, Zip";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
			this.butCancel.Location = new System.Drawing.Point(785,527);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new System.Drawing.Size(75,26);
			this.butCancel.TabIndex = 8;
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
			this.butOK.Location = new System.Drawing.Point(704,527);
			this.butOK.Name = "butOK";
			this.butOK.Size = new System.Drawing.Size(75,26);
			this.butOK.TabIndex = 7;
			this.butOK.Text = "&OK";
			this.butOK.Click += new System.EventHandler(this.butOK_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label17);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.textPayToZip);
			this.groupBox3.Controls.Add(this.textPayToST);
			this.groupBox3.Controls.Add(this.textPayToCity);
			this.groupBox3.Controls.Add(this.textPayToAddress2);
			this.groupBox3.Controls.Add(this.textPayToAddress);
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox3.Location = new System.Drawing.Point(41,315);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(429,122);
			this.groupBox3.TabIndex = 53;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Pay To Address";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(5,70);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(97,16);
			this.label13.TabIndex = 19;
			this.label13.Text = "Address 2";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textPayToZip
			// 
			this.textPayToZip.Location = new System.Drawing.Point(318,91);
			this.textPayToZip.Name = "textPayToZip";
			this.textPayToZip.Size = new System.Drawing.Size(102,20);
			this.textPayToZip.TabIndex = 4;
			// 
			// textPayToST
			// 
			this.textPayToST.Location = new System.Drawing.Point(264,91);
			this.textPayToST.Name = "textPayToST";
			this.textPayToST.Size = new System.Drawing.Size(52,20);
			this.textPayToST.TabIndex = 3;
			// 
			// textPayToCity
			// 
			this.textPayToCity.Location = new System.Drawing.Point(103,91);
			this.textPayToCity.Name = "textPayToCity";
			this.textPayToCity.Size = new System.Drawing.Size(159,20);
			this.textPayToCity.TabIndex = 2;
			// 
			// textPayToAddress2
			// 
			this.textPayToAddress2.Location = new System.Drawing.Point(103,69);
			this.textPayToAddress2.Name = "textPayToAddress2";
			this.textPayToAddress2.Size = new System.Drawing.Size(317,20);
			this.textPayToAddress2.TabIndex = 1;
			// 
			// textPayToAddress
			// 
			this.textPayToAddress.Location = new System.Drawing.Point(103,47);
			this.textPayToAddress.Name = "textPayToAddress";
			this.textPayToAddress.Size = new System.Drawing.Size(317,20);
			this.textPayToAddress.TabIndex = 0;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(4,49);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(98,14);
			this.label14.TabIndex = 3;
			this.label14.Text = "Address";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(4,93);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(98,15);
			this.label15.TabIndex = 4;
			this.label15.Text = "City, ST, Zip";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(103,14);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(317,33);
			this.label17.TabIndex = 20;
			this.label17.Text = "Optional.  Only used on e-claims.  This gets sent in addition to the practice or " +
    "billing address.";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(100,14);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(310,29);
			this.label18.TabIndex = 54;
			this.label18.Text = "Optional.  If using on e-claims, cannot be a PO Box.  Overrides the practice addr" +
    "ess.";
			// 
			// FormPractice
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5,13);
			this.ClientSize = new System.Drawing.Size(892,576);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupSwiss);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.listPlaceService);
			this.Controls.Add(this.labelPlaceService);
			this.Controls.Add(this.textBankNumber);
			this.Controls.Add(this.textPracticeTitle);
			this.Controls.Add(this.listProvider);
			this.Controls.Add(this.butCancel);
			this.Controls.Add(this.butOK);
			this.Controls.Add(this.listBillType);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.label3);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormPractice";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Edit Practice Info";
			this.Load += new System.EventHandler(this.FormPractice_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupSwiss.ResumeLayout(false);
			this.groupSwiss.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void FormPractice_Load(object sender, System.EventArgs e) {
			textPracticeTitle.Text=PrefC.GetString(PrefName.PracticeTitle);
			textAddress.Text=PrefC.GetString(PrefName.PracticeAddress);
			textAddress2.Text=PrefC.GetString(PrefName.PracticeAddress2);
			textCity.Text=PrefC.GetString(PrefName.PracticeCity);
			textST.Text=PrefC.GetString(PrefName.PracticeST);
			textZip.Text=PrefC.GetString(PrefName.PracticeZip);
			string phone=PrefC.GetString(PrefName.PracticePhone);
			if(phone.Length==10 
				&& (CultureInfo.CurrentCulture.Name=="en-US" || 
				CultureInfo.CurrentCulture.Name.EndsWith("CA"))) //Canadian. en-CA or fr-CA
			{
				textPhone.Text="("+phone.Substring(0,3)+")"+phone.Substring(3,3)+"-"+phone.Substring(6);
			}
			else{
				textPhone.Text=phone;
			}
			checkUseBillingAddressOnClaims.Checked=PrefC.GetBool(PrefName.UseBillingAddressOnClaims);
			textBillingAddress.Text=PrefC.GetString(PrefName.PracticeBillingAddress);
			textBillingAddress2.Text=PrefC.GetString(PrefName.PracticeBillingAddress2);
			textBillingCity.Text=PrefC.GetString(PrefName.PracticeBillingCity);
			textBillingST.Text=PrefC.GetString(PrefName.PracticeBillingST);
			textBillingZip.Text=PrefC.GetString(PrefName.PracticeBillingZip);
			textPayToAddress.Text=PrefC.GetString(PrefName.PracticePayToAddress);
			textPayToAddress2.Text=PrefC.GetString(PrefName.PracticePayToAddress2);
			textPayToCity.Text=PrefC.GetString(PrefName.PracticePayToCity);
			textPayToST.Text=PrefC.GetString(PrefName.PracticePayToST);
			textPayToZip.Text=PrefC.GetString(PrefName.PracticePayToZip);
			textBankNumber.Text=PrefC.GetString(PrefName.PracticeBankNumber);
			if(CultureInfo.CurrentCulture.Name.EndsWith("CH")) {//CH is for switzerland. eg de-CH
				textBankRouting.Text=PrefC.GetString(PrefName.BankRouting);
				textBankAddress.Text=PrefC.GetString(PrefName.BankAddress);
			}
			else {
				groupSwiss.Visible=false;
			}
			listProvider.Items.Clear();
			for(int i=0;i<ProviderC.ListShort.Count;i++){
				listProvider.Items.Add(ProviderC.ListShort[i].GetLongDesc());
				if(ProviderC.ListShort[i].ProvNum==PrefC.GetLong(PrefName.PracticeDefaultProv)){
					listProvider.SelectedIndex=i;
				}
			}
			listBillType.Items.Clear();
			for(int i=0;i<DefC.Short[(int)DefCat.BillingTypes].Length;i++){
				listBillType.Items.Add(DefC.Short[(int)DefCat.BillingTypes][i].ItemName);
				if(DefC.Short[(int)DefCat.BillingTypes][i].DefNum==PrefC.GetLong(PrefName.PracticeDefaultBillType))
					listBillType.SelectedIndex=i;
			}
			if(PrefC.GetBool(PrefName.EasyHidePublicHealth)){
				labelPlaceService.Visible=false;
				listPlaceService.Visible=false;
			}
			listPlaceService.Items.Clear();
			for(int i=0;i<Enum.GetNames(typeof(PlaceOfService)).Length;i++){
				listPlaceService.Items.Add(Lan.g("enumPlaceOfService",Enum.GetNames(typeof(PlaceOfService))[i]));
			}
			listPlaceService.SelectedIndex=PrefC.GetInt(PrefName.DefaultProcedurePlaceService);
			for(int i=0;i<ProviderC.ListShort.Count;i++){
				comboInsBillingProv.Items.Add(ProviderC.ListShort[i].GetLongDesc());
			}
			if(PrefC.GetLong(PrefName.InsBillingProv)==0){
				radioInsBillingProvDefault.Checked=true;//default=0
			}
			else if(PrefC.GetLong(PrefName.InsBillingProv)==-1){
				radioInsBillingProvTreat.Checked=true;//treat=-1
			}
			else{
				radioInsBillingProvSpecific.Checked=true;//specific=any number >0. Foreign key to ProvNum
				comboInsBillingProv.SelectedIndex=Providers.GetIndex(PrefC.GetLong(PrefName.InsBillingProv));
			}
		}

		private void textPhone_TextChanged(object sender, System.EventArgs e) {
			int cursor=textPhone.SelectionStart;
			int length=textPhone.Text.Length;
			textPhone.Text=TelephoneNumbers.AutoFormat(textPhone.Text);
			if(textPhone.Text.Length>length)
				cursor++;
			textPhone.SelectionStart=cursor;		
		}

		//private void butTreatProv_Click(object sender, System.EventArgs e) {
		//	listBillProv.SelectedIndex=-1;
		//}

		private void butOK_Click(object sender, System.EventArgs e) {
			string phone=textPhone.Text;
			if(Application.CurrentCulture.Name=="en-US"
				|| CultureInfo.CurrentCulture.Name.EndsWith("CA")) //Canadian. en-CA or fr-CA)
			{
				phone=phone.Replace("(","");
				phone=phone.Replace(")","");
				phone=phone.Replace(" ","");
				phone=phone.Replace("-","");
				if(phone.Length!=0 && phone.Length!=10){
					MessageBox.Show(Lan.g(this,"Invalid phone"));
					return;
				}
			}
			if(radioInsBillingProvSpecific.Checked && comboInsBillingProv.SelectedIndex==-1){
				MsgBox.Show(this,"You must select a provider.");
				return;
			}
			bool changed=false;
			if( Prefs.UpdateString(PrefName.PracticeTitle,textPracticeTitle.Text)
				| Prefs.UpdateString(PrefName.PracticeAddress,textAddress.Text)
				| Prefs.UpdateString(PrefName.PracticeAddress2,textAddress2.Text)
				| Prefs.UpdateString(PrefName.PracticeCity,textCity.Text)
				| Prefs.UpdateString(PrefName.PracticeST,textST.Text)
				| Prefs.UpdateString(PrefName.PracticeZip,textZip.Text)
				| Prefs.UpdateString(PrefName.PracticePhone,phone)
				| Prefs.UpdateBool(PrefName.UseBillingAddressOnClaims,checkUseBillingAddressOnClaims.Checked)
				| Prefs.UpdateString(PrefName.PracticeBillingAddress,textBillingAddress.Text)
				| Prefs.UpdateString(PrefName.PracticeBillingAddress2,textBillingAddress2.Text)
				| Prefs.UpdateString(PrefName.PracticeBillingCity,textBillingCity.Text)
				| Prefs.UpdateString(PrefName.PracticeBillingST,textBillingST.Text)
				| Prefs.UpdateString(PrefName.PracticeBillingZip,textBillingZip.Text)
				| Prefs.UpdateString(PrefName.PracticePayToAddress,textPayToAddress.Text)
				| Prefs.UpdateString(PrefName.PracticePayToAddress2,textPayToAddress2.Text)
				| Prefs.UpdateString(PrefName.PracticePayToCity,textPayToCity.Text)
				| Prefs.UpdateString(PrefName.PracticePayToST,textPayToST.Text)
				| Prefs.UpdateString(PrefName.PracticePayToZip,textPayToZip.Text)
				| Prefs.UpdateString(PrefName.PracticeBankNumber,textBankNumber.Text))
			{
				changed=true;
			}
			if(CultureInfo.CurrentCulture.Name.EndsWith("CH")) {//CH is for switzerland. eg de-CH
				if( Prefs.UpdateString(PrefName.BankRouting,textBankRouting.Text)
					| Prefs.UpdateString(PrefName.BankAddress,textBankAddress.Text))
				{
					changed=true;
				}
			}
			if(listProvider.SelectedIndex==-1//practice really needs a default prov
				&& ProviderC.ListShort.Count > 0)
			{
				listProvider.SelectedIndex=0;
			}
			if(listProvider.SelectedIndex!=-1){
				if(Prefs.UpdateLong(PrefName.PracticeDefaultProv,ProviderC.ListShort[listProvider.SelectedIndex].ProvNum)){
					changed=true;
				}
			}
			if(listBillType.SelectedIndex!=-1){
				if(Prefs.UpdateLong(PrefName.PracticeDefaultBillType
					,DefC.Short[(int)DefCat.BillingTypes][listBillType.SelectedIndex].DefNum))
				{
					changed=true;
				}
			}
			if(Prefs.UpdateLong(PrefName.DefaultProcedurePlaceService,listPlaceService.SelectedIndex)){
				changed=true;
			}
			if(radioInsBillingProvDefault.Checked){//default=0
				if(Prefs.UpdateLong(PrefName.InsBillingProv,0)){
					changed=true;
				}
			}
			else if(radioInsBillingProvTreat.Checked){//treat=-1
				if(Prefs.UpdateLong(PrefName.InsBillingProv,-1)){
					changed=true;
				}
			}
			else{
				if(Prefs.UpdateLong(PrefName.InsBillingProv,ProviderC.ListShort[comboInsBillingProv.SelectedIndex].ProvNum)){
					changed=true;
				}
			}
			if(changed){
				DataValid.SetInvalid(InvalidType.Prefs);
			}
			FormMobile.UploadPreference(PrefName.PracticeTitle);
			DialogResult=DialogResult.OK;
		}

		private void butCancel_Click(object sender, System.EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}

	

	}
}
