using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using OpenCAD.Core.Graphics;
using OpenCAD.Core.Maths;
using OpenCAD.Core.Modeling.Datums;
using OpenCAD.Core.Topology;
using OpenCAD.GUI.Buffers;
using SharpGL;
using SharpGL.Enumerations;

namespace OpenCAD.GUI.SceneGraph
{
    public class GeometryLeaf : ILeafNode
    {
        private readonly OpenGL _gl;
        private readonly IShaderProgram _shader;
        private readonly VAO _lineVAO;
        private readonly VAO _pointVAO;
        private readonly Vect4 _edgecolour = Color.FromArgb(255, 0, 112, 204).ToVector4();
        private readonly Vect4 _basecolour = Color.FromArgb(50, 0, 112, 204).ToVector4();
        private const float Size = 10f;

        public GeometryLeaf(OpenGL gl, IShaderProgram shader)
        {
            _gl = gl;
            _shader = shader;

            const double s = 5.0;
            var v0 = new Vertex("v0", new Vect3(0, 0, 0));
            var v1 = new Vertex("v1", new Vect3(0, 0, s));
            var v2 = new Vertex("v2", new Vect3(s, 0, s));
            var v3 = new Vertex("v3", new Vect3(s, 0, 0));
            var v4 = new Vertex("v4", new Vect3(0, s, 0));
            var v5 = new Vertex("v5", new Vect3(0, s, s));
            var v6 = new Vertex("v6", new Vect3(s, s, s));
            var v7 = new Vertex("v7", new Vect3(s, s, 0));


            var f0 = new Face("f0");
            var f1 = new Face("f1");
            var f2 = new Face("f2");
            var f3 = new Face("f3");
            var f4 = new Face("f4");
            var f5 = new Face("f5");
            LineHalfEdge e0a = null;
            LineHalfEdge e0b = null;
            LineHalfEdge e1a = null;
            LineHalfEdge e1b = null;
            LineHalfEdge e2a = null;
            LineHalfEdge e2b = null;
            LineHalfEdge e3a = null;
            LineHalfEdge e3b = null;
            LineHalfEdge e4a = null;
            LineHalfEdge e4b = null;
            LineHalfEdge e5a = null;
            LineHalfEdge e5b = null;
            LineHalfEdge e6a = null;
            LineHalfEdge e6b = null;
            LineHalfEdge e7a = null;
            LineHalfEdge e7b = null;
            LineHalfEdge e8a = null;
            LineHalfEdge e8b = null;
            LineHalfEdge e9a = null;
            LineHalfEdge e9b = null;
            LineHalfEdge e10a = null;
            LineHalfEdge e10b = null;
            LineHalfEdge e11a = null;
            LineHalfEdge e11b = null;

            e0a = new LineHalfEdge("e0a", v1, new Lazy<IHalfEdge>(() => e0b), f0);
            e1a = new LineHalfEdge("e1a", v2, new Lazy<IHalfEdge>(() => e1b), f0);
            e2a = new LineHalfEdge("e2a", v3, new Lazy<IHalfEdge>(() => e2b), f0);
            e3a = new LineHalfEdge("e3a", v0, new Lazy<IHalfEdge>(() => e3b), f0);
            f0.Loops.Add(new EdgeLoop(e0a, e1a, e2a, e3a));

            e0b = new LineHalfEdge("e0b", v0, new Lazy<IHalfEdge>(() => e0a), f1);
            e7a = new LineHalfEdge("e7a", v4, new Lazy<IHalfEdge>(() => e7b), f1);
            e8a = new LineHalfEdge("e8a", v5, new Lazy<IHalfEdge>(() => e8b), f1);
            e4a = new LineHalfEdge("e4a", v1, new Lazy<IHalfEdge>(() => e4b), f1);
            f1.Loops.Add(new EdgeLoop(e0b, e7a, e8a, e4a));

            e1b = new LineHalfEdge("e1b", v1, new Lazy<IHalfEdge>(() => e1a), f2);
            e4b = new LineHalfEdge("e4b", v5, new Lazy<IHalfEdge>(() => e4a), f2);
            e9a = new LineHalfEdge("e9a", v6, new Lazy<IHalfEdge>(() => e9b), f2);
            e5a = new LineHalfEdge("e5a", v2, new Lazy<IHalfEdge>(() => e5b), f2);
            f2.Loops.Add(new EdgeLoop(e1b, e4b, e9a, e5a));


            e2b = new LineHalfEdge("e2b", v2, new Lazy<IHalfEdge>(() => e2a), f3);
            e5b = new LineHalfEdge("e5b", v6, new Lazy<IHalfEdge>(() => e5a), f3);
            e10a = new LineHalfEdge("e10a", v7, new Lazy<IHalfEdge>(() => e10b), f3);
            e6a = new LineHalfEdge("e6a", v3, new Lazy<IHalfEdge>(() => e6b), f3);
            f3.Loops.Add(new EdgeLoop(e2b, e5b, e10a, e6a));


            e3b = new LineHalfEdge("e3b", v3, new Lazy<IHalfEdge>(() => e3a), f4);
            e6b = new LineHalfEdge("e6b", v7, new Lazy<IHalfEdge>(() => e6a), f4);
            e11a = new LineHalfEdge("e11a", v4, new Lazy<IHalfEdge>(() => e11b), f4);
            e7b = new LineHalfEdge("e7b", v0, new Lazy<IHalfEdge>(() => e7a), f4);
            f4.Loops.Add(new EdgeLoop(e3b, e6b, e11a, e7b));


            e8b = new LineHalfEdge("e8b", v4, new Lazy<IHalfEdge>(() => e8a), f5);
            e11b = new LineHalfEdge("e11b", v7, new Lazy<IHalfEdge>(() => e11a), f5);
            e10b = new LineHalfEdge("e10b", v6, new Lazy<IHalfEdge>(() => e10a), f5);
            e9b = new LineHalfEdge("e9b", v5, new Lazy<IHalfEdge>(() => e9b), f5);
            f5.Loops.Add(new EdgeLoop(e8b, e11b, e10b, e9b));

            var shell = new Shell(f0, f1, f2, f3, f4, f5);

            var linedata = new List<Vert>();
            var pointdata = new List<Vert>();

            var t = CreateT(10).ToArray();
            

            foreach (var face in shell.Faces)
            {
                foreach (var loop in face.Loops)
                {
                    foreach (var edge in loop.Edges)
                    {
                        var points = t.Select(v => edge.Equation(v)).ToArray();
                        foreach (var lines in points.Zip(points.Skip(1), Tuple.Create))
                        {
                            linedata.Add(new Vert(lines.Item1, Vect3.Zero, Color.Gold.ToVector4()));
                            linedata.Add(new Vert(lines.Item2, Vect3.Zero, Color.Red.ToVector4()));
                        }
                        pointdata.AddRange(points.Select(d => new Vert(d, Vect3.Zero, Color.Gold.ToVector4())));
                    }
                }
            }

            _lineVAO = new VAO(gl, _shader, new VBO(gl, BeginMode.Lines, linedata));
            _pointVAO = new VAO(gl, _shader, new VBO(gl, BeginMode.Points, pointdata));
        }

        public void Render()
        {
            _gl.Disable(OpenGL.GL_DEPTH_TEST);
            _gl.PointSize(5f);
            _lineVAO.Render();
            _pointVAO.Render();
            _gl.Enable(OpenGL.GL_DEPTH_TEST);
        }

        private IEnumerable<double> CreateT(int numberOfSpaces)
        {
            var space = 1.0 / numberOfSpaces;
            for (int i = 0; i < numberOfSpaces; i++)
            {
                yield return i*space;
            }
            yield return 1.0;
        } 
    }
}