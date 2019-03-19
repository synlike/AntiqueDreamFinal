using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneScan : MonoBehaviour
{
    public GameObject player;
    Player playerScript;

    Animator anim;
    Animator animPlayer;
    public Animator animPorte;
    public AudioClip son;
    public AudioClip robotAffole;
    public AudioSource dodo;


    void Start()
    {
        dodo=GetComponent<AudioSource>();
        dodo.clip=son;
        dodo.Play();
        anim = GetComponent<Animator>();
        animPlayer = player.GetComponent<Animator>();
        playerScript = player.GetComponent<Player>();
    }

    void LaunchCutScene()
    {
        anim.SetTrigger("Launch");
    }

    void DestroyCutScene()
    {
        playerScript.enabled = true;
        Destroy(gameObject);
    }

    void CloseDoor()
    {
        GetComponent<AudioSource>().PlayOneShot(robotAffole);
        animPorte.SetTrigger("Close");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            dodo.Stop();
            animPlayer.SetBool("iswalking", false);
            playerScript.enabled = false;
            LaunchCutScene();
        }
    }
}
