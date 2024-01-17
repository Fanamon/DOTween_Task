using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float idleSpeed = 0;
        int leftMouseButton = 0;

        bool isKeyPressed = false;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * (-1), 0, 0);

            isKeyPressed = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);

            isKeyPressed = true;
        }

        if (Input.GetMouseButtonDown(leftMouseButton))
        {
            _animator.SetTrigger("Attack");
        }

        if (isKeyPressed)
        {
            _animator.SetFloat("Speed", _speed);
        }
        else
        {
            _animator.SetFloat("Speed", idleSpeed);
        }
    }
}
