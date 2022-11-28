using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missle : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform target;

    //�ڵ����������ٶȣ��д�С�з���
    Vector3 speed = new Vector3(0, 0, 10);

    //�洢ת��ǰ�ڵ��ı��������ٶ�
    Vector3 lastSpeed;

    //��ת���ٶȣ���λ ��/��
    int rotateSpeed = 90;

    //Ŀ�굽�������ߵ����������ճ���
    Vector3 finalForward;

    //�Լ���forward�����mFinalForward֮��ļн�
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

    //����λ��
    void UpdatePosition()
    {
        transform.position = transform.position + speed * Time.deltaTime;
    }

    //��ת��ʹ�䳯��Ŀ��㣬Ҫ�ı��ٶȵķ���
    void UpdateRotation()
    {
        //�Ƚ��ٶ�תΪ�������꣬��ת֮���ٱ�Ϊ��������
        lastSpeed = transform.InverseTransformDirection(speed);

        ChangeForward(rotateSpeed * Time.deltaTime);

        speed = transform.TransformDirection(lastSpeed);
    }

    void ChangeForward(float speed)
    {
        //���Ŀ��㵽����ĳ���
        finalForward = (target.position - transform.position).normalized;
        if (finalForward != transform.forward)
        {
            angleOffset = Vector3.Angle(transform.forward, finalForward);
            if (angleOffset > rotateSpeed)
            {
                angleOffset = rotateSpeed;
            }
            //������forward��������ת�����ճ���
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
