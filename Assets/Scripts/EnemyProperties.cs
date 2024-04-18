using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyProperties : ScriptableObject
{
    [SerializeField] float defaultEnemyHealth;
    [SerializeField] float defaultEnemySpeed;
    [SerializeField] bool defaultCanSeePlayer = false;

    public float enemyHealth;
    public float enemySpeed;
    public float detectionRange;
    public bool canSeePlayer;
    public Vector3 currentEnemyPosition;


    public void ResetData() // remove all data from asset
    {
        enemyHealth = defaultEnemyHealth;
        enemySpeed = defaultEnemySpeed;
        canSeePlayer = defaultCanSeePlayer;

        currentEnemyPosition = Vector3.zero;
    }
}