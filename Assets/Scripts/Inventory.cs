using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private GameObject parentForWeapon;

    private GameObject _weaponInhand;
    private Vector2 _handPosition;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0:
                    SpawnWeaponInHand(rand);
                    break;
                case 1:
                    SpawnWeaponInHand(rand);
                    break;
                case 2:
                    SpawnWeaponInHand(rand);
                    break;
            }
        }
    }

    private void SpawnWeaponInHand(int indexGun)
    {
        if (_weaponInhand != null)
        {
            WeaponThrow(_weaponInhand);
        }
        _handPosition = transform.position;
        _weaponInhand = Instantiate(weapons[indexGun], _handPosition, Quaternion.identity);
        _weaponInhand.transform.SetParent(parentForWeapon.transform);
    }

    private void WeaponThrow(GameObject weaponInHand)
    {
        weaponInHand.AddComponent<Rigidbody2D>();
        weaponInHand.GetComponent<Rigidbody2D>().mass = 1f;
        weaponInHand.AddComponent<BoxCollider2D>();
        Vector2 throwDirection = _handPosition;
        throwDirection.x += 1f;
        throwDirection.x *= parentForWeapon.transform.parent.transform.localScale.x;
        weaponInHand.GetComponent<Rigidbody2D>().velocity = throwDirection;
        weaponInHand.transform.parent = null;
    }
}
