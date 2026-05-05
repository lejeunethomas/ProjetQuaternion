using UnityEngine;

public class MyVector4
{
    public float x, y, z, w;

    public MyVector4(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    public static float Scalaire(MyVector4 a, MyVector4 b)
    {
        return ((a.x * b.x) + (a.y * b.y) + (a.z * b.z) + (a.w * b.w));
    }
}
