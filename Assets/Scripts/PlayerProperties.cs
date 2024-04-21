using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerProperties : ScriptableObject
{
    [SerializeField] int defaultStarCount = 0;

    public int starCount;

    public void OnDisable()
    {
        ResetData();
    }

    public void ResetData()
    {
        starCount = defaultStarCount;
    }
}
