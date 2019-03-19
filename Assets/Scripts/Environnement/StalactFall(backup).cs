using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalactFall : MonoBehaviour
{
    private Vector3 pos;
    private Quaternion rot;
    
    public GameObject prefabStalact;
    private GameObject currentStalact;
    private GameObject nextStalact;

    public bool isFalling;
    public float fallFrequency = 3;
    public float spawnFrequency = 4;

    void Start()
    {
        pos = transform.position;
        rot = Quaternion.identity;
        currentStalact = gameObject;
    }


    void Update()
    {
        if(!isFalling)
        {
            print("Falling");
            currentStalact.GetComponent<StalactFall>().isFalling = true;
            StartCoroutine(TimeBeforeFall(fallFrequency));
        }
    }

    public void Falling()
    {
        print("Falling");
        currentStalact.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine(TimeBeforeSpawn(spawnFrequency));
    }

    public void SetIsFalling(bool val)
    {
        isFalling = val;
    }


    public IEnumerator TimeBeforeFall(float waitTime)
    {
        print("Time before fall");
        yield return new WaitForSeconds(waitTime);
        Falling();
    }

    public IEnumerator TimeBeforeSpawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        nextStalact = Instantiate(prefabStalact, pos, rot) as GameObject;
        Destroy(currentStalact);
        currentStalact = nextStalact;
        currentStalact.name = "Stalactite";
        currentStalact.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        currentStalact.GetComponent<StalactFall>().isFalling = false;
    }
}
