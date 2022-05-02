using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float fltmoveSpeed = 5f;
    Vector2 rawInput;
    [SerializeField] float fltpaddingLeft;
    [SerializeField] float fltpaddingRight;
    [SerializeField] float fltpaddingTop;
    [SerializeField] float fltpaddingBottom;

    Vector2 minBounds;
    Vector2 maxBounds;

    void Start() 
    {
        InitBounds();
    }

    void Update()
    {
        Move();
    }


    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }
    void Move()
    {
        Vector2 delta = rawInput * fltmoveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + fltpaddingLeft, maxBounds.x - fltpaddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + fltpaddingBottom, maxBounds.y - fltpaddingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
       rawInput = value.Get<Vector2>();
       Debug.Log(rawInput);
    }
}
