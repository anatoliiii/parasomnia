using System;
using UnityEngine;

public class HolyWater : MonoBehaviour
{
    private static float _healthRegen = 0.15f;
    private static float _chaosRegen = 0.1f;

    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private ChaosBar _chaosBar;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            _healthBar = col.GetComponent<HealthBar>();
            _chaosBar = col.GetComponent<ChaosBar>();
            
            _healthBar.TakeHolyWater(_healthRegen);
            _chaosBar.TakeHolyWater(_chaosRegen);
        }
        Destroy(gameObject);
    }
}
