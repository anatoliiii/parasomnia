using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField, Range(0f,1f)] private float healthBoss;
    private void Start()
    {
        StartHealthOnBoss();
    }

    private void Update()
    {
        if (healthBoss <= 0f) BossToDie();
        healthBar.fillAmount = healthBoss;
    }

    public void TakeDamage(float damage)
    {
        healthBoss -= damage;
    }

    private void StartHealthOnBoss()
    {
        healthBar = GameObject.Find("BossHealthBar").GetComponent<Image>();
        healthBar.enabled = true;
        healthBoss = 1f;
    }

    private void BossToDie()
    {
        Destroy(gameObject);
    }
}
