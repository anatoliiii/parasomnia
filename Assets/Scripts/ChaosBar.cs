using UnityEngine;
using UnityEngine.UI;

public class ChaosBar : MonoBehaviour
{
    [SerializeField] private Image chaosBar;
    [SerializeField]
    [Range(0f,1f)] private float fill;

    public int chaosControl = 1;

    private float partOfChaos = 0.02f;

    private void Start()
    {
        fill = 0f;
    }

    private void Update()
    {
        chaosBar.fillAmount = fill;
    }
    public void TakeChaos()
    {
        fill += partOfChaos;
        if (fill > 0.4f && fill <0.8f) chaosControl = 2;
        if (fill > 0.8f) chaosControl = 3;
    }
    
    public void TakeHolyWater(float water)
    {
        fill -= water;
        if (fill < 0f) fill = 0f;
    }
}
