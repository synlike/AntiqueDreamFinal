using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slopes : MonoBehaviour
{
    public GameObject player;
    CharacterControllerZia slopeAngle;
    Player playerScript;
    Animator anim;

    public AudioClip glissade;

    void Start()
    {
        anim = player.GetComponent<Animator>();
        slopeAngle = player.GetComponent<CharacterControllerZia>();
        playerScript = player.GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            GetComponent<AudioSource>().PlayOneShot(glissade);
            slopeAngle.maxSlopeAngle = 25;
            anim.SetBool("sliding", true);
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            slopeAngle.maxSlopeAngle = 60;
            anim.SetBool("sliding", false);
        }
    }
}
