using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject head;
    public GameObject neck;
    public GameObject body;

    public GameObject machine;
    public GameObject player;
    Player playerScript;
    public SpriteRenderer halo;

    public Animator animMachine;
    public Animator animPlayer;
    public Animator cutScene;
    public bool playerIn;
    public AudioClip validSound;
    public AudioClip levier;

    public GameObject eve;

    void Start()
    {
        playerScript = player.GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Grab") && playerIn)
        {
            animPlayer.SetTrigger("activate");
            GetComponent<AudioSource>().PlayOneShot(levier);


            if (machine.GetComponent<MachineEnigme>().threeParts)
            {
                GetComponent<AudioSource>().PlayOneShot(validSound);
                StartCoroutine(TimeBeforeControlBack());
            }
            else
            {
                Debug.Log("Nope");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            playerIn = true;
            halo.enabled = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            playerIn = false;
            halo.enabled = false;
        }
    }

    IEnumerator TimeBeforeControlBack()
    {
        playerScript.isLookingLeft = true;
        playerScript.enabled = false;
        Debug.Log("Ascenseur débloqué !");
        eve.GetComponent<SpriteRenderer>().enabled = true;
        animMachine.SetTrigger("charge");
        yield return new WaitForSeconds(4f);
        head.GetComponent<SpriteRenderer>().enabled = false;
        neck.GetComponent<SpriteRenderer>().enabled = false;
        body.GetComponent<SpriteRenderer>().enabled = false;
        animMachine.SetTrigger("stopCharge");
        cutScene.SetTrigger("Launch");
    }
}
