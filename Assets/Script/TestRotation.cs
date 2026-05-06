using UnityEngine;
using System.Diagnostics; // Pour le profiling (Stopwatch)

public class TestRotation : MonoBehaviour
{
    void Start()
    {
        // Paramètres de test : rotation de 90° sur l'axe Y
        MyVector3 pointDepart = new MyVector3(1f, 2f, 3f);
        MyVector3 axeRotation = new MyVector3(0f, 1f, 0f);
        float angleRadians = Mathf.PI / 2f; 

        // Initialisation des structures
        MyQuaternion rotationQuat = MyQuaternion.AxisAngle(angleRadians, axeRotation);
        MyMatrix3x3 rotationMat = rotationQuat.ToMatrix();

        // Validation : comparaison des résultats mathématiques
        MyVector3 resultatQuat = MyQuaternion.RotateVector(rotationQuat, pointDepart);
        MyVector3 resultatMat = MyMatrix3x3.MultiplyVector(rotationMat, pointDepart);

        UnityEngine.Debug.Log("<b>--- TEST DE VALIDITÉ ---</b>");
        UnityEngine.Debug.Log($"Point final avec Quaternion : ({resultatQuat.x}, {resultatQuat.y}, {resultatQuat.z})");
        UnityEngine.Debug.Log($"Point final avec Matrice    : ({resultatMat.x}, {resultatMat.y}, {resultatMat.z})");

        // Benchmark des performances
        int nombreIterations = 100000;
        Stopwatch chrono = new Stopwatch();

        // Profiling Quaternions
        chrono.Start();
        for (int i = 0; i < nombreIterations; i++)
        {
            MyQuaternion.RotateVector(rotationQuat, pointDepart);
        }
        chrono.Stop();
        long tempsQuat = chrono.ElapsedMilliseconds;

        chrono.Reset();

        // Profiling Matrices
        chrono.Start();
        for (int i = 0; i < nombreIterations; i++)
        {
            MyMatrix3x3.MultiplyVector(rotationMat, pointDepart);
        }
        chrono.Stop();
        long tempsMat = chrono.ElapsedMilliseconds;

        // Affichage des résultats du bench
        UnityEngine.Debug.Log("<b>--- COMPARAISON DES PERFORMANCES (100 000 calculs) ---</b>");
        UnityEngine.Debug.Log($"Temps de calcul Quaternions : {tempsQuat} ms");
        UnityEngine.Debug.Log($"Temps de calcul Matrices    : {tempsMat} ms");
    }
}