using UnityEngine;
using UnityEngine.UI;
public class KeyUp : MonoBehaviour
{

    //при приближении подсказка. при нажатии поднять и отобразить в HUD
    [Header("Вспомогательная панель")]
    [SerializeField]
    private GameObject HelpPanel;
    public Text HelpPanelText;
    public string HelpPanelInText;
    private bool player = false;
    private GameObject Player;
    public Text questText;



    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    public void Key()
    {
        if (player)
        {
            
            questText.text = "";
            HelpPanel.active = false;
            Destroy(gameObject);
            GameObject character = GameObject.FindGameObjectWithTag("Player");
            character.GetComponent<Character>().PlayAction("ItemUp");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = true;
            HelpPanelText.text = HelpPanelInText;

            questText.text = HelpPanelInText;
            HelpPanel.active = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HelpPanel.active = false;
            player = false;
        }
    }
}

