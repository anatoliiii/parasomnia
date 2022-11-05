using System;
using UnityEngine;

public class FieldOfAnnihilation : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }
}
