using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1To2 : MonoBehaviour
{

    public GameObject loadingScreen;
    AsyncOperation async; 


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            //SceneManager.LoadScene(1);
            StartCoroutine(LoadingScreenFunction());
        }
    }

    IEnumerator LoadingScreenFunction()
    {
        loadingScreen.SetActive(true);
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = true;
        yield return null;
    }
}
