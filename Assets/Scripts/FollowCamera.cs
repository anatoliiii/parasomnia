using System;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float _smoothTime = 0.2f;
    private Vector3 _velocity = Vector3.zero;
    private Vector3 playerPosition;
    public void InBossZone()
    {
        gameObject.GetComponent<Camera>().orthographicSize = 8f;
    }

    public void BeyondBossZone()
    {
        gameObject.GetComponent<Camera>().orthographicSize = 5f;
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            if (gameObject.GetComponent<Camera>().orthographicSize == 5f)
            {
                playerPosition = new Vector3(player.position.x,player.position.y,transform.position.z);
                SmoothCamera();
            }
            else
            {
                playerPosition = new Vector3(player.position.x,player.position.y+5f,transform.position.z);
                SmoothCamera();
            }
        }
    }

    private void SmoothCamera()
    {
        transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref _velocity, _smoothTime);
    }
}
