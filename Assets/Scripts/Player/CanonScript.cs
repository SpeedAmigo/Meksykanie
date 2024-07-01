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
    public ProjectileProperties projectileProperties;
    private AmmoManager ammoManager;
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
        projectile.GetComponent<Rigidbody>().velocity = Vector3.zero; // reloads projectile velocity because without it projectile would go in the wrong direction
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

    void Predict()
    {
        trajectoryPredictor.PredictProjectileTrajectory(ProjectileData());
    }
    private IEnumerator ReloadCorutine()
    {
        //Debug.Log("Reloading");
        isReloaded = false;

        yield return new WaitForSeconds(4);

        isReloaded = true;
        //Debug.Log("Cannon reloaded");
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
        if (Input.GetKeyDown(KeyCode.Space) && isReloaded == true && ammoManager.hasAmmo == true)
        {
            var projectile = _pool.Get();

            projectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * force, ForceMode.Impulse);

            StartCoroutine(ReloadCorutine());
            EventManager.Reloading.Invoke();
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
        ammoManager = GetComponent<AmmoManager>();
    }

}
