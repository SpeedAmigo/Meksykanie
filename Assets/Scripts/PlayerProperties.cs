using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerProperties : ScriptableObject
{
     int defaultStarCount = 100;
     int defaultExplosivesCount = 0;
     int defaultFlammableCount = 0;  

    public int starCount;
    public int explosivesCount;
    public int flammableCount;

    public void OnDisable()
    {
        ResetData();
    }

    public void ResetData()
    {
        starCount = defaultStarCount;
        explosivesCount = defaultExplosivesCount;
        flammableCount = defaultFlammableCount;
    }
}
