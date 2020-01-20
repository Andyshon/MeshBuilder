using Builder;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    private Cube _cube;
    private void Start()
    {
        _cube = CubeBuilder.Start()
            .WithName("Cubinio")
            .WithColor(new Color(0.7f, 0.49f, 0.04f))
            .WithDimension(1,1,1)
            .Build();

        _cube.GameObject.transform.Translate(0f, 1f, -8f);
    }
}