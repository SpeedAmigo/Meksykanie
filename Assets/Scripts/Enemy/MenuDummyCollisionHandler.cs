using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDummyCollisionHandler : MonoBehaviour
{
    public MenuDummyButtons menuDummyButtons;
    
    private Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            int index = menuDummyButtons.gameObjects.IndexOf(gameObject);

            if (index != -1)
            {
                if (rb != null)
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero; // stop roation
                }


                Vector3 currentPosition = gameObject.transform.position;
                gameObject.transform.position = new Vector3(currentPosition.x, currentPosition.y + 10, currentPosition.z);
                
                menuDummyButtons.MenuFunction(index);
            }
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
