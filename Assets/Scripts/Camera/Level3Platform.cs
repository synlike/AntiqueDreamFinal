using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Platform : MonoBehaviour
{
    public PlayerInput input;
    public Player player;
    public Animator anim;
    public Camera mainCam;
    public Camera tmpCam;
    
    void Switch()
    {
        input.enabled = false;
        player.enabled = false;
        anim.SetTrigger("forceIdle");
        tmpCam.enabled = true;
        mainCam.enabled = false;
    }

    void SwitchBack()
    {
        input.enabled = true;
        player.enabled = true;
        mainCam.enabled = true;
        tmpCam.enabled = false;
    }
}
