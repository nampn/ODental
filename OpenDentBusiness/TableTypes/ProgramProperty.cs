using System;

namespace OpenDentBusiness{

	///<summary>Some program links (bridges), have properties that need to be set.  The property names are always hard coded.  User can change the value.  The property is usually retrieved based on its name.</summary>
	[Serializable]
	public class ProgramProperty:TableBase {
		///<summary>Primary key.</summary>
		[CrudColumn(IsPriKey=true)]
		public long ProgramPropertyNum;
		///<summary>FK to program.ProgramNum</summary>
		public long ProgramNum;
		///<summary>The description or prompt for this property.</summary>
		public string PropertyDesc;
		///<summary>The value.</summary>
		public string PropertyValue;
	}

	



	

	


}










