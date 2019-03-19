using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStairsCol : MonoBehaviour
{
    public BoxCollider2D bc;
    public EdgeCollider2D ec;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            bc.enabled = false;
            ec.enabled = false;
        }
    }
}
