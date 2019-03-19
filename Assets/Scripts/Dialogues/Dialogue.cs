using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public PlayerInput control;

    public float letterPause = 0.2f;
    int iterations = 0;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip paysanBeche;

    public Animator anim;
    public Animator zia;
    string ligne1;
    string message;
    public GameObject panel;
    public Text textComp;

    bool next=true;
    public bool inTrigger;

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
                zia.SetBool("istalking",true);
                anim.SetTrigger("speak");
                panel.GetComponent<Image>().enabled = true;
                textComp.GetComponent<Text>().enabled = true;
                GetComponent<AudioSource>().PlayOneShot(sound1);
                message = "Pirès : Oh! Zia, pourrais-tu dire à ta mère que nous avons enfin une récolte de prête! ";
            }
            else if (iterations == 1)
            {
                GetComponent<AudioSource>().PlayOneShot(sound2);
                message = "Pirès : Vous êtes les premières prévenues car il n'y en aura pas assez pour tout le monde.";
            }
            else if (iterations == 2)
            {
                GetComponent<AudioSource>().PlayOneShot(sound3);
                message = "Zia : Merci Monsieur Pirès. Je vais prévenir ma mère tout de suite.";
            }
            else if (iterations == 3)
            {
                textComp.text = "";
                panel.GetComponent<Image>().enabled = false;
                textComp.GetComponent<Text>().enabled = false;
                anim.SetTrigger("finishSpeak");
                zia.SetBool("istalking",false);
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
                anim.SetBool("hello",true);
                
               
                print("coucou salut ça va je meurt");
                
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
