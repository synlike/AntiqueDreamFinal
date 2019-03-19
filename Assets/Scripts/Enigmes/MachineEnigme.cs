using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineEnigme : MonoBehaviour
{
    public bool carrying;
    public GameObject head;
    public GameObject neck;
    public GameObject body;
    public GameObject player;
    Interact playerInt;

    public SpriteRenderer halo;
    public int allParts = 0;
    public bool threeParts;
    public AudioClip son; // son quand on met une pièce dans la machine

    public bool inTrig;
    

    void Start()
    {
        playerInt = player.GetComponent<Interact>();
    }

    void Update()
    {
         if (Input.GetButtonDown("Grab") && inTrig)
         {
             if(playerInt.HasHead)
             {
                GetComponent<AudioSource>().PlayOneShot(son);
                 Debug.Log("tete");
                 playerInt.ClearInventory();
                 head.GetComponent<SpriteRenderer>().enabled = true;
                 playerInt.Interacting = false;
                 playerInt.Grabbing = false;
                 playerInt.HasHead = false;
                 allParts++;
             }
             else if (playerInt.HasNeck)
             {
                GetComponent<AudioSource>().PlayOneShot(son);
                 Debug.Log("cou");
                 playerInt.ClearInventory();
                 neck.GetComponent<SpriteRenderer>().enabled = true;
                 playerInt.Interacting = false;
                 playerInt.Grabbing = false;
                 playerInt.HasNeck = false;
                 allParts++;
             }
             else if (playerInt.HasBody)
             {
                GetComponent<AudioSource>().PlayOneShot(son);
                 Debug.Log("torse");
                 playerInt.ClearInventory();
                 body.GetComponent<SpriteRenderer>().enabled = true;
                 playerInt.Interacting = false;
                 playerInt.Grabbing = false;
                 playerInt.HasBody = false;
                 allParts++;
             }
         }

        if(allParts == 3 && !threeParts)
        {
            Debug.Log("La porte s'ouvre !");
            threeParts = true;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            inTrig = true;
            if (playerInt.inventory != "")
            {
                halo.enabled = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            inTrig = false;
            halo.enabled = false;
        }
    }
}
