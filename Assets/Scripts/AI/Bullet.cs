using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _speed;
    private Transform _player;
    private Vector2 _target;
    private int _damage = 1;
    void Update()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _target = new Vector2(_player.position.x, _player.position.y);
        StartCoroutine(Shot());
    }

    IEnumerator Shot()
    {
        transform.Translate(new Vector2(_player.position.x, transform.position.y) * _speed);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Попадание");
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }


    }
}
