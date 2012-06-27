//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class DiseaseDefCrud {
		///<summary>Gets one DiseaseDef object from the database using the primary key.  Returns null if not found.</summary>
		internal static DiseaseDef SelectOne(long diseaseDefNum){
			string command="SELECT * FROM diseasedef "
				+"WHERE DiseaseDefNum = "+POut.Long(diseaseDefNum);
			List<DiseaseDef> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one DiseaseDef object from the database using a query.</summary>
		internal static DiseaseDef SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<DiseaseDef> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of DiseaseDef objects from the database using a query.</summary>
		internal static List<DiseaseDef> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<DiseaseDef> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<DiseaseDef> TableToList(DataTable table){
			List<DiseaseDef> retVal=new List<DiseaseDef>();
			DiseaseDef diseaseDef;
			for(int i=0;i<table.Rows.Count;i++) {
				diseaseDef=new DiseaseDef();
				diseaseDef.DiseaseDefNum= PIn.Long  (table.Rows[i]["DiseaseDefNum"].ToString());
				diseaseDef.DiseaseName  = PIn.String(table.Rows[i]["DiseaseName"].ToString());
				diseaseDef.ItemOrder    = PIn.Int   (table.Rows[i]["ItemOrder"].ToString());
				diseaseDef.IsHidden     = PIn.Bool  (table.Rows[i]["IsHidden"].ToString());
				diseaseDef.DateTStamp   = PIn.DateT (table.Rows[i]["DateTStamp"].ToString());
				retVal.Add(diseaseDef);
			}
			return retVal;
		}

		///<summary>Inserts one DiseaseDef into the database.  Returns the new priKey.</summary>
		internal static long Insert(DiseaseDef diseaseDef){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				diseaseDef.DiseaseDefNum=DbHelper.GetNextOracleKey("diseasedef","DiseaseDefNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(diseaseDef,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							diseaseDef.DiseaseDefNum++;
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
				return Insert(diseaseDef,false);
			}
		}

		///<summary>Inserts one DiseaseDef into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(DiseaseDef diseaseDef,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				diseaseDef.DiseaseDefNum=ReplicationServers.GetKey("diseasedef","DiseaseDefNum");
			}
			string command="INSERT INTO diseasedef (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="DiseaseDefNum,";
			}
			command+="DiseaseName,ItemOrder,IsHidden) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(diseaseDef.DiseaseDefNum)+",";
			}
			command+=
				 "'"+POut.String(diseaseDef.DiseaseName)+"',"
				+    POut.Int   (diseaseDef.ItemOrder)+","
				+    POut.Bool  (diseaseDef.IsHidden)+")";
				//DateTStamp can only be set by MySQL
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				diseaseDef.DiseaseDefNum=Db.NonQ(command,true);
			}
			return diseaseDef.DiseaseDefNum;
		}

		///<summary>Updates one DiseaseDef in the database.</summary>
		internal static void Update(DiseaseDef diseaseDef){
			string command="UPDATE diseasedef SET "
				+"DiseaseName  = '"+POut.String(diseaseDef.DiseaseName)+"', "
				+"ItemOrder    =  "+POut.Int   (diseaseDef.ItemOrder)+", "
				+"IsHidden     =  "+POut.Bool  (diseaseDef.IsHidden)+" "
				//DateTStamp can only be set by MySQL
				+"WHERE DiseaseDefNum = "+POut.Long(diseaseDef.DiseaseDefNum);
			Db.NonQ(command);
		}

		///<summary>Updates one DiseaseDef in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(DiseaseDef diseaseDef,DiseaseDef oldDiseaseDef){
			string command="";
			if(diseaseDef.DiseaseName != oldDiseaseDef.DiseaseName) {
				if(command!=""){ command+=",";}
				command+="DiseaseName = '"+POut.String(diseaseDef.DiseaseName)+"'";
			}
			if(diseaseDef.ItemOrder != oldDiseaseDef.ItemOrder) {
				if(command!=""){ command+=",";}
				command+="ItemOrder = "+POut.Int(diseaseDef.ItemOrder)+"";
			}
			if(diseaseDef.IsHidden != oldDiseaseDef.IsHidden) {
				if(command!=""){ command+=",";}
				command+="IsHidden = "+POut.Bool(diseaseDef.IsHidden)+"";
			}
			//DateTStamp can only be set by MySQL
			if(command==""){
				return;
			}
			command="UPDATE diseasedef SET "+command
				+" WHERE DiseaseDefNum = "+POut.Long(diseaseDef.DiseaseDefNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one DiseaseDef from the database.</summary>
		internal static void Delete(long diseaseDefNum){
			string command="DELETE FROM diseasedef "
				+"WHERE DiseaseDefNum = "+POut.Long(diseaseDefNum);
			Db.NonQ(command);
		}

	}
}