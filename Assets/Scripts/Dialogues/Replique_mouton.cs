using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Replique_mouton : MonoBehaviour
{
    public PlayerInput control;

    public float letterPause = 0.2f;
    int iterations = 0;
    public AudioClip sound1;
    public AudioClip sound2;

    string ligne1;
    string message;
    public GameObject panel;
    public Text textComp;

    bool next=true;
    public bool inTrigger;

    //public Animator zia;

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
                control.enabled = false;
                panel.GetComponent<Image>().enabled = true;
                textComp.GetComponent<Text>().enabled = true;
                GetComponent<AudioSource>().PlayOneShot(sound1);
                message = "Affiche: Mouton perdu près de la forêt. Si vous avez des informations, n’hésitez pas à nous contacter. - famille Calagor …. ";
            }
            else if (iterations == 1)
            {
                control.enabled = false;
                panel.GetComponent<Image>().enabled = true;
                textComp.GetComponent<Text>().enabled = true;
                GetComponent<AudioSource>().PlayOneShot(sound2);
                message = "Zia: Encore un animal de disparu? Quelque chose doit faire peur aux animaux par ici... ";
            }
            else if (iterations == 2)
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
