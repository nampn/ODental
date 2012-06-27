using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;
using OpenDentBusiness;

namespace OpenDentBusiness{
	///<summary></summary>
	public class EtransMessageTexts {

		///<summary></summary>
		public static long Insert(EtransMessageText etransMessageText) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				etransMessageText.EtransMessageTextNum=Meth.GetLong(MethodBase.GetCurrentMethod(),etransMessageText);
				return etransMessageText.EtransMessageTextNum;
			}
			return Crud.EtransMessageTextCrud.Insert(etransMessageText);
		}

		///<summary>If the message text is X12, then it always normalizes it to include carriage returns for better readability.</summary>
		public static string GetMessageText(long etransMessageTextNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetString(MethodBase.GetCurrentMethod(),etransMessageTextNum);
			}
			if(etransMessageTextNum==0) {
				return "";
			}
			string command="SELECT MessageText FROM etransmessagetext WHERE EtransMessageTextNum="+POut.Long(etransMessageTextNum);
			string msgText=Db.GetScalar(command);
			if(!X12object.IsX12(msgText)) {
				return msgText;
			}
			Match match=Regex.Match(msgText,"~[^(\n)(\r)]");
			while(match.Success){
				msgText=msgText.Substring(0,match.Index)+"~\r\n"+msgText.Substring(match.Index+1);
				match=Regex.Match(msgText,"~[^(\n)(\r)]");
			}
			return msgText;
			//MatchCollection matches=Regex.Matches(msgText,"~[^(\n)(\r)]");
			//for(int i=0;i<matches.Count;i++) {
				//Regex.
			//	matches[i].
			//}
			//msgText=Regex.Replace(msgText,"~[^(\r\n)(\n)(\r)]","~\r\n");
		}

		/*
		///<summary></summary>
		public static void Update(EtransMessageText EtransMessageText) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),EtransMessageText);
				return;
			}
			string command= "UPDATE EtransMessageText SET "
				+"ClearingHouseNum = '"   +POut.PInt   (EtransMessageText.ClearingHouseNum)+"', "
				+"Etype= '"               +POut.PInt   ((int)EtransMessageText.Etype)+"', "
				+"Note= '"                +POut.PString(EtransMessageText.Note)+"', "
				+"EtransMessageTextMessageTextNum= '"+POut.PInt   (EtransMessageText.EtransMessageTextMessageTextNum)+"' "
				+"WHERE EtransMessageTextNum = "+POut.PInt(EtransMessageText.EtransMessageTextNum);
			Db.NonQ(command);
		}
*/

		///<summary></summary>
		public static void Delete(long etransMessageTextNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),etransMessageTextNum);
				return;
			}
			if(etransMessageTextNum==0) {
				return;
			}
			string command;
			command="DELETE FROM etransmessagetext WHERE EtransMessageTextNum="+POut.Long(etransMessageTextNum);
			Db.NonQ(command);
		}
		



		
	}
}