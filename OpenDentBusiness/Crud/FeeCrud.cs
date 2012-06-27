//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class FeeCrud {
		///<summary>Gets one Fee object from the database using the primary key.  Returns null if not found.</summary>
		internal static Fee SelectOne(long feeNum){
			string command="SELECT * FROM fee "
				+"WHERE FeeNum = "+POut.Long(feeNum);
			List<Fee> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Fee object from the database using a query.</summary>
		internal static Fee SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Fee> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Fee objects from the database using a query.</summary>
		internal static List<Fee> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Fee> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<Fee> TableToList(DataTable table){
			List<Fee> retVal=new List<Fee>();
			Fee fee;
			for(int i=0;i<table.Rows.Count;i++) {
				fee=new Fee();
				fee.FeeNum       = PIn.Long  (table.Rows[i]["FeeNum"].ToString());
				fee.Amount       = PIn.Double(table.Rows[i]["Amount"].ToString());
				fee.OldCode      = PIn.String(table.Rows[i]["OldCode"].ToString());
				fee.FeeSched     = PIn.Long  (table.Rows[i]["FeeSched"].ToString());
				fee.UseDefaultFee= PIn.Bool  (table.Rows[i]["UseDefaultFee"].ToString());
				fee.UseDefaultCov= PIn.Bool  (table.Rows[i]["UseDefaultCov"].ToString());
				fee.CodeNum      = PIn.Long  (table.Rows[i]["CodeNum"].ToString());
				retVal.Add(fee);
			}
			return retVal;
		}

		///<summary>Inserts one Fee into the database.  Returns the new priKey.</summary>
		internal static long Insert(Fee fee){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				fee.FeeNum=DbHelper.GetNextOracleKey("fee","FeeNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(fee,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							fee.FeeNum++;
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
				return Insert(fee,false);
			}
		}

		///<summary>Inserts one Fee into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(Fee fee,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				fee.FeeNum=ReplicationServers.GetKey("fee","FeeNum");
			}
			string command="INSERT INTO fee (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="FeeNum,";
			}
			command+="Amount,OldCode,FeeSched,UseDefaultFee,UseDefaultCov,CodeNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(fee.FeeNum)+",";
			}
			command+=
				 "'"+POut.Double(fee.Amount)+"',"
				+"'"+POut.String(fee.OldCode)+"',"
				+    POut.Long  (fee.FeeSched)+","
				+    POut.Bool  (fee.UseDefaultFee)+","
				+    POut.Bool  (fee.UseDefaultCov)+","
				+    POut.Long  (fee.CodeNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				fee.FeeNum=Db.NonQ(command,true);
			}
			return fee.FeeNum;
		}

		///<summary>Updates one Fee in the database.</summary>
		internal static void Update(Fee fee){
			string command="UPDATE fee SET "
				+"Amount       = '"+POut.Double(fee.Amount)+"', "
				+"OldCode      = '"+POut.String(fee.OldCode)+"', "
				+"FeeSched     =  "+POut.Long  (fee.FeeSched)+", "
				+"UseDefaultFee=  "+POut.Bool  (fee.UseDefaultFee)+", "
				+"UseDefaultCov=  "+POut.Bool  (fee.UseDefaultCov)+", "
				+"CodeNum      =  "+POut.Long  (fee.CodeNum)+" "
				+"WHERE FeeNum = "+POut.Long(fee.FeeNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Fee in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(Fee fee,Fee oldFee){
			string command="";
			if(fee.Amount != oldFee.Amount) {
				if(command!=""){ command+=",";}
				command+="Amount = '"+POut.Double(fee.Amount)+"'";
			}
			if(fee.OldCode != oldFee.OldCode) {
				if(command!=""){ command+=",";}
				command+="OldCode = '"+POut.String(fee.OldCode)+"'";
			}
			if(fee.FeeSched != oldFee.FeeSched) {
				if(command!=""){ command+=",";}
				command+="FeeSched = "+POut.Long(fee.FeeSched)+"";
			}
			if(fee.UseDefaultFee != oldFee.UseDefaultFee) {
				if(command!=""){ command+=",";}
				command+="UseDefaultFee = "+POut.Bool(fee.UseDefaultFee)+"";
			}
			if(fee.UseDefaultCov != oldFee.UseDefaultCov) {
				if(command!=""){ command+=",";}
				command+="UseDefaultCov = "+POut.Bool(fee.UseDefaultCov)+"";
			}
			if(fee.CodeNum != oldFee.CodeNum) {
				if(command!=""){ command+=",";}
				command+="CodeNum = "+POut.Long(fee.CodeNum)+"";
			}
			if(command==""){
				return;
			}
			command="UPDATE fee SET "+command
				+" WHERE FeeNum = "+POut.Long(fee.FeeNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one Fee from the database.</summary>
		internal static void Delete(long feeNum){
			string command="DELETE FROM fee "
				+"WHERE FeeNum = "+POut.Long(feeNum);
			Db.NonQ(command);
		}

	}
}