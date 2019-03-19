using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "grabbable")
        {
            print("grabbable");
        }
    }
}
