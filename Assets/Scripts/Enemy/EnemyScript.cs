using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : FieldOfView
{
    public GameObject target;
    private NavMeshAgent _agent;
    //public EnemyProperties enemyProperties;

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

    //public void OnDisable()
    //{
    //    enemyProperties.ResetData();
    //}

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        StartCoroutine(FOVcorutine());
    }

    // Update is called once per frame
    void Update()
    {
        //enemyProperties.currentEnemyPosition = transform.position;

        if (canSeePlayer == true)
        {
            MoveToTarget();
        }
        else
        {
            StopEnemy();
        }
    }

}
