public class Matrix2x2
{
    public float m00, m01;
    public float m10, m11;

    // Constructeur
    public Matrix2x2(float m00, float m01, float m10, float m11)
    {
        this.m00 = m00;
        this.m01 = m01;
        this.m10 = m10;
        this.m11 = m11;
    }

    // Produit matriciel 2x2
    public static Matrix2x2 Multiply(Matrix2x2 a, Matrix2x2 b)
    {
        float r00 = (a.m00 * b.m00) + (a.m01 * b.m10);
        float r01 = (a.m00 * b.m01) + (a.m01 * b.m11);
        float r10 = (a.m10 * b.m00) + (a.m11 * b.m10);
        float r11 = (a.m10 * b.m01) + (a.m11 * b.m11);

        return new Matrix2x2(r00, r01, r10, r11);
    }
    
    //Transformation
    public static Complex Transform(Matrix2x2 a)
    {
        return new Complex(a.m00,a.m10);
    }

    public override string ToString()
    {
        return $"[{m00}, {m01}]\n[{m10}, {m11}]";
    }
}