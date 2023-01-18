using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2      inputVector;
    public float        speed;

    Rigidbody2D         rigid;
    SpriteRenderer      spriteRenderer;


    void  Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update(){
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 nextVector = ( inputVector * speed * Time.fixedDeltaTime );
        rigid.MovePosition( rigid.position + nextVector );
    }

    void LateUpdate()
    {
        if(inputVector.x != 0){
            spriteRenderer.flipX = inputVector.x < 0;
        }
    }
}
