﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Reflection;

namespace OpenDentBusiness{
	///<summary></summary>
	public class RecallTypes{
		///<summary></summary>
		public static DataTable RefreshCache() {
			//No need to check RemotingRole; Calls GetTableRemotelyIfNeeded().
			string c="SELECT * FROM recalltype ORDER BY Description";
			DataTable table=Cache.GetTableRemotelyIfNeeded(MethodBase.GetCurrentMethod(),c);
			table.TableName="RecallType";
			FillCache(table);
			return table;
		}

		public static void FillCache(DataTable table){
			//No need to check RemotingRole; no call to db.
			List<RecallType> list=Crud.RecallTypeCrud.TableToList(table);
			//reorder rows for better usability
			RecallTypeC.Listt=new List<RecallType>();
			for(int i=0;i<list.Count;i++){
				if(list[i].RecallTypeNum==PrefC.GetLong(PrefName.RecallTypeSpecialProphy)){
					RecallTypeC.Listt.Add(list[i]);
					break;
				}
			}
			for(int i=0;i<list.Count;i++){
				if(list[i].RecallTypeNum==PrefC.GetLong(PrefName.RecallTypeSpecialChildProphy)){
					RecallTypeC.Listt.Add(list[i]);
					break;
				}
			}
			for(int i=0;i<list.Count;i++){
				if(list[i].RecallTypeNum==PrefC.GetLong(PrefName.RecallTypeSpecialPerio)){
					RecallTypeC.Listt.Add(list[i]);
					break;
				}
			}
			for(int i=0;i<list.Count;i++){//now add the rest
				if(!RecallTypeC.Listt.Contains(list[i])){
					RecallTypeC.Listt.Add(list[i]);
				}
			}
		}

		///<summary></summary>
		public static long Insert(RecallType recallType) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				recallType.RecallTypeNum=Meth.GetLong(MethodBase.GetCurrentMethod(),recallType);
				return recallType.RecallTypeNum;
			}
			return Crud.RecallTypeCrud.Insert(recallType);
		}

		///<summary></summary>
		public static void Update(RecallType recallType) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),recallType);
				return;
			}
			Crud.RecallTypeCrud.Update(recallType);
		}

		public static string GetDescription(long recallTypeNum) {
			//No need to check RemotingRole; no call to db.
			if(recallTypeNum==0){
				return "";
			}
			for(int i=0;i<RecallTypeC.Listt.Count;i++){
				if(RecallTypeC.Listt[i].RecallTypeNum==recallTypeNum){
					return RecallTypeC.Listt[i].Description;
				}
			}
			return "";
		}

		public static Interval GetInterval(long recallTypeNum) {
			//No need to check RemotingRole; no call to db.
			if(recallTypeNum==0){
				return new Interval(0,0,0,0);
			}
			for(int i=0;i<RecallTypeC.Listt.Count;i++){
				if(RecallTypeC.Listt[i].RecallTypeNum==recallTypeNum){
					return RecallTypeC.Listt[i].DefaultInterval;
				}
			}
			return new Interval(0,0,0,0);
		}

		///<summary>Returns a collection of proccodes (D####).  Count could be zero.</summary>
		public static List<string> GetProcs(long recallTypeNum) {
			//No need to check RemotingRole; no call to db.
			List<string> retVal=new List<string>();
			if(recallTypeNum==0){
				return retVal;
			}
			for(int i=0;i<RecallTypeC.Listt.Count;i++){
				if(RecallTypeC.Listt[i].RecallTypeNum==recallTypeNum){
					if(RecallTypeC.Listt[i].Procedures==""){
						return retVal;
					}
					string[] strArray=RecallTypeC.Listt[i].Procedures.Split(',');
					retVal.AddRange(strArray);
					return retVal;
				}
			}
			return retVal;
		}

		///<summary>Also makes sure both types are defined as special types.</summary>
		public static bool PerioAndProphyBothHaveTriggers(){
			//No need to check RemotingRole; no call to db.
			if(RecallTypes.PerioType==0 || RecallTypes.ProphyType==0){
				return false;
			}
			if(RecallTriggers.GetForType(RecallTypes.PerioType).Count==0){
				return false;
			}
			if(RecallTriggers.GetForType(RecallTypes.ProphyType).Count==0){
				return false;
			}
			return true;
		}

		public static string GetTimePattern(long recallTypeNum) {
			//No need to check RemotingRole; no call to db.
			if(recallTypeNum==0){
				return "";
			}
			for(int i=0;i<RecallTypeC.Listt.Count;i++){
				if(RecallTypeC.Listt[i].RecallTypeNum==recallTypeNum){
					return RecallTypeC.Listt[i].TimePattern;
				}
			}
			return "";
		}

		public static string GetSpecialTypeStr(long recallTypeNum) {
			//No need to check RemotingRole; no call to db.
			if(recallTypeNum==PrefC.GetLong(PrefName.RecallTypeSpecialProphy)){
				return Lans.g("FormRecallTypeEdit","Prophy");
			}
			if(recallTypeNum==PrefC.GetLong(PrefName.RecallTypeSpecialChildProphy)){
				return Lans.g("FormRecallTypeEdit","ChildProphy");
			}
			if(recallTypeNum==PrefC.GetLong(PrefName.RecallTypeSpecialPerio)){
				return Lans.g("FormRecallTypeEdit","Perio");
			}
			return "";
		}

		public static bool IsSpecialRecallType(long recallTypeNum) {
			//No need to check RemotingRole; no call to db.
			if(recallTypeNum==PrefC.GetLong(PrefName.RecallTypeSpecialProphy)) {
				return true;
			}
			if(recallTypeNum==PrefC.GetLong(PrefName.RecallTypeSpecialChildProphy)) {
				return true;
			}
			if(recallTypeNum==PrefC.GetLong(PrefName.RecallTypeSpecialPerio)) {
				return true;
			}
			return false;
		}

		///<summary>Gets a list of all active recall types.  Those without triggers are excluded.  Perio and Prophy are both included.  One of them should later be removed from the collection.</summary>
		public static List<RecallType> GetActive(){
			//No need to check RemotingRole; no call to db.
			List<RecallType> retVal=new List<RecallType>();
			List<RecallTrigger> triggers;
			for(int i=0;i<RecallTypeC.Listt.Count;i++){
				triggers=RecallTriggers.GetForType(RecallTypeC.Listt[i].RecallTypeNum);
				if(triggers.Count>0){
					retVal.Add(RecallTypeC.Listt[i].Copy());
				}
			}
			return retVal;
		}

		/*
		///<summary>Gets a list of all inactive recall types.  Only those without triggers are included.</summary>
		public static List<RecallType> GetInactive(){
			//No need to check RemotingRole; no call to db.
			List<RecallType> retVal=new List<RecallType>();
			List<RecallTrigger> triggers;
			for(int i=0;i<RecallTypeC.Listt.Count;i++){
				triggers=RecallTriggers.GetForType(RecallTypeC.Listt[i].RecallTypeNum);
				if(triggers.Count==0){
					retVal.Add(RecallTypeC.Listt[i].Clone());
				}
			}
			return retVal;
		}*/

		///<summary>Gets the pref table RecallTypeSpecialProphy RecallTypeNum.</summary>
		public static long ProphyType{
			//No need to check RemotingRole; no call to db.
			get{
				return PrefC.GetLong(PrefName.RecallTypeSpecialProphy);
			}
		}

		///<summary>Gets the pref table RecallTypeSpecialPerio RecallTypeNum.</summary>
		public static long PerioType{
			//No need to check RemotingRole; no call to db.
			get{
				return PrefC.GetLong(PrefName.RecallTypeSpecialPerio);
			}
		}

		///<summary>Gets the pref table RecallTypeSpecialChildProphy RecallTypeNum.</summary>
		public static long ChildProphyType{
			//No need to check RemotingRole; no call to db.
			get{
				return PrefC.GetLong(PrefName.RecallTypeSpecialChildProphy);
			}
		}

		/// <summary>Deletes the current recalltype and recalltrigger tables and fills them with our default.  Typically ran to switch T codes to D codes.</summary>
		public static void SetToDefault() {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod());
				return;
			}
			string command="DELETE FROM recalltype";
			Db.NonQ(command);
			command="INSERT INTO recalltype (RecallTypeNum,Description,DefaultInterval,TimePattern,Procedures) VALUES (1,'Prophy',393217,'/XXXX/','D0120,D1110')";
			Db.NonQ(command);
			command="INSERT INTO recalltype (RecallTypeNum,Description,DefaultInterval,TimePattern,Procedures) VALUES (2,'Child Prophy',0,'XXX','D0120,D1120,D1203')";
			Db.NonQ(command);
			command="INSERT INTO recalltype (RecallTypeNum,Description,DefaultInterval,TimePattern,Procedures) VALUES (3,'Perio',262144,'/XXXX/','D4910')";
			Db.NonQ(command);
			command="INSERT INTO recalltype (RecallTypeNum,Description,DefaultInterval,Procedures) VALUES (4,'4BW',16777216,'D0274')";
			Db.NonQ(command);
			command="INSERT INTO recalltype (RecallTypeNum,Description,DefaultInterval,Procedures) VALUES (5,'Pano',83886080,'D0330')";
			Db.NonQ(command);
			command="INSERT INTO recalltype (RecallTypeNum,Description,DefaultInterval,Procedures) VALUES (6,'FMX',83886080,'D0210')";
			Db.NonQ(command);
			command="DELETE FROM recalltrigger";
			Db.NonQ(command);
			//command="INSERT INTO recalltrigger (RecallTriggerNum,RecallTypeNum,CodeNum) VALUES (1,1,"+ProcedureCodes.GetCodeNum("D0415")+")";//collection of microorg for culture
			//Db.NonQ(command);
			command="INSERT INTO recalltrigger (RecallTriggerNum,RecallTypeNum,CodeNum) VALUES (1,1,"+ProcedureCodes.GetCodeNum("D0150")+")";
			Db.NonQ(command);
			command="INSERT INTO recalltrigger (RecallTriggerNum,RecallTypeNum,CodeNum) VALUES (2,4,"+ProcedureCodes.GetCodeNum("D0274")+")";
			Db.NonQ(command);
			command="INSERT INTO recalltrigger (RecallTriggerNum,RecallTypeNum,CodeNum) VALUES (3,5,"+ProcedureCodes.GetCodeNum("D0330")+")";
			Db.NonQ(command);
			command="INSERT INTO recalltrigger (RecallTriggerNum,RecallTypeNum,CodeNum) VALUES (4,6,"+ProcedureCodes.GetCodeNum("D0210")+")";
			Db.NonQ(command);
			command="INSERT INTO recalltrigger (RecallTriggerNum,RecallTypeNum,CodeNum) VALUES (5,1,"+ProcedureCodes.GetCodeNum("D1110")+")";
			Db.NonQ(command);
			command="INSERT INTO recalltrigger (RecallTriggerNum,RecallTypeNum,CodeNum) VALUES (6,1,"+ProcedureCodes.GetCodeNum("D1120")+")";
			Db.NonQ(command);
			command="INSERT INTO recalltrigger (RecallTriggerNum,RecallTypeNum,CodeNum) VALUES (7,3,"+ProcedureCodes.GetCodeNum("D4910")+")";
			Db.NonQ(command);
			command="INSERT INTO recalltrigger (RecallTriggerNum,RecallTypeNum,CodeNum) VALUES (8,3,"+ProcedureCodes.GetCodeNum("D4341")+")";
			Db.NonQ(command);
			//Update the special types in preference table.
			command="UPDATE preference SET ValueString='1' WHERE PrefName='RecallTypeSpecialProphy'";
			Db.NonQ(command);
			command="UPDATE preference SET ValueString='2' WHERE PrefName='RecallTypeSpecialChildProphy'";
			Db.NonQ(command);
			command="UPDATE preference SET ValueString='3' WHERE PrefName='RecallTypeSpecialPerio'";
			Db.NonQ(command);
			command="UPDATE preference SET ValueString='1,2,3' WHERE PrefName='RecallTypesShowingInList'";
			Db.NonQ(command);
		}



	}
}