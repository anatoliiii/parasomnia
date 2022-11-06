using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject handForAttack;
    
    private ChaosBar _chaosBar;
    private float _bossDamage;
    private void Start()
    {
        _chaosBar = GameObject.FindGameObjectWithTag("Player").GetComponent<ChaosBar>();
    }

    public void AttackPlayer()
    {
        _bossDamage = 15f; //стандартный урон
        _bossDamage *= _chaosBar.chaosControl;
        handForAttack.SetActive(true);
        Collider2D colInfo = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 8f), 1.75f);
        if (colInfo.tag == "Player")
        {
            colInfo.GetComponent<HealthBar>().TakeDamage(_bossDamage);
        }
    }
}
