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
    private void Start()
    {
        //Вызывается автоматически при старте сцены
       
        fadeImage.gameObject.SetActive(true); //Включаем картинку
        fadeImage.color = new Color(fadeOutColor.r, fadeOutColor.g, fadeOutColor.b, 1f); // Ставим стартовый цвет
        fadeOut = true; //Запускаем процесс
    }

    public void StartGame()
    {
        //Вызывается из UI
        if (_player || SceneManager.GetActiveScene().name == "StartMenu")
        {
            fadeImage.gameObject.SetActive(true);
            fadeImage.color = new Color(fadeInColor.r, fadeInColor.g, fadeInColor.b, 0);
            fadeIn = true;
        }
    }

    private void StartScene()
    {
        //Метод запускающий сцену, вызывается в апдейте, когда прозрачность картинки станет достаточно низкой, т.е. экран затемнится
  


        SceneManager.LoadScene(_nameScene);
    }

    private void Update()
    {
        if (fadeIn)
        {
            alphaColor = Mathf.Lerp(fadeImage.color.a, 1, Time.deltaTime * 20f);
            fadeImage.color = new Color(fadeInColor.r, fadeInColor.g, fadeInColor.b, alphaColor);
        }

        if (fadeOut)
        {
            alphaColor = Mathf.Lerp(fadeImage.color.a, 0, Time.deltaTime * 20f);
            fadeImage.color = new Color(fadeOutColor.r, fadeOutColor.g, fadeOutColor.b, alphaColor);
        }

        if (alphaColor > 0.95 && fadeIn)
        {
            fadeIn = false;
            StartScene(); // Вызываем метод со стартом нужной сцены.
        }

        if (alphaColor < 0.05 && fadeOut)
        {
            fadeOut = false;
            fadeImage.gameObject
                .SetActive(false); // Отключаем картинку, чтобы не было прозрачной картинки на весь экран во время игры, иначе может негативно сказаться на производительности
        }
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