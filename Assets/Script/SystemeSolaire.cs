using UnityEngine;

public class SystemeSolaire : MonoBehaviour
{
    [Header("Les Astres")]
    public Transform soleil;
    public Transform terre;
    public Transform lune;

    [Header("Vitesses (Radians par seconde)")]
    public float vitesseOrbiteTerre = 0.5f;
    public float vitesseOrbiteLune = 2f;
    public float vitesseRotationSurSoi = 1f;

    void Update()
    {
        // Rotation locale continue sur l'axe Y pour tous les astres
        float angleActuel = Time.time * vitesseRotationSurSoi;
        MyQuaternion rotationSurSoi = MyQuaternion.AxisAngle(angleActuel, new MyVector3(0f, 1f, 0f));
        
        soleil.rotation = rotationSurSoi.ToUnity();
        terre.rotation = rotationSurSoi.ToUnity();
        lune.rotation = rotationSurSoi.ToUnity();

        // On sauvegarde l'ancienne position pour calculer la trajectoire de la lune correctement
        Vector3 anciennePositionTerre = terre.position;

        // --- Orbite de la Terre ---
        
        // Mise à l'origine par rapport au Soleil
        Vector3 diffTerre = terre.position - soleil.position;
        MyVector3 posTerreOrigine = new MyVector3(diffTerre.x, diffTerre.y, diffTerre.z);
        
        // Rotation via Quaternion
        float petitAngleTerre = vitesseOrbiteTerre * Time.deltaTime;
        MyQuaternion qOrbiteTerre = MyQuaternion.AxisAngle(petitAngleTerre, new MyVector3(0f, 1f, 0f));
        MyVector3 nouvellePosTerreOrigine = MyQuaternion.RotateVector(qOrbiteTerre, posTerreOrigine);
        
        // Repositionnement absolu
        terre.position = new Vector3(nouvellePosTerreOrigine.x, nouvellePosTerreOrigine.y, nouvellePosTerreOrigine.z) + soleil.position;


        // --- Orbite de la Lune ---
        
        // Mise à l'origine par rapport à l'ancienne position de la Terre (évite la désynchronisation)
        Vector3 diffLune = lune.position - anciennePositionTerre;
        MyVector3 posLuneOrigine = new MyVector3(diffLune.x, diffLune.y, diffLune.z);
        
        // Rotation via Quaternion
        float petitAngleLune = vitesseOrbiteLune * Time.deltaTime;
        MyQuaternion qOrbiteLune = MyQuaternion.AxisAngle(petitAngleLune, new MyVector3(0f, 1f, 0f));
        MyVector3 nouvellePosLuneOrigine = MyQuaternion.RotateVector(qOrbiteLune, posLuneOrigine);
        
        // Repositionnement par rapport à la nouvelle position de la Terre
        lune.position = new Vector3(nouvellePosLuneOrigine.x, nouvellePosLuneOrigine.y, nouvellePosLuneOrigine.z) + terre.position;
    }
}