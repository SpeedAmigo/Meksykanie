using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartUIScript : MonoBehaviour
{
    public Image image;
    public float fillTime = 5f;
    public float fillAmount = 0f;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public IEnumerator ImageFill()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fillTime) 
        {
            elapsedTime += Time.deltaTime;
            fillAmount = elapsedTime / fillTime;

            image.fillAmount = fillAmount;

            yield return null;
        }
        fillAmount = 1f;
        image.fillAmount = fillAmount;
    }
}
