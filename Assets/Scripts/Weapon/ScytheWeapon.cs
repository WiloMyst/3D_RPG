using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 镰刀
public class ScytheWeapon : Weapon
{
    public const string ANIM_PARM_ISATTACK = "isAttack";

    private Animator anim;

    public int atkValue = 50;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public override void Attack()
    {
        anim.SetTrigger(ANIM_PARM_ISATTACK);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tag.ENEMY)
        {
            other.GetComponent<Enemy>().TakeDamage(atkValue);
        }
    }
}
