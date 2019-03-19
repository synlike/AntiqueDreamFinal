using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zia : MonoBehaviour {
    
    Animator animator;
	Rigidbody2D rigid;
	//bool marche;
	
	public int vitesse=15;
	bool isLookingLeft;
    //int vitesseSaut=10;

    //Saut with Raycast
    public bool grounded;
    public bool isJumping;
    public Transform lineJump;

    public AudioClip jumpSound;
    public AudioClip landSound;
    
    [Range(1, 20)]
    public float jumpVelocity = 7;
    

    void Start () {
		isLookingLeft=false;
		rigid=GetComponent<Rigidbody2D>();
		
		animator = GetComponent<Animator>();
	}
	
	void Update () {
        Walking();
        Jumping();
        UpdateFlip();
        Raycasting();
	}
    

    void Raycasting()
    {
        //Debug.DrawLine(transform.position, lineJump.position, Color.green);
        grounded = Physics2D.Linecast(transform.position, lineJump.position, 1 << LayerMask.NameToLayer("Ground"));
    }

    void Walking()
    {
        float varHorizontal = Input.GetAxis("Horizontal");
        if (varHorizontal != 0)
        {
            rigid.velocity += new Vector2(varHorizontal, 0);
            rigid.velocity = new Vector2(Mathf.Clamp(rigid.velocity.x, -vitesse, vitesse), rigid.velocity.y);

            if (varHorizontal > 0)
            {
                isLookingLeft = false;
            }
            else
            {
                isLookingLeft = true;
            }
            animator.SetBool("iswalking", true);
        }
        else
        {
            animator.SetBool("iswalking", false);
        }
    }

    void Jumping()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            animator.SetBool("isjumping", true);
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
            GetComponent<AudioSource>().PlayOneShot(jumpSound);
        }

        if(!grounded)
            isJumping = true;


        if (grounded && isJumping)
        {
            GetComponent<AudioSource>().PlayOneShot(landSound);
            animator.SetBool("isjumping", false);
            isJumping = false;
        }

    }


    void UpdateFlip(){
		SpriteRenderer sprite=GetComponent<SpriteRenderer>();
		if (isLookingLeft){
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        else{
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
	}
}
