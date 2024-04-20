using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("Star"))
        {
            Destroy(other.gameObject);
        }
    }
}
