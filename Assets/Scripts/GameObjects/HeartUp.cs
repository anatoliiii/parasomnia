using UnityEngine;
//просто добавляем +1 хп и удаляем объект
public class HeartUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.tag == "Player")
        {
            collision.GetComponent<InfoBar>().Heart++;
            Destroy(gameObject);
            collision.GetComponent<Character>().PlayAction("ItemUp");
        }*/
    }

}
