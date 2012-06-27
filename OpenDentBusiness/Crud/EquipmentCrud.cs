//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class EquipmentCrud {
		///<summary>Gets one Equipment object from the database using the primary key.  Returns null if not found.</summary>
		internal static Equipment SelectOne(long equipmentNum){
			string command="SELECT * FROM equipment "
				+"WHERE EquipmentNum = "+POut.Long(equipmentNum);
			List<Equipment> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Equipment object from the database using a query.</summary>
		internal static Equipment SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Equipment> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Equipment objects from the database using a query.</summary>
		internal static List<Equipment> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Equipment> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<Equipment> TableToList(DataTable table){
			List<Equipment> retVal=new List<Equipment>();
			Equipment equipment;
			for(int i=0;i<table.Rows.Count;i++) {
				equipment=new Equipment();
				equipment.EquipmentNum = PIn.Long  (table.Rows[i]["EquipmentNum"].ToString());
				equipment.Description  = PIn.String(table.Rows[i]["Description"].ToString());
				equipment.SerialNumber = PIn.String(table.Rows[i]["SerialNumber"].ToString());
				equipment.ModelYear    = PIn.String(table.Rows[i]["ModelYear"].ToString());
				equipment.DatePurchased= PIn.Date  (table.Rows[i]["DatePurchased"].ToString());
				equipment.DateSold     = PIn.Date  (table.Rows[i]["DateSold"].ToString());
				equipment.PurchaseCost = PIn.Double(table.Rows[i]["PurchaseCost"].ToString());
				equipment.MarketValue  = PIn.Double(table.Rows[i]["MarketValue"].ToString());
				equipment.Location     = PIn.String(table.Rows[i]["Location"].ToString());
				equipment.DateEntry    = PIn.Date  (table.Rows[i]["DateEntry"].ToString());
				retVal.Add(equipment);
			}
			return retVal;
		}

		///<summary>Inserts one Equipment into the database.  Returns the new priKey.</summary>
		internal static long Insert(Equipment equipment){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				equipment.EquipmentNum=DbHelper.GetNextOracleKey("equipment","EquipmentNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(equipment,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							equipment.EquipmentNum++;
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
				return Insert(equipment,false);
			}
		}

		///<summary>Inserts one Equipment into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(Equipment equipment,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				equipment.EquipmentNum=ReplicationServers.GetKey("equipment","EquipmentNum");
			}
			string command="INSERT INTO equipment (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EquipmentNum,";
			}
			command+="Description,SerialNumber,ModelYear,DatePurchased,DateSold,PurchaseCost,MarketValue,Location,DateEntry) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(equipment.EquipmentNum)+",";
			}
			command+=
				 "'"+POut.String(equipment.Description)+"',"
				+"'"+POut.String(equipment.SerialNumber)+"',"
				+"'"+POut.String(equipment.ModelYear)+"',"
				+    POut.Date  (equipment.DatePurchased)+","
				+    POut.Date  (equipment.DateSold)+","
				+"'"+POut.Double(equipment.PurchaseCost)+"',"
				+"'"+POut.Double(equipment.MarketValue)+"',"
				+"'"+POut.String(equipment.Location)+"',"
				+    POut.Date  (equipment.DateEntry)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				equipment.EquipmentNum=Db.NonQ(command,true);
			}
			return equipment.EquipmentNum;
		}

		///<summary>Updates one Equipment in the database.</summary>
		internal static void Update(Equipment equipment){
			string command="UPDATE equipment SET "
				+"Description  = '"+POut.String(equipment.Description)+"', "
				+"SerialNumber = '"+POut.String(equipment.SerialNumber)+"', "
				+"ModelYear    = '"+POut.String(equipment.ModelYear)+"', "
				+"DatePurchased=  "+POut.Date  (equipment.DatePurchased)+", "
				+"DateSold     =  "+POut.Date  (equipment.DateSold)+", "
				+"PurchaseCost = '"+POut.Double(equipment.PurchaseCost)+"', "
				+"MarketValue  = '"+POut.Double(equipment.MarketValue)+"', "
				+"Location     = '"+POut.String(equipment.Location)+"', "
				+"DateEntry    =  "+POut.Date  (equipment.DateEntry)+" "
				+"WHERE EquipmentNum = "+POut.Long(equipment.EquipmentNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Equipment in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(Equipment equipment,Equipment oldEquipment){
			string command="";
			if(equipment.Description != oldEquipment.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(equipment.Description)+"'";
			}
			if(equipment.SerialNumber != oldEquipment.SerialNumber) {
				if(command!=""){ command+=",";}
				command+="SerialNumber = '"+POut.String(equipment.SerialNumber)+"'";
			}
			if(equipment.ModelYear != oldEquipment.ModelYear) {
				if(command!=""){ command+=",";}
				command+="ModelYear = '"+POut.String(equipment.ModelYear)+"'";
			}
			if(equipment.DatePurchased != oldEquipment.DatePurchased) {
				if(command!=""){ command+=",";}
				command+="DatePurchased = "+POut.Date(equipment.DatePurchased)+"";
			}
			if(equipment.DateSold != oldEquipment.DateSold) {
				if(command!=""){ command+=",";}
				command+="DateSold = "+POut.Date(equipment.DateSold)+"";
			}
			if(equipment.PurchaseCost != oldEquipment.PurchaseCost) {
				if(command!=""){ command+=",";}
				command+="PurchaseCost = '"+POut.Double(equipment.PurchaseCost)+"'";
			}
			if(equipment.MarketValue != oldEquipment.MarketValue) {
				if(command!=""){ command+=",";}
				command+="MarketValue = '"+POut.Double(equipment.MarketValue)+"'";
			}
			if(equipment.Location != oldEquipment.Location) {
				if(command!=""){ command+=",";}
				command+="Location = '"+POut.String(equipment.Location)+"'";
			}
			if(equipment.DateEntry != oldEquipment.DateEntry) {
				if(command!=""){ command+=",";}
				command+="DateEntry = "+POut.Date(equipment.DateEntry)+"";
			}
			if(command==""){
				return;
			}
			command="UPDATE equipment SET "+command
				+" WHERE EquipmentNum = "+POut.Long(equipment.EquipmentNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one Equipment from the database.</summary>
		internal static void Delete(long equipmentNum){
			string command="DELETE FROM equipment "
				+"WHERE EquipmentNum = "+POut.Long(equipmentNum);
			Db.NonQ(command);
		}

	}
}