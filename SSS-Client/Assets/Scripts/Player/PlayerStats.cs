using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    private float health;
    
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField] 
    private Image healthBar;
    [SerializeField] 
    private GameObject explosionVFX;
    
    private bool canPlayAnim = true;
    
     void Start()
    {
        health = maxHealth;
        healthBar.fillAmount = health / maxHealth;
    }
     
    public void PlayerTakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / maxHealth;
        if (canPlayAnim)
        {
            playerAnimator.SetTrigger("IsDamage");
            StartCoroutine(AntiSpamAnimation());
        }
        
        if (health <= 0)
        {
            EndGameManager.endGameManager.isGameOver = true;
            EndGameManager.endGameManager.StartResolveSequence();
            Instantiate(explosionVFX,transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    
    private IEnumerator AntiSpamAnimation()
    {
        canPlayAnim = false;
        yield return new WaitForSeconds(0.15f);
        canPlayAnim = true;
    }
}
