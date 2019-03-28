using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueAgora : MonoBehaviour
{
    public PlayerInput control;
    public Player player;

    public float letterPause = 0.2f;
    int iterations = 0;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;
    public AudioClip sound6;
    

    public Animator anim;
    public Animator zia;

    string ligne1;
    string message;
    public GameObject panel;
    public Text textComp;

    bool next = true;
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
            textComp.text = "";
            if (iterations == 0)
            {
                
                control.enabled = false;
                zia.SetBool("istalking",true);
                anim.SetBool("isspeaking", true);
                panel.GetComponent<Image>().enabled = true;
                textComp.GetComponent<Text>().enabled = true;
                GetComponent<AudioSource>().PlayOneShot(sound1);
                message = "Zia : Cassandre, monsieur Pirès m'a dit qu'il y avait plein de nouveaux légumes. Ça veut dire qu'on ne vas pas avoir besoin de manger des animaux?";
            }
            else if (iterations == 1)
            {
                GetComponent<AudioSource>().PlayOneShot(sound2);
                message = "Cassandre : Je ne sais pas Zia. Les récoltes sont mauvaises ces dernières années. Le vote décidera de si oui ou non nous allons devoir manger des animaux.";
            }
            else if (iterations == 2)
            {
                GetComponent<AudioSource>().PlayOneShot(sound3);
                message = "Zia : D'accord, Madame...";
            }
            else if (iterations == 3)
            {
                textComp.text = "";
                panel.GetComponent<Image>().enabled = false;
                textComp.GetComponent<Text>().enabled = false;
                anim.SetBool("isspeaking",false);
                zia.SetBool("istalking",false);
                control.enabled = true;
                player.enabled = true;

            }

            StartCoroutine(TypeText());
            iterations++;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
            inTrigger = true;
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
