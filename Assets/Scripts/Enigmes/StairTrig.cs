using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairTrig : MonoBehaviour
{
    public GameObject stairs;
    EdgeCollider2D collider;

    void Start()
    {
        collider = stairs.GetComponent<EdgeCollider2D>();
    }


    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collider.enabled = true;
        }
    }

}
