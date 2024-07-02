using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public GameObject[] popUps;
    public int popUpIndex;
    public GameObject tank;
    public GameObject shop;
    public GameObject tutorialSpawner;
    public GameObject shifter;
    public Canvas tankCanvas;

    public EnemyDamageScript enemy;

    public bool dummyHasDied = false;
    public bool hasBeenClicked = false;
    public bool tutorialFinished = false;
    private void MovementTutorial()
    {
        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (!hasBeenClicked)
                {
                    StartCoroutine(PopUpDelay(2));
                    hasBeenClicked = true;
                }
                //popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            shifter.GetComponent<CanvasManager>().enabled = true;
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W))
            {
                if (!hasBeenClicked)
                {
                    StartCoroutine(PopUpDelay(2));
                    hasBeenClicked = true;
                }
                //popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1))
            {
                if (!hasBeenClicked)
                {
                    StartCoroutine(PopUpDelay(2));
                    hasBeenClicked = true;
                }
                //popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            tank.GetComponent<TurretMovement>().enabled = true;
            tank.GetComponent<CanonScript>().enabled = true;
            tankCanvas.enabled = true;
            tank.GetComponent<AmmoManager>().enabled = true;
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                if (!hasBeenClicked)
                {
                    StartCoroutine(PopUpDelay(2));
                    hasBeenClicked = true;
                }
                //popUpIndex++;
            }
        }
        else if (popUpIndex == 4)
        {
            tutorialSpawner.SetActive(true);
            if (dummyHasDied == true)
            {
                if (!hasBeenClicked)
                {
                    StartCoroutine(PopUpDelay(2));
                    hasBeenClicked = true;
                }
                //popUpIndex++;
            }
        }
        else if (popUpIndex == 5)
        {
            shop.GetComponent<shopManager>().enabled = true;
            tutorialSpawner.SetActive(false);
            if (Input.GetKeyDown(KeyCode.B))
            {
                shop.SetActive(true);
                tutorialFinished = true;
                StartCoroutine(SceneLoadingDely());
                popUpIndex++;
            }
        }
    }

    public void TutorialFinished()
    {
        if (tutorialFinished)
        {
            sceneLoader.LoadScene(3);
        }
    }

    public IEnumerator SceneLoadingDely()
    {
        yield return new WaitForSeconds(3);
        TutorialFinished();
    }
    
    public IEnumerator PopUpDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        popUpIndex++;
        hasBeenClicked = false;
    }
    

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
        tankCanvas.enabled = false;

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
