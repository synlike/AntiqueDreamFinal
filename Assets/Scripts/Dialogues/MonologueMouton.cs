using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonologueMouton : MonoBehaviour
{
	public PlayerInput control;

    public float letterPause = 0.2f;
    int iterations = 0;
    public AudioClip mouton;
    public AudioClip zia;

    string ligne1;
    string message;
    public GameObject panel;
    public Text textComp;

    bool next=true;
    public bool inTrigger;

    //public Animator zia;

    // Use this for initialization

    /*
    void Start()
    {
        textComp.text = "";
        
    }

    void Update()
    {
    }
   


     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" && inTrigger)
        {
            
            if (next==true)
            {
            	GetComponent<AudioSource>().PlayOneShot(mouton);
            	textComp.text = "";
                control.enabled = false;
                panel.GetComponent<Image>().enabled = true;
                textComp.GetComponent<Text>().enabled = true;
                GetComponent<AudioSource>().PlayOneShot(zia);
                message = "Le mouton des Calagor? Vite... je dois l'aider à fuir. ";
                StartCoroutine(TypeText());
            	iterations++;
            	next = false;
            	
                //anim.SetBool("hello",true);
    
                
            }
            

        }
            
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
            inTrigger = false;
            textComp.text = "";
            panel.GetComponent<Image>().enabled = false;
            textComp.GetComponent<Text>().enabled = false;
            control.enabled = true;
            Destroy(this);
    }*/


//////ATTTTAAAA!!!

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
        if (inTrigger && next)
        {
            next = false;
            print("blabla" +next);
            textComp.text = "";
            if (iterations == 0)
            {
                control.enabled = false;
                panel.GetComponent<Image>().enabled = true;
                textComp.GetComponent<Text>().enabled = true;
                GetComponent<AudioSource>().PlayOneShot(zia);
                message = "Le mouton des Calagor? Vite... je dois l'aider à fuir. ";
            }
            else if (iterations == 1)
            {
                textComp.text = "";
                panel.GetComponent<Image>().enabled = false;
                textComp.GetComponent<Text>().enabled = false;
                control.enabled = true;
                Destroy(this);
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
                GetComponent<AudioSource>().PlayOneShot(mouton);
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
