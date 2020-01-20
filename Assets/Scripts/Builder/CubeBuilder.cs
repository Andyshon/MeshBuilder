using System.Collections.Generic;
using Handlers;
using UnityEngine;

namespace Builder
{
    public class CubeBuilder: IMeshName, IMeshDimension, IMeshColor, ICoordinates
    {
        private string _name = "Cube";
        private float _length = 1;
        private float _width = 1;
        private float _height = 1;

        private Vector3 _position;
        private Color _color = new Color(0f, 0.7f, 0f);

        public static CubeBuilder Start()
        {
            return new CubeBuilder();
        }

        public Cube Build()
        {
            var cube = new Cube
            {
                Name = _name,
                Height = _height,
                Length = _length,
                Width = _width,
                Color = _color,
                Position = _position,
                GameObject = new GameObject(_name) {tag = "MyCube"}
            };

            ApplyDefaultMesh(cube);
            
            return cube;
        }
        
        public IMeshColor WithName(string name)
        {
            this._name = name;
            return this;
        }

        private void ApplyDefaultMesh(Cube cube)
        {
            cube.GameObject.transform.position = _position;
            cube.GameObject.AddComponent<CubeHandler>();
            cube.GameObject.AddComponent<MeshRenderer>();
            var meshFilter = cube.GameObject.AddComponent<MeshFilter>();
            cube.Mesh = meshFilter.mesh;
            
            // var material = new Material(Shader.Find("Standard"));
            var material = Resources.Load("CubeMaterial", typeof(Material)) as Material;
            //material.SetColor("_Color", cube.Color);
            cube.GameObject.GetComponent<Renderer>().material = material;
            
            var c = SetCoordinates(new Vector3[8]);
            var vertices = SetVertices(c);
            var triangles = SetTriangles();
            
            cube.Mesh.Clear();
            cube.Mesh.vertices = vertices;
            cube.Mesh.triangles = triangles;
            cube.Mesh.Optimize();
            cube.Mesh.RecalculateNormals();
            
            cube.GameObject.AddComponent<MeshCollider>();
            cube.GameObject.GetComponent<MeshCollider>().sharedMesh = cube.Mesh;
        }

        public IMeshDimension WithColor(Color color)
        {
            this._color = color;
            return this;
        }
        

        public ICoordinates WithDimension(float length, float width, float height)
        {
            this._length = length;
            this._width = width;
            this._height = height;
            return this;
        }

        public CubeBuilder WithCoordinates(Vector3 position)
        {
            this._position = position;
            return this;
        }
        
        // Define the co-ordinates of each Corner of the cube 
        private Vector3[] SetCoordinates(Vector3[] c)
        {
            float width = 10;
            float minus = -width / 2;
            float plus =  width / 2;
            c[0] = new Vector3(0 + minus, 0,0 + minus);
            c[1] = new Vector3(0 + plus, 0,0 + minus);
            c[2] = new Vector3(0 + plus, 0,0 + plus);
            c[3] = new Vector3(0 + minus, 0,0 + plus);
            
            c[4] = new Vector3(0 + minus,0 + width, 0 + minus);
            c[5] = new Vector3(0 + plus, 0 + width, 0 + minus);
            c[6] = new Vector3(0 + plus, 0 + width,  0 + plus);
            c[7] = new Vector3(0 + minus, 0 + width, 0 + plus);
            
            return c;
        }
        
        // Define the vertices that the cube is composed of 16 vertices (4 vertices per side).
        private static Vector3[] SetVertices(IReadOnlyList<Vector3> c)
        {
            return new Vector3[]
            {
                c[0], c[1], c[2], c[3],
                c[4], c[5], c[6], c[7]
            };
        }

        // Define the Polygons (triangles) that make up the Mesh
        // Unity uses a 'Clockwise Winding Order' for determining front-facing polygons.
        private static int[] SetTriangles()
        {
            return new int[]
            {
                0,1,3, 1,2,3,
                3,7,4, 0,3,4,
                0,4,5, 1,0,5,
                1,5,6, 2,1,6,
                2,6,7, 3,2,7,
                4,7,6, 6,5,4
            };
        }
    }
}