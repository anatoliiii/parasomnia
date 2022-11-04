using UnityEngine;
// скрипт подъепо по лестнице. Вешается на саму лестницу
public class Chair : MonoBehaviour
{
    public float gravS;


    private void OnTriggerEnter2D(Collider2D collision)// при входе в лестницу отключается гравитация и включается передвижение по вертикали
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Character>().OnChair = true;//включаем передвижение по вертикале
            if (gravS == 0)
            {
                gravS = collision.GetComponent<Rigidbody2D>().gravityScale;
            }
            collision.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)// возвращаем гравитацию
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Character>().OnChair = false;
            collision.GetComponent<Rigidbody2D>().gravityScale = gravS;
        }
    }

    private void Update()
    {

    }
}
