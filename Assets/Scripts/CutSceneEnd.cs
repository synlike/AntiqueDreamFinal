using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEnd : MonoBehaviour
{
    public Player playerScript;

    public AudioClip robotReveil;

    void DestroyScene()
    {
        Destroy(gameObject);
        playerScript.enabled = true;
    }

    void startRobotReveil()
    {
        GetComponent<AudioSource>().PlayOneShot(robotReveil);
    }
}
