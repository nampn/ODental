﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SparksToothChart {
	///<summary>Contains one vertex (xyz) and one normal.</summary>
	public class VertexNormal {
		public Vertex3f Vertex;
		public Vertex3f Normal;

		public override string ToString() {
			return "v:"+Vertex.ToString()+" n:"+Normal.ToString();
		}

		public VertexNormal Copy(){
			VertexNormal vn=new VertexNormal();
			vn.Vertex=this.Vertex.Copy();
			vn.Normal=this.Normal.Copy();
			return vn;
		}
	}
}
