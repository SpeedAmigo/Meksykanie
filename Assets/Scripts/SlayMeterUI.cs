using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml.Schema;

public class SlayMeterUI : MonoBehaviour
{
    public Image image;
    public TMP_Text multiplier;
    public ScoreCounter scoreCounter;
    public int multiplierInt = 0;

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

    private Dictionary<int, int> multiplierValue = new Dictionary<int, int>()
    {
        {0, 3},
        {3, 2},
        {7, 1},
        {10, 0}
    };


    // This method should be called whenever the integer value changes
    public void SlayMeterSlider(int newValue)
    {
        if (newValue >= 1 && newValue <= 10)
        {
            float newFillAmount = value[newValue];
            image.fillAmount = newFillAmount;
            MultiplierAction(newValue);
        }
    }

    public void MultiplierAction(int value)
    {
        if (multiplierValue.TryGetValue(value, out int multiplierVal))
        {
            multiplier.text = multiplierVal.ToString();
            multiplierInt = multiplierVal;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.fillAmount = 1;
        multiplier.text = multiplierValue[0].ToString();
        multiplierInt = multiplierValue[0];
    }
}
