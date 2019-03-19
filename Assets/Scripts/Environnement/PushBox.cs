using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour
{
    public Player player;
    public Animator anim;
    public bool intrig;
    bool soundOn;

    public AudioClip pushingBox;

    void Start()
    {
        
    }
    
    void Update()
    {
        if(intrig && player.isWalking)
        {
            anim.SetBool("pushing", true);
            if (!soundOn)
            {
                GetComponent<AudioSource>().Play();
                soundOn = true;
            }
        }
        else
        {
            anim.SetBool("pushing", false);
            if (soundOn)
            {
                GetComponent<AudioSource>().Stop();
                soundOn = false;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            intrig = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            intrig = false;
        }
    }

}
