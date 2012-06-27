//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class PrinterCrud {
		///<summary>Gets one Printer object from the database using the primary key.  Returns null if not found.</summary>
		internal static Printer SelectOne(long printerNum){
			string command="SELECT * FROM printer "
				+"WHERE PrinterNum = "+POut.Long(printerNum);
			List<Printer> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Printer object from the database using a query.</summary>
		internal static Printer SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Printer> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Printer objects from the database using a query.</summary>
		internal static List<Printer> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Printer> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<Printer> TableToList(DataTable table){
			List<Printer> retVal=new List<Printer>();
			Printer printer;
			for(int i=0;i<table.Rows.Count;i++) {
				printer=new Printer();
				printer.PrinterNum   = PIn.Long  (table.Rows[i]["PrinterNum"].ToString());
				printer.ComputerNum  = PIn.Long  (table.Rows[i]["ComputerNum"].ToString());
				printer.PrintSit     = (PrintSituation)PIn.Int(table.Rows[i]["PrintSit"].ToString());
				printer.PrinterName  = PIn.String(table.Rows[i]["PrinterName"].ToString());
				printer.DisplayPrompt= PIn.Bool  (table.Rows[i]["DisplayPrompt"].ToString());
				retVal.Add(printer);
			}
			return retVal;
		}

		///<summary>Inserts one Printer into the database.  Returns the new priKey.</summary>
		internal static long Insert(Printer printer){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				printer.PrinterNum=DbHelper.GetNextOracleKey("printer","PrinterNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(printer,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							printer.PrinterNum++;
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
				return Insert(printer,false);
			}
		}

		///<summary>Inserts one Printer into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(Printer printer,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				printer.PrinterNum=ReplicationServers.GetKey("printer","PrinterNum");
			}
			string command="INSERT INTO printer (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="PrinterNum,";
			}
			command+="ComputerNum,PrintSit,PrinterName,DisplayPrompt) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(printer.PrinterNum)+",";
			}
			command+=
				     POut.Long  (printer.ComputerNum)+","
				+    POut.Int   ((int)printer.PrintSit)+","
				+"'"+POut.String(printer.PrinterName)+"',"
				+    POut.Bool  (printer.DisplayPrompt)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				printer.PrinterNum=Db.NonQ(command,true);
			}
			return printer.PrinterNum;
		}

		///<summary>Updates one Printer in the database.</summary>
		internal static void Update(Printer printer){
			string command="UPDATE printer SET "
				+"ComputerNum  =  "+POut.Long  (printer.ComputerNum)+", "
				+"PrintSit     =  "+POut.Int   ((int)printer.PrintSit)+", "
				+"PrinterName  = '"+POut.String(printer.PrinterName)+"', "
				+"DisplayPrompt=  "+POut.Bool  (printer.DisplayPrompt)+" "
				+"WHERE PrinterNum = "+POut.Long(printer.PrinterNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Printer in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(Printer printer,Printer oldPrinter){
			string command="";
			if(printer.ComputerNum != oldPrinter.ComputerNum) {
				if(command!=""){ command+=",";}
				command+="ComputerNum = "+POut.Long(printer.ComputerNum)+"";
			}
			if(printer.PrintSit != oldPrinter.PrintSit) {
				if(command!=""){ command+=",";}
				command+="PrintSit = "+POut.Int   ((int)printer.PrintSit)+"";
			}
			if(printer.PrinterName != oldPrinter.PrinterName) {
				if(command!=""){ command+=",";}
				command+="PrinterName = '"+POut.String(printer.PrinterName)+"'";
			}
			if(printer.DisplayPrompt != oldPrinter.DisplayPrompt) {
				if(command!=""){ command+=",";}
				command+="DisplayPrompt = "+POut.Bool(printer.DisplayPrompt)+"";
			}
			if(command==""){
				return;
			}
			command="UPDATE printer SET "+command
				+" WHERE PrinterNum = "+POut.Long(printer.PrinterNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one Printer from the database.</summary>
		internal static void Delete(long printerNum){
			string command="DELETE FROM printer "
				+"WHERE PrinterNum = "+POut.Long(printerNum);
			Db.NonQ(command);
		}

	}
}