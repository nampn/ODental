using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenDental {
	public partial class FormSheetImportEnumPicker:Form {
		public bool ShowClearButton;

		public FormSheetImportEnumPicker(string prompt) {
			InitializeComponent();
			Lan.F(this);
			labelPrompt.Text=prompt;
		}

		private void FormSheetImportEnumPicker_Load(object sender,EventArgs e) {
			if(!ShowClearButton) {
				butClear.Visible=false;
			}
		}

		private void butClear_Click(object sender,EventArgs e) {
			comboResult.SelectedIndex=-1;
			DialogResult=DialogResult.OK;
		}

		private void butOK_Click(object sender,EventArgs e) {
			DialogResult=DialogResult.OK;
		}

		private void butCancel_Click(object sender,EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}

		

		
	}
}