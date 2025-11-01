using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// 可交互物体
public class InteractableObject : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    private bool haveInteracted = false;

    // 点击物体后的行为
    public void OnClick(NavMeshAgent playerAgent)
    {
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 2; //避免与物体重合
        playerAgent.SetDestination(transform.position);
        haveInteracted = false;
        //Interact();
    }

    private void Update()
    {
        if(haveInteracted == false && playerAgent != null && playerAgent.pathPending == false) //pathPending==false表示路径已计算完毕
        {
            if(playerAgent.remainingDistance <= 2) //走到面前时才进行交互
            {
                Interact();
                haveInteracted = true;
            }
        }
    }

    // 与物体交互的实现
    protected virtual void Interact()
    {
        print("Interacting with Interactable Object.");
    }
}
