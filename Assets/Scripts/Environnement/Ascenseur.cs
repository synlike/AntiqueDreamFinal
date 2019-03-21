using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascenseur : MonoBehaviour
{
    public GameObject player;
    public GameObject ascenseur;
    public GameObject halo;

    Animator animAsc;
    PlayerInput playerInput;
    CharacterControllerZia controller;
    Player playerScript;
    bool inTrig;

    void Start()
    {
        playerInput = player.GetComponent<PlayerInput>();
        controller = player.GetComponent<CharacterControllerZia>();
        playerScript = player.GetComponent<Player>();
        animAsc = ascenseur.GetComponent<Animator>();
    }


    void Update()
    {

        if (Input.GetButtonDown("Grab") && inTrig == true)
        {
            playerInput.enabled = false;
            controller.enabled = false;
            playerScript.enabled = false;

            player.transform.SetParent(ascenseur.transform);

            animAsc.SetTrigger("activate");
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            inTrig = true;
            halo.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            inTrig = false;
            halo.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
