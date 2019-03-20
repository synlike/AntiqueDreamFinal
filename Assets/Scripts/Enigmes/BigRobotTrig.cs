using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRobotTrig : MonoBehaviour
{
    public GameObject arm;
    public Animator animArm;
    public AudioClip baisseBras;

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            arm.GetComponent<BoxCollider2D>().enabled = true;
            animArm.SetTrigger("down");
            GetComponent<AudioSource>().PlayOneShot(baisseBras); 

        }
    }

}
