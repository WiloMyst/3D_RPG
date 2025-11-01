using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 标枪本体
public class JavelinBullet : MonoBehaviour
{
    public int atkValue = 30;
    private Rigidbody rgd;
    private Collider col;
    private bool hasThrown = false;

    private void Start()
    {
        rgd = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    // 掷出后发生碰撞的事件
    private void OnCollisionEnter(Collision collision)
    {
        if(hasThrown == false || collision.collider.tag == Tag.PLAYER) { return; }

        rgd.isKinematic = true;
        col.enabled = false;

        transform.parent = collision.gameObject.transform; //插在敌人身上

        Destroy(this.gameObject, 1.0f);

        if (collision.gameObject.tag == Tag.ENEMY)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(atkValue);
        }
    }

    public void SetThrown(bool thrown)
    {
        hasThrown = thrown;
    }
}
