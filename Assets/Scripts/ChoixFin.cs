using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoixFin : MonoBehaviour
{
    public GameObject panelText;
    public Text text;

    public GameObject panelBtn;
    public Button btnYes;
    public Image btnYesImg;
    public Button btnNo;
    public Image btnNoImg;

    public bool activation;

    public Animator animPlayer;
    public Animator anim;
    
    public Text textComp;
    public float letterPause = 0.2f;
    string message;
    bool next = true;

    void Start()
    {
        message = "zia ; Il est vrai que cette etrange creature m'a sauvé la vie ... \nDois - je le ramener au village ?";
    }

    void Update()
    {
        if (activation)
        {
            StartCoroutine(drawPanels());
            activation = false;
        }
        
    }
    
    IEnumerator drawPanels()
    {
        panelText.GetComponent<Image>().enabled = true;
        text.enabled = true;
        StartCoroutine(TypeText());
        yield return new WaitForSeconds(9f);
        panelBtn.GetComponent<Image>().enabled = true;
        btnYes.interactable = true;
        btnYesImg.enabled = true;
        btnNo.interactable = true;
        btnNoImg.enabled = true;
    }

    public void answerYes()
    {
        anim.SetTrigger("oui");
        panelText.GetComponent<Image>().enabled = false;
        text.enabled = false;
        panelBtn.GetComponent<Image>().enabled = false;
        btnYes.interactable = false;
        btnYesImg.enabled = false;
        btnNo.interactable = false;
        btnNoImg.enabled = false;
    }

    public void answerNo()
    {
        anim.SetTrigger("non");
        panelText.GetComponent<Image>().enabled = false;
        text.enabled = false;
        panelBtn.GetComponent<Image>().enabled = false;
        btnYes.interactable = false;
        btnYesImg.enabled = false;
        btnNo.interactable = false;
        btnNoImg.enabled = false;
    }


    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            textComp.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
        next = true;
    }

}
