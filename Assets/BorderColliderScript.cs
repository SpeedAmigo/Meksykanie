using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderColliderScript : MonoBehaviour
{
    public GameObject colliderPopUp;
    // Start is called before the first frame update
    void Start()
    {
        colliderPopUp.SetActive(false);
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("WallCollider"))
        {
            colliderPopUp.SetActive(true);
        }
        else
        {
            colliderPopUp.SetActive(false);
        }
    }
}
