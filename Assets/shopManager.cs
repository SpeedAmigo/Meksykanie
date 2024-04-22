using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopManager : MonoBehaviour
{
    public GameObject shopUI;
    private bool shopEnabled = false;

    public int explosiveAmmoCost = 50;
    public int flammableAmmoCost = 75;

    public PlayerProperties playerProperties;

    private void Start()
    {
        shopUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && shopEnabled == false)
        {
            Time.timeScale = 0f;
            shopUI.SetActive(true);
            shopEnabled = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else if (Input.GetKeyDown(KeyCode.B) && shopEnabled == true)
        {
            Time.timeScale = 1f;
            shopUI.SetActive(false);
            shopEnabled = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ExplosiveButton()
    {
        if (playerProperties.starCount >= explosiveAmmoCost)
        {
            playerProperties.starCount -= 50;
            playerProperties.explosivesCount += 10;
        }
    }

    public void FlammableButton()
    {
        if (playerProperties.starCount >= flammableAmmoCost)
        {
            playerProperties.starCount -= 75;
            playerProperties.flammableCount += 10;
        }
    }
}
