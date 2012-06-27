using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace OpenDentBusiness{
	///<summary></summary>
	public class AllergyDefs{

		///<summary>Gets one AllergyDef from the db.</summary>
		public static AllergyDef GetOne(long allergyDefNum){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb){
				return Meth.GetObject<AllergyDef>(MethodBase.GetCurrentMethod(),allergyDefNum);
			}
			return Crud.AllergyDefCrud.SelectOne(allergyDefNum);
		}

		///<summary></summary>
		public static long Insert(AllergyDef allergyDef){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb){
				allergyDef.AllergyDefNum=Meth.GetLong(MethodBase.GetCurrentMethod(),allergyDef);
				return allergyDef.AllergyDefNum;
			}
			return Crud.AllergyDefCrud.Insert(allergyDef);
		}

		///<summary></summary>
		public static void Update(AllergyDef allergyDef){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb){
				Meth.GetVoid(MethodBase.GetCurrentMethod(),allergyDef);
				return;
			}
			Crud.AllergyDefCrud.Update(allergyDef);
		}

		///<summary></summary>
		public static List<AllergyDef> TableToList(DataTable table) {
			//No need to check RemotingRole; no call to db.
			return Crud.AllergyDefCrud.TableToList(table);
		}

		///<summary></summary>
		public static void Delete(long allergyDefNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),allergyDefNum);
				return;
			}
			string command= "DELETE FROM allergydef WHERE AllergyDefNum = "+POut.Long(allergyDefNum);
			Db.NonQ(command);
			DeletedObjects.SetDeleted(DeletedObjectType.AllergyDef,allergyDefNum);
		}

		///<summary>Gets all AllergyDefs based on hidden status.</summary>
		public static List<AllergyDef> GetAll(bool isHidden) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb){
				return Meth.GetObject<List<AllergyDef>>(MethodBase.GetCurrentMethod(),isHidden);
			}
			string command="";
			if(!isHidden) {
				command="SELECT * FROM allergydef WHERE IsHidden="+POut.Bool(isHidden)
					+" ORDER BY Description";
			}
			else {
				command="SELECT * FROM allergydef ORDER BY Description";
			}
			return Crud.AllergyDefCrud.SelectMany(command);
		}

		///<summary>Returns true if the allergy def is in use and false if not.</summary>
		public static bool DefIsInUse(long allergyDefNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb){
				return Meth.GetBool(MethodBase.GetCurrentMethod(),allergyDefNum);
			}
			string command="SELECT COUNT(*) FROM allergy WHERE AllergyDefNum="+POut.Long(allergyDefNum);
			if(Db.GetCount(command)!="0") {
				return true;
			}
			return false;
		}

		public static List<long> GetChangedSinceAllergyDefNums(DateTime changedSince) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetObject<List<long>>(MethodBase.GetCurrentMethod(),changedSince);
			}
			string command="SELECT AllergyDefNum FROM allergydef WHERE DateTStamp > "+POut.DateT(changedSince);
			DataTable dt=Db.GetTable(command);
			List<long> allergyDefNums = new List<long>(dt.Rows.Count);
			for(int i=0;i<dt.Rows.Count;i++) {
				allergyDefNums.Add(PIn.Long(dt.Rows[i]["AllergyDefNum"].ToString()));
			}
			return allergyDefNums;
		}

		///<summary>Used along with GetChangedSinceAllergyDefNums</summary>
		public static List<AllergyDef> GetMultAllergyDefs(List<long> allergyDefNums) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetObject<List<AllergyDef>>(MethodBase.GetCurrentMethod(),allergyDefNums);
			}
			string strAllergyDefNums="";
			DataTable table;
			if(allergyDefNums.Count>0) {
				for(int i=0;i<allergyDefNums.Count;i++) {
					if(i>0) {
						strAllergyDefNums+="OR ";
					}
					strAllergyDefNums+="AllergyDefNum='"+allergyDefNums[i].ToString()+"' ";
				}
				string command="SELECT * FROM allergydef WHERE "+strAllergyDefNums;
				table=Db.GetTable(command);
			}
			else {
				table=new DataTable();
			}
			AllergyDef[] multAllergyDefs=Crud.AllergyDefCrud.TableToList(table).ToArray();
			List<AllergyDef> allergyDefList=new List<AllergyDef>(multAllergyDefs);
			return allergyDefList;
		}

		///<summary>Returns the text for a SnomedAllergy Enum as it should appear in human readable form for a CCD.</summary>
		public static string GetSnomedAllergyDesc(SnomedAllergy snomed) {
			string result;
			switch(snomed){
				case SnomedAllergy.AdverseReactions:
					result="420134006 - Propensity to adverse reactions (disorder)";
					break;
				case SnomedAllergy.AdverseReactionsToDrug:
					result="419511003 - Propensity to adverse reactions to drug (disorder)";
					break;
				case SnomedAllergy.AdverseReactionsToFood:
					result="418471000 - Propensity to adverse reactions to food (disorder)";
					break;
				case SnomedAllergy.AdverseReactionsToSubstance:
					result="419199007 - Propensity to adverse reactions to substance (disorder)";
					break;
				case SnomedAllergy.AllergyToSubstance:
					result="418038007 - Allergy to substance (disorder)";
					break;
				case SnomedAllergy.DrugAllergy:
					result="416098002 - Drug allergy (disorder)";
					break;
				case SnomedAllergy.DrugIntolerance:
					result="59037007 - Drug intolerance (disorder)";
					break;
				case SnomedAllergy.FoodAllergy:
					result="235719002 - Food allergy (disorder)";
					break;
				case SnomedAllergy.FoodIntolerance:
					result="420134006 - Food intolerance (disorder)";
					break;
				case SnomedAllergy.None:
					result="";
					break;
				default:
					result="Error";
					break;
			}
			return result;
		}

		///<summary>Returns the name of the allergy. Returns an empty string if allergyDefNum=0.</summary>
		public static string GetDescription(long allergyDefNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetString(MethodBase.GetCurrentMethod(),allergyDefNum);
			}
			if(allergyDefNum==0) {
				return "";
			}
			return Crud.AllergyDefCrud.SelectOne(allergyDefNum).Description;
		}

	}
}