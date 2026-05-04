using UnityEngine;
using System;

public class NewEmptyCSharpScript
{
    public static Complex Translate(Complex z, Complex t)
    {
        return Complex.Add(z, t);
    }

    public static Complex Homothetie(Complex z, float k)
    {
        return new Complex(z.real * k, z.imaginary * k);
    }

    public static Complex Rotation(Complex z, float r)
    {
        float rotReal = (float)Math.Cos(r);
        float rotImaginary = (float)Math.Sin(r);

        Complex rotateur = new Complex(rotReal, rotImaginary);

        return Complex.Multiply(z, rotateur);
    }

    public static Complex Similitude(Complex z, Complex a, Complex b)
    {
        Complex sr = Complex.Multiply(z, a);

        return Complex.Add(sr, b);
    }
}
