using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnet : MonoBehaviour
{
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<Star>(out Star star))
        {
            star.SetTarget(transform.parent.position);
        }
    }
}
