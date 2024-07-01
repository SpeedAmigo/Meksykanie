using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadIndicator : MonoBehaviour
{
    public Image image;

    public void Awake()
    {
        EventManager.Reloading.AddListener(Reload);
    }

    public void OnDisable()
    {
        EventManager.Reloading.RemoveListener(Reload);
    }

    public void Reload()
    {
        image.fillAmount = 0;
        StartCoroutine(CannonReloadIndicator());
    }

    public IEnumerator CannonReloadIndicator()
    {
        float duration = 4f;
        float elapsedTime = 0f;

        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            image.fillAmount = Mathf.Clamp01(elapsedTime / duration);
            yield return null;
        }
        image.fillAmount = 1f;
    }
    void Start()
    {
        image = GetComponent<Image>();

        image.fillAmount = 0;
        StartCoroutine(CannonReloadIndicator());
    }
}
