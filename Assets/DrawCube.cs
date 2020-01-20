using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCube : MonoBehaviour
{
    
    private Vector3[] vertices;
    private int[] triangles;
    private Mesh mesh;

    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        mesh = GetComponent<MeshFilter>().mesh;

        mesh.Clear();
        
        draw(mesh);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void draw(Mesh mesh)
    {
        // 000
        //     100
        //         101
        //             001
        // 010
        //     110
        //         111
        //             011
        vertices = new[]
        {
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, 0, 1),
            new Vector3(0, 0, 1),
            new Vector3(0, 1, 0),
            new Vector3(1, 1, 0),
            new Vector3(1, 1, 1),
            new Vector3(0, 1, 1),
        };

        triangles = new[]
        {
            0,1,2,
            2,3,0,
            
            0,4,5,
            5,1,0,
            
            5,6,2,
            2,1,5,
            
            2,6,7,
            7,3,2,
            
            3,7,4,
            4,0,3,
            
            4,7,6,
            4,6,5
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}
