//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class ClaimFormCrud {
		///<summary>Gets one ClaimForm object from the database using the primary key.  Returns null if not found.</summary>
		internal static ClaimForm SelectOne(long claimFormNum){
			string command="SELECT * FROM claimform "
				+"WHERE ClaimFormNum = "+POut.Long(claimFormNum);
			List<ClaimForm> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ClaimForm object from the database using a query.</summary>
		internal static ClaimForm SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ClaimForm> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ClaimForm objects from the database using a query.</summary>
		internal static List<ClaimForm> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ClaimForm> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<ClaimForm> TableToList(DataTable table){
			List<ClaimForm> retVal=new List<ClaimForm>();
			ClaimForm claimForm;
			for(int i=0;i<table.Rows.Count;i++) {
				claimForm=new ClaimForm();
				claimForm.ClaimFormNum= PIn.Long  (table.Rows[i]["ClaimFormNum"].ToString());
				claimForm.Description = PIn.String(table.Rows[i]["Description"].ToString());
				claimForm.IsHidden    = PIn.Bool  (table.Rows[i]["IsHidden"].ToString());
				claimForm.FontName    = PIn.String(table.Rows[i]["FontName"].ToString());
				claimForm.FontSize    = PIn.Float (table.Rows[i]["FontSize"].ToString());
				claimForm.UniqueID    = PIn.String(table.Rows[i]["UniqueID"].ToString());
				claimForm.PrintImages = PIn.Bool  (table.Rows[i]["PrintImages"].ToString());
				claimForm.OffsetX     = PIn.Int   (table.Rows[i]["OffsetX"].ToString());
				claimForm.OffsetY     = PIn.Int   (table.Rows[i]["OffsetY"].ToString());
				retVal.Add(claimForm);
			}
			return retVal;
		}

		///<summary>Inserts one ClaimForm into the database.  Returns the new priKey.</summary>
		internal static long Insert(ClaimForm claimForm){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				claimForm.ClaimFormNum=DbHelper.GetNextOracleKey("claimform","ClaimFormNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(claimForm,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							claimForm.ClaimFormNum++;
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
				return Insert(claimForm,false);
			}
		}

		///<summary>Inserts one ClaimForm into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(ClaimForm claimForm,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				claimForm.ClaimFormNum=ReplicationServers.GetKey("claimform","ClaimFormNum");
			}
			string command="INSERT INTO claimform (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ClaimFormNum,";
			}
			command+="Description,IsHidden,FontName,FontSize,UniqueID,PrintImages,OffsetX,OffsetY) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(claimForm.ClaimFormNum)+",";
			}
			command+=
				 "'"+POut.String(claimForm.Description)+"',"
				+    POut.Bool  (claimForm.IsHidden)+","
				+"'"+POut.String(claimForm.FontName)+"',"
				+    POut.Float (claimForm.FontSize)+","
				+"'"+POut.String(claimForm.UniqueID)+"',"
				+    POut.Bool  (claimForm.PrintImages)+","
				+    POut.Int   (claimForm.OffsetX)+","
				+    POut.Int   (claimForm.OffsetY)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				claimForm.ClaimFormNum=Db.NonQ(command,true);
			}
			return claimForm.ClaimFormNum;
		}

		///<summary>Updates one ClaimForm in the database.</summary>
		internal static void Update(ClaimForm claimForm){
			string command="UPDATE claimform SET "
				+"Description = '"+POut.String(claimForm.Description)+"', "
				+"IsHidden    =  "+POut.Bool  (claimForm.IsHidden)+", "
				+"FontName    = '"+POut.String(claimForm.FontName)+"', "
				+"FontSize    =  "+POut.Float (claimForm.FontSize)+", "
				+"UniqueID    = '"+POut.String(claimForm.UniqueID)+"', "
				+"PrintImages =  "+POut.Bool  (claimForm.PrintImages)+", "
				+"OffsetX     =  "+POut.Int   (claimForm.OffsetX)+", "
				+"OffsetY     =  "+POut.Int   (claimForm.OffsetY)+" "
				+"WHERE ClaimFormNum = "+POut.Long(claimForm.ClaimFormNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ClaimForm in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(ClaimForm claimForm,ClaimForm oldClaimForm){
			string command="";
			if(claimForm.Description != oldClaimForm.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(claimForm.Description)+"'";
			}
			if(claimForm.IsHidden != oldClaimForm.IsHidden) {
				if(command!=""){ command+=",";}
				command+="IsHidden = "+POut.Bool(claimForm.IsHidden)+"";
			}
			if(claimForm.FontName != oldClaimForm.FontName) {
				if(command!=""){ command+=",";}
				command+="FontName = '"+POut.String(claimForm.FontName)+"'";
			}
			if(claimForm.FontSize != oldClaimForm.FontSize) {
				if(command!=""){ command+=",";}
				command+="FontSize = "+POut.Float(claimForm.FontSize)+"";
			}
			if(claimForm.UniqueID != oldClaimForm.UniqueID) {
				if(command!=""){ command+=",";}
				command+="UniqueID = '"+POut.String(claimForm.UniqueID)+"'";
			}
			if(claimForm.PrintImages != oldClaimForm.PrintImages) {
				if(command!=""){ command+=",";}
				command+="PrintImages = "+POut.Bool(claimForm.PrintImages)+"";
			}
			if(claimForm.OffsetX != oldClaimForm.OffsetX) {
				if(command!=""){ command+=",";}
				command+="OffsetX = "+POut.Int(claimForm.OffsetX)+"";
			}
			if(claimForm.OffsetY != oldClaimForm.OffsetY) {
				if(command!=""){ command+=",";}
				command+="OffsetY = "+POut.Int(claimForm.OffsetY)+"";
			}
			if(command==""){
				return;
			}
			command="UPDATE claimform SET "+command
				+" WHERE ClaimFormNum = "+POut.Long(claimForm.ClaimFormNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one ClaimForm from the database.</summary>
		internal static void Delete(long claimFormNum){
			string command="DELETE FROM claimform "
				+"WHERE ClaimFormNum = "+POut.Long(claimFormNum);
			Db.NonQ(command);
		}

	}
}