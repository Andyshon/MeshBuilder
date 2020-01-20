using UnityEngine;

namespace Builder
{
    public interface IMeshColor
    {
        IMeshDimension WithColor(Color color);
    }
}