using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameTaskState
{
    Waiting,
    Executing,
    Completed,
    End
}

// 游戏任务
[CreateAssetMenu()]
public class GameTaskSO : ScriptableObject
{
    public GameTaskState state;

    public List<string> diague;

    public ItemSO startReward;
    public ItemSO endReward;

    public int enemyCountNeed = 10;

    public int currentEnemyCount = 0;

    public void Start()
    {
        currentEnemyCount = 0;
        state = GameTaskState.Executing;
        EventCenter.OnEnemyDied += OnEnemyDied;
    }
    public void End()
    {
        state = GameTaskState.End;
        EventCenter.OnEnemyDied -= OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        if (state == GameTaskState.Completed) return;
        if (++currentEnemyCount >= enemyCountNeed)
        {
            state = GameTaskState.Completed;
            MessageUI.Instance.Show("任务完成，请前去领赏！");
        }
    }
}
