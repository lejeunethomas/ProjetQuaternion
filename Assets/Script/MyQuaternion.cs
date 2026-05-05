using UnityEngine;
using System;

public class MyQuaternion
{
    public float a, x, y, z;

    public MyQuaternion(float real, float x, float y, float z)
    {
        this.a = real;
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static MyQuaternion Add(MyQuaternion Q1, MyQuaternion Q2)
    {
        return new MyQuaternion(Q1.a + Q2.a, Q1.x + Q2.x, Q1.y + Q2.y, Q1.z + Q2.z);
    }

    public static MyQuaternion Conjugaison(MyQuaternion Q)
    {
        return new MyQuaternion(Q.a, -Q.x, -Q.y, -Q.z);
    }

    public float Norm()
    {
        return (float)Math.Sqrt(a * a + x * x + y * y + z * z);
    }

    public MyQuaternion Normalize()
    {
        float norm = this.Norm();

        if (norm == 0f)
        {
            return new MyQuaternion(1f, 0f, 0f, 0f);
        }
        
        return new MyQuaternion(a/norm, x/norm, y/norm, z/norm);
    }

    public static MyQuaternion Multiply(MyQuaternion Q1, MyQuaternion Q2)
    {
        float nA = (Q1.a * Q2.a) - (Q1.x * Q2.x) - (Q1.y * Q2.y) - (Q1.z * Q2.z);
        float nX = (Q1.a * Q2.x) + (Q1.x * Q2.a) + (Q1.y * Q2.z) - (Q1.z * Q2.y);
        float nY = (Q1.a * Q2.y) - (Q1.x * Q2.z) + (Q1.y * Q2.a) + (Q1.z * Q2.x);
        float nZ = (Q1.a * Q2.z) + (Q1.x * Q2.y) - (Q1.y * Q2.x) + (Q1.z * Q2.a);
        
        return new MyQuaternion(nA, nX, nY, nZ);
    }
}
