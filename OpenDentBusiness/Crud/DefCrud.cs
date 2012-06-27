//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class DefCrud {
		///<summary>Gets one Def object from the database using the primary key.  Returns null if not found.</summary>
		internal static Def SelectOne(long defNum){
			string command="SELECT * FROM definition "
				+"WHERE DefNum = "+POut.Long(defNum);
			List<Def> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Def object from the database using a query.</summary>
		internal static Def SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Def> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Def objects from the database using a query.</summary>
		internal static List<Def> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Def> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<Def> TableToList(DataTable table){
			List<Def> retVal=new List<Def>();
			Def def;
			for(int i=0;i<table.Rows.Count;i++) {
				def=new Def();
				def.DefNum   = PIn.Long  (table.Rows[i]["DefNum"].ToString());
				def.Category = (DefCat)PIn.Int(table.Rows[i]["Category"].ToString());
				def.ItemOrder= PIn.Int   (table.Rows[i]["ItemOrder"].ToString());
				def.ItemName = PIn.String(table.Rows[i]["ItemName"].ToString());
				def.ItemValue= PIn.String(table.Rows[i]["ItemValue"].ToString());
				def.ItemColor= Color.FromArgb(PIn.Int(table.Rows[i]["ItemColor"].ToString()));
				def.IsHidden = PIn.Bool  (table.Rows[i]["IsHidden"].ToString());
				retVal.Add(def);
			}
			return retVal;
		}

		///<summary>Inserts one Def into the database.  Returns the new priKey.</summary>
		internal static long Insert(Def def){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				def.DefNum=DbHelper.GetNextOracleKey("definition","DefNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(def,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							def.DefNum++;
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
				return Insert(def,false);
			}
		}

		///<summary>Inserts one Def into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(Def def,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				def.DefNum=ReplicationServers.GetKey("definition","DefNum");
			}
			string command="INSERT INTO definition (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="DefNum,";
			}
			command+="Category,ItemOrder,ItemName,ItemValue,ItemColor,IsHidden) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(def.DefNum)+",";
			}
			command+=
				     POut.Int   ((int)def.Category)+","
				+    POut.Int   (def.ItemOrder)+","
				+"'"+POut.String(def.ItemName)+"',"
				+"'"+POut.String(def.ItemValue)+"',"
				+    POut.Int   (def.ItemColor.ToArgb())+","
				+    POut.Bool  (def.IsHidden)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				def.DefNum=Db.NonQ(command,true);
			}
			return def.DefNum;
		}

		///<summary>Updates one Def in the database.</summary>
		internal static void Update(Def def){
			string command="UPDATE definition SET "
				+"Category =  "+POut.Int   ((int)def.Category)+", "
				+"ItemOrder=  "+POut.Int   (def.ItemOrder)+", "
				+"ItemName = '"+POut.String(def.ItemName)+"', "
				+"ItemValue= '"+POut.String(def.ItemValue)+"', "
				+"ItemColor=  "+POut.Int   (def.ItemColor.ToArgb())+", "
				+"IsHidden =  "+POut.Bool  (def.IsHidden)+" "
				+"WHERE DefNum = "+POut.Long(def.DefNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Def in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(Def def,Def oldDef){
			string command="";
			if(def.Category != oldDef.Category) {
				if(command!=""){ command+=",";}
				command+="Category = "+POut.Int   ((int)def.Category)+"";
			}
			if(def.ItemOrder != oldDef.ItemOrder) {
				if(command!=""){ command+=",";}
				command+="ItemOrder = "+POut.Int(def.ItemOrder)+"";
			}
			if(def.ItemName != oldDef.ItemName) {
				if(command!=""){ command+=",";}
				command+="ItemName = '"+POut.String(def.ItemName)+"'";
			}
			if(def.ItemValue != oldDef.ItemValue) {
				if(command!=""){ command+=",";}
				command+="ItemValue = '"+POut.String(def.ItemValue)+"'";
			}
			if(def.ItemColor != oldDef.ItemColor) {
				if(command!=""){ command+=",";}
				command+="ItemColor = "+POut.Int(def.ItemColor.ToArgb())+"";
			}
			if(def.IsHidden != oldDef.IsHidden) {
				if(command!=""){ command+=",";}
				command+="IsHidden = "+POut.Bool(def.IsHidden)+"";
			}
			if(command==""){
				return;
			}
			command="UPDATE definition SET "+command
				+" WHERE DefNum = "+POut.Long(def.DefNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one Def from the database.</summary>
		internal static void Delete(long defNum){
			string command="DELETE FROM definition "
				+"WHERE DefNum = "+POut.Long(defNum);
			Db.NonQ(command);
		}

	}
}