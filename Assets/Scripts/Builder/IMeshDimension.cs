namespace Builder
{
    public interface IMeshDimension
    {
        ICoordinates WithDimension(float length, float width, float height);
    }
}