using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // public LineRenderer _line;
    public float _speed = 10f;
    float _direction;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _direction = transform.localScale.x;
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector2(_speed * _direction, _rigidbody.velocity.y);
        transform.localScale = new Vector3(_direction, transform.localScale.y, transform.localScale.z);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall") _direction *= -1;
    }
}
