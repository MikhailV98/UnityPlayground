using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //  Стартовые параметры
    [SerializeField]
    float movementSpeed = 10;

    //  Дополнительные переменные
    private Rigidbody rigidbody;

    [SerializeField]
    public Camera camera;

    [SerializeField]
    public GameObject targetCursor;

    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //  Перемещение персонажа
        Vector3 moveDirection = new Vector3(0,0,0);
        if (Input.GetKey(KeyCode.W))
            moveDirection.z += movementSpeed;
        if (Input.GetKey(KeyCode.S))
            moveDirection.z -= movementSpeed;
        if (Input.GetKey(KeyCode.D))
            moveDirection.x += movementSpeed;
        if (Input.GetKey(KeyCode.A))
            moveDirection.x -= movementSpeed;

        rigidbody.velocity = moveDirection;

        //  Курсор
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit agentTarget, 1000f, layer))
        {
            targetCursor.transform.position = agentTarget.point;
        }
    }
}
