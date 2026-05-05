using UnityEngine;

public class Matrix3x3
{
    public float[,] m =  new float[3, 3];

    public Matrix3x3(float[,] m)
    {
        this.m = m;
    }

    public static Matrix3x3 Multiply(Matrix3x3 m1, Matrix3x3 m2)
    {
        float[,] result = new float[3, 3];
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                result[i, j] = (m1.m[i, 0] * m2.m[0, j]) + (m1.m[i, 1] * m2.m[1, j]) + (m1.m[i, 2] * m2.m[2, j]);
            }
        }
        
        return new Matrix3x3(result);
    }
}
