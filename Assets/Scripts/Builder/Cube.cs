using UnityEngine;

namespace Builder
{
    public class Cube
    {
        public GameObject GameObject { get; set; }
        public Mesh Mesh { get; set; }
        public Color Color { get; set; }
        public Vector3 Position { get; set; }
        public string Name { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
    }
}