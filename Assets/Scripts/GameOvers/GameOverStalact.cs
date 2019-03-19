using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverStalact : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    public GameObject GameOverScreen;
    public GameObject BoutonOui;
    public GameObject BoutonNon;
    public GameObject Zia_decede;
    public ParallaxManager parallax;
    bool grounded;

    public AudioClip stalactiteSound;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "sol")
        {
            print("sol");
            GetComponent<AudioSource>().PlayOneShot(stalactiteSound);
            grounded = true;
        }
        if (collision.gameObject.tag == "player" && !grounded)
        {
            
            GameOverScreen.SetActive(true);
            player.transform.position = spawnPoint.transform.position;
            BoutonOui.SetActive(true);
            BoutonNon.SetActive(true);
            Zia_decede.SetActive(true);
            player.SetActive(false);
            print("touché");
            
        }
    }
}
