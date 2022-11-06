using System.Collections;
using UnityEngine;

public class BossTransform : MonoBehaviour
{

    private BossAttack _bossAttack;
    
    private GameObject _playerTarget;
    private Vector2 _target;
    private float _bossSpeed = 12f;
    private bool _isAttacked;

    private int attackCheck;

    private void Start()
    {
        _bossAttack = GetComponent<BossAttack>();
        _playerTarget = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (transform.position.x == _playerTarget.transform.position.x && attackCheck <1)
        {
            attackCheck++;
            _isAttacked = !_isAttacked;
            StartCoroutine(WaitAttackTime());
        }
        if (!_isAttacked)
        {
            attackCheck = 0;
            _target = new Vector2(_playerTarget.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position,_target,_bossSpeed*Time.deltaTime);
        }
    }

    private IEnumerator WaitAttackTime()
    {
        yield return new WaitForSeconds(1f);
        _bossAttack.AttackPlayer();
        yield return new WaitForSeconds(1f);
        _bossAttack.handForAttack.SetActive(false);
        _isAttacked = !_isAttacked;
    }
}
