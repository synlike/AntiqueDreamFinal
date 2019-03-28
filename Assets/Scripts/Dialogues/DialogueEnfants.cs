using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueEnfants : MonoBehaviour
{
	public PlayerInput control;
    public Player player;

    public float letterPause = 0.2f;
    int iterations = 0;
    public AudioClip sound1;

    string ligne1;
    string message;
    public GameObject panel;
    public Text textComp;
    public Animator zia;

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
            control.enabled = false;
            player.enabled = false;
            zia.SetBool("iswalking", false);
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
                message = "Enfants : Laisse-nous Zia! Nous sommes en pleine partie de billes!! ";
            }
            else if (iterations == 1)
            {
                zia.SetBool("istalking",false);
                textComp.text = "";
                panel.GetComponent<Image>().enabled = false;
                textComp.GetComponent<Text>().enabled = false;
                control.enabled = true;
                player.enabled = true;
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
