//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class CreditCardCrud {
		///<summary>Gets one CreditCard object from the database using the primary key.  Returns null if not found.</summary>
		internal static CreditCard SelectOne(long creditCardNum){
			string command="SELECT * FROM creditcard "
				+"WHERE CreditCardNum = "+POut.Long(creditCardNum);
			List<CreditCard> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one CreditCard object from the database using a query.</summary>
		internal static CreditCard SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<CreditCard> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of CreditCard objects from the database using a query.</summary>
		internal static List<CreditCard> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<CreditCard> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<CreditCard> TableToList(DataTable table){
			List<CreditCard> retVal=new List<CreditCard>();
			CreditCard creditCard;
			for(int i=0;i<table.Rows.Count;i++) {
				creditCard=new CreditCard();
				creditCard.CreditCardNum = PIn.Long  (table.Rows[i]["CreditCardNum"].ToString());
				creditCard.PatNum        = PIn.Long  (table.Rows[i]["PatNum"].ToString());
				creditCard.Address       = PIn.String(table.Rows[i]["Address"].ToString());
				creditCard.Zip           = PIn.String(table.Rows[i]["Zip"].ToString());
				creditCard.XChargeToken  = PIn.String(table.Rows[i]["XChargeToken"].ToString());
				creditCard.CCNumberMasked= PIn.String(table.Rows[i]["CCNumberMasked"].ToString());
				creditCard.CCExpiration  = PIn.Date  (table.Rows[i]["CCExpiration"].ToString());
				creditCard.ItemOrder     = PIn.Int   (table.Rows[i]["ItemOrder"].ToString());
				creditCard.ChargeAmt     = PIn.Double(table.Rows[i]["ChargeAmt"].ToString());
				creditCard.DateStart     = PIn.Date  (table.Rows[i]["DateStart"].ToString());
				creditCard.DateStop      = PIn.Date  (table.Rows[i]["DateStop"].ToString());
				creditCard.Note          = PIn.String(table.Rows[i]["Note"].ToString());
				creditCard.PayPlanNum    = PIn.Long  (table.Rows[i]["PayPlanNum"].ToString());
				retVal.Add(creditCard);
			}
			return retVal;
		}

		///<summary>Inserts one CreditCard into the database.  Returns the new priKey.</summary>
		internal static long Insert(CreditCard creditCard){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				creditCard.CreditCardNum=DbHelper.GetNextOracleKey("creditcard","CreditCardNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(creditCard,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							creditCard.CreditCardNum++;
							loopcount++;
						}
						else{
							throw ex;
						}
					}
				}
				throw new ApplicationException("Insert failed.  Could not generate primary key.");
			}
			else {
				return Insert(creditCard,false);
			}
		}

		///<summary>Inserts one CreditCard into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(CreditCard creditCard,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				creditCard.CreditCardNum=ReplicationServers.GetKey("creditcard","CreditCardNum");
			}
			string command="INSERT INTO creditcard (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="CreditCardNum,";
			}
			command+="PatNum,Address,Zip,XChargeToken,CCNumberMasked,CCExpiration,ItemOrder,ChargeAmt,DateStart,DateStop,Note,PayPlanNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(creditCard.CreditCardNum)+",";
			}
			command+=
				     POut.Long  (creditCard.PatNum)+","
				+"'"+POut.String(creditCard.Address)+"',"
				+"'"+POut.String(creditCard.Zip)+"',"
				+"'"+POut.String(creditCard.XChargeToken)+"',"
				+"'"+POut.String(creditCard.CCNumberMasked)+"',"
				+    POut.Date  (creditCard.CCExpiration)+","
				+    POut.Int   (creditCard.ItemOrder)+","
				+"'"+POut.Double(creditCard.ChargeAmt)+"',"
				+    POut.Date  (creditCard.DateStart)+","
				+    POut.Date  (creditCard.DateStop)+","
				+"'"+POut.String(creditCard.Note)+"',"
				+    POut.Long  (creditCard.PayPlanNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				creditCard.CreditCardNum=Db.NonQ(command,true);
			}
			return creditCard.CreditCardNum;
		}

		///<summary>Updates one CreditCard in the database.</summary>
		internal static void Update(CreditCard creditCard){
			string command="UPDATE creditcard SET "
				+"PatNum        =  "+POut.Long  (creditCard.PatNum)+", "
				+"Address       = '"+POut.String(creditCard.Address)+"', "
				+"Zip           = '"+POut.String(creditCard.Zip)+"', "
				+"XChargeToken  = '"+POut.String(creditCard.XChargeToken)+"', "
				+"CCNumberMasked= '"+POut.String(creditCard.CCNumberMasked)+"', "
				+"CCExpiration  =  "+POut.Date  (creditCard.CCExpiration)+", "
				+"ItemOrder     =  "+POut.Int   (creditCard.ItemOrder)+", "
				+"ChargeAmt     = '"+POut.Double(creditCard.ChargeAmt)+"', "
				+"DateStart     =  "+POut.Date  (creditCard.DateStart)+", "
				+"DateStop      =  "+POut.Date  (creditCard.DateStop)+", "
				+"Note          = '"+POut.String(creditCard.Note)+"', "
				+"PayPlanNum    =  "+POut.Long  (creditCard.PayPlanNum)+" "
				+"WHERE CreditCardNum = "+POut.Long(creditCard.CreditCardNum);
			Db.NonQ(command);
		}

		///<summary>Updates one CreditCard in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(CreditCard creditCard,CreditCard oldCreditCard){
			string command="";
			if(creditCard.PatNum != oldCreditCard.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(creditCard.PatNum)+"";
			}
			if(creditCard.Address != oldCreditCard.Address) {
				if(command!=""){ command+=",";}
				command+="Address = '"+POut.String(creditCard.Address)+"'";
			}
			if(creditCard.Zip != oldCreditCard.Zip) {
				if(command!=""){ command+=",";}
				command+="Zip = '"+POut.String(creditCard.Zip)+"'";
			}
			if(creditCard.XChargeToken != oldCreditCard.XChargeToken) {
				if(command!=""){ command+=",";}
				command+="XChargeToken = '"+POut.String(creditCard.XChargeToken)+"'";
			}
			if(creditCard.CCNumberMasked != oldCreditCard.CCNumberMasked) {
				if(command!=""){ command+=",";}
				command+="CCNumberMasked = '"+POut.String(creditCard.CCNumberMasked)+"'";
			}
			if(creditCard.CCExpiration != oldCreditCard.CCExpiration) {
				if(command!=""){ command+=",";}
				command+="CCExpiration = "+POut.Date(creditCard.CCExpiration)+"";
			}
			if(creditCard.ItemOrder != oldCreditCard.ItemOrder) {
				if(command!=""){ command+=",";}
				command+="ItemOrder = "+POut.Int(creditCard.ItemOrder)+"";
			}
			if(creditCard.ChargeAmt != oldCreditCard.ChargeAmt) {
				if(command!=""){ command+=",";}
				command+="ChargeAmt = '"+POut.Double(creditCard.ChargeAmt)+"'";
			}
			if(creditCard.DateStart != oldCreditCard.DateStart) {
				if(command!=""){ command+=",";}
				command+="DateStart = "+POut.Date(creditCard.DateStart)+"";
			}
			if(creditCard.DateStop != oldCreditCard.DateStop) {
				if(command!=""){ command+=",";}
				command+="DateStop = "+POut.Date(creditCard.DateStop)+"";
			}
			if(creditCard.Note != oldCreditCard.Note) {
				if(command!=""){ command+=",";}
				command+="Note = '"+POut.String(creditCard.Note)+"'";
			}
			if(creditCard.PayPlanNum != oldCreditCard.PayPlanNum) {
				if(command!=""){ command+=",";}
				command+="PayPlanNum = "+POut.Long(creditCard.PayPlanNum)+"";
			}
			if(command==""){
				return;
			}
			command="UPDATE creditcard SET "+command
				+" WHERE CreditCardNum = "+POut.Long(creditCard.CreditCardNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one CreditCard from the database.</summary>
		internal static void Delete(long creditCardNum){
			string command="DELETE FROM creditcard "
				+"WHERE CreditCardNum = "+POut.Long(creditCardNum);
			Db.NonQ(command);
		}

	}
}