﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenDentBusiness;

namespace OpenDental.Bridges {
	public class ECW {
		///<summary>AptNum is always passed in by eCW.  It is used in the logic for setting procedures complete within apt edit window.</summary>
		public static long AptNum;
		public static string EcwConfigPath;
		public static long UserId;
		public static string JSessionId;
		public static string JSessionIdSSO;

		//OD accepts commandline arguments from eCW.  That's handled in FormOpenDental.

		//public static void SendHL7(Appointment apt,Patient pat) {
		//  OpenDentBusiness.HL7.DFT dft=new OpenDentBusiness.HL7.DFT(apt,pat);
		//  HL7Msg msg=new HL7Msg();
		//  msg.AptNum=apt.AptNum;
		//  msg.HL7Status=HL7MessageStatus.OutPending;//it will be marked outSent by the HL7 service.
		//  msg.MsgText=dft.GenerateMessage();
		//  HL7Msgs.Insert(msg);
		//}

		public static void SendHL7(long aptNum,long provNum,Patient pat,string pdfDataBase64,string pdfDescription,bool justPDF) {
			OpenDentBusiness.HL7.DFT dft=new OpenDentBusiness.HL7.DFT();
			dft.InitializeEcw(aptNum,provNum,pat,pdfDataBase64,pdfDescription,justPDF);
			HL7Msg msg=new HL7Msg();
			if(justPDF){
				msg.AptNum=0;//Prevents the appt complete button from changing to the "Revise" button prematurely.
			}
			else{
				msg.AptNum=aptNum;
			}
			msg.HL7Status=HL7MessageStatus.OutPending;//it will be marked outSent by the HL7 service.
			msg.MsgText=dft.GenerateMessage();
			HL7Msgs.Insert(msg);
		}



	}
}
