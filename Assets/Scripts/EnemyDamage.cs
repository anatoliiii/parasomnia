using System;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private ChaosBar chaosBar;
    [SerializeField] private HealthBar playerHealth;
    private float enemyDamage;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            enemyDamage = 5f;
            chaosBar = col.GetComponent<ChaosBar>();
            enemyDamage *= chaosBar.chaosControl;
            playerHealth = col.GetComponent<HealthBar>();
            playerHealth.TakeDamage(enemyDamage);
        }
    }
}
