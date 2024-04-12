using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.Pool;

public class CanonScript : MonoBehaviour
{
    TrajectoryPredictor trajectoryPredictor;

    [SerializeField]
    Rigidbody projectileRb;

    [SerializeField, Range(0.0f, 200f)]
    float force;

    public Transform projectileSpawnPoint;
    public ProjectileScript projectileScript;
    //public float projectileSpeed = 100;
    public bool isReloaded = false;

    private ObjectPool<ProjectileScript> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<ProjectileScript>(CreateProjectile, TakeProjectileFromPool, OnPutBackInPool, OnDestroyProjectile, false, 3, 5);
    }

    private ProjectileScript CreateProjectile()
    {
        var projectile = Instantiate(projectileScript);

        projectile.SetPool(_pool);
        return projectile;
    }

    private void TakeProjectileFromPool(ProjectileScript projectile)
    {
        projectile.transform.position = projectileSpawnPoint.position;
        projectile.transform.rotation = projectileSpawnPoint.rotation;

        projectile.gameObject.SetActive(true);
    }

    private void OnPutBackInPool(ProjectileScript projectile)
    {
        projectile.gameObject.SetActive(false);
    }

    private void OnDestroyProjectile(ProjectileScript projectile)
    {
        Destroy(projectile.gameObject);
    }

    private void OnEnable()
    {
        trajectoryPredictor = GetComponent<TrajectoryPredictor>();

        if (projectileSpawnPoint == null)
        {
            projectileSpawnPoint = transform;
        }
    }

    private void Update()
    {
        OnPlayerTrigger();
        Predict();
    }

    private void Start()
    {
        StartCoroutine(ReloadCorutine());
    }

    void Predict()
    {
        trajectoryPredictor.PredictProjectileTrajectory(ProjectileData());
    }
    private IEnumerator ReloadCorutine()
    {
        Debug.Log("Reloading");
        isReloaded = false;

        yield return new WaitForSeconds(4);

        isReloaded = true;
        Debug.Log("Cannon reloaded");
    }

    ProjectileProperties ProjectileData()
    {
        ProjectileProperties properties = new ProjectileProperties();
        Rigidbody r = projectileRb.GetComponent<Rigidbody>();

        properties.direction = projectileSpawnPoint.forward;
        properties.initialPosition = projectileSpawnPoint.position;
        properties.initialSpeed = force;
        properties.mass = r.mass;
        properties.drag = r.drag;

        return properties;
    }

    public void OnPlayerTrigger()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isReloaded == true)
        {
            var projectile = _pool.Get();

            //projectile.GetComponent<Rigidbody>().velocity = projectileSpawnPoint.forward * force;
            projectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * force, ForceMode.Impulse);

            StartCoroutine(ReloadCorutine());
        }
    }
}
