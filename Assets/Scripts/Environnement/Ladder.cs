using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject fermeture;
    public CharacterControllerZia controller;
    public Player playerScript;
    public Animator anim;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            print("yo");
            controller.climbing = false;
            playerScript.climbing = false;
            anim.SetTrigger("returnIdle");
            fermeture.GetComponent<BoxCollider2D>().enabled = !fermeture.GetComponent<BoxCollider2D>().enabled;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            anim.SetTrigger("returnIdle");
            playerScript.climbing = false;
            controller.climbing = false;
        }
    }
}
