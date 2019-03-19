using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public bool zoomIn;
    public bool zoomOut;

    BoxCollider2D collider;
    Vector2 offset;   // x = 1.3    new = 1.4
    Vector2 size;     // x = 6.6    new = 8.4

    public float zoomTarget = 5.5f;


    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        offset = collider.offset;
        size = collider.size;
    }

    void Update()
    {
        if (zoomIn)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 3, Time.deltaTime);
        }
        if (zoomOut)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, zoomTarget, Time.deltaTime);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            offset.x += 0.1f;
            size.x += 1.8f;
            collider.offset = offset;
            collider.size = size;
            zoomIn = false;
            zoomOut = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            offset.x -= 0.1f;
            size.x -= 1.8f;
            collider.offset = offset;
            collider.size = size;
            zoomOut = false;
            zoomIn = true;
        }
    }
}
