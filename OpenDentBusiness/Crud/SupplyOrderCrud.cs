//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class SupplyOrderCrud {
		///<summary>Gets one SupplyOrder object from the database using the primary key.  Returns null if not found.</summary>
		internal static SupplyOrder SelectOne(long supplyOrderNum){
			string command="SELECT * FROM supplyorder "
				+"WHERE SupplyOrderNum = "+POut.Long(supplyOrderNum);
			List<SupplyOrder> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one SupplyOrder object from the database using a query.</summary>
		internal static SupplyOrder SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SupplyOrder> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of SupplyOrder objects from the database using a query.</summary>
		internal static List<SupplyOrder> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SupplyOrder> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<SupplyOrder> TableToList(DataTable table){
			List<SupplyOrder> retVal=new List<SupplyOrder>();
			SupplyOrder supplyOrder;
			for(int i=0;i<table.Rows.Count;i++) {
				supplyOrder=new SupplyOrder();
				supplyOrder.SupplyOrderNum= PIn.Long  (table.Rows[i]["SupplyOrderNum"].ToString());
				supplyOrder.SupplierNum   = PIn.Long  (table.Rows[i]["SupplierNum"].ToString());
				supplyOrder.DatePlaced    = PIn.Date  (table.Rows[i]["DatePlaced"].ToString());
				supplyOrder.Note          = PIn.String(table.Rows[i]["Note"].ToString());
				supplyOrder.AmountTotal   = PIn.Double(table.Rows[i]["AmountTotal"].ToString());
				retVal.Add(supplyOrder);
			}
			return retVal;
		}

		///<summary>Inserts one SupplyOrder into the database.  Returns the new priKey.</summary>
		internal static long Insert(SupplyOrder supplyOrder){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				supplyOrder.SupplyOrderNum=DbHelper.GetNextOracleKey("supplyorder","SupplyOrderNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(supplyOrder,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							supplyOrder.SupplyOrderNum++;
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
				return Insert(supplyOrder,false);
			}
		}

		///<summary>Inserts one SupplyOrder into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(SupplyOrder supplyOrder,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				supplyOrder.SupplyOrderNum=ReplicationServers.GetKey("supplyorder","SupplyOrderNum");
			}
			string command="INSERT INTO supplyorder (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="SupplyOrderNum,";
			}
			command+="SupplierNum,DatePlaced,Note,AmountTotal) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(supplyOrder.SupplyOrderNum)+",";
			}
			command+=
				     POut.Long  (supplyOrder.SupplierNum)+","
				+    POut.Date  (supplyOrder.DatePlaced)+","
				+"'"+POut.String(supplyOrder.Note)+"',"
				+"'"+POut.Double(supplyOrder.AmountTotal)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				supplyOrder.SupplyOrderNum=Db.NonQ(command,true);
			}
			return supplyOrder.SupplyOrderNum;
		}

		///<summary>Updates one SupplyOrder in the database.</summary>
		internal static void Update(SupplyOrder supplyOrder){
			string command="UPDATE supplyorder SET "
				+"SupplierNum   =  "+POut.Long  (supplyOrder.SupplierNum)+", "
				+"DatePlaced    =  "+POut.Date  (supplyOrder.DatePlaced)+", "
				+"Note          = '"+POut.String(supplyOrder.Note)+"', "
				+"AmountTotal   = '"+POut.Double(supplyOrder.AmountTotal)+"' "
				+"WHERE SupplyOrderNum = "+POut.Long(supplyOrder.SupplyOrderNum);
			Db.NonQ(command);
		}

		///<summary>Updates one SupplyOrder in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(SupplyOrder supplyOrder,SupplyOrder oldSupplyOrder){
			string command="";
			if(supplyOrder.SupplierNum != oldSupplyOrder.SupplierNum) {
				if(command!=""){ command+=",";}
				command+="SupplierNum = "+POut.Long(supplyOrder.SupplierNum)+"";
			}
			if(supplyOrder.DatePlaced != oldSupplyOrder.DatePlaced) {
				if(command!=""){ command+=",";}
				command+="DatePlaced = "+POut.Date(supplyOrder.DatePlaced)+"";
			}
			if(supplyOrder.Note != oldSupplyOrder.Note) {
				if(command!=""){ command+=",";}
				command+="Note = '"+POut.String(supplyOrder.Note)+"'";
			}
			if(supplyOrder.AmountTotal != oldSupplyOrder.AmountTotal) {
				if(command!=""){ command+=",";}
				command+="AmountTotal = '"+POut.Double(supplyOrder.AmountTotal)+"'";
			}
			if(command==""){
				return;
			}
			command="UPDATE supplyorder SET "+command
				+" WHERE SupplyOrderNum = "+POut.Long(supplyOrder.SupplyOrderNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one SupplyOrder from the database.</summary>
		internal static void Delete(long supplyOrderNum){
			string command="DELETE FROM supplyorder "
				+"WHERE SupplyOrderNum = "+POut.Long(supplyOrderNum);
			Db.NonQ(command);
		}

	}
}