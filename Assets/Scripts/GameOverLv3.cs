using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverLv3 : MonoBehaviour
{
    public Transform respawn;
    public GameObject player;

    void Start()
    {
        
    }
    
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            player.transform.position = respawn.position;
        }
    }
}
