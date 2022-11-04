using UnityEngine;

public class KustikInvis : MonoBehaviour
{

    private SpriteRenderer _renderKust;
    private bool _canHide = false;
    private bool _hiding = false;
    BoxCollider2D _boxCollider2D;
    private Color _color;
    public float Speed = 1f; //Задает скорость изменения цвета в единицах в секунду. 
    void Start()
    {
        _renderKust = GetComponent<SpriteRenderer>();
        _color = _renderKust.color;
    }

    void Update()
    {


        if (_canHide)
        {
            _color.a -= Speed * Time.deltaTime;
            _color.a = Mathf.Clamp(_color.a, 0.5f, 1);
            _renderKust.color = _color;
            _hiding = true;
        }
        else
        {
            _color.a += Speed * Time.deltaTime;
            _color.a = Mathf.Clamp(_color.a, 0.5f, 1);
            _renderKust.color = _color;
            _hiding = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            _canHide = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            _canHide = false;

    }
}
