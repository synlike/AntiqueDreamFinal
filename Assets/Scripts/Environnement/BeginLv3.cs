using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginLv3 : MonoBehaviour
{
    public SpriteRenderer sacados;
    public GameObject player;

    PlayerInput playerInput;
    Player playerScript;
    CharacterControllerZia controller;

    void Start()
    {
        playerInput = player.GetComponent<PlayerInput>();
        controller = player.GetComponent<CharacterControllerZia>();
        playerScript = player.GetComponent<Player>();

        playerScript.isLookingLeft = true;
        playerInput.enabled = false;
        controller.enabled = false;
    }

    void unlockPlayer()
    {
        transform.DetachChildren();
        playerInput.enabled = true;
        controller.enabled = true;
        sacados.enabled = true;
    }


    void Update()
    {
        
    }
}
