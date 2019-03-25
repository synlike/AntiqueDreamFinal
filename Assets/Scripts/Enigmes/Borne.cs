using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borne : MonoBehaviour
{

    public bool isValve;
    public bool inTrig;
    public bool activated;

    public GameObject valve;
    public SpriteRenderer valveTmp;
    public SpriteRenderer valveHalo;
    public GameObject player;
    public Animator animPlayer;
    public Animator animPlatform;
    public Animator animValve;

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
        if (collision.gameObject.tag == "player")
        {
            inTrig = true;
            if (player.GetComponent<Interact>().inventory == "valveSol")
            {
                valveTmp.enabled = true;
                Color newColor = new Color(1, 1, 1, 0.5f);
                valveTmp.color = newColor;
            }

            if (isValve)
            {
                valveHalo.enabled = true;
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
        GetComponent<AudioSource>().PlayOneShot(valveSound);
        animValve.SetTrigger("activate");
        valveTmp.enabled = false;
        animPlayer.SetTrigger("activate");
        activated = true;
        yield return new WaitForSeconds(1f);
        StartCoroutine(SwitchOn());
    }

    IEnumerator SwitchOn()
    {
        animPlatform.SetTrigger("turnOn");
        yield return new WaitForSeconds(1.5f);
        activated = false;
    }
}
