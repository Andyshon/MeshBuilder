using Builder;
using UnityEngine;

namespace Handlers
{
    public class CubeHandler : MonoBehaviour
    {
        private Material _material;

        private void Start()
        {
            _material= Resources.Load("CubeMaterial", typeof(Material)) as Material;
        }

        private void OnMouseOver()
        {
            this.gameObject.GetComponent<MeshRenderer>().materials[0].SetColor("_Color", Color.red);
        }

        private void OnMouseExit()
        {
            this.gameObject.GetComponent<Renderer>().material = _material;
        }

        private void OnMouseDown()
        {
            var p = transform.position; p.y += 10;
        
            foreach (var obj in CubesBasket.Cubes)
            {
                if (((Cube) obj).Position == p)
                {
                    Debug.Log("That place is own by another cube!!!");
                    return;
                }
            }
        
            var cube = CubeBuilder.Start()
                .WithName("Cubinio")
                .WithColor(new Color(0.7f, 0.49f, 0.04f))
                .WithDimension(1, 1, 1)
                .WithCoordinates(p)
                .Build();

            CubesBasket.Cubes.Add(cube);
        }
    }
}