using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDummyButtons : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public AudioSource audioSource;

    private float[] volumeLevels = new float[] {0f, 0f, 0f, 0.25f, 0.5f, 0.75f, 1f};

    public void MenuFunction(int index)
    {
        if (index == 0)
        {
            Debug.Log("Play");
        }
        if (index == 1)
        {
            Debug.Log("Quit");
        }

        if (index >= 2 && index < volumeLevels.Length)
        {
            float volume = volumeLevels[index];
            //audioSource.volume = volume;
            Debug.Log("Volume set to: " + (volume * 100) + "%");
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
