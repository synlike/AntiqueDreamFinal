using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCollider : MonoBehaviour
{
    public BoxCollider2D bc;

    void Start()
    {
    }
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            bc.enabled = false;
        }
    }
}
