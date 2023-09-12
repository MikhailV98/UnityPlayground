using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    public float cameraSpeed = 20;

    private bool isMoving = false;
    
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        if (isMoving)
        {
            Vector3 direction = playerTransform.position - transform.position;
            transform.position += direction.normalized * cameraSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isMoving = true;

        Debug.Log("exit");
    }

    private void OnTriggerStay(Collider other)
    {
        isMoving = false;
        Debug.Log("enter");
    }
}
