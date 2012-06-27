using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace OpenDentBusiness{
  ///<summary></summary>
	public class AutoCodeConds{
		
		///<summary></summary>
		public static DataTable RefreshCache() {
			//No need to check RemotingRole; Calls GetTableRemotelyIfNeeded().
			string command="SELECT * from autocodecond ORDER BY cond";
			DataTable table=Cache.GetTableRemotelyIfNeeded(MethodBase.GetCurrentMethod(),command);
			table.TableName="AutoCodeCond";
			FillCache(table);
			return table;
		}

		public static void FillCache(DataTable table){
			//No need to check RemotingRole; no call to db.
			AutoCodeCondC.List=Crud.AutoCodeCondCrud.TableToList(table).ToArray();
		}

		///<summary></summary>
		public static void ClearCache() {
			AutoCodeCondC.List=null;
		}

		///<summary></summary>
		public static long Insert(AutoCodeCond Cur){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Cur.AutoCodeCondNum=Meth.GetLong(MethodBase.GetCurrentMethod(),Cur);
				return Cur.AutoCodeCondNum;
			}
			return Crud.AutoCodeCondCrud.Insert(Cur);
		}

		///<summary></summary>
		public static void Update(AutoCodeCond Cur){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),Cur);
				return;
			}
			Crud.AutoCodeCondCrud.Update(Cur);
		}

		///<summary></summary>
		public static void Delete(AutoCodeCond Cur){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),Cur);
			}
			string command= "DELETE from autocodecond WHERE autocodecondnum = '"
				+POut.Long(Cur.AutoCodeCondNum)+"'";
			Db.NonQ(command);
		}

		///<summary></summary>
		public static void DeleteForItemNum(long itemNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),itemNum);
				return;
			}
			string command= "DELETE from autocodecond WHERE autocodeitemnum = '"
				+POut.Long(itemNum)+"'";//AutoCodeItems.Cur.AutoCodeItemNum)
			Db.NonQ(command);
		}

		///<summary></summary>
		public static List<AutoCodeCond> GetListForItem(long autoCodeItemNum) {
			//No need to check RemotingRole; no call to db.
			List<AutoCodeCond> retVal=new List<AutoCodeCond>();
			for(int i=0;i<AutoCodeCondC.List.Length;i++){
				if(AutoCodeCondC.List[i].AutoCodeItemNum==autoCodeItemNum){
					retVal.Add(AutoCodeCondC.List[i]);
				} 
			}
			return retVal;   
		}

		///<summary></summary>
		public static bool IsSurf(AutoCondition myAutoCondition){
			//No need to check RemotingRole; no call to db.
			switch(myAutoCondition){
				case AutoCondition.One_Surf:
				case AutoCondition.Two_Surf:
				case AutoCondition.Three_Surf:
				case AutoCondition.Four_Surf:
				case AutoCondition.Five_Surf:
					return true;
				default:
					return false;
			}
		}

		///<summary></summary>
		public static bool ConditionIsMet(AutoCondition myAutoCondition, string toothNum,string surf,bool isAdditional,bool willBeMissing,int age){
			//No need to check RemotingRole; no call to db.
			switch(myAutoCondition){
				case AutoCondition.Anterior:
					return Tooth.IsAnterior(toothNum);
				case AutoCondition.Posterior:
					return Tooth.IsPosterior(toothNum);
				case AutoCondition.Premolar:
					return Tooth.IsPreMolar(toothNum);
				case AutoCondition.Molar:
					return Tooth.IsMolar(toothNum);
				case AutoCondition.One_Surf:
					return surf.Length==1;
				case AutoCondition.Two_Surf:
					return surf.Length==2;
				case AutoCondition.Three_Surf:
					return surf.Length==3;
				case AutoCondition.Four_Surf:
					return surf.Length==4;
				case AutoCondition.Five_Surf:
					return surf.Length==5;
				case AutoCondition.First:
					return !isAdditional;
				case AutoCondition.EachAdditional:
					return isAdditional;
				case AutoCondition.Maxillary:
					return Tooth.IsMaxillary(toothNum);
				case AutoCondition.Mandibular:
					return !Tooth.IsMaxillary(toothNum);
				case AutoCondition.Primary:
					return Tooth.IsPrimary(toothNum);
				case AutoCondition.Permanent:
					return !Tooth.IsPrimary(toothNum);
				case AutoCondition.Pontic:
					return willBeMissing;
				case AutoCondition.Retainer:
					return !willBeMissing;
				case AutoCondition.AgeOver18:
					return age>18;
				default:
					return false;
			}
		}



	}

	

	


}









