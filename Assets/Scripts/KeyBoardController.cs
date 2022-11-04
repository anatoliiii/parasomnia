using UnityEngine;

public class KeyBoardController : MonoBehaviour
{
    public Character Character;


    private void Start()
    {
        Character = Character == null ? GetComponent<Character>() : Character;
    }

    private void Update()
    {

        if (Character != null)
        {
            if (Input.GetButton("Horizontal"))
            {
                Character.Run(Input.GetAxis("Horizontal"));
            }
            if (Input.GetButton("Vertical"))
            {
                Character.Chairs(Input.GetAxis("Vertical"));
            }
            if (Input.GetKey(KeyCode.Space))
            {
                Character.Jump();
            }
        }
    }
}