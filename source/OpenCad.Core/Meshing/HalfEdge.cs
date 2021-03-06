﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//clockwise half edge
namespace OpenCAD.Core.Meshing
{
    public class HalfEdge
    {
        public MeshVertex ToVertex { get; set; }
        public HalfEdge Opposite { get; set; }
        public HalfEdgeFace HalfEdgeFace { get; set; }
        public HalfEdge Next { get; set; }
        public MeshVertex FromVertex { get { return Opposite.ToVertex; } }

        public HalfEdge()
        {
            
        }
        public override string ToString()
        {
            return "HalfEdge<From:{0},To{1}>".fmt(ToVertex,FromVertex);
        }
    }
}
