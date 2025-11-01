using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum EnemyState
    {
        NormalState,
        FightingState,
        MovingState,
        RestingState
    }

    private EnemyState state = EnemyState.NormalState;
    private EnemyState childState = EnemyState.RestingState;
    private NavMeshAgent enemyAgent;

    public float restTime = 2f;
    private float restTimer = 0;

    public int HP = 100;

    public int exp = 20;

    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // 设置敌人状态
        if(state == EnemyState.NormalState)
        {
            if(childState == EnemyState.RestingState) // 静止
            {
                restTimer += Time.deltaTime;

                if(restTimer > restTime)
                {
                    Vector3 randomPosition = FindRandomPosition(); // 随机目的地
                    enemyAgent.SetDestination(randomPosition);
                    childState = EnemyState.MovingState;
                }
            }
            else if(childState == EnemyState.MovingState) // 游走
            {
                if(enemyAgent.remainingDistance <= 0)
                {
                    restTimer = 0;
                    childState = EnemyState.RestingState;
                }
            }
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage(30);
        //}
    }

    Vector3 FindRandomPosition()
    {
        Vector3 randomDir = new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f));
        return transform.position + randomDir.normalized * Random.Range(2, 5);
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if(HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // 爆装备
        GetComponent<Collider>().enabled = false;
        int count = 4;
        for (int i = 0; i < count; i++)
        {
            SpawnPickableItem();
        }
        EventCenter.EnemyDied(this);
        Destroy(this.gameObject);
    }

    public void SpawnPickableItem()
    {
        ItemSO item = ItemDBManager.Instance.GetRandomItem();
        GameObject go = GameObject.Instantiate(item.prefab, transform.position, Quaternion.identity);
        go.tag = Tag.INTERACTABLE;
        // 禁用动画，防止生成位置错误
        Animator anim = go.GetComponent<Animator>();
        if (anim != null)
        {
            anim.enabled = false;
        }
        // 添加可拾取组件
        PickableObject po = go.AddComponent<PickableObject>();
        po.itemSO = item;
        Collider collider = go.GetComponent<Collider>();
        if(collider != null)
        {
            collider.enabled = true;
            collider.isTrigger = false;
        }
        Rigidbody rgd = go.GetComponent<Rigidbody>();
        if(rgd != null)
        {
            rgd.isKinematic = false;
            rgd.useGravity = true;
        }
    }
}
