using Builder;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    private static Cube _cube;

    void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("R")))
        {
            // DrawCube(3);
        }
    }

    public static void DrawCube(float levels)
    {
        DestroyAllCubes();
        
        _cube = CubeBuilder.Start()
            .WithName("Cubinio")
            .WithColor(new Color(0.7f, 0.49f, 0.04f))
            .WithDimension(1,1,levels)
            .WithCoordinates(new Vector3(0,0,0))
            .Build();

        _cube.GameObject.transform.Translate(0f, 1f, -8f);
    }

    private static void DestroyAllCubes()
    {
        var gameObjects = GameObject.FindGameObjectsWithTag("MyCube");
        foreach (var obj in gameObjects)
        {
            Destroy(obj);
        }
    }
}