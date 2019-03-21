using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleurs : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "robot")
        {
            anim.SetTrigger("activate");
        }
    }
}
