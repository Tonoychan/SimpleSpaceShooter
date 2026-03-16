using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    
    private float health;

    [SerializeField] 
    private Image healthBar;
    
     void Start()
    {
        health = maxHealth;
        healthBar.fillAmount = health / maxHealth;
    }
     
    public void PlayerTakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
