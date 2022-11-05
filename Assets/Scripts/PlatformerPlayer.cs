using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    public float speed = 15f;
    private Rigidbody2D _body;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && speed != 0) Shooting();
    }
    private void FixedUpdate()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;
    }

    private void Shooting()
    {
        gameObject.GetComponent<ChaosBar>().TakeChaos();
    }
}
