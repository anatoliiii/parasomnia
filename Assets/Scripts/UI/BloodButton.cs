using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodButton : MonoBehaviour
{
    public Image blood;
    public Sprite bloodReplace;
    public void OnButReplace()
    {
        blood = GetComponent<Image>();
        blood.sprite = bloodReplace; 
        blood.canvas.transform.SetParent(transform, false);
    }
}
