using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerExplore : MonoBehaviour
{
    public Transform target;
    public float distance = 12.0f;
    private float xSpeed = 250.0f;
    private float ySpeed = 120.0f;
    private float yMinLimit = -45f;
    private float yMaxLimit = 85f;
    private float x = 0.0f;
    private float y = 0.0f;

    //　カメラのキャラクターからの相対値を指定
    [SerializeField]
    private Vector3 basePos = new Vector3(0f, 0f, 2f);
    // 障害物とするレイヤー
    private LayerMask obstacleLayer;

    // Start is called before the first frame update
    void Start()
    {
        var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

    }

    // Update is called once per frame
    void Update()
    {

        if (target != null)
        {
            
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            var rotation = Quaternion.Euler(y, x, 0);
            var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }

        //　通常のカメラ位置を計算
        var cameraPos = target.position + (-target.forward * basePos.z) + (Vector3.up * basePos.y);

        RaycastHit hit;
        //　キャラクターとカメラの間に障害物があったら障害物の位置にカメラを移動させる
        if (Physics.Linecast(target.position, transform.position, out hit, obstacleLayer))
        {
            transform.position = hit.point;
        }
        //　レイを視覚的に確認
        Debug.DrawLine(target.position, transform.position, Color.red, 0f, false);
    }

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }

        if (angle > 360)
        {
            angle -= 360;
        }

        return Mathf.Clamp(angle, min, max);
    }

}
