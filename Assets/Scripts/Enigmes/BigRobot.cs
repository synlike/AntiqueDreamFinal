using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRobot : MonoBehaviour
{
    
    public bool isValve;
    public bool inTrig;
    public bool activated;

    public GameObject valve;
    public SpriteRenderer valveTmp;
    public SpriteRenderer valveHalo;
    public GameObject arm;
    public GameObject player;
    public Animator animPlayer;
    public Animator animRobot;
    public Animator animArm;
    public Animator animValve;
    public AudioClip insererValve;
    public AudioClip leverBras;
    public AudioClip valveSound;

    void Start()
    {

    }


    void Update()
    {

        if (Input.GetButtonDown("Grab") && isValve && inTrig && !activated)
        {
            StartCoroutine(ValveOn());
      

        }

        if (Input.GetButtonDown("Grab") && player.GetComponent<Interact>().inventory == "valveSol" && !isValve && inTrig)
        {
            valve.SetActive(true);
            valve.GetComponent<SpriteRenderer>().enabled = true;
            valveHalo.enabled = true;
            player.GetComponent<Interact>().ClearInventory();
            player.GetComponent<Interact>().grabbing = false;
            isValve = true;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            inTrig = true;
            if(player.GetComponent<Interact>().inventory == "valveSol")
            {
                valveTmp.enabled = true;
                Color newColor = new Color(1, 1, 1, 0.5f);
                valveTmp.color = newColor;
            }

            if (isValve)
            {
                valveHalo.enabled = true;
                GetComponent<AudioSource>().PlayOneShot(insererValve); 
                print("inserer valve"); // ICI ON INSERE LA VALVE DANS SA GROSSE 
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            inTrig = false;
            valveTmp.enabled = false;
            valveHalo.enabled = false;
        }
    }

    IEnumerator ValveOn()
    {
        GetComponent<AudioSource>().PlayOneShot(valveSound); // LA VALVE TOURNE
        animValve.SetTrigger("activate");
        valveTmp.enabled = false;
        animPlayer.SetTrigger("activate");
        activated = true;
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(SwitchOn());
    }

    IEnumerator SwitchOn()
    {
        animRobot.SetTrigger("turnOn");
        yield return new WaitForSeconds(1.5f);
        animArm.SetTrigger("up");
        arm.GetComponent<BoxCollider2D>().enabled = false;
        activated = false;
        GetComponent<AudioSource>().PlayOneShot(leverBras); // lE BRAS SE LEVE
    }
}
