using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private Transform shootingPoint;
    [SerializeField]
    private float shootInterval;

    private float resetInterval;
    
    void Start()
    {
        resetInterval = shootInterval;
    }

    
    void Update()
    {
        shootInterval-= Time.deltaTime;
        if (shootInterval <=0)
        {
            Shoot();
            shootInterval = resetInterval;
        }
    }

    void Shoot()
    {
        Instantiate(laserPrefab, shootingPoint.position, Quaternion.identity);
    }
}
