using System.Collections;
using UnityEngine;

public class CubeMesh : MonoBehaviour
{
    private Vector3[] vertices;
    private Vector2[] uvs;
    private int[] triangles;
    private Mesh mesh;


    private Color[] colors;
    private void Start()
    {

        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        mesh = GetComponent<MeshFilter>().mesh;
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        //Material mat = new Material(Shader.Find("Unlit"));

        mesh.Clear();

        // DrawRectangle(mesh);

        // DrawCube(mesh);


        //mat.color = new Color(0.13f, 0.19f, 0.34f);

        //renderer.material = mat;


        StartCoroutine(BuildingCreator(mesh, 15, 4));
            colors = new Color[vertices.Length];
    }

    private void Update()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = new Color(i*10, i*10, i*10);
        }

        mesh.colors = colors;
    }

    private void DrawRectangle(Mesh mesh)
    {
        mesh.vertices = new Vector3[]
        {
            new Vector3(0, 0,0), new Vector3(0, 1,0), new Vector3(1, 1,0),
            new Vector3(1,0,0), new Vector3(2, 0), new Vector3(2, 1), 
        };
        mesh.triangles =  new int[]
        {
            0, 1, 2,
            0, 2, 3,
            2, 5, 3,
            3, 5, 4
        };
    }

    // private void DrawCube(Mesh mesh)
    // {
    //     vertices = new[]
    //     {
    //         new Vector3(0, 0, 0),
    //         new Vector3(1, 0, 0),
    //         new Vector3(1, 0, 1),
    //         new Vector3(0, 0, 1),
    //         new Vector3(0, 1, 0),
    //         new Vector3(1, 1, 0),
    //         new Vector3(1, 1, 1),
    //         new Vector3(0, 1, 1),
    //     };
    //
    //     triangles = new[]
    //     {
    //         0,1,2,
    //         2,3,0,
    //         
    //         0,4,5,
    //         5,1,0,
    //         
    //         5,6,2,
    //         2,1,5,
    //         
    //         2,6,7,
    //         7,3,2,
    //         
    //         3,7,4,
    //         4,0,3,
    //         
    //         4,7,6,
    //         4,6,5
    //     };
    //
    //     mesh.vertices = vertices;
    //     mesh.triangles = triangles;
    // }

    private IEnumerator BuildingCreator(Mesh mesh, int totalLevels, int corners)
    {
        vertices = new Vector3[(totalLevels + 1) * corners];
        triangles = new int[totalLevels * corners * 6];

        int kostilb = 0;
        
        for (int lvl = 0; lvl < (totalLevels + 1); lvl++)
        {
            for (int j = 0; j < corners; j++)
            {
                int left = 0;
                int right = 0;

                if (j == 1)
                {
                    left = 1;
                }
                else if (j == 2)
                {
                    left = 1;
                    right = 1;
                }
                else if (j == 3)
                {
                    right = 1;
                }
                
                vertices[lvl * corners + j] = new Vector3(left, lvl, right);
            }
        }
        // //
        for (int lvl = 0; lvl < totalLevels; lvl++)
        {
            
            for (int j = 0; j < corners; j++)
            {
                int currentPoint = (lvl * corners) + j;
                
                for (int k = 0; k < 6; k++)
                {
                    int res = 0;
        
                    if (k == 0)
                    {
                        res = currentPoint;
                    }
                    else if (k == 1)
                    {
                        res = currentPoint + corners;
                    }
                    else if (k == 2)
                    {
                        if (j == corners - 1)
                        {
                            res = currentPoint + 1;
                        }
                        else
                        {
                            res = currentPoint + corners + 1;
                        }
                    }
                    else if (k == 3)
                    {
                        res = currentPoint + 1;
                        if (j == corners- 1)
                        {
                            res -= corners;
                        }
                    }
                    else if (k == 4)
                    {
                        res = currentPoint;
                    }
                    else if (k == 5)
                    {
                        if (j == corners - 1)
                        {
                            res = currentPoint + 1;
                        }
                        else
                        {
                            res = currentPoint + corners + 1;
                        }
                    }

                    triangles[kostilb] = res;
                    
                    mesh.vertices = vertices;
                    mesh.triangles = triangles;
                    
                    kostilb++;
                    
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }
}