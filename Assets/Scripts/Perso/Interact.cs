using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    //RayCast to interact
    public bool interacting;
    public bool grabbing;
    public bool inTrigger;
    private bool hasHead;
    private bool hasNeck;
    private bool hasBody;

    Player player;

    public Image image;
    Sprite sprite;

    public string inventory;


    public Transform holdPoint;
    public Transform lineStart, lineEndRight, lineEndLeft;

    Transform direction;

    public GameObject currentObject;

    GameObject lastHit;
    RaycastHit2D hit;

    public AudioClip recupObjet;

    void Start()
    {
        player = GetComponent<Player>();
        direction = lineEndRight;
    }


    void Update()
    {
        /* INTERACTION AVEC OBJETS */
        Raycasting();
    }
    

    void Raycasting()
    {
        if (player.isLookingLeft)
            direction = lineEndLeft;
        else
            direction = lineEndRight;

        Debug.DrawLine(lineStart.position, direction.position, Color.green);
        //if (!grabbing)
       // {
            if (Physics2D.Linecast(lineStart.position, direction.position, 1 << LayerMask.NameToLayer("Object")))
            {
                hit = Physics2D.Linecast(lineStart.position, direction.position, 1 << LayerMask.NameToLayer("Object"));
                interacting = true;
                lastHit = hit.transform.gameObject;
                lastHit.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                if(lastHit != null)
                {
                    lastHit.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                }
                interacting = false;
            }

            if (Input.GetButtonDown("Grab") && interacting == true)
            {
                if (hit.transform.gameObject.tag == "grabbable")
                {
                    TakeItem();
                }
                else if (hit.transform.gameObject.tag == "caisse")
                {
                    Debug.Log("C'est une caisse !");
                }
            }
        //}
    }

    void TakeItem()
    {
        if (grabbing)
        {
            Instantiate(currentObject, new Vector3(transform.position.x+1, transform.position.y, transform.position.z), Quaternion.identity);
            currentObject.transform.position = hit.collider.gameObject.transform.position;
            currentObject.SetActive(true);
        }
        if(hit.collider.gameObject.name == "sacados")
        {
            player.SetAnimJet();
        }
        else
        {
            player.SetAnimNorm();
        }
        Debug.Log("Take");
        GetComponent<AudioSource>().PlayOneShot(recupObjet);
        grabbing = true;
        sprite = hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite;
        image.sprite = sprite;
        image.enabled = true;
        inventory = hit.collider.gameObject.name;
        currentObject = hit.collider.gameObject;
        currentObject.name = hit.collider.gameObject.name;
        CheckValues();
        DestroyItem();
    }

    public void ClearInventory()
    {
        inventory = "";
        image.enabled = false;
    }

    public void DestroyItem()
    {
        //Destroy(hit.collider.gameObject);
        hit.collider.gameObject.SetActive(false);
    }

    public void CheckValues()
    {
        if (inventory == "tete")
            hasHead = true;
        else if (inventory == "cou")
            hasNeck = true;
        else if (inventory == "torse")
            hasBody = true;
    }

    public void EraseValues()
    {
        hasHead = false;
        hasNeck = false;
        hasBody = false;
    }

    public bool HasHead
    {
        get { return hasHead; }
        set { hasHead = value; }
    }

    public bool HasNeck
    {
        get { return hasNeck; }
        set { hasNeck = value; }
    }

    public bool HasBody
    {
        get { return hasBody; }
        set { hasBody = value; }
    }

    public bool Interacting
    {
        get { return interacting; }
        set { interacting = value; }
    }

    public bool Grabbing
    {
        get { return grabbing; }
        set { grabbing = value; }
    }
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "machine")
            inTrigger = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "machine")
            inTrigger = false;
    }
}
