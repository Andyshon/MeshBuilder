using UnityEngine;

public class SimpleMeshCreator : MonoBehaviour {
	
	GameObject _cube;
	private Mesh mesh;

	private Vector3[] vertices;
	private int[] triangles;

	private float length = 1f;
	private float width = 1f;
	private float height = 1f;

	private Vector3[] c;

	void Start () {
		InitGameObject();
        
        SetDimensions(1,1,1);
        SetCoordinates();
        SetVertices(); 
        SetTriangles();
        
        BuildMesh();
        ApplyMaterial();
    }

	// 1) Create an empty GameObject with the required Components
	private void InitGameObject()
	{
		_cube = new GameObject("My Cube"); 
		_cube.AddComponent<MeshRenderer>();
		MeshFilter meshFilter = _cube.AddComponent<MeshFilter>();
		mesh = meshFilter.mesh;	
	}

	// 2) Define the cube's dimensions
	private void SetDimensions(float length, float width, float height)
	{
		this.length = length;
		this.width = width;
		this.height = height;
	}

	// 3) Define the co-ordinates of each Corner of the cube 
	private void SetCoordinates()
	{
		c = new Vector3[8];

		c[0] = new Vector3(-length * .5f, -width * .5f, height * .5f);
		c[1] = new Vector3(length * .5f, -width * .5f, height * .5f);
		c[2] = new Vector3(length * .5f, -width * .5f, -height * .5f);
		c[3] = new Vector3(-length * .5f, -width * .5f, -height * .5f);

		c[4] = new Vector3(-length * .5f, width * .5f, height * .5f);
		c[5] = new Vector3(length * .5f, width * .5f, height * .5f);
		c[6] = new Vector3(length * .5f, width * .5f, -height * .5f);
		c[7] = new Vector3(-length * .5f, width * .5f, -height * .5f);
	}

	// 4) Define the vertices that the cube is composed of 16 vertices (4 vertices per side).
	private void SetVertices()
	{
		vertices = new Vector3[]
		{
			c[0], c[1], c[2], c[3], // Bottom
			c[7], c[4], c[0], c[3], // Left
			c[4], c[5], c[1], c[0], // Front
			c[6], c[7], c[3], c[2], // Back
			c[5], c[6], c[2], c[1], // Right
			c[7], c[6], c[5], c[4]  // Top
		};
	}

	// 5) Define the Polygons (triangles) that make up the Mesh
	// Unity uses a 'Clockwise Winding Order' for determining front-facing polygons.
	private void SetTriangles()
	{
		triangles = new int[]
		{
			3, 1, 0,        3, 2, 1,        // Bottom	
			7, 5, 4,        7, 6, 5,        // Left
			11, 9, 8,       11, 10, 9,      // Front
			15, 13, 12,     15, 14, 13,     // Back
			19, 17, 16,     19, 18, 17,	    // Right
			23, 21, 20,     23, 22, 21,	    // Top
		};
	}

	private void BuildMesh()
	{
		mesh.Clear();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.Optimize();
		mesh.RecalculateNormals();

		_cube.transform.Translate(0f, 1f, -8f);	
	}

	private void ApplyMaterial()
	{
		Material cubeMaterial = new Material(Shader.Find("Standard"));
		cubeMaterial.SetColor("_Color", new Color(0f, 0.7f, 0f));
		_cube.GetComponent<Renderer>().material = cubeMaterial;	
	}
	
	
    void Update () {
        //Rotate the cube
        // _cube.transform.Rotate(5f * Time.deltaTime, 15f * Time.deltaTime, 3f * Time.deltaTime);
    }
}