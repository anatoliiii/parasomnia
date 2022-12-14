using UnityEngine;

public class KeyBoardDoor : MonoBehaviour
{
    public Doors Doors;
    private GameObject Player;
    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Doors = Doors == null ? GetComponent<Doors>() : Doors;
    }

    private void Update()
    {
        if (Doors != null)
        {
            if (Input.GetKey(KeyCode.F))
            {
                    Doors.StartScene();
            }
        }

    }
}
