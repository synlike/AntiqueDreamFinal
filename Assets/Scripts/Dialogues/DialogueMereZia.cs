using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMereZia : MonoBehaviour
{
    public PlayerInput control;

    public float letterPause = 0.2f;
    int iterations = 0;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;

    string ligne1;
    string message;
    public GameObject panel;
    public Text textComp;

    bool next=true;
    public bool inTrigger;

    public Animator zia;

    // Use this for initialization
    void Start()
    {
        textComp.text = "";
        
    }

    void Update()
    {
        DialogueManager();
    }

    void DialogueManager()
    {
        if (Input.GetButtonDown("Grab") && inTrigger && next)
        {
            next = false;
            print("blabla" +next);
            textComp.text = "";
            if (iterations == 0)
            {
                zia.SetBool("istalking",true);
                control.enabled = false;
                panel.GetComponent<Image>().enabled = true;
                textComp.GetComponent<Text>().enabled = true;
                GetComponent<AudioSource>().PlayOneShot(sound1);
                message = "Vendeuse: Je ne sais pas quoi penser du vote... Tout ce que je veux c’est pouvoir nourrir mes enfants.";
            }
            else if (iterations == 1)
            {
            	control.enabled = false;
                panel.GetComponent<Image>().enabled = true;
                textComp.GetComponent<Text>().enabled = true;
                GetComponent<AudioSource>().PlayOneShot(sound2);
                message = "Mère de Zia: Oui ça serait un soulagement… Tiens Zia, tu voulais me voir?";
            }
            else if (iterations == 2)
            {
            	control.enabled = false;
                panel.GetComponent<Image>().enabled = true;
                textComp.GetComponent<Text>().enabled = true;
                GetComponent<AudioSource>().PlayOneShot(sound3);
                message = "Zia: Oui maman! Monsieur Pirès m’a dit que la prochaine récolte ne tarderait pas. Il souhaite organiser un troc.";
            }
            else if (iterations == 3)
            {
            	control.enabled = false;
                panel.GetComponent<Image>().enabled = true;
                textComp.GetComponent<Text>().enabled = true;
                GetComponent<AudioSource>().PlayOneShot(sound4);
                message = "Mère de Zia: D’accord, merci Zia. Je vais y aller bientôt. ";
            }
            else if (iterations == 4)
            {
                textComp.text = "";
                panel.GetComponent<Image>().enabled = false;
                textComp.GetComponent<Text>().enabled = false;
                control.enabled = true;
                Destroy(this);
                zia.SetBool("istalking",false);
            }

            StartCoroutine(TypeText());
            iterations++;
            next = false;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            
            if (next==true)
            {
                inTrigger = true;
                //anim.SetBool("hello",true);
    
                
            }
            

        }
            
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
            inTrigger = false;
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
