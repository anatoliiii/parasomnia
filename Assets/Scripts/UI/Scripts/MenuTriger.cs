using UnityEngine;
using UnityEngine.UI;

public class MenuTriger : MonoBehaviour
{
    public Sprite[] BGSprite;
    public Sprite[] TriggerSprite;
    public Image Trigger;
    public Image BG;
    [SerializeField]
    private bool OnTrigger;

    public void NewTrigger()
    {
        OnTrigger = !OnTrigger;
        if (OnTrigger)
        {
            Trigger.sprite = TriggerSprite[0];
            BG.sprite = BGSprite[0];
        }
        else
        {
            Trigger.sprite = TriggerSprite[1];
            BG.sprite = BGSprite[1];
        }
    }
}
