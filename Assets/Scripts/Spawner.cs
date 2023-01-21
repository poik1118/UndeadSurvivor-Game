using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[]          spawnPoint;

    float                       timer;
    int                         level;


    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.FloorToInt(GameManager.instance.gameTime / 10f);

        if( timer > (level == 0 ? 0.5f : 0.2f) ){
            timer = 0;
            Spawn();
        }
    }

    void Spawn(){
        GameObject enemy = GameManager.instance.poolManager.GetPool(level);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }
}
