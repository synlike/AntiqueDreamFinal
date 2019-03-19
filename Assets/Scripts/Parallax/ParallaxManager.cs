using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    public Transform[] backgrounds;        // Tableau de tous les arrières plans et avants plans
    private float[] parallaxScales;        // Proportion du mouvement du background
    public float smoothing;                // Mettre une valeur au dessus de 0

    private Transform cam;                 // Référence de la position de la caméra principale
    //Vector3 posCam;
    [SerializeField] float posYDepart = 1f;
    public Camera camera;
    public Vector3 previousCamPos;        // Enregistre la position de la caméra à la frame précédente

    Vector3 posBackground1;
    Vector3 posBackground2;
    Vector3 posBackground3;


    // Appelé avant Start(). Utilisé pour les références
    void Awake()
    {
        cam = camera.transform;
    }


    void Start()
    {
        previousCamPos = new Vector3(camera.transform.position.x, posYDepart); //cam.position;

        // Assigne les bonnes "parallaxScales" au bon background
        parallaxScales = new float[backgrounds.Length];
        for(int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }


    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }
        
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPos.y - cam.position.y) * parallaxScales[i];

            float backgroundTargetPosY = backgrounds[i].position.y + parallax;


            Vector3 backgroundTargetPos = new Vector3(backgrounds[i].position.x, backgroundTargetPosY, backgrounds[i].position.z);
            
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }
        
        previousCamPos = cam.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            posBackground1 = backgrounds[0].transform.position;
            posBackground2 = backgrounds[1].transform.position;
            posBackground3 = backgrounds[2].transform.position;
        }
    }
}
