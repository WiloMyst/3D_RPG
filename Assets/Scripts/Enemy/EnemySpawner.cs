using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 敌人生成器
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float spawnTime;
    private float spawnTimer; //计时器

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer > spawnTime)
        {
            spawnTimer = 0;
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        GameObject.Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
