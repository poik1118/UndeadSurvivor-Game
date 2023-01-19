using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D                  colli;


    void Awake()
    {
        colli = GetComponent<Collider2D>();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if ( !collision.CompareTag( "Area" ) ) return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;

        Vector3 playerDir = GameManager.instance.player.inputVector;
        
        float dirX = playerPos.x - myPos.x;
        float dirY = playerPos.y - myPos.y;

        float diffX = Mathf.Abs(dirX);
        float diffY = Mathf.Abs(dirY);

        dirX = dirX > 0 ? 1 : -1;
        dirY = dirY > 0 ? 1 : -1;

        switch ( transform.tag ){
            case "Ground":
                if ( diffX > diffY ){
                    transform.Translate( Vector3.right * dirX * 40 );
                }
                else if ( diffX < diffY ){
                    transform.Translate( Vector3.up * dirY * 40 );
                }
                break;

            case "Enemy":
                if ( colli.enabled ){
                    transform.Translate( playerDir * 20 + new Vector3( Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f ) );
                }
                break;

        }

    }

}
