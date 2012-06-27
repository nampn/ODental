//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class ReminderRuleCrud {
		///<summary>Gets one ReminderRule object from the database using the primary key.  Returns null if not found.</summary>
		internal static ReminderRule SelectOne(long reminderRuleNum){
			string command="SELECT * FROM reminderrule "
				+"WHERE ReminderRuleNum = "+POut.Long(reminderRuleNum);
			List<ReminderRule> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ReminderRule object from the database using a query.</summary>
		internal static ReminderRule SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ReminderRule> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ReminderRule objects from the database using a query.</summary>
		internal static List<ReminderRule> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ReminderRule> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<ReminderRule> TableToList(DataTable table){
			List<ReminderRule> retVal=new List<ReminderRule>();
			ReminderRule reminderRule;
			for(int i=0;i<table.Rows.Count;i++) {
				reminderRule=new ReminderRule();
				reminderRule.ReminderRuleNum  = PIn.Long  (table.Rows[i]["ReminderRuleNum"].ToString());
				reminderRule.ReminderCriterion= (EhrCriterion)PIn.Int(table.Rows[i]["ReminderCriterion"].ToString());
				reminderRule.CriterionFK      = PIn.Long  (table.Rows[i]["CriterionFK"].ToString());
				reminderRule.CriterionValue   = PIn.String(table.Rows[i]["CriterionValue"].ToString());
				reminderRule.Message          = PIn.String(table.Rows[i]["Message"].ToString());
				retVal.Add(reminderRule);
			}
			return retVal;
		}

		///<summary>Inserts one ReminderRule into the database.  Returns the new priKey.</summary>
		internal static long Insert(ReminderRule reminderRule){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				reminderRule.ReminderRuleNum=DbHelper.GetNextOracleKey("reminderrule","ReminderRuleNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(reminderRule,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							reminderRule.ReminderRuleNum++;
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
				return Insert(reminderRule,false);
			}
		}

		///<summary>Inserts one ReminderRule into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(ReminderRule reminderRule,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				reminderRule.ReminderRuleNum=ReplicationServers.GetKey("reminderrule","ReminderRuleNum");
			}
			string command="INSERT INTO reminderrule (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ReminderRuleNum,";
			}
			command+="ReminderCriterion,CriterionFK,CriterionValue,Message) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(reminderRule.ReminderRuleNum)+",";
			}
			command+=
				     POut.Int   ((int)reminderRule.ReminderCriterion)+","
				+    POut.Long  (reminderRule.CriterionFK)+","
				+"'"+POut.String(reminderRule.CriterionValue)+"',"
				+"'"+POut.String(reminderRule.Message)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				reminderRule.ReminderRuleNum=Db.NonQ(command,true);
			}
			return reminderRule.ReminderRuleNum;
		}

		///<summary>Updates one ReminderRule in the database.</summary>
		internal static void Update(ReminderRule reminderRule){
			string command="UPDATE reminderrule SET "
				+"ReminderCriterion=  "+POut.Int   ((int)reminderRule.ReminderCriterion)+", "
				+"CriterionFK      =  "+POut.Long  (reminderRule.CriterionFK)+", "
				+"CriterionValue   = '"+POut.String(reminderRule.CriterionValue)+"', "
				+"Message          = '"+POut.String(reminderRule.Message)+"' "
				+"WHERE ReminderRuleNum = "+POut.Long(reminderRule.ReminderRuleNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ReminderRule in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(ReminderRule reminderRule,ReminderRule oldReminderRule){
			string command="";
			if(reminderRule.ReminderCriterion != oldReminderRule.ReminderCriterion) {
				if(command!=""){ command+=",";}
				command+="ReminderCriterion = "+POut.Int   ((int)reminderRule.ReminderCriterion)+"";
			}
			if(reminderRule.CriterionFK != oldReminderRule.CriterionFK) {
				if(command!=""){ command+=",";}
				command+="CriterionFK = "+POut.Long(reminderRule.CriterionFK)+"";
			}
			if(reminderRule.CriterionValue != oldReminderRule.CriterionValue) {
				if(command!=""){ command+=",";}
				command+="CriterionValue = '"+POut.String(reminderRule.CriterionValue)+"'";
			}
			if(reminderRule.Message != oldReminderRule.Message) {
				if(command!=""){ command+=",";}
				command+="Message = '"+POut.String(reminderRule.Message)+"'";
			}
			if(command==""){
				return;
			}
			command="UPDATE reminderrule SET "+command
				+" WHERE ReminderRuleNum = "+POut.Long(reminderRule.ReminderRuleNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one ReminderRule from the database.</summary>
		internal static void Delete(long reminderRuleNum){
			string command="DELETE FROM reminderrule "
				+"WHERE ReminderRuleNum = "+POut.Long(reminderRuleNum);
			Db.NonQ(command);
		}

	}
}