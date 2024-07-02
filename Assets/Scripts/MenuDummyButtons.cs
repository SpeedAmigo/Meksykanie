using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDummyButtons : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public List<GameObject> volumeIndicators;
    public GameObject circle;
    public AudioSource audioSource;
    public SceneLoader sceneLoader;

    private float[] volumeLevels = new float[] {0f, 0f, 0f, 0.25f, 0.5f, 0.75f, 1f};

    public void MenuFunction(int index)
    {
        if (index == 0)
        {
            Application.Quit();
        }
        if (index == 1)
        {
            sceneLoader.LoadScene(1);
        }

        if (index >= 2 && index < volumeLevels.Length)
        {
            float volume = volumeLevels[index];
            //audioSource.volume = volume;
            Debug.Log("Volume set to: " + (volume * 100) + "%");

            for (int i = 0; i < volumeIndicators.Count; i++)
            {
                if (i == index - 2)
                {
                    volumeIndicators[i].SetActive(true);
                }
                else
                    volumeIndicators[i].SetActive(false);
            }
           
        }
    }

    private void Start()
    {
        foreach (GameObject obj in volumeIndicators) 
        {
            obj.SetActive(false);
        }
    }
}
