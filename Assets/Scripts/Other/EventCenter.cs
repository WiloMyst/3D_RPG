using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 事件中心
public class EventCenter : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyDied;

    public static void EnemyDied(Enemy enemy)
    {
        OnEnemyDied?.Invoke(enemy); //先判断OnEnemyDied是否为空，再调用
    }
}
