using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingDetect : MonoBehaviour
{
    public Transform rayOriginRight, endLine;

    RaycastHit2D hit;
    bool jumping;
    bool isJumping;

    public GameObject dustPrefab;
    private ParticleSystem dustParticle;

    public AudioClip landingSound;
    Player playerScript;
    CharacterControllerZia controller;
    Animator anim;


    void Start()
    {
        playerScript = GetComponent<Player>();
        controller = GetComponent<CharacterControllerZia>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        LineCasting();
    }


    void LineCasting()
    {
        Debug.DrawLine(rayOriginRight.position, endLine.position, Color.blue);
        
        if (Physics2D.Linecast(rayOriginRight.position, endLine.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            hit = Physics2D.Linecast(rayOriginRight.position, endLine.position, 1 << LayerMask.NameToLayer("Ground"));
            isJumping = false;
        }
        else
        {
            isJumping = true;
            jumping = true;
        }

        if (isJumping && !playerScript.jumping && !playerScript.climbing && !controller.collisions.below)
        {

            if(playerScript.hasJetpack)
                anim.SetTrigger("chuteSpe");
            else
                anim.SetTrigger("chute");
        }

        if (!isJumping && jumping)
        {
            GetComponent<AudioSource>().PlayOneShot(landingSound);
            GameObject dust = Instantiate(dustPrefab, rayOriginRight.position, Quaternion.identity) as GameObject;
            dustParticle = dust.GetComponent<ParticleSystem>();
            jumping = false;
            
            float totalDuration = dustParticle.duration + dustParticle.startLifetime;
            Destroy(dust, totalDuration);

        }
    }

}
