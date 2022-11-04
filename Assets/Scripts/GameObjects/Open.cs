using UnityEngine;

public class Open : MonoBehaviour
{
    private GameObject Player;
    private BoxCollider2D _collider2D;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            /*if (collision.GetComponent<InfoBar>().Key)
            {
                collision.GetComponent<InfoBar>().Key = false;
              _collider2D.isTrigger = false;
            }*/

        }
    }
}
