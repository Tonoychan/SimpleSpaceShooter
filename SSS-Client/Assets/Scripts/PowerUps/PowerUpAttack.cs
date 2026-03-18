using System;
using UnityEngine;

public class PowerUpAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var playerShooting = other.GetComponent<PlayerShooting>();
            playerShooting.IncreaseUpgradelevel(1);
            Destroy(gameObject);
        }
    }
    
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
