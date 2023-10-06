using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float bulletRange = 20f;

    public Vector3 bulletDirection;
    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        if ((transform.position - _startPosition).magnitude < bulletRange)
        {
            transform.position += bulletDirection.normalized * bulletSpeed * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Hit enemy
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
