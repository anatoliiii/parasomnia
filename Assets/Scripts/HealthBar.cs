using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField]
    [Range(0f,1f)] private float fill;

    private void Start()
    {
        fill = 1f;
    }

    private void Update()
    {
        healthBar.fillAmount = fill;
        if (healthBar.fillAmount == 0) Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        damage /= 100;
        fill -= damage;
    }

    public void TakeHolyWater(float water)
    {
        fill += water;
        if (fill > 1f) fill = 1f;
    }
}
