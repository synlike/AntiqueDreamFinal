using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTraveling : MonoBehaviour
{
    public PlayerInput playerInput;
    public Player player;
    public Animator animPlayer;
    public Camera cameraMain;
    public Camera cameraTmp;

    public float travelingDuration;
    public Transform target;
    public Transform target2;

    bool eventPassed;
    bool travelingOn;
    bool travelingOff;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player" && !eventPassed)
        {
            animPlayer.SetBool("iswalking", false);
            player.enabled = false;
            playerInput.enabled = false;
            cameraTmp.transform.position = cameraMain.transform.position;
            cameraTmp.enabled = true;
            StartCoroutine(Transition());
        }
    }

    IEnumerator Transition()
    {
        float t = 0.0f;
        Vector3 startingPos = cameraMain.transform.position;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / travelingDuration);

            cameraTmp.transform.position = Vector3.Lerp(startingPos, target.position, t);
            yield return 0;
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(Transition2());
    }


    IEnumerator Transition2()
    {
        float t = 0.0f;
        Vector3 startingPos = cameraTmp.transform.position;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / travelingDuration);

            cameraTmp.transform.position = Vector3.Lerp(startingPos, target2.position, t);
            yield return 0;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(TransitionBack());
    }

    IEnumerator TransitionBack()
    {
        float t = 0.0f;
        Vector3 startingPos = cameraTmp.transform.position;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / travelingDuration);

            cameraTmp.transform.position = Vector3.Lerp(startingPos, cameraMain.transform.position, t);
            yield return 0;
        }
        eventPassed = true;
        cameraMain.enabled = true;
        cameraTmp.enabled = false;
        player.enabled = true;
        playerInput.enabled = true;
    }

}
