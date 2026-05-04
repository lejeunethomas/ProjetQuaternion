using UnityEngine;

public class FractalGenerator
{
    public static int GenerateFractal(Complex c, int maxIterations)
    {
        Complex z = new Complex(0, 0);

        for (int i = 0; i < maxIterations; i++)
        {
            z = Complex.Multiply(z, z);
            z = Complex.Add(z, c);
            
            if ((z.real * z.real) + (z.imaginary * z.imaginary) >= 4f)
            {
                return i;
            }
        }
        
        return maxIterations;
    }
}
