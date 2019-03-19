using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Jouer()
    {
    	SceneManager.LoadScene("Scene1");
    }

    public void Quitter()
    {
    	Application.Quit();
    }
}
