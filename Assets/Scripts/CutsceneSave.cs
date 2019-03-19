using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneSave : MonoBehaviour
{
    public GameObject player;
    CharacterControllerZia controllerScript;
    Player playerScript;
    Animator anim;
    Animator animPlayer;

    public GameObject rocher;
    public GameObject rocherFall;
    public GameObject scene;

    public GameObject spawnPoint;

    bool movingPlayer;

    Vector3 position;

    public AudioClip robotRescousse;


    void Start()
    {
        anim = GetComponent<Animator>();
        animPlayer = player.GetComponent<Animator>();
        playerScript = player.GetComponent<Player>();
        controllerScript = player.GetComponent<CharacterControllerZia>();
    }

    void Update()
    {
        if (movingPlayer)
        {
            player.transform.position = Vector3.Lerp(player.transform.position, spawnPoint.transform.position, 2 * Time.deltaTime);
        }
    }

    void LaunchCutscene()
    {
        anim.SetTrigger("Launch");
    }

    void DestroyPlayer()
    {
        player.GetComponent<SpriteRenderer>().flipX = true;
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<BoxCollider2D>().enabled = false;
        animPlayer.SetTrigger("sit");
    }

    void DestroyCutscene()
    {
        scene.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        StartCoroutine(TimeBeforeControlBack());
    }

    void MovingPlayer()
    {
        movingPlayer = !movingPlayer;
    }

    void FallingRock()
    {
        Destroy(rocher);
        rocherFall.GetComponent<SpriteRenderer>().enabled = true;
        rocherFall.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        rocherFall.GetComponent<Rigidbody2D>().gravityScale = 0.9f;
    }

    void startRobotRescousse()
    {
        GetComponent<AudioSource>().PlayOneShot(robotRescousse);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            animPlayer.SetBool("iswalking", false);
            playerScript.enabled = false;
            LaunchCutscene();
        }
    }

    IEnumerator TimeBeforeControlBack()
    {
        animPlayer.SetTrigger("standup");
        yield return new WaitForSeconds(2f);
        playerScript.enabled = true;
        playerScript.velocity.x = 0f;
    }
}
