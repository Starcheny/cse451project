using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raser : MonoBehaviour
{
    // Start is called before the first frame update

    //the position of fire point
    [SerializeField] private float dist;
    public Transform firePoint;
    private LineRenderer _lineRenderer;
    private GameObject GameObjectHit;
    [SerializeField] private Gradient redColor, greenColor;
    public float attackDamage = 1;
    [SerializeField] private float maxDist;
    private float time = 0f;
    private GameObject game_player;
    void Start()
    {
        dist = 0.5f;
        _lineRenderer = GetComponentInChildren<LineRenderer>();
        //find the player
        this.game_player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        time += 1*Time.deltaTime;
        if (time >=1f)
        {
            Detect();
            dist += 2f;
            time = 0;
            if (dist > maxDist)
            {
                dist = 0f;
            }
        }
    }

    private void Detect()
    {
        RaycastHit hitInfo;

        _lineRenderer.SetPosition(0, firePoint.position);
        if (Physics.Raycast(firePoint.position, transform.right, out hitInfo,dist))
        {
            Debug.DrawLine(firePoint.position, hitInfo.point, Color.green);
            //Debug.DrawRay(firePoint.position, Vector3.right * hitInfo.distance, Color.yellow);
            
            if (hitInfo.collider.tag == "ground")
            {
                Debug.DrawLine(firePoint.position, hitInfo.point, Color.green);

                _lineRenderer.SetPosition(1, hitInfo.point);
                _lineRenderer.colorGradient = greenColor;
            }
            else if (hitInfo.collider.CompareTag("Player"))
            {
                Debug.DrawLine(firePoint.position, hitInfo.point, Color.red);
                Debug.Log("Did Hit");
                _lineRenderer.SetPosition(1, hitInfo.point);
                _lineRenderer.colorGradient = redColor;
                // cur off health;

                this.game_player.GetComponent<player_health>().be_hit(attackDamage);
            }

            else if (hitInfo.collider.CompareTag("Mobs"))
            {
                Debug.DrawLine(firePoint.position, hitInfo.point, Color.red);
                Debug.Log("Did Hit");
                _lineRenderer.SetPosition(1, hitInfo.point);
                _lineRenderer.colorGradient = redColor;
                // cur off health;

                //this.game_player.GetComponent<player_health>().be_hit(attackDamage);
            }
        }
        else
        {
            //Debug.DrawLine(firePoint.position, new Vector3(firePoint.position.x+dist, firePoint.position.y, firePoint.position.z), Color.red);
            //Debug.Log("Did not Hit");
            float temp = dist;
            _lineRenderer.SetPosition(1,
               new Vector3(firePoint.position.x + dist, firePoint.position.y, firePoint.position.z));
            _lineRenderer.colorGradient = greenColor;
        }

        
    }
}
