using Builder;
using UnityEngine;

namespace Handlers
{
    public class PlaneHandler : MonoBehaviour
    {
        private void OnMouseOver()
        {
            ChangeColor(Color.blue);
        }

        private void OnMouseExit()
        {
            ChangeColor(Color.white);
        }

        private void ChangeColor(Color color)
        {
            this.gameObject.GetComponent<MeshRenderer>().materials[0].SetColor("_Color", color);
        }

        private void OnMouseDown()
        {
            var cube = CubeBuilder.Start()
                .WithName("Cubinio")
                .WithColor(new Color(0.7f, 0.49f, 0.04f))
                .WithDimension(1,1,1)
                .WithCoordinates(transform.position)
                .Build();

            CubesBasket.Cubes.Add(cube);
        }
    }
}