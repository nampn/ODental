//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class OperatoryCrud {
		///<summary>Gets one Operatory object from the database using the primary key.  Returns null if not found.</summary>
		internal static Operatory SelectOne(long operatoryNum){
			string command="SELECT * FROM operatory "
				+"WHERE OperatoryNum = "+POut.Long(operatoryNum);
			List<Operatory> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Operatory object from the database using a query.</summary>
		internal static Operatory SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Operatory> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Operatory objects from the database using a query.</summary>
		internal static List<Operatory> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Operatory> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<Operatory> TableToList(DataTable table){
			List<Operatory> retVal=new List<Operatory>();
			Operatory operatory;
			for(int i=0;i<table.Rows.Count;i++) {
				operatory=new Operatory();
				operatory.OperatoryNum  = PIn.Long  (table.Rows[i]["OperatoryNum"].ToString());
				operatory.OpName        = PIn.String(table.Rows[i]["OpName"].ToString());
				operatory.Abbrev        = PIn.String(table.Rows[i]["Abbrev"].ToString());
				operatory.ItemOrder     = PIn.Int   (table.Rows[i]["ItemOrder"].ToString());
				operatory.IsHidden      = PIn.Bool  (table.Rows[i]["IsHidden"].ToString());
				operatory.ProvDentist   = PIn.Long  (table.Rows[i]["ProvDentist"].ToString());
				operatory.ProvHygienist = PIn.Long  (table.Rows[i]["ProvHygienist"].ToString());
				operatory.IsHygiene     = PIn.Bool  (table.Rows[i]["IsHygiene"].ToString());
				operatory.ClinicNum     = PIn.Long  (table.Rows[i]["ClinicNum"].ToString());
				operatory.SetProspective= PIn.Bool  (table.Rows[i]["SetProspective"].ToString());
				retVal.Add(operatory);
			}
			return retVal;
		}

		///<summary>Inserts one Operatory into the database.  Returns the new priKey.</summary>
		internal static long Insert(Operatory operatory){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				operatory.OperatoryNum=DbHelper.GetNextOracleKey("operatory","OperatoryNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(operatory,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							operatory.OperatoryNum++;
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
				return Insert(operatory,false);
			}
		}

		///<summary>Inserts one Operatory into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(Operatory operatory,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				operatory.OperatoryNum=ReplicationServers.GetKey("operatory","OperatoryNum");
			}
			string command="INSERT INTO operatory (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="OperatoryNum,";
			}
			command+="OpName,Abbrev,ItemOrder,IsHidden,ProvDentist,ProvHygienist,IsHygiene,ClinicNum,SetProspective) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(operatory.OperatoryNum)+",";
			}
			command+=
				 "'"+POut.String(operatory.OpName)+"',"
				+"'"+POut.String(operatory.Abbrev)+"',"
				+    POut.Int   (operatory.ItemOrder)+","
				+    POut.Bool  (operatory.IsHidden)+","
				+    POut.Long  (operatory.ProvDentist)+","
				+    POut.Long  (operatory.ProvHygienist)+","
				+    POut.Bool  (operatory.IsHygiene)+","
				+    POut.Long  (operatory.ClinicNum)+","
				+    POut.Bool  (operatory.SetProspective)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				operatory.OperatoryNum=Db.NonQ(command,true);
			}
			return operatory.OperatoryNum;
		}

		///<summary>Updates one Operatory in the database.</summary>
		internal static void Update(Operatory operatory){
			string command="UPDATE operatory SET "
				+"OpName        = '"+POut.String(operatory.OpName)+"', "
				+"Abbrev        = '"+POut.String(operatory.Abbrev)+"', "
				+"ItemOrder     =  "+POut.Int   (operatory.ItemOrder)+", "
				+"IsHidden      =  "+POut.Bool  (operatory.IsHidden)+", "
				+"ProvDentist   =  "+POut.Long  (operatory.ProvDentist)+", "
				+"ProvHygienist =  "+POut.Long  (operatory.ProvHygienist)+", "
				+"IsHygiene     =  "+POut.Bool  (operatory.IsHygiene)+", "
				+"ClinicNum     =  "+POut.Long  (operatory.ClinicNum)+", "
				+"SetProspective=  "+POut.Bool  (operatory.SetProspective)+" "
				+"WHERE OperatoryNum = "+POut.Long(operatory.OperatoryNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Operatory in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(Operatory operatory,Operatory oldOperatory){
			string command="";
			if(operatory.OpName != oldOperatory.OpName) {
				if(command!=""){ command+=",";}
				command+="OpName = '"+POut.String(operatory.OpName)+"'";
			}
			if(operatory.Abbrev != oldOperatory.Abbrev) {
				if(command!=""){ command+=",";}
				command+="Abbrev = '"+POut.String(operatory.Abbrev)+"'";
			}
			if(operatory.ItemOrder != oldOperatory.ItemOrder) {
				if(command!=""){ command+=",";}
				command+="ItemOrder = "+POut.Int(operatory.ItemOrder)+"";
			}
			if(operatory.IsHidden != oldOperatory.IsHidden) {
				if(command!=""){ command+=",";}
				command+="IsHidden = "+POut.Bool(operatory.IsHidden)+"";
			}
			if(operatory.ProvDentist != oldOperatory.ProvDentist) {
				if(command!=""){ command+=",";}
				command+="ProvDentist = "+POut.Long(operatory.ProvDentist)+"";
			}
			if(operatory.ProvHygienist != oldOperatory.ProvHygienist) {
				if(command!=""){ command+=",";}
				command+="ProvHygienist = "+POut.Long(operatory.ProvHygienist)+"";
			}
			if(operatory.IsHygiene != oldOperatory.IsHygiene) {
				if(command!=""){ command+=",";}
				command+="IsHygiene = "+POut.Bool(operatory.IsHygiene)+"";
			}
			if(operatory.ClinicNum != oldOperatory.ClinicNum) {
				if(command!=""){ command+=",";}
				command+="ClinicNum = "+POut.Long(operatory.ClinicNum)+"";
			}
			if(operatory.SetProspective != oldOperatory.SetProspective) {
				if(command!=""){ command+=",";}
				command+="SetProspective = "+POut.Bool(operatory.SetProspective)+"";
			}
			if(command==""){
				return;
			}
			command="UPDATE operatory SET "+command
				+" WHERE OperatoryNum = "+POut.Long(operatory.OperatoryNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one Operatory from the database.</summary>
		internal static void Delete(long operatoryNum){
			string command="DELETE FROM operatory "
				+"WHERE OperatoryNum = "+POut.Long(operatoryNum);
			Db.NonQ(command);
		}

	}
}