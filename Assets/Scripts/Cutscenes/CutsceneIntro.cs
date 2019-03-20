using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneIntro : MonoBehaviour
{
    public Camera cameraMain;
    public Camera cameraSecondo;
    public Player player;

    public GameObject PanelEtoStart;

    Animator playerAnim;
    Animator anim;
    Player playerScript;
    CharacterControllerZia characterControl;
    PlayerInput inputScript;

    Transform posCameraMain;
    bool dezoom;
    public bool play;


    void Start()
    {
        anim = GetComponent<Animator>();

        playerAnim = player.GetComponent<Animator>();
        playerAnim.SetTrigger("sit");
        playerScript = player.GetComponent<Player>();
        characterControl = player.GetComponent<CharacterControllerZia>();
        inputScript = player.GetComponent<PlayerInput>();

        playerScript.isLookingLeft = true;
        inputScript.enabled = false;
        playerScript.enabled = false;
        characterControl.enabled = false;
    }


    void Update()
    {
        if (play)
        {
            playerAnim.SetTrigger("standup");
            dezoom = true;
            anim.SetTrigger("activate");
            play = false;
        }

        if (dezoom)
        {
            StartCoroutine(Dezoom());
            //StartCoroutine(FadeTo(1.0f, 3f));
        }
    }

    void Play()
    {
        play = true;
    }

    IEnumerator Dezoom()
    {
        cameraSecondo.transform.position = Vector3.Lerp(cameraSecondo.transform.position, cameraMain.transform.position, Time.deltaTime);
        cameraSecondo.orthographicSize = Mathf.Lerp(cameraSecondo.orthographicSize, 3, Time.deltaTime);
        yield return new WaitForSeconds(3f);
        dezoom = false;
        cameraMain.GetComponent<Camera>().enabled = true;
        cameraSecondo.GetComponent<Camera>().enabled = false;
        playerScript.enabled = true;
        characterControl.enabled = true;
        inputScript.enabled = true;
    }

   /* public void FadeOut()
    {
        StartCoroutine(FadeTo(0f, 3f));
    }*/

    /*IEnumerator FadeTo(float aValue, float aTime)
    {

        float alpha = GetComponent<SpriteRenderer>().color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }
    }*/
}
