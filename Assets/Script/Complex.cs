using System;

public class Complex
{
    public float real;
    public float imaginary;

    public Complex(float real, float imaginary)
    {
        this.real = real;
        this.imaginary = imaginary;
    }

    // Addition
    public static Complex Add(Complex a, Complex b)
    {
        return new Complex(a.real + b.real, a.imaginary + b.imaginary);
    }

    // Multiplication
    public static Complex Multiply(Complex a, Complex b)
    {
        float newReal = (a.real * b.real) - (a.imaginary * b.imaginary);
        float newImaginary = (a.real * b.imaginary) + (a.imaginary * b.real);
        return new Complex(newReal, newImaginary);
    }

    // Conjugaison
    public Complex Conjugate()
    {
        return new Complex(this.real, -this.imaginary);
    }

    // Module
    public float Modulus()
    {
        return (float)Math.Sqrt((this.real * this.real) + (this.imaginary * this.imaginary));
    }

    // Argument (en radians)
    public float Argument()
    {
        return (float)Math.Atan2(this.imaginary, this.real);
    }

    // Division
    public static Complex Divide(Complex a, Complex b)
    {
        float denominator = (b.real * b.real) + (b.imaginary * b.imaginary);
        if (denominator == 0)
        {
            throw new DivideByZeroException("Division par un complexe nul impossible.");
        }

        Complex conjugateB = b.Conjugate();
        Complex numerator = Multiply(a, conjugateB);

        return new Complex(numerator.real / denominator, numerator.imaginary / denominator);
    }
    
    // Transformation
    public static Matrix2x2 Transform(Complex a)
    {
        return new Matrix2x2(a.real, -a.imaginary, a.imaginary, a.real);
    }

    // Surcharge de la méthode ToString pour faciliter l'affichage dans la console Unity
    public override string ToString()
    {
        string sign = imaginary >= 0 ? "+" : "-";
        return $"{real} {sign} {Math.Abs(imaginary)}i";
    }
}