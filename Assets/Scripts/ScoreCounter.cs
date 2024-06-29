using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class ScoreCounter : MonoBehaviour
{
    public TMP_Text score;
    public SlayMeterUI slayMeterUI;
    private int valueToAdd = 10;
    public int multiplier;

    public int ScoreCalculation()
    {
        int calculatetInt = valueToAdd * multiplier;

        return calculatetInt;
    }

    public void ScoreEvent()
    {
        int scoreToAdd = ScoreCalculation();
        int currentScore;

        if (int.TryParse(score.text, out currentScore))
        {
            currentScore += scoreToAdd;

            score.text = currentScore.ToString();
        }
    }

    public void Awake()
    {
        EventManager.ScorePoints.AddListener(ScoreEvent);
    }

    public void OnDisable()
    {
        EventManager.ScorePoints.RemoveListener(ScoreEvent);
    }

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        multiplier = slayMeterUI.multiplierInt;
    }
}
