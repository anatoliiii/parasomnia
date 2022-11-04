using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private int speed;

    void Update()
    {
        Vector3 position = player.transform.position; position.z = -10.0F;
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}
