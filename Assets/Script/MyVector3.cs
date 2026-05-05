using UnityEngine;

public class MyVector3
{
    public float x, y, z;

    public MyVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static float Scalaire(MyVector3 a, MyVector3 b)
    {
        return ((a.x * b.x) + (a.y * b.y) + (a.z * b.z));
    }

    public static MyVector3 Produit(MyVector3 a, MyVector3 b)
    {
        float nX = (a.y * b.z) - (a.z * b.y);
        float nY = (a.z * b.x) - (a.x * b.z);
        float nZ = (a.x * b.y) - (a.y * b.x);
        
        return new MyVector3(nX, nY, nZ);
    }
}
