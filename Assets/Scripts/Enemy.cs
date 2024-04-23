using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] string name;
    protected int hp = 100;
    [SerializeField] int hp2 = 100;

    protected void ResetData()
    {

        hp = 100;
    }
}
