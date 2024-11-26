using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 标枪
public class JavelinWeapon : Weapon
{
    public float bulletSpeed = 0;
    public GameObject bulletPrefab;
    private GameObject bulletGO;

    private void Start()
    {
        SpawnBullet();
    }

    public override void Attack()
    {
        if(bulletGO == null) { return; }

        bulletGO.transform.parent = null; // 解除关联父物体位置
        bulletGO.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        bulletGO.GetComponent<Collider>().enabled = true;
        bulletGO.GetComponent<JavelinBullet>().SetThrown(true); // 掷出
        Destroy(bulletGO, 10.0f);
        bulletGO = null;

        Invoke("SpawnBullet", 0.5f); // 生成时间间隔
    }

    private void SpawnBullet()
    {
        bulletGO = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation);
        bulletGO.transform.parent = transform; // 关联父物体位置
        bulletGO.GetComponent<Collider>().enabled = false;
        bulletGO.GetComponent<JavelinBullet>().SetThrown(false);
        // 是否为可交互(拾起)状态
        if(tag == Tag.INTERACTABLE)
        {
            Destroy(bulletGO.GetComponent<JavelinBullet>());

            bulletGO.tag = Tag.INTERACTABLE;
            PickableObject po = bulletGO.AddComponent<PickableObject>();
            po.itemSO = GetComponent<PickableObject>().itemSO;

            Rigidbody rgd = bulletGO.GetComponent<Rigidbody>();
            rgd.isKinematic = false;
            rgd.useGravity = true;
            rgd.constraints = RigidbodyConstraints.None; // 取消冻结

            bulletGO.GetComponent<Collider>().enabled = true;
            bulletGO.transform.parent = null;
            Destroy(this.gameObject);
        }
    }
}
