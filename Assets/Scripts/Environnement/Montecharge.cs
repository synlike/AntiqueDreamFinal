using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Montecharge : MonoBehaviour
{
    public GameObject player;

    public bool inTrigger;
    Animator anim;
    bool isUp;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Grab") && inTrigger)
        {
            print("inTrig");
            if (!isUp)
            {
                anim.SetBool("up", true);
                anim.SetBool("down", false);
                player.transform.SetParent(transform);
                isUp = true;
            }
            else
            {
                anim.SetBool("up", false);
                anim.SetBool("down", true);
                player.transform.SetParent(transform);
                isUp = false;
            }


        }
    }
    
    void unlockPlayer()
    {
        transform.DetachChildren();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
            inTrigger = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
            inTrigger = false;
    }
}
