using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControllerZia))]
public class Player : MonoBehaviour
{
    Animator animator;

    public AudioClip jumpSound;

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .3f;
    float accelerationTimeGrounded = .1f;
    public float moveSpeed = 6;
    
    public bool isLookingLeft;
    public bool jumping;

    float gravity = -20;
    float jumpVelocity = 8;
    float velocityXSmoothing;
    public Vector3 velocity;
    
    CharacterControllerZia controller;

    public Vector2 directionalInput;

    PlayerInput playerInput;
    public bool releve;
    Animator animPlayer;

    public bool isWalking;
    public bool walkingSound;

    public bool hasJetpack;
    public int jumpCount;

    public bool inLadder;
    public bool climbing;

    Object[] footsteps;

    AudioClip footstep;

    //Particle Jump

    void Start(){
        controller = GetComponent<CharacterControllerZia>();
        animator = GetComponent<Animator>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);

        playerInput = GetComponent<PlayerInput>();
        //playerInput.enabled = false;
        footsteps = Resources.LoadAll("sound/sons_footstep/Plage");
    }

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }


    void Update(){

        if(controller.collisions.above || controller.collisions.below)
        {
            animator.SetBool("isjumping", false);
            jumping = false;
            jumpCount = 0;
            if (!controller.collisions.slidingDownMaxSlope)
            {
                velocity.y = 0;
            }
        }

        if (!jumping)
        {
            if (directionalInput.x != 0)
            {
                animator.SetBool("iswalking", true);
                isWalking = true;
            }
            else
            {
                animator.SetBool("iswalking", false);
                isWalking = false;
            }
        }

        if (Input.GetButtonDown("Jump") && controller.collisions.below && !controller.collisions.slidingDownMaxSlope && !hasJetpack)
        {
                GetComponent<AudioSource>().PlayOneShot(jumpSound);
                animator.SetBool("isjumping", true);
                jumping = true;
                animator.SetFloat("jump_velocity", velocity.y);
                velocity.y = jumpVelocity;
        }
        else if(Input.GetButtonDown("Jump") && hasJetpack && jumpCount < 2)
        {
            if(jumpCount == 0 && controller.collisions.below)
            {
                GetComponent<AudioSource>().PlayOneShot(jumpSound);
                animator.SetBool("isjumping", true);
                jumping = true;
                animator.SetFloat("jump_velocity", velocity.y);
                velocity.y = jumpVelocity;

                jumpCount++;
            }
            else if (jumpCount == 1)
            {
                GetComponent<AudioSource>().PlayOneShot(jumpSound);
                animator.SetBool("doubleJump", true);
                jumping = true;
                animator.SetFloat("jump_velocity", velocity.y);
                velocity.y = jumpVelocity;

                jumpCount++;
            }
        }

        if (inLadder && Input.GetButton("ClimbLadder"))
        {
            //print("climb");
            controller.climbing = true;
            climbing = true;
            animator.SetTrigger("climb");
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.015f, transform.position.z);
        }

        /*if (!controller.collisions.below)
        {
            animator.SetBool("isjumping", true);
        }*/


        float targetVelocityX = directionalInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime, directionalInput);

        if (directionalInput.x > 0)
            isLookingLeft = false;
        else if(directionalInput.x < 0)
            isLookingLeft = true;

        UpdateFlip();

        if (isWalking && !walkingSound && controller.collisions.below)
        {
            StartCoroutine(Walking());
        }

    }


    void UpdateFlip()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (isLookingLeft)
        {
            //transform.rotation = Quaternion.Euler(0, 180f, 0);
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
            //transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "releve" && !releve)
        {
            animator.SetTrigger("sit");
            releve = true;
            StartCoroutine(TimeBeforeControlBack());
        }

        if(collision.gameObject.tag == "champs")
        {
            footsteps = Resources.LoadAll("sound/sons_footstep/Champs");
        }
        else if (collision.gameObject.tag == "plage")
        {
            footsteps = Resources.LoadAll("sound/sons_footstep/Plage");
        }
        else if (collision.gameObject.tag == "metal")
        {
            footsteps = Resources.LoadAll("sound/sons_footstep/Metal");
        }
        else if(collision.gameObject.tag == "pierre")
        {
            footsteps = Resources.LoadAll("sound/sons_footstep/Pierre");
        }

        if (collision.gameObject.tag == "ladder")
        {
            inLadder = true;
        }
    }

    public void SetAnimJet()
    {
        hasJetpack = true;
        animator.SetTrigger("jetpack");
    }

    public void SetAnimNorm()
    {
        hasJetpack = false;
        animator.SetTrigger("forceIdle");
    }

    IEnumerator TimeBeforeControlBack()
    {
        animator.SetTrigger("standup");
        yield return new WaitForSeconds(2f);
        playerInput.enabled = true;
    }

    IEnumerator Walking()
    {
        footstep = (AudioClip)footsteps[Random.Range(0, footsteps.Length)];
        walkingSound = true;
        GetComponent<AudioSource>().PlayOneShot(footstep);
        yield return new WaitForSeconds(0.6f);
        walkingSound = false;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ladder")
        {
            inLadder = false;
        }
    }
}
