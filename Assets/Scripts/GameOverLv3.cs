using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverLv3 : MonoBehaviour
{
    public Transform respawn;
    public GameObject player;
    public GameObject GameOverScreen;
    public GameObject BoutonOui;
    public GameObject BoutonNon;
    public GameObject Zia_decede;
    
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
            GameOverScreen.SetActive(true);
            BoutonOui.SetActive(true);
            BoutonNon.SetActive(true);
            Zia_decede.SetActive(true);
            player.SetActive(false);
            print("touché");
        }
    }
}
