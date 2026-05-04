using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class FractalDisplay : MonoBehaviour
{
    [Header("Paramètres de la texture")]
    public int width = 512;
    public int height = 512;
    public int maxIterations = 100;

    private Texture2D fractalTexture;

    void Start()
    {
        fractalTexture = new Texture2D(width, height);
        
        GetComponent<Renderer>().material.mainTexture = fractalTexture;

        DrawFractal();
    }

    void DrawFractal()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float percentX = x / (float)width;
                float percentY = y / (float)height;
                
                float minReal = -2.1f;
                float maxReal = 1.0f;
                float minImaginary = -1.2f;
                float maxImaginary = 1.2f;
                
                float real = minReal + (percentX * (maxReal - minReal));
                float imaginary = minImaginary + (percentY * (maxImaginary - minImaginary));
                
                Complex c = new Complex(real, imaginary);
                
                int iterations = FractalGenerator.GenerateFractal(c, maxIterations);

                if (iterations == maxIterations)
                {
                    fractalTexture.SetPixel(x, y, Color.black);
                }
                else
                {
                    float nuance = (float)iterations / maxIterations;
                    Color pixelColor = new Color(nuance, nuance, nuance);
                    fractalTexture.SetPixel(x, y, pixelColor);
                }
            }
        }

        fractalTexture.Apply();
    }
}