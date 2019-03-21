using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneFinLv3 : MonoBehaviour
{
    public ChoixFin scriptSuite;

    public Animator ending;
    public GameObject player;
    Player playerScript;
    CharacterControllerZia controller;
    PlayerInput inputScript;
    public Animator animPlayer;
    Animator animZia;

    Animator cutscene;


    void Start()
    {
        playerScript = player.GetComponent<Player>();
        controller = player.GetComponent<CharacterControllerZia>();
        inputScript = player.GetComponent<PlayerInput>();
        animZia = player.GetComponent<Animator>();
        cutscene = GetComponent<Animator>();
    }
    
    void Update()
    {

    }
    

    void EndFirstAnim()
    {
        player.GetComponent<SpriteRenderer>().flipX = true;
        scriptSuite.activation = true;
        
    }

    void startWalking()
    {
        animPlayer.SetBool("iswalking", true);
        player.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void activateCredits()
    {
        ending.SetTrigger("activate");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            controller.enabled = false;
            inputScript.enabled = false;
            playerScript.enabled = false;
            cutscene.SetTrigger("activate");
            animZia.SetBool("iswalking", false);
            animZia.SetTrigger("forceIdle");
        }
    }
}
