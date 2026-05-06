using UnityEngine;

public class MyMatrix3x3
{
    public float[,] m = new float[3, 3];

    public MyMatrix3x3(float[,] m)
    {
        this.m = m;
    }

    public static MyMatrix3x3 Multiply(MyMatrix3x3 m1, MyMatrix3x3 m2)
    {
        float[,] result = new float[3, 3];
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                result[i, j] = (m1.m[i, 0] * m2.m[0, j]) + (m1.m[i, 1] * m2.m[1, j]) + (m1.m[i, 2] * m2.m[2, j]);
            }
        }
        
        return new MyMatrix3x3(result);
    }

    // Multiplication d'une matrice 3x3 par un vecteur 3D
    public static MyVector3 MultiplyVector(MyMatrix3x3 m, MyVector3 v)
    {
        // Produit matriciel ligne * colonne
        float nX = (m.m[0, 0] * v.x) + (m.m[0, 1] * v.y) + (m.m[0, 2] * v.z);
        float nY = (m.m[1, 0] * v.x) + (m.m[1, 1] * v.y) + (m.m[1, 2] * v.z);
        float nZ = (m.m[2, 0] * v.x) + (m.m[2, 1] * v.y) + (m.m[2, 2] * v.z);
        
        return new MyVector3(nX, nY, nZ);
    }
}