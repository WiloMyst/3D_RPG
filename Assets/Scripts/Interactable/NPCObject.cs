using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NPC角色
public class NPCObject : InteractableObject
{
    public string npcName;
    public List<string> contentList;

    protected override void Interact()
    {
        DialogueUI.Instance.Show(npcName, contentList);
    }
}
