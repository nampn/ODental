//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class ChartViewCrud {
		///<summary>Gets one ChartView object from the database using the primary key.  Returns null if not found.</summary>
		internal static ChartView SelectOne(long chartViewNum){
			string command="SELECT * FROM chartview "
				+"WHERE ChartViewNum = "+POut.Long(chartViewNum);
			List<ChartView> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ChartView object from the database using a query.</summary>
		internal static ChartView SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ChartView> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ChartView objects from the database using a query.</summary>
		internal static List<ChartView> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ChartView> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<ChartView> TableToList(DataTable table){
			List<ChartView> retVal=new List<ChartView>();
			ChartView chartView;
			for(int i=0;i<table.Rows.Count;i++) {
				chartView=new ChartView();
				chartView.ChartViewNum     = PIn.Long  (table.Rows[i]["ChartViewNum"].ToString());
				chartView.Description      = PIn.String(table.Rows[i]["Description"].ToString());
				chartView.ItemOrder        = PIn.Int   (table.Rows[i]["ItemOrder"].ToString());
				chartView.ProcStatuses     = (ChartViewProcStat)PIn.Int(table.Rows[i]["ProcStatuses"].ToString());
				chartView.ObjectTypes      = (ChartViewObjs)PIn.Int(table.Rows[i]["ObjectTypes"].ToString());
				chartView.ShowProcNotes    = PIn.Bool  (table.Rows[i]["ShowProcNotes"].ToString());
				chartView.IsAudit          = PIn.Bool  (table.Rows[i]["IsAudit"].ToString());
				chartView.SelectedTeethOnly= PIn.Bool  (table.Rows[i]["SelectedTeethOnly"].ToString());
				chartView.OrionStatusFlags = (OrionStatus)PIn.Int(table.Rows[i]["OrionStatusFlags"].ToString());
				chartView.DatesShowing     = (ChartViewDates)PIn.Int(table.Rows[i]["DatesShowing"].ToString());
				retVal.Add(chartView);
			}
			return retVal;
		}

		///<summary>Inserts one ChartView into the database.  Returns the new priKey.</summary>
		internal static long Insert(ChartView chartView){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				chartView.ChartViewNum=DbHelper.GetNextOracleKey("chartview","ChartViewNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(chartView,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							chartView.ChartViewNum++;
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
				return Insert(chartView,false);
			}
		}

		///<summary>Inserts one ChartView into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(ChartView chartView,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				chartView.ChartViewNum=ReplicationServers.GetKey("chartview","ChartViewNum");
			}
			string command="INSERT INTO chartview (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ChartViewNum,";
			}
			command+="Description,ItemOrder,ProcStatuses,ObjectTypes,ShowProcNotes,IsAudit,SelectedTeethOnly,OrionStatusFlags,DatesShowing) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(chartView.ChartViewNum)+",";
			}
			command+=
				 "'"+POut.String(chartView.Description)+"',"
				+    POut.Int   (chartView.ItemOrder)+","
				+    POut.Int   ((int)chartView.ProcStatuses)+","
				+    POut.Int   ((int)chartView.ObjectTypes)+","
				+    POut.Bool  (chartView.ShowProcNotes)+","
				+    POut.Bool  (chartView.IsAudit)+","
				+    POut.Bool  (chartView.SelectedTeethOnly)+","
				+    POut.Int   ((int)chartView.OrionStatusFlags)+","
				+    POut.Int   ((int)chartView.DatesShowing)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				chartView.ChartViewNum=Db.NonQ(command,true);
			}
			return chartView.ChartViewNum;
		}

		///<summary>Updates one ChartView in the database.</summary>
		internal static void Update(ChartView chartView){
			string command="UPDATE chartview SET "
				+"Description      = '"+POut.String(chartView.Description)+"', "
				+"ItemOrder        =  "+POut.Int   (chartView.ItemOrder)+", "
				+"ProcStatuses     =  "+POut.Int   ((int)chartView.ProcStatuses)+", "
				+"ObjectTypes      =  "+POut.Int   ((int)chartView.ObjectTypes)+", "
				+"ShowProcNotes    =  "+POut.Bool  (chartView.ShowProcNotes)+", "
				+"IsAudit          =  "+POut.Bool  (chartView.IsAudit)+", "
				+"SelectedTeethOnly=  "+POut.Bool  (chartView.SelectedTeethOnly)+", "
				+"OrionStatusFlags =  "+POut.Int   ((int)chartView.OrionStatusFlags)+", "
				+"DatesShowing     =  "+POut.Int   ((int)chartView.DatesShowing)+" "
				+"WHERE ChartViewNum = "+POut.Long(chartView.ChartViewNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ChartView in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(ChartView chartView,ChartView oldChartView){
			string command="";
			if(chartView.Description != oldChartView.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(chartView.Description)+"'";
			}
			if(chartView.ItemOrder != oldChartView.ItemOrder) {
				if(command!=""){ command+=",";}
				command+="ItemOrder = "+POut.Int(chartView.ItemOrder)+"";
			}
			if(chartView.ProcStatuses != oldChartView.ProcStatuses) {
				if(command!=""){ command+=",";}
				command+="ProcStatuses = "+POut.Int   ((int)chartView.ProcStatuses)+"";
			}
			if(chartView.ObjectTypes != oldChartView.ObjectTypes) {
				if(command!=""){ command+=",";}
				command+="ObjectTypes = "+POut.Int   ((int)chartView.ObjectTypes)+"";
			}
			if(chartView.ShowProcNotes != oldChartView.ShowProcNotes) {
				if(command!=""){ command+=",";}
				command+="ShowProcNotes = "+POut.Bool(chartView.ShowProcNotes)+"";
			}
			if(chartView.IsAudit != oldChartView.IsAudit) {
				if(command!=""){ command+=",";}
				command+="IsAudit = "+POut.Bool(chartView.IsAudit)+"";
			}
			if(chartView.SelectedTeethOnly != oldChartView.SelectedTeethOnly) {
				if(command!=""){ command+=",";}
				command+="SelectedTeethOnly = "+POut.Bool(chartView.SelectedTeethOnly)+"";
			}
			if(chartView.OrionStatusFlags != oldChartView.OrionStatusFlags) {
				if(command!=""){ command+=",";}
				command+="OrionStatusFlags = "+POut.Int   ((int)chartView.OrionStatusFlags)+"";
			}
			if(chartView.DatesShowing != oldChartView.DatesShowing) {
				if(command!=""){ command+=",";}
				command+="DatesShowing = "+POut.Int   ((int)chartView.DatesShowing)+"";
			}
			if(command==""){
				return;
			}
			command="UPDATE chartview SET "+command
				+" WHERE ChartViewNum = "+POut.Long(chartView.ChartViewNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one ChartView from the database.</summary>
		internal static void Delete(long chartViewNum){
			string command="DELETE FROM chartview "
				+"WHERE ChartViewNum = "+POut.Long(chartViewNum);
			Db.NonQ(command);
		}

	}
}