using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlayMeterUI : MonoBehaviour
{
    public Image image;

    private Dictionary<int, float> value = new Dictionary<int, float>()
    {
        {0, 1.0f},
        {1, 0.9f},
        {2, 0.8f},
        {3, 0.7f},
        {4, 0.6f},
        {5, 0.5f},
        {6, 0.4f},
        {7, 0.3f},
        {8, 0.2f},
        {9, 0.1f},
        {10, 0.0f}
    };


    // This method should be called whenever the integer value changes
    public void SlayMeterSlider(int newValue)
    {
        if (newValue >= 1 && newValue <= 10)
        {
            float newFillAmount = value[newValue];
            image.fillAmount = newFillAmount;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.fillAmount = 1;
    }
}
