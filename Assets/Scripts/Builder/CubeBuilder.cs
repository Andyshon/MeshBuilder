using System.Collections.Generic;
using UnityEngine;

namespace Builder
{
    public class CubeBuilder: IMeshName, IMeshDimension, IMeshColor
    {
        private string _name = "Cube";
        private float _length = 1;
        private float _width = 1;
        private float _height = 1;

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
                GameObject = new GameObject(_name)
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
            cube.GameObject.AddComponent<MeshRenderer>();
            var meshFilter = cube.GameObject.AddComponent<MeshFilter>();
            cube.Mesh = meshFilter.mesh;
            
            var material = new Material(Shader.Find("Standard"));
            material.SetColor("_Color", cube.Color);
            cube.GameObject.GetComponent<Renderer>().material = material;
            
            var c = SetCoordinates(new Vector3[8]);
            var vertices = SetVertices(c);
            var triangles = SetTriangles();
            
            cube.Mesh.Clear();
            cube.Mesh.vertices = vertices;
            cube.Mesh.triangles = triangles;
            cube.Mesh.Optimize();
            cube.Mesh.RecalculateNormals();
        }

        public IMeshDimension WithColor(Color color)
        {
            this._color = color;
            return this;
        }

        public CubeBuilder WithDimension(float length, float width, float height)
        {
            this._length = length;
            this._width = width;
            this._height = height;
            return this;
        }
        
        
        
        
        
        
        // Define the co-ordinates of each Corner of the cube 
        private Vector3[] SetCoordinates(Vector3[] c)
        {
            c[0] = new Vector3(-_length * .5f, -_width * .5f, _height * .5f);
            c[1] = new Vector3(_length * .5f, -_width * .5f, _height * .5f);
            c[2] = new Vector3(_length * .5f, -_width * .5f, -_height * .5f);
            c[3] = new Vector3(-_length * .5f, -_width * .5f, -_height * .5f);

            c[4] = new Vector3(-_length * .5f, _width * .5f, _height * .5f);
            c[5] = new Vector3(_length * .5f, _width * .5f, _height * .5f);
            c[6] = new Vector3(_length * .5f, _width * .5f, -_height * .5f);
            c[7] = new Vector3(-_length * .5f, _width * .5f, -_height * .5f);

            return c;
        }

        // Define the vertices that the cube is composed of 16 vertices (4 vertices per side).
        private static Vector3[] SetVertices(IReadOnlyList<Vector3> c)
        {
            return new Vector3[]
            {
                c[0], c[1], c[2], c[3], // Bottom
                c[7], c[4], c[0], c[3], // Left
                c[4], c[5], c[1], c[0], // Front
                c[6], c[7], c[3], c[2], // Back
                c[5], c[6], c[2], c[1], // Right
                c[7], c[6], c[5], c[4]  // Top
            };
        }

        // Define the Polygons (triangles) that make up the Mesh
        // Unity uses a 'Clockwise Winding Order' for determining front-facing polygons.
        private static int[] SetTriangles()
        {
            return new int[]
            {
                3, 1, 0, 3, 2, 1, // Bottom	
                7, 5, 4, 7, 6, 5, // Left
                11, 9, 8, 11, 10, 9, // Front
                15, 13, 12, 15, 14, 13, // Back
                19, 17, 16, 19, 18, 17, // Right
                23, 21, 20, 23, 22, 21, // Top
            };
        }
    }
}