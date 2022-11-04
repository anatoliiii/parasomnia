using UnityEngine;

public class Gun : MonoBehaviour
{

    public Sprite[] Guns;
    public int ActiveGun;

    public void NewGun()
    {
        Debug.Log(Guns.Length);
        if (ActiveGun < Guns.Length - 1)
        {
            ActiveGun++;
            gameObject.GetComponent<SpriteRenderer>().sprite = Guns[ActiveGun];
        }
        else if (ActiveGun == Guns.Length - 1)
        {
            ActiveGun = 0;
            gameObject.GetComponent<SpriteRenderer>().sprite = Guns[ActiveGun];
        }
    }
}
