using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //  ��������� ���������
    [SerializeField] float movementSpeed = 10;
    [SerializeField] float _shootRate = 0.5f;

    //  �������������� ����������
    Rigidbody _rigidbody;

    [SerializeField] Camera _camera;

    [SerializeField] GameObject _targetCursor;

    [SerializeField] GameObject _bullet;

    [SerializeField] Transform _bulletStartPoint;

    public LayerMask layer;
    private float _coolDown = 0;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //  ����������� ���������
        Vector3 moveDirection = new Vector3(0,0,0);
        if (Input.GetKey(KeyCode.W))
            moveDirection.z += movementSpeed;
        if (Input.GetKey(KeyCode.S))
            moveDirection.z -= movementSpeed;
        if (Input.GetKey(KeyCode.D))
            moveDirection.x += movementSpeed;
        if (Input.GetKey(KeyCode.A))
            moveDirection.x -= movementSpeed;

        _rigidbody.velocity = moveDirection;
        

        //  ������
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit agentTarget, 1000f, layer))
        {
            _targetCursor.transform.position = agentTarget.point;
        }

        //  ��������
        transform.eulerAngles = new Vector3(0, GetRotationFromVector(transform.position - _targetCursor.transform.position), 0);

        //  ��������
        if (Input.GetMouseButton(0))
        {
            Shoot(_targetCursor.transform.position);
        }
        _coolDown -= Time.deltaTime;
    }


    float GetRotationFromVector(Vector3 vectorsDifference)  //  ��������� ���� �������� �� ������� ������� ����� �������
    {
        float startAngle = Mathf.Atan(vectorsDifference.x / vectorsDifference.z) * 180 / Mathf.PI;
        float angle = startAngle;
        if (vectorsDifference.z > 0)
            angle += 180;


        return angle;
    }

    void Shoot(Vector3 target)
    {
        if (_coolDown <= 0)
        {
            GameObject bullet = Instantiate(_bullet, _bulletStartPoint.position, transform.rotation);
            bullet.GetComponent<Bullet>().bulletDirection = target - transform.position;
            _coolDown = _shootRate;
        }
    }
}
