using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 控制相机跟随玩家移动
public class CameraController : MonoBehaviour
{
    public float zoomSpeed = 5;

    private Vector3 offset;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        // 计算相机和玩家之间的位置偏移
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 相机移动时保持与玩家的位置偏移
        transform.position = playerTransform.position + offset;

        // 用鼠标滚轮控制相机远近
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.fieldOfView += scroll*zoomSpeed;
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 37, 70); // 限定范围
    }
}
