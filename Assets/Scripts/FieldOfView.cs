using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject player;

    public LayerMask targetMask;
    public LayerMask[] obstacleMasks;

    EnemyProperties enemyProperties;

    //public bool canSeePlayer;

    private void Start()
    {
        StartCoroutine(FOVcorutine());
    }

    private IEnumerator FOVcorutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true) 
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMasks.Length))
                    enemyProperties.canSeePlayer = true;
                else
                    enemyProperties.canSeePlayer = false;
            }
            else
                enemyProperties.canSeePlayer = false;
        }
        else if (enemyProperties.canSeePlayer) 
        {
            enemyProperties.canSeePlayer = false;
        }
    }
}
