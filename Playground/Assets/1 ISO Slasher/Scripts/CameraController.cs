using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /* https://www.youtube.com/watch?v=DoDZuFNh4tw */

    public Transform target;

    public float speed = 4f;
    private Vector3 _position;

    void Start()
    {
        _position = target.InverseTransformPoint(transform.position);
    }

    void Update()
    {
        var currentPosition = target.TransformPoint(_position);
        transform.position = Vector3.Lerp(transform.position, currentPosition, speed * Time.deltaTime);
    }
}
