using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactites : MonoBehaviour
{
    public float gravityScale = 0.9f;
    public GameObject stalactite;
    public bool triggered;
    public AudioClip son;

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
            stalactite.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            stalactite.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
            GetComponent<AudioSource>().PlayOneShot(son);
        }
    }
}
