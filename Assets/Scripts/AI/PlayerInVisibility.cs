using UnityEngine;

public class PlayerInVisibility : MonoBehaviour
{

    private SpriteRenderer _render;
    public bool _canHide = false;
    private bool _hiding = false;
    void Start()
    {
        _render = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (_canHide)
        {

            Physics2D.IgnoreLayerCollision(1, 9, true);
            _render.sortingOrder = 0;
            _hiding = true;
        }
        else
        {
            Physics2D.IgnoreLayerCollision(1, 9, false);

            _render.sortingOrder = 5;
            _hiding = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "kust")
        {
            _canHide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "kust")
        {
            _canHide = false;
        }
    }
}
