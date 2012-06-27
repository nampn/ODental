//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class VaccinePatCrud {
		///<summary>Gets one VaccinePat object from the database using the primary key.  Returns null if not found.</summary>
		internal static VaccinePat SelectOne(long vaccinePatNum){
			string command="SELECT * FROM vaccinepat "
				+"WHERE VaccinePatNum = "+POut.Long(vaccinePatNum);
			List<VaccinePat> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one VaccinePat object from the database using a query.</summary>
		internal static VaccinePat SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<VaccinePat> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of VaccinePat objects from the database using a query.</summary>
		internal static List<VaccinePat> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<VaccinePat> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<VaccinePat> TableToList(DataTable table){
			List<VaccinePat> retVal=new List<VaccinePat>();
			VaccinePat vaccinePat;
			for(int i=0;i<table.Rows.Count;i++) {
				vaccinePat=new VaccinePat();
				vaccinePat.VaccinePatNum  = PIn.Long  (table.Rows[i]["VaccinePatNum"].ToString());
				vaccinePat.VaccineDefNum  = PIn.Long  (table.Rows[i]["VaccineDefNum"].ToString());
				vaccinePat.DateTimeStart  = PIn.DateT (table.Rows[i]["DateTimeStart"].ToString());
				vaccinePat.DateTimeEnd    = PIn.DateT (table.Rows[i]["DateTimeEnd"].ToString());
				vaccinePat.AdministeredAmt= PIn.Float (table.Rows[i]["AdministeredAmt"].ToString());
				vaccinePat.DrugUnitNum    = PIn.Long  (table.Rows[i]["DrugUnitNum"].ToString());
				vaccinePat.LotNumber      = PIn.String(table.Rows[i]["LotNumber"].ToString());
				vaccinePat.PatNum         = PIn.Long  (table.Rows[i]["PatNum"].ToString());
				vaccinePat.NotGiven       = PIn.Bool  (table.Rows[i]["NotGiven"].ToString());
				vaccinePat.Note           = PIn.String(table.Rows[i]["Note"].ToString());
				retVal.Add(vaccinePat);
			}
			return retVal;
		}

		///<summary>Inserts one VaccinePat into the database.  Returns the new priKey.</summary>
		internal static long Insert(VaccinePat vaccinePat){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				vaccinePat.VaccinePatNum=DbHelper.GetNextOracleKey("vaccinepat","VaccinePatNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(vaccinePat,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							vaccinePat.VaccinePatNum++;
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
				return Insert(vaccinePat,false);
			}
		}

		///<summary>Inserts one VaccinePat into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(VaccinePat vaccinePat,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				vaccinePat.VaccinePatNum=ReplicationServers.GetKey("vaccinepat","VaccinePatNum");
			}
			string command="INSERT INTO vaccinepat (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="VaccinePatNum,";
			}
			command+="VaccineDefNum,DateTimeStart,DateTimeEnd,AdministeredAmt,DrugUnitNum,LotNumber,PatNum,NotGiven,Note) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(vaccinePat.VaccinePatNum)+",";
			}
			command+=
				     POut.Long  (vaccinePat.VaccineDefNum)+","
				+    POut.DateT (vaccinePat.DateTimeStart)+","
				+    POut.DateT (vaccinePat.DateTimeEnd)+","
				+    POut.Float (vaccinePat.AdministeredAmt)+","
				+    POut.Long  (vaccinePat.DrugUnitNum)+","
				+"'"+POut.String(vaccinePat.LotNumber)+"',"
				+    POut.Long  (vaccinePat.PatNum)+","
				+    POut.Bool  (vaccinePat.NotGiven)+","
				+"'"+POut.String(vaccinePat.Note)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				vaccinePat.VaccinePatNum=Db.NonQ(command,true);
			}
			return vaccinePat.VaccinePatNum;
		}

		///<summary>Updates one VaccinePat in the database.</summary>
		internal static void Update(VaccinePat vaccinePat){
			string command="UPDATE vaccinepat SET "
				+"VaccineDefNum  =  "+POut.Long  (vaccinePat.VaccineDefNum)+", "
				+"DateTimeStart  =  "+POut.DateT (vaccinePat.DateTimeStart)+", "
				+"DateTimeEnd    =  "+POut.DateT (vaccinePat.DateTimeEnd)+", "
				+"AdministeredAmt=  "+POut.Float (vaccinePat.AdministeredAmt)+", "
				+"DrugUnitNum    =  "+POut.Long  (vaccinePat.DrugUnitNum)+", "
				+"LotNumber      = '"+POut.String(vaccinePat.LotNumber)+"', "
				+"PatNum         =  "+POut.Long  (vaccinePat.PatNum)+", "
				+"NotGiven       =  "+POut.Bool  (vaccinePat.NotGiven)+", "
				+"Note           = '"+POut.String(vaccinePat.Note)+"' "
				+"WHERE VaccinePatNum = "+POut.Long(vaccinePat.VaccinePatNum);
			Db.NonQ(command);
		}

		///<summary>Updates one VaccinePat in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(VaccinePat vaccinePat,VaccinePat oldVaccinePat){
			string command="";
			if(vaccinePat.VaccineDefNum != oldVaccinePat.VaccineDefNum) {
				if(command!=""){ command+=",";}
				command+="VaccineDefNum = "+POut.Long(vaccinePat.VaccineDefNum)+"";
			}
			if(vaccinePat.DateTimeStart != oldVaccinePat.DateTimeStart) {
				if(command!=""){ command+=",";}
				command+="DateTimeStart = "+POut.DateT(vaccinePat.DateTimeStart)+"";
			}
			if(vaccinePat.DateTimeEnd != oldVaccinePat.DateTimeEnd) {
				if(command!=""){ command+=",";}
				command+="DateTimeEnd = "+POut.DateT(vaccinePat.DateTimeEnd)+"";
			}
			if(vaccinePat.AdministeredAmt != oldVaccinePat.AdministeredAmt) {
				if(command!=""){ command+=",";}
				command+="AdministeredAmt = "+POut.Float(vaccinePat.AdministeredAmt)+"";
			}
			if(vaccinePat.DrugUnitNum != oldVaccinePat.DrugUnitNum) {
				if(command!=""){ command+=",";}
				command+="DrugUnitNum = "+POut.Long(vaccinePat.DrugUnitNum)+"";
			}
			if(vaccinePat.LotNumber != oldVaccinePat.LotNumber) {
				if(command!=""){ command+=",";}
				command+="LotNumber = '"+POut.String(vaccinePat.LotNumber)+"'";
			}
			if(vaccinePat.PatNum != oldVaccinePat.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(vaccinePat.PatNum)+"";
			}
			if(vaccinePat.NotGiven != oldVaccinePat.NotGiven) {
				if(command!=""){ command+=",";}
				command+="NotGiven = "+POut.Bool(vaccinePat.NotGiven)+"";
			}
			if(vaccinePat.Note != oldVaccinePat.Note) {
				if(command!=""){ command+=",";}
				command+="Note = '"+POut.String(vaccinePat.Note)+"'";
			}
			if(command==""){
				return;
			}
			command="UPDATE vaccinepat SET "+command
				+" WHERE VaccinePatNum = "+POut.Long(vaccinePat.VaccinePatNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one VaccinePat from the database.</summary>
		internal static void Delete(long vaccinePatNum){
			string command="DELETE FROM vaccinepat "
				+"WHERE VaccinePatNum = "+POut.Long(vaccinePatNum);
			Db.NonQ(command);
		}

	}
}