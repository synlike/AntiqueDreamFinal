using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCircle : MonoBehaviour
{

    private bool insideCol;
    private bool rotation;
    private bool paternOk;
    private bool fading;
    private bool doorOpen;

    public Quaternion currentRot;
    public Quaternion rotDepart;
    public Quaternion rotFin;
    public float currentRotZ;
    private float tmpAnimTot = 1;
    private float tmpAnimActu;


    public GameObject cercle;
    public GameObject cercle0;
    public GameObject cercle1;
    public GameObject cercle2;
    public GameObject cercle3;
    public GameObject cercleNuke;

    public GameObject pillar1;
    public GameObject pillar2;
    public GameObject pillar3;

    public AudioClip tourner;
    public AudioClip ouvrir_porte;
    public Animator zia;
    public Animator anim;

    void Start()
    {
    }


    void Update()
    {
        //cercle.transform.Rotate(Vector3.back * Time.deltaTime * 100);
        if (Input.GetButtonDown("Grab") && insideCol && !rotation && paternOk == false)
        {
            GetComponent<AudioSource>().PlayOneShot(tourner);
            zia.SetTrigger("activate");
            print("Rotate one time");
            rotDepart = cercle.transform.rotation;
            rotFin = Quaternion.Euler(0, 0, rotDepart.eulerAngles.z-120);
            rotation = true;
            tmpAnimActu = 0;
        }

        if(rotation)
        {
            tmpAnimActu += Time.deltaTime;
            float ratioAnim = tmpAnimActu / tmpAnimTot;
            cercle.transform.rotation = Quaternion.Lerp(rotDepart, rotFin, ratioAnim);

            if (ratioAnim > 1)
            {
                rotation = false;
                CheckValidation();
            }
        }

        if(fading)
        {
            StartCoroutine(FadeTo(1.0f, 5.0f));
        }

        if(paternOk && !fading && doorOpen)
        {
            GetComponent<AudioSource>().PlayOneShot(ouvrir_porte);
            anim.SetTrigger("Open");
            doorOpen = false;

        }

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            print("Pillar enter");
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            insideCol = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            print("Pillar exit");
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            insideCol = false;
        }
    }
    
    public bool SetPaternOk
    {
        get { return paternOk; }
        set { paternOk = value; }
    }

    void CheckValidation()
    {
        if (   (int) cercle.transform.rotation.eulerAngles.z == 0
            && (int)cercle1.transform.rotation.eulerAngles.z == 0
            && (int)cercle2.transform.rotation.eulerAngles.z == 0
            && (int)cercle3.transform.rotation.eulerAngles.z == 0)
        {
            print("L'énigme est résolue");
            
            fading = true;
            paternOk = true;
            doorOpen = true;
            pillar1.GetComponent<RotateCircle>().SetPaternOk = true;
            pillar2.GetComponent<RotateCircle>().SetPaternOk = true;
            pillar3.GetComponent<RotateCircle>().SetPaternOk = true;
            
        }
        else
            print("L'énigme n'est pas résolue");
    }


    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = cercleNuke.transform.GetComponent<SpriteRenderer>().color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            cercleNuke.transform.GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }
        fading = false;
    }

}
