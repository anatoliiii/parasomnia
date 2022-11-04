using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public AudioSource ButtonSound;
    public void Exit()
    {
        Debug.Log("Вышло");
        Application.Quit();
    }
    public void Sound()
    {
        ButtonSound.Play();
    }

}
