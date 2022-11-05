using System;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float _smoothTime = 0.2f;
    private Vector3 _velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 playerPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref _velocity, _smoothTime);
        }
    }
}
