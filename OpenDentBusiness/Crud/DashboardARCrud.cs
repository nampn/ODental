//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class DashboardARCrud {
		///<summary>Gets one DashboardAR object from the database using the primary key.  Returns null if not found.</summary>
		internal static DashboardAR SelectOne(long dashboardARNum){
			string command="SELECT * FROM dashboardar "
				+"WHERE DashboardARNum = "+POut.Long(dashboardARNum);
			List<DashboardAR> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one DashboardAR object from the database using a query.</summary>
		internal static DashboardAR SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<DashboardAR> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of DashboardAR objects from the database using a query.</summary>
		internal static List<DashboardAR> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<DashboardAR> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<DashboardAR> TableToList(DataTable table){
			List<DashboardAR> retVal=new List<DashboardAR>();
			DashboardAR dashboardAR;
			for(int i=0;i<table.Rows.Count;i++) {
				dashboardAR=new DashboardAR();
				dashboardAR.DashboardARNum= PIn.Long  (table.Rows[i]["DashboardARNum"].ToString());
				dashboardAR.DateCalc      = PIn.Date  (table.Rows[i]["DateCalc"].ToString());
				dashboardAR.BalTotal      = PIn.Double(table.Rows[i]["BalTotal"].ToString());
				dashboardAR.InsEst        = PIn.Double(table.Rows[i]["InsEst"].ToString());
				retVal.Add(dashboardAR);
			}
			return retVal;
		}

		///<summary>Inserts one DashboardAR into the database.  Returns the new priKey.</summary>
		internal static long Insert(DashboardAR dashboardAR){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				dashboardAR.DashboardARNum=DbHelper.GetNextOracleKey("dashboardar","DashboardARNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(dashboardAR,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							dashboardAR.DashboardARNum++;
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
				return Insert(dashboardAR,false);
			}
		}

		///<summary>Inserts one DashboardAR into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(DashboardAR dashboardAR,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				dashboardAR.DashboardARNum=ReplicationServers.GetKey("dashboardar","DashboardARNum");
			}
			string command="INSERT INTO dashboardar (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="DashboardARNum,";
			}
			command+="DateCalc,BalTotal,InsEst) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(dashboardAR.DashboardARNum)+",";
			}
			command+=
				     POut.Date  (dashboardAR.DateCalc)+","
				+"'"+POut.Double(dashboardAR.BalTotal)+"',"
				+"'"+POut.Double(dashboardAR.InsEst)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				dashboardAR.DashboardARNum=Db.NonQ(command,true);
			}
			return dashboardAR.DashboardARNum;
		}

		///<summary>Updates one DashboardAR in the database.</summary>
		internal static void Update(DashboardAR dashboardAR){
			string command="UPDATE dashboardar SET "
				+"DateCalc      =  "+POut.Date  (dashboardAR.DateCalc)+", "
				+"BalTotal      = '"+POut.Double(dashboardAR.BalTotal)+"', "
				+"InsEst        = '"+POut.Double(dashboardAR.InsEst)+"' "
				+"WHERE DashboardARNum = "+POut.Long(dashboardAR.DashboardARNum);
			Db.NonQ(command);
		}

		///<summary>Updates one DashboardAR in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(DashboardAR dashboardAR,DashboardAR oldDashboardAR){
			string command="";
			if(dashboardAR.DateCalc != oldDashboardAR.DateCalc) {
				if(command!=""){ command+=",";}
				command+="DateCalc = "+POut.Date(dashboardAR.DateCalc)+"";
			}
			if(dashboardAR.BalTotal != oldDashboardAR.BalTotal) {
				if(command!=""){ command+=",";}
				command+="BalTotal = '"+POut.Double(dashboardAR.BalTotal)+"'";
			}
			if(dashboardAR.InsEst != oldDashboardAR.InsEst) {
				if(command!=""){ command+=",";}
				command+="InsEst = '"+POut.Double(dashboardAR.InsEst)+"'";
			}
			if(command==""){
				return;
			}
			command="UPDATE dashboardar SET "+command
				+" WHERE DashboardARNum = "+POut.Long(dashboardAR.DashboardARNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one DashboardAR from the database.</summary>
		internal static void Delete(long dashboardARNum){
			string command="DELETE FROM dashboardar "
				+"WHERE DashboardARNum = "+POut.Long(dashboardARNum);
			Db.NonQ(command);
		}

	}
}