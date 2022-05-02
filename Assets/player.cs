using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    [SerializeField] float fltmoveSpeed = 5f;
    Vector2 rawInput;

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 delta = rawInput * fltmoveSpeed * Time.deltaTime;
        transform.position += delta;
    }

    void OnMove(InputValue value)
    {
       rawInput = value.Get<Vector2>();
       Debug.Log(rawInput);
    }
}
