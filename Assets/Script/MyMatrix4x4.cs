using UnityEngine;

public class MyMatrix4x4
{
    public float[,] m =  new float[4, 4];

    public MyMatrix4x4(float[,] m)
    {
        this.m = m;
    }

    public static MyMatrix4x4 Multiply(MyMatrix4x4 m1, MyMatrix4x4 m2)
    {
        float[,] result = new float[4, 4];
        
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                result[i, j] = (m1.m[i, 0] * m2.m[0, j]) + (m1.m[i, 1] * m2.m[1, j]) +
                               (m1.m[i, 2] * m2.m[2, j] + (m1.m[i, 3] * m2.m[3, j]));
            }
        }
        
        return new MyMatrix4x4(result);
    }

}
