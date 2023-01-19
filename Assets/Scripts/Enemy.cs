using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float                speed;
    public Rigidbody2D          target;

    bool                    isLive = true;

    Rigidbody2D                 rigid;
    SpriteRenderer              spriteRen;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRen = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();   
    }

    void FixedUpdate()
    {
        if( !isLive ) return;

        // target( Player ) 추적 로직
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition( rigid.position + nextVec );
        rigid.velocity = Vector2.zero;

    }

    void LateUpdate()
    {
        if( !isLive ) return;

        // 바라보는 방향 조정
        spriteRen.flipX = target.position.x < rigid.position.x;
    }

}
