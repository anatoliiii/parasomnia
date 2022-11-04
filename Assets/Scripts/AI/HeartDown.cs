using UnityEngine;

public class HeartDown : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //collision.GetComponent<InfoBar>().Heart--;
        }
    }
}
