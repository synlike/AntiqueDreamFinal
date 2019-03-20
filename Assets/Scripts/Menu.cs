using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public CutsceneIntro playGame;
    public Button howToQuitBtn;
    public Image howToQuitImg;
    public Button CreditQuitBtn;
    public Image CreditQuitImg;

    private void Start()
    {
        howToQuitBtn.interactable = false;
        howToQuitImg.enabled = false;
        CreditQuitBtn.interactable = false;
        CreditQuitImg.enabled = false;
    }

    public void Play()
    {
        menu.SetActive(false);
        playGame.play = true;

    }

    public void HowTo()
    {
        howToQuitBtn.interactable = true;
        howToQuitImg.enabled = true;
        MoveInFront(howToQuitBtn);
    }
    public void HowToQuit()
    {
        howToQuitBtn.interactable = false;
        howToQuitImg.enabled = false;
        MoveInBack(howToQuitBtn);
    }

    public void Credit()
    {
        CreditQuitBtn.interactable = true;
        CreditQuitImg.enabled = true;
        MoveInFront(CreditQuitBtn);
    }
    public void CreditQuit()
    {
        CreditQuitBtn.interactable = false;
        CreditQuitImg.enabled = false;
        MoveInBack(CreditQuitBtn);
    }

    public void Quit()
    {
    	Application.Quit();
    }

    public void MoveInBack(Button objet)
    {
        objet.transform.SetSiblingIndex(0);
    }
    public void MoveInFront(Button objet)
    {
        objet.transform.SetSiblingIndex(6);
    }
}
