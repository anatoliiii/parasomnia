using UnityEngine;
using UnityEngine.UI;
//скрипт вспомогательной панели
public class HelpPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject HelpPanelUI;
    public string HelpPanelInText;
    public Text HelpPanelText;
    private bool player;

    private void OnTriggerEnter2D(Collider2D collision) // при входе открывается вспомогательное окно
    {
        if (collision.tag == "Player")
        {
            player = true;
            HelpPanelText.text = HelpPanelInText;
            HelpPanelUI.active = true;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && player) // при нажатии F открывается записка, уходит вспомогательное окно
        {

            HelpPanelUI.active = false;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)// при выходе из объекта вспомогательное окно скрывается
    {
        if (collision.tag == "Player")
        {
            HelpPanelUI.active = false;
            player = false;
        }
    }
}
