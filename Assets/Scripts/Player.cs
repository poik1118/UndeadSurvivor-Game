using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2          inputVector;
    public float            speed;

    Rigidbody2D             rigid;
    SpriteRenderer          spriteRend;
    Animator                anim;


    void  Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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
        anim.SetFloat("Speed", inputVector.magnitude);

        if(inputVector.x != 0){
            spriteRend.flipX = inputVector.x < 0;
        }
    }
}
