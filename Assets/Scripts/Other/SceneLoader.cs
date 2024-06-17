using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreenGeneral;

    public GameObject loadingScreen;
    public Image loadingBar;

    public void LoadScene(int sceneId)
    {
        StartCoroutine(SceneLoaderMethod(sceneId));
        loadingScreenGeneral.SetActive(true);
    }

    IEnumerator SceneLoaderMethod(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            loadingBar.fillAmount = progressValue;

            Debug.Log("Scene Loaded");

            yield return null;
        }
    }

    private void Start()
    {
        loadingScreenGeneral.SetActive(false);
    }
}
