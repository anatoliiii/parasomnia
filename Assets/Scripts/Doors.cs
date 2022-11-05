using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Doors : MonoBehaviour
{

    bool fadeIn; //Не трогаем
    bool fadeOut; //Не трогаем
    float alphaColor; //Не трогаем

    public Image fadeImage;
    public Color fadeInColor;
    public Color fadeOutColor;

   
    public string _nameScene;
    private bool _player = false;
    public void StartGame()
    {
    }

    public void StartScene()
    {
        //Метод запускающий сцену, вызывается в апдейте, когда прозрачность картинки станет достаточно низкой, т.е. экран затемнится
  


        SceneManager.LoadScene(_nameScene);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player = false;
        }
    }

}