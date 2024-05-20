using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpawner : MonoBehaviour
{
    public GameObject dummy;

    public void OnEnable()
    {
        dummy.SetActive(true);
        dummy.transform.position = transform.position;
    }
}
