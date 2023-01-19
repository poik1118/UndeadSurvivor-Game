using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[]         prefabs;    // 프리펩 보관

    List<GameObject>[]          pools;      // 풀 저장 리스트

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for ( int index = 0; index < pools.Length; index++ ){
            pools[index] = new List<GameObject>();
        }

    }

    public GameObject GetPool(int index){
        GameObject select = null;

        // 선택한 풀의 비활성화된 게임오브젝트 접근
        foreach( GameObject item in pools[index] ){
            if( !item.activeSelf ){     //  발견하면 select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if( !select ){  // 선택된 오브젝트가 없으면 
            select = Instantiate(prefabs[index], transform);    //  새롭게 생성 후 select 변수에 등록
            pools[index].Add(select);
        }

        return select;
    }
}
