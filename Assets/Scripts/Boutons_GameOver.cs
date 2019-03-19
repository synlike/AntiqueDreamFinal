using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boutons_GameOver : MonoBehaviour
{
	public GameObject player;
    //public GameObject spawnPoint;
    public GameObject GameOverScreen;
    public GameObject BoutonOui;
    public GameObject BoutonNon;
    public GameObject Zia_decede;

    public void Recommencer()
    {
        GameOverScreen.SetActive(false);
        player.SetActive(true);
        BoutonOui.SetActive(false);
        BoutonNon.SetActive(false);
        Zia_decede.SetActive(false);
        
    }

   public void Quitter()
   {
   	SceneManager.LoadScene(1);
   }
}
