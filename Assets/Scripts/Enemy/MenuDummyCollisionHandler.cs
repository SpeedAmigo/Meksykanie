using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDummyCollisionHandler : MonoBehaviour
{
    public MenuDummyButtons menuDummyButtons;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            int index = menuDummyButtons.gameObjects.IndexOf(gameObject);

            if (index != -1)
            {
                menuDummyButtons.MenuFunction(index);
            }
        }
    }
}
