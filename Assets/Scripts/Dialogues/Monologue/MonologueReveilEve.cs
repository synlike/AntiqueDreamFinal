using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonologueReveilEve : MonoBehaviour
{
	public PlayerInput control;

    public float letterPause = 0.2f;
    int iterations = 0;
    public AudioClip zia;

    string ligne1;
    string message;
    public GameObject panel;
    public Text textComp;

    bool next=true;
    public bool inTrigger;


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

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            
            if (next==true)
            {
            	StartCoroutine(AfficherMonologue());
            }
            

        }
            
    }

    IEnumerator AfficherMonologue()
    {
        inTrigger = true;
        textComp.text = "";
        //control.enabled = false;
        panel.GetComponent<Image>().enabled = true;
        textComp.GetComponent<Text>().enabled = true;
        GetComponent<AudioSource>().PlayOneShot(zia);
        message = "Oh...qu'est ce que c'est?";
        StartCoroutine(TypeText());


        yield return new WaitForSeconds(3f);
        textComp.text = "";
        panel.GetComponent<Image>().enabled = false;
        textComp.GetComponent<Text>().enabled = false;
        control.enabled = true;
        Destroy(this);
        //GetComponent<AudioSource>().PlayOneShot(mouton);
        //anim.SetBool("hello",true);
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
