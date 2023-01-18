using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2      inputVector;

    Rigidbody2D         rigid;


    void  Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + inputVector);
    }
}
