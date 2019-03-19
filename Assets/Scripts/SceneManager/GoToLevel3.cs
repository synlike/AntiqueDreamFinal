using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel3 : MonoBehaviour
{
    public GameObject loadingScreen;
    AsyncOperation async;

    

    void changeScene()
    {
        StartCoroutine(LoadingScreenFunction());
    }

    IEnumerator LoadingScreenFunction()
    {
        loadingScreen.SetActive(true);
        async = SceneManager.LoadSceneAsync(2);
        async.allowSceneActivation = true;
        yield return null;
    }
}

//PS : Ce script pourrait être rassemblé en un seul
