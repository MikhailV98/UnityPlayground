using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceletonController : MonoBehaviour
{
    [SerializeField] float _damage;
    [SerializeField] float _attackRange;
    [SerializeField] float _moveSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //  Attack player
        }
    }
}
