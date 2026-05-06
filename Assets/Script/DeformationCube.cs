using UnityEngine;

public class DeformationCube : MonoBehaviour
{
    [Header("Paramètres de déformation")]
    public float facteurCisaillement = 1f; // Facteur k pour la matrice
    public float facteurEchelle = 1.5f;    // Scale global
    public float amplitudeRebond = 1f;     

    private Mesh mesh;
    private Vector3[] pointsOrigine;
    private Vector3[] pointsDeformes;

    void Start()
    {
        // Init du mesh et sauvegarde des vertices de base
        mesh = GetComponent<MeshFilter>().mesh;
        pointsOrigine = mesh.vertices;
        pointsDeformes = new Vector3[pointsOrigine.Length];
    }

    void Update()
    {
        // Shear dynamique basé sur le temps
        float k = Mathf.Sin(Time.time) * facteurCisaillement;

        // Matrice de cisaillement (Shear) sur X
        float[,] tableauShear = new float[3, 3] {
            { 1f, k,  0f },
            { 0f, 1f, 0f },
            { 0f, 0f, 1f }
        };
        MyMatrix3x3 matriceCisaillement = new MyMatrix3x3(tableauShear);

        // Boucle sur les vertices pour appliquer les transformations
        for (int i = 0; i < pointsOrigine.Length; i++)
        {
            MyVector3 point = new MyVector3(pointsOrigine[i].x, pointsOrigine[i].y, pointsOrigine[i].z);

            // Scale
            point.x *= facteurEchelle;
            point.y *= facteurEchelle;
            point.z *= facteurEchelle;

            // Application de la matrice de cisaillement
            MyVector3 pointCisaille = MyMatrix3x3.MultiplyVector(matriceCisaillement, point);

            // Translation sur l'axe Y (rebond)
            float animY = Mathf.Sin(Time.time * 2f) * amplitudeRebond;
            pointCisaille.y += animY;

            pointsDeformes[i] = new Vector3(pointCisaille.x, pointCisaille.y, pointCisaille.z);
        }

        // Test de rotation avec notre classe Quaternion
        MyQuaternion qRot = MyQuaternion.AxisAngle(Time.time, new MyVector3(1f, 1f, 0f));
        transform.rotation = qRot.ToUnity();

        // Update du mesh et des normales pour l'éclairage
        mesh.vertices = pointsDeformes;
        mesh.RecalculateNormals(); 
    }
}