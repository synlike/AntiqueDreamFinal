using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPlatforms : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    public GameObject GameOverScreen;
    public GameObject BoutonOui;
    public GameObject BoutonNon;
    public GameObject Zia_decede;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            GameOverScreen.SetActive(true);
            player.transform.position = spawnPoint.transform.position;
            BoutonOui.SetActive(true);
            BoutonNon.SetActive(true);
            Zia_decede.SetActive(true);
            player.SetActive(false);
            print("coulé");
        }
    }

}
