using System;
using UnityEngine;

public class PowerUpHeal : MonoBehaviour
{
    [SerializeField]
    private int healAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var playerStats = other.GetComponent<PlayerStats>();
            playerStats.PlayerAddHealth(healAmount);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
