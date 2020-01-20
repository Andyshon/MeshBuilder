using UnityEngine;

namespace Builder
{
    public interface ICoordinates
    {
        CubeBuilder WithCoordinates(Vector3 position);
    }
}