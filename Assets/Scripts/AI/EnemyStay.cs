using System.Collections;
using UnityEngine;

public class EnemyStay : MonoBehaviour
{
    private float _direction;

    // Start is called before the first frame update
    void Start()
    {
        _direction = transform.localScale.x;
        StartCoroutine(Directionmn());
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(_direction, transform.localScale.y, transform.localScale.z);

    }
    IEnumerator Directionmn()
    {
        while (true)
        {
            _direction = -_direction;
            yield return new WaitForSeconds(3f);
        }

    }
}
