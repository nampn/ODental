//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class ProcButtonCrud {
		///<summary>Gets one ProcButton object from the database using the primary key.  Returns null if not found.</summary>
		internal static ProcButton SelectOne(long procButtonNum){
			string command="SELECT * FROM procbutton "
				+"WHERE ProcButtonNum = "+POut.Long(procButtonNum);
			List<ProcButton> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ProcButton object from the database using a query.</summary>
		internal static ProcButton SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ProcButton> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ProcButton objects from the database using a query.</summary>
		internal static List<ProcButton> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ProcButton> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<ProcButton> TableToList(DataTable table){
			List<ProcButton> retVal=new List<ProcButton>();
			ProcButton procButton;
			for(int i=0;i<table.Rows.Count;i++) {
				procButton=new ProcButton();
				procButton.ProcButtonNum= PIn.Long  (table.Rows[i]["ProcButtonNum"].ToString());
				procButton.Description  = PIn.String(table.Rows[i]["Description"].ToString());
				procButton.ItemOrder    = PIn.Int   (table.Rows[i]["ItemOrder"].ToString());
				procButton.Category     = PIn.Long  (table.Rows[i]["Category"].ToString());
				procButton.ButtonImage  = PIn.String(table.Rows[i]["ButtonImage"].ToString());
				retVal.Add(procButton);
			}
			return retVal;
		}

		///<summary>Inserts one ProcButton into the database.  Returns the new priKey.</summary>
		internal static long Insert(ProcButton procButton){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				procButton.ProcButtonNum=DbHelper.GetNextOracleKey("procbutton","ProcButtonNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(procButton,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							procButton.ProcButtonNum++;
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
				return Insert(procButton,false);
			}
		}

		///<summary>Inserts one ProcButton into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(ProcButton procButton,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				procButton.ProcButtonNum=ReplicationServers.GetKey("procbutton","ProcButtonNum");
			}
			string command="INSERT INTO procbutton (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ProcButtonNum,";
			}
			command+="Description,ItemOrder,Category,ButtonImage) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(procButton.ProcButtonNum)+",";
			}
			command+=
				 "'"+POut.String(procButton.Description)+"',"
				+    POut.Int   (procButton.ItemOrder)+","
				+    POut.Long  (procButton.Category)+","
				+DbHelper.ParamChar+"paramButtonImage)";
			if(procButton.ButtonImage==null) {
				procButton.ButtonImage="";
			}
			OdSqlParameter paramButtonImage=new OdSqlParameter("paramButtonImage",OdDbType.Text,procButton.ButtonImage);
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramButtonImage);
			}
			else {
				procButton.ProcButtonNum=Db.NonQ(command,true,paramButtonImage);
			}
			return procButton.ProcButtonNum;
		}

		///<summary>Updates one ProcButton in the database.</summary>
		internal static void Update(ProcButton procButton){
			string command="UPDATE procbutton SET "
				+"Description  = '"+POut.String(procButton.Description)+"', "
				+"ItemOrder    =  "+POut.Int   (procButton.ItemOrder)+", "
				+"Category     =  "+POut.Long  (procButton.Category)+", "
				+"ButtonImage  =  "+DbHelper.ParamChar+"paramButtonImage "
				+"WHERE ProcButtonNum = "+POut.Long(procButton.ProcButtonNum);
			if(procButton.ButtonImage==null) {
				procButton.ButtonImage="";
			}
			OdSqlParameter paramButtonImage=new OdSqlParameter("paramButtonImage",OdDbType.Text,procButton.ButtonImage);
			Db.NonQ(command,paramButtonImage);
		}

		///<summary>Updates one ProcButton in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(ProcButton procButton,ProcButton oldProcButton){
			string command="";
			if(procButton.Description != oldProcButton.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(procButton.Description)+"'";
			}
			if(procButton.ItemOrder != oldProcButton.ItemOrder) {
				if(command!=""){ command+=",";}
				command+="ItemOrder = "+POut.Int(procButton.ItemOrder)+"";
			}
			if(procButton.Category != oldProcButton.Category) {
				if(command!=""){ command+=",";}
				command+="Category = "+POut.Long(procButton.Category)+"";
			}
			if(procButton.ButtonImage != oldProcButton.ButtonImage) {
				if(command!=""){ command+=",";}
				command+="ButtonImage = "+DbHelper.ParamChar+"paramButtonImage";
			}
			if(command==""){
				return;
			}
			if(procButton.ButtonImage==null) {
				procButton.ButtonImage="";
			}
			OdSqlParameter paramButtonImage=new OdSqlParameter("paramButtonImage",OdDbType.Text,procButton.ButtonImage);
			command="UPDATE procbutton SET "+command
				+" WHERE ProcButtonNum = "+POut.Long(procButton.ProcButtonNum);
			Db.NonQ(command,paramButtonImage);
		}

		///<summary>Deletes one ProcButton from the database.</summary>
		internal static void Delete(long procButtonNum){
			string command="DELETE FROM procbutton "
				+"WHERE ProcButtonNum = "+POut.Long(procButtonNum);
			Db.NonQ(command);
		}

	}
}