using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missle : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform target;

    //炮弹本地坐标速度，有大小有方向。
    Vector3 speed = new Vector3(0, 0, 10);

    //存储转向前炮弹的本地坐标速度
    Vector3 lastSpeed;

    //旋转的速度，单位 度/秒
    int rotateSpeed = 90;

    //目标到自身连线的向量，最终朝向
    Vector3 finalForward;

    //自己的forward朝向和mFinalForward之间的夹角
    float angleOffset;

    private GameObject player;

    RaycastHit hit;

    void Start()
    {

        speed = transform.TransformDirection(speed);
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform;
        CheckHint();
        UpdateRotation();
        UpdatePosition();
    }

    void CheckHint()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.transform == target && hit.distance < 1)
            {
                this.player.GetComponent<player_health>().be_hit(10f);
                Destroy(gameObject);
            }
        }
    }

    //更新位置
    void UpdatePosition()
    {
        transform.position = transform.position + speed * Time.deltaTime;
    }

    //旋转，使其朝向目标点，要改变速度的方向
    void UpdateRotation()
    {
        //先将速度转为本地坐标，旋转之后再变为世界坐标
        lastSpeed = transform.InverseTransformDirection(speed);

        ChangeForward(rotateSpeed * Time.deltaTime);

        speed = transform.TransformDirection(lastSpeed);
    }

    void ChangeForward(float speed)
    {
        //获得目标点到自身的朝向
        finalForward = (target.position - transform.position).normalized;
        if (finalForward != transform.forward)
        {
            angleOffset = Vector3.Angle(transform.forward, finalForward);
            if (angleOffset > rotateSpeed)
            {
                angleOffset = rotateSpeed;
            }
            //将自身forward朝向慢慢转向最终朝向
            transform.forward = Vector3.Lerp(transform.forward, finalForward, speed / angleOffset);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    public void collide()
    {
        Destroy(this.gameObject);
    }

}
