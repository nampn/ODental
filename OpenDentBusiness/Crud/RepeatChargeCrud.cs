//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class RepeatChargeCrud {
		///<summary>Gets one RepeatCharge object from the database using the primary key.  Returns null if not found.</summary>
		internal static RepeatCharge SelectOne(long repeatChargeNum){
			string command="SELECT * FROM repeatcharge "
				+"WHERE RepeatChargeNum = "+POut.Long(repeatChargeNum);
			List<RepeatCharge> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one RepeatCharge object from the database using a query.</summary>
		internal static RepeatCharge SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<RepeatCharge> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of RepeatCharge objects from the database using a query.</summary>
		internal static List<RepeatCharge> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<RepeatCharge> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<RepeatCharge> TableToList(DataTable table){
			List<RepeatCharge> retVal=new List<RepeatCharge>();
			RepeatCharge repeatCharge;
			for(int i=0;i<table.Rows.Count;i++) {
				repeatCharge=new RepeatCharge();
				repeatCharge.RepeatChargeNum= PIn.Long  (table.Rows[i]["RepeatChargeNum"].ToString());
				repeatCharge.PatNum         = PIn.Long  (table.Rows[i]["PatNum"].ToString());
				repeatCharge.ProcCode       = PIn.String(table.Rows[i]["ProcCode"].ToString());
				repeatCharge.ChargeAmt      = PIn.Double(table.Rows[i]["ChargeAmt"].ToString());
				repeatCharge.DateStart      = PIn.Date  (table.Rows[i]["DateStart"].ToString());
				repeatCharge.DateStop       = PIn.Date  (table.Rows[i]["DateStop"].ToString());
				repeatCharge.Note           = PIn.String(table.Rows[i]["Note"].ToString());
				retVal.Add(repeatCharge);
			}
			return retVal;
		}

		///<summary>Inserts one RepeatCharge into the database.  Returns the new priKey.</summary>
		internal static long Insert(RepeatCharge repeatCharge){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				repeatCharge.RepeatChargeNum=DbHelper.GetNextOracleKey("repeatcharge","RepeatChargeNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(repeatCharge,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							repeatCharge.RepeatChargeNum++;
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
				return Insert(repeatCharge,false);
			}
		}

		///<summary>Inserts one RepeatCharge into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(RepeatCharge repeatCharge,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				repeatCharge.RepeatChargeNum=ReplicationServers.GetKey("repeatcharge","RepeatChargeNum");
			}
			string command="INSERT INTO repeatcharge (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="RepeatChargeNum,";
			}
			command+="PatNum,ProcCode,ChargeAmt,DateStart,DateStop,Note) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(repeatCharge.RepeatChargeNum)+",";
			}
			command+=
				     POut.Long  (repeatCharge.PatNum)+","
				+"'"+POut.String(repeatCharge.ProcCode)+"',"
				+"'"+POut.Double(repeatCharge.ChargeAmt)+"',"
				+    POut.Date  (repeatCharge.DateStart)+","
				+    POut.Date  (repeatCharge.DateStop)+","
				+"'"+POut.String(repeatCharge.Note)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				repeatCharge.RepeatChargeNum=Db.NonQ(command,true);
			}
			return repeatCharge.RepeatChargeNum;
		}

		///<summary>Updates one RepeatCharge in the database.</summary>
		internal static void Update(RepeatCharge repeatCharge){
			string command="UPDATE repeatcharge SET "
				+"PatNum         =  "+POut.Long  (repeatCharge.PatNum)+", "
				+"ProcCode       = '"+POut.String(repeatCharge.ProcCode)+"', "
				+"ChargeAmt      = '"+POut.Double(repeatCharge.ChargeAmt)+"', "
				+"DateStart      =  "+POut.Date  (repeatCharge.DateStart)+", "
				+"DateStop       =  "+POut.Date  (repeatCharge.DateStop)+", "
				+"Note           = '"+POut.String(repeatCharge.Note)+"' "
				+"WHERE RepeatChargeNum = "+POut.Long(repeatCharge.RepeatChargeNum);
			Db.NonQ(command);
		}

		///<summary>Updates one RepeatCharge in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(RepeatCharge repeatCharge,RepeatCharge oldRepeatCharge){
			string command="";
			if(repeatCharge.PatNum != oldRepeatCharge.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(repeatCharge.PatNum)+"";
			}
			if(repeatCharge.ProcCode != oldRepeatCharge.ProcCode) {
				if(command!=""){ command+=",";}
				command+="ProcCode = '"+POut.String(repeatCharge.ProcCode)+"'";
			}
			if(repeatCharge.ChargeAmt != oldRepeatCharge.ChargeAmt) {
				if(command!=""){ command+=",";}
				command+="ChargeAmt = '"+POut.Double(repeatCharge.ChargeAmt)+"'";
			}
			if(repeatCharge.DateStart != oldRepeatCharge.DateStart) {
				if(command!=""){ command+=",";}
				command+="DateStart = "+POut.Date(repeatCharge.DateStart)+"";
			}
			if(repeatCharge.DateStop != oldRepeatCharge.DateStop) {
				if(command!=""){ command+=",";}
				command+="DateStop = "+POut.Date(repeatCharge.DateStop)+"";
			}
			if(repeatCharge.Note != oldRepeatCharge.Note) {
				if(command!=""){ command+=",";}
				command+="Note = '"+POut.String(repeatCharge.Note)+"'";
			}
			if(command==""){
				return;
			}
			command="UPDATE repeatcharge SET "+command
				+" WHERE RepeatChargeNum = "+POut.Long(repeatCharge.RepeatChargeNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one RepeatCharge from the database.</summary>
		internal static void Delete(long repeatChargeNum){
			string command="DELETE FROM repeatcharge "
				+"WHERE RepeatChargeNum = "+POut.Long(repeatChargeNum);
			Db.NonQ(command);
		}

	}
}