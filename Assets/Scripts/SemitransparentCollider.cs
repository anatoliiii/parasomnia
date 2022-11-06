using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class SemitransparentCollider : MonoBehaviour
{
    public CapsuleCollider2D Collider1;
    private BoxCollider2D Collider;

    private void Start()
    {
        Collider = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider == Collider1)
        {
            Collider.isTrigger = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
            Collider.isTrigger = false;
        
        
    }
}
