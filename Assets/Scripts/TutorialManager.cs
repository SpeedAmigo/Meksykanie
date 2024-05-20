using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public int popUpIndex;
    public GameObject tank;
    public GameObject shop;
    public GameObject tutorialSpawner;
    public GameObject shifter;

    public EnemyDamageScript enemy;

    public bool dummyHasDied = false;
    private void MovementTutorial()
    {
        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            shifter.GetComponent<CanvasManager>().enabled = true;
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            tank.GetComponent<TurretMovement>().enabled = true;
            tank.GetComponent<CanonScript>().enabled = true;
            tank.GetComponent<AmmoManager>().enabled = true;
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 4)
        {
            tutorialSpawner.SetActive(true);
            if (dummyHasDied == true)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 5)
        {
            shop.SetActive(true);
            shop.GetComponent<shopManager>().enabled = true;
            tutorialSpawner.SetActive(false);
            if (Input.GetKeyDown(KeyCode.B))
            {
                popUpIndex++;
            }
        }
    }
    /*
    public IEnumerator PopUpDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        popUpIndex++;
    }
    */

    public void HandleEnemyDeath()
    {
        dummyHasDied = true;
    }

    private void Start()
    {
        MovementTutorial();

        tank.GetComponent<CanonScript>().enabled = false;
        tank.GetComponent<TurretMovement>().enabled = false;
        tank.GetComponent<AmmoManager>().enabled = false;
        shop.GetComponent<shopManager>().enabled = false;
        shifter.GetComponent<CanvasManager>().enabled = false;

        if (enemy != null)
        {
            enemy.onEnemyDeath.AddListener(HandleEnemyDeath);
        }

    }

    private void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        MovementTutorial();
    }
}
