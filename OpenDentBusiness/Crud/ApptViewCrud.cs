//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class ApptViewCrud {
		///<summary>Gets one ApptView object from the database using the primary key.  Returns null if not found.</summary>
		internal static ApptView SelectOne(long apptViewNum){
			string command="SELECT * FROM apptview "
				+"WHERE ApptViewNum = "+POut.Long(apptViewNum);
			List<ApptView> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ApptView object from the database using a query.</summary>
		internal static ApptView SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ApptView> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ApptView objects from the database using a query.</summary>
		internal static List<ApptView> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ApptView> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<ApptView> TableToList(DataTable table){
			List<ApptView> retVal=new List<ApptView>();
			ApptView apptView;
			for(int i=0;i<table.Rows.Count;i++) {
				apptView=new ApptView();
				apptView.ApptViewNum        = PIn.Long  (table.Rows[i]["ApptViewNum"].ToString());
				apptView.Description        = PIn.String(table.Rows[i]["Description"].ToString());
				apptView.ItemOrder          = PIn.Int   (table.Rows[i]["ItemOrder"].ToString());
				apptView.RowsPerIncr        = PIn.Byte  (table.Rows[i]["RowsPerIncr"].ToString());
				apptView.OnlyScheduledProvs = PIn.Bool  (table.Rows[i]["OnlyScheduledProvs"].ToString());
				apptView.OnlySchedBeforeTime= PIn.Time(table.Rows[i]["OnlySchedBeforeTime"].ToString());
				apptView.OnlySchedAfterTime = PIn.Time(table.Rows[i]["OnlySchedAfterTime"].ToString());
				apptView.StackBehavUR       = (ApptViewStackBehavior)PIn.Int(table.Rows[i]["StackBehavUR"].ToString());
				apptView.StackBehavLR       = (ApptViewStackBehavior)PIn.Int(table.Rows[i]["StackBehavLR"].ToString());
				apptView.ClinicNum          = PIn.Long  (table.Rows[i]["ClinicNum"].ToString());
				retVal.Add(apptView);
			}
			return retVal;
		}

		///<summary>Inserts one ApptView into the database.  Returns the new priKey.</summary>
		internal static long Insert(ApptView apptView){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				apptView.ApptViewNum=DbHelper.GetNextOracleKey("apptview","ApptViewNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(apptView,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							apptView.ApptViewNum++;
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
				return Insert(apptView,false);
			}
		}

		///<summary>Inserts one ApptView into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(ApptView apptView,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				apptView.ApptViewNum=ReplicationServers.GetKey("apptview","ApptViewNum");
			}
			string command="INSERT INTO apptview (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ApptViewNum,";
			}
			command+="Description,ItemOrder,RowsPerIncr,OnlyScheduledProvs,OnlySchedBeforeTime,OnlySchedAfterTime,StackBehavUR,StackBehavLR,ClinicNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(apptView.ApptViewNum)+",";
			}
			command+=
				 "'"+POut.String(apptView.Description)+"',"
				+    POut.Int   (apptView.ItemOrder)+","
				+    POut.Byte  (apptView.RowsPerIncr)+","
				+    POut.Bool  (apptView.OnlyScheduledProvs)+","
				+    POut.Time  (apptView.OnlySchedBeforeTime)+","
				+    POut.Time  (apptView.OnlySchedAfterTime)+","
				+    POut.Int   ((int)apptView.StackBehavUR)+","
				+    POut.Int   ((int)apptView.StackBehavLR)+","
				+    POut.Long  (apptView.ClinicNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				apptView.ApptViewNum=Db.NonQ(command,true);
			}
			return apptView.ApptViewNum;
		}

		///<summary>Updates one ApptView in the database.</summary>
		internal static void Update(ApptView apptView){
			string command="UPDATE apptview SET "
				+"Description        = '"+POut.String(apptView.Description)+"', "
				+"ItemOrder          =  "+POut.Int   (apptView.ItemOrder)+", "
				+"RowsPerIncr        =  "+POut.Byte  (apptView.RowsPerIncr)+", "
				+"OnlyScheduledProvs =  "+POut.Bool  (apptView.OnlyScheduledProvs)+", "
				+"OnlySchedBeforeTime=  "+POut.Time  (apptView.OnlySchedBeforeTime)+", "
				+"OnlySchedAfterTime =  "+POut.Time  (apptView.OnlySchedAfterTime)+", "
				+"StackBehavUR       =  "+POut.Int   ((int)apptView.StackBehavUR)+", "
				+"StackBehavLR       =  "+POut.Int   ((int)apptView.StackBehavLR)+", "
				+"ClinicNum          =  "+POut.Long  (apptView.ClinicNum)+" "
				+"WHERE ApptViewNum = "+POut.Long(apptView.ApptViewNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ApptView in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(ApptView apptView,ApptView oldApptView){
			string command="";
			if(apptView.Description != oldApptView.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(apptView.Description)+"'";
			}
			if(apptView.ItemOrder != oldApptView.ItemOrder) {
				if(command!=""){ command+=",";}
				command+="ItemOrder = "+POut.Int(apptView.ItemOrder)+"";
			}
			if(apptView.RowsPerIncr != oldApptView.RowsPerIncr) {
				if(command!=""){ command+=",";}
				command+="RowsPerIncr = "+POut.Byte(apptView.RowsPerIncr)+"";
			}
			if(apptView.OnlyScheduledProvs != oldApptView.OnlyScheduledProvs) {
				if(command!=""){ command+=",";}
				command+="OnlyScheduledProvs = "+POut.Bool(apptView.OnlyScheduledProvs)+"";
			}
			if(apptView.OnlySchedBeforeTime != oldApptView.OnlySchedBeforeTime) {
				if(command!=""){ command+=",";}
				command+="OnlySchedBeforeTime = "+POut.Time  (apptView.OnlySchedBeforeTime)+"";
			}
			if(apptView.OnlySchedAfterTime != oldApptView.OnlySchedAfterTime) {
				if(command!=""){ command+=",";}
				command+="OnlySchedAfterTime = "+POut.Time  (apptView.OnlySchedAfterTime)+"";
			}
			if(apptView.StackBehavUR != oldApptView.StackBehavUR) {
				if(command!=""){ command+=",";}
				command+="StackBehavUR = "+POut.Int   ((int)apptView.StackBehavUR)+"";
			}
			if(apptView.StackBehavLR != oldApptView.StackBehavLR) {
				if(command!=""){ command+=",";}
				command+="StackBehavLR = "+POut.Int   ((int)apptView.StackBehavLR)+"";
			}
			if(apptView.ClinicNum != oldApptView.ClinicNum) {
				if(command!=""){ command+=",";}
				command+="ClinicNum = "+POut.Long(apptView.ClinicNum)+"";
			}
			if(command==""){
				return;
			}
			command="UPDATE apptview SET "+command
				+" WHERE ApptViewNum = "+POut.Long(apptView.ApptViewNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one ApptView from the database.</summary>
		internal static void Delete(long apptViewNum){
			string command="DELETE FROM apptview "
				+"WHERE ApptViewNum = "+POut.Long(apptViewNum);
			Db.NonQ(command);
		}

	}
}