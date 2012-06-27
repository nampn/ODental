//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class PaySplitCrud {
		///<summary>Gets one PaySplit object from the database using the primary key.  Returns null if not found.</summary>
		internal static PaySplit SelectOne(long splitNum){
			string command="SELECT * FROM paysplit "
				+"WHERE SplitNum = "+POut.Long(splitNum);
			List<PaySplit> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one PaySplit object from the database using a query.</summary>
		internal static PaySplit SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<PaySplit> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of PaySplit objects from the database using a query.</summary>
		internal static List<PaySplit> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<PaySplit> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<PaySplit> TableToList(DataTable table){
			List<PaySplit> retVal=new List<PaySplit>();
			PaySplit paySplit;
			for(int i=0;i<table.Rows.Count;i++) {
				paySplit=new PaySplit();
				paySplit.SplitNum    = PIn.Long  (table.Rows[i]["SplitNum"].ToString());
				paySplit.SplitAmt    = PIn.Double(table.Rows[i]["SplitAmt"].ToString());
				paySplit.PatNum      = PIn.Long  (table.Rows[i]["PatNum"].ToString());
				paySplit.ProcDate    = PIn.Date  (table.Rows[i]["ProcDate"].ToString());
				paySplit.PayNum      = PIn.Long  (table.Rows[i]["PayNum"].ToString());
				paySplit.IsDiscount  = PIn.Bool  (table.Rows[i]["IsDiscount"].ToString());
				paySplit.DiscountType= PIn.Byte  (table.Rows[i]["DiscountType"].ToString());
				paySplit.ProvNum     = PIn.Long  (table.Rows[i]["ProvNum"].ToString());
				paySplit.PayPlanNum  = PIn.Long  (table.Rows[i]["PayPlanNum"].ToString());
				paySplit.DatePay     = PIn.Date  (table.Rows[i]["DatePay"].ToString());
				paySplit.ProcNum     = PIn.Long  (table.Rows[i]["ProcNum"].ToString());
				paySplit.DateEntry   = PIn.Date  (table.Rows[i]["DateEntry"].ToString());
				paySplit.UnearnedType= PIn.Long  (table.Rows[i]["UnearnedType"].ToString());
				paySplit.ClinicNum   = PIn.Long  (table.Rows[i]["ClinicNum"].ToString());
				retVal.Add(paySplit);
			}
			return retVal;
		}

		///<summary>Inserts one PaySplit into the database.  Returns the new priKey.</summary>
		internal static long Insert(PaySplit paySplit){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				paySplit.SplitNum=DbHelper.GetNextOracleKey("paysplit","SplitNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(paySplit,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							paySplit.SplitNum++;
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
				return Insert(paySplit,false);
			}
		}

		///<summary>Inserts one PaySplit into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(PaySplit paySplit,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				paySplit.SplitNum=ReplicationServers.GetKey("paysplit","SplitNum");
			}
			string command="INSERT INTO paysplit (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="SplitNum,";
			}
			command+="SplitAmt,PatNum,ProcDate,PayNum,IsDiscount,DiscountType,ProvNum,PayPlanNum,DatePay,ProcNum,DateEntry,UnearnedType,ClinicNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(paySplit.SplitNum)+",";
			}
			command+=
				 "'"+POut.Double(paySplit.SplitAmt)+"',"
				+    POut.Long  (paySplit.PatNum)+","
				+    POut.Date  (paySplit.ProcDate)+","
				+    POut.Long  (paySplit.PayNum)+","
				+    POut.Bool  (paySplit.IsDiscount)+","
				+    POut.Byte  (paySplit.DiscountType)+","
				+    POut.Long  (paySplit.ProvNum)+","
				+    POut.Long  (paySplit.PayPlanNum)+","
				+    POut.Date  (paySplit.DatePay)+","
				+    POut.Long  (paySplit.ProcNum)+","
				+    DbHelper.Now()+","
				+    POut.Long  (paySplit.UnearnedType)+","
				+    POut.Long  (paySplit.ClinicNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				paySplit.SplitNum=Db.NonQ(command,true);
			}
			return paySplit.SplitNum;
		}

		///<summary>Updates one PaySplit in the database.</summary>
		internal static void Update(PaySplit paySplit){
			string command="UPDATE paysplit SET "
				+"SplitAmt    = '"+POut.Double(paySplit.SplitAmt)+"', "
				+"PatNum      =  "+POut.Long  (paySplit.PatNum)+", "
				+"ProcDate    =  "+POut.Date  (paySplit.ProcDate)+", "
				+"PayNum      =  "+POut.Long  (paySplit.PayNum)+", "
				+"IsDiscount  =  "+POut.Bool  (paySplit.IsDiscount)+", "
				+"DiscountType=  "+POut.Byte  (paySplit.DiscountType)+", "
				+"ProvNum     =  "+POut.Long  (paySplit.ProvNum)+", "
				+"PayPlanNum  =  "+POut.Long  (paySplit.PayPlanNum)+", "
				+"DatePay     =  "+POut.Date  (paySplit.DatePay)+", "
				+"ProcNum     =  "+POut.Long  (paySplit.ProcNum)+", "
				//DateEntry not allowed to change
				+"UnearnedType=  "+POut.Long  (paySplit.UnearnedType)+", "
				+"ClinicNum   =  "+POut.Long  (paySplit.ClinicNum)+" "
				+"WHERE SplitNum = "+POut.Long(paySplit.SplitNum);
			Db.NonQ(command);
		}

		///<summary>Updates one PaySplit in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(PaySplit paySplit,PaySplit oldPaySplit){
			string command="";
			if(paySplit.SplitAmt != oldPaySplit.SplitAmt) {
				if(command!=""){ command+=",";}
				command+="SplitAmt = '"+POut.Double(paySplit.SplitAmt)+"'";
			}
			if(paySplit.PatNum != oldPaySplit.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(paySplit.PatNum)+"";
			}
			if(paySplit.ProcDate != oldPaySplit.ProcDate) {
				if(command!=""){ command+=",";}
				command+="ProcDate = "+POut.Date(paySplit.ProcDate)+"";
			}
			if(paySplit.PayNum != oldPaySplit.PayNum) {
				if(command!=""){ command+=",";}
				command+="PayNum = "+POut.Long(paySplit.PayNum)+"";
			}
			if(paySplit.IsDiscount != oldPaySplit.IsDiscount) {
				if(command!=""){ command+=",";}
				command+="IsDiscount = "+POut.Bool(paySplit.IsDiscount)+"";
			}
			if(paySplit.DiscountType != oldPaySplit.DiscountType) {
				if(command!=""){ command+=",";}
				command+="DiscountType = "+POut.Byte(paySplit.DiscountType)+"";
			}
			if(paySplit.ProvNum != oldPaySplit.ProvNum) {
				if(command!=""){ command+=",";}
				command+="ProvNum = "+POut.Long(paySplit.ProvNum)+"";
			}
			if(paySplit.PayPlanNum != oldPaySplit.PayPlanNum) {
				if(command!=""){ command+=",";}
				command+="PayPlanNum = "+POut.Long(paySplit.PayPlanNum)+"";
			}
			if(paySplit.DatePay != oldPaySplit.DatePay) {
				if(command!=""){ command+=",";}
				command+="DatePay = "+POut.Date(paySplit.DatePay)+"";
			}
			if(paySplit.ProcNum != oldPaySplit.ProcNum) {
				if(command!=""){ command+=",";}
				command+="ProcNum = "+POut.Long(paySplit.ProcNum)+"";
			}
			//DateEntry not allowed to change
			if(paySplit.UnearnedType != oldPaySplit.UnearnedType) {
				if(command!=""){ command+=",";}
				command+="UnearnedType = "+POut.Long(paySplit.UnearnedType)+"";
			}
			if(paySplit.ClinicNum != oldPaySplit.ClinicNum) {
				if(command!=""){ command+=",";}
				command+="ClinicNum = "+POut.Long(paySplit.ClinicNum)+"";
			}
			if(command==""){
				return;
			}
			command="UPDATE paysplit SET "+command
				+" WHERE SplitNum = "+POut.Long(paySplit.SplitNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one PaySplit from the database.</summary>
		internal static void Delete(long splitNum){
			string command="DELETE FROM paysplit "
				+"WHERE SplitNum = "+POut.Long(splitNum);
			Db.NonQ(command);
		}

	}
}