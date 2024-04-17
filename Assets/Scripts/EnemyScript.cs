using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent _agent;

    public EnemyProperties enemyProperties;

    public float DistanceCalculation()
    {
        float distance = Vector3.Distance(_agent.transform.position, target.transform.position);
        
        return distance;
    }

    public void MoveToTarget()
    {
        _agent.isStopped = false;
        _agent.SetDestination(target.transform.position);

        if (DistanceCalculation() <= 10)
        {
            StopEnemy();
        }
    }

    public void StopEnemy()
    {
       _agent.isStopped = true;
    }

    private void OnDisable()
    {
        enemyProperties.ResetData(); // remove all data from asset 
    }

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyProperties.currentEnemyPosition = transform.position;

        if (enemyProperties.canSeePlayer == true)
        {
            MoveToTarget();
        }
        else
        {
            StopEnemy();
        }

    }

}
