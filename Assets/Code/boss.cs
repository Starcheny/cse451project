using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
    // Start is called before the first frame update

    //health
    public float health;

    //animator
    private Animator animator;

    private GameObject game_player;
    public float check_range;

    public Transform patrolRoute;

    private Transform target;

    int patrolIndex;

    public NavMeshAgent nav;


    public Transform povOrigin;
    public Transform projectileOrigin;
    public GameObject projectfilePrefab;
    public float time;
    private bool stop;

    private float max_health;

    float hp_percent;
    public Image hp_image;
    public Image hp_image2;
    void Start()
    {
        //find animator
        this.animator = this.GetComponent<Animator>();

        //find the player
        this.game_player = GameObject.FindGameObjectWithTag("Player");


        this.health = 2000;


        this.max_health = 2000f;
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0)
        {
            SceneManager.LoadScene(2);
        }



        if (patrolRoute)
        {
            target = patrolRoute.GetChild(patrolIndex);

            float distance = Vector3.Distance(transform.position, target.position);


            if (distance <= 2f)
            {
                patrolIndex++;
                if (patrolIndex >= patrolRoute.childCount)
                {
                    patrolIndex = 0;
                }
            }

        }

        float Distance = Vector3.Distance(this.transform.position, this.game_player.transform.position);

        if (Distance < check_range)
        {
            
            target = null;
            stop = true;
            this.transform.LookAt(new Vector3(this.game_player.transform.position.x, this.game_player.transform.position.y, this.game_player.transform.position.z));
            this.nav.SetDestination(this.transform.position);
            this.animator.SetBool("shoot", true);
            this.animator.SetBool("run", false);
            shoot();
        }
        else
        {
            stop = false;
            this.animator.SetBool("shoot", false);
        }


        if (target)
        {
            if (stop != true)
            {
                this.animator.SetBool("run", true);
                this.nav.SetDestination(target.position);
            }

        }

        hp_percent = this.health / this.max_health;

        hp_image.fillAmount = hp_percent;

        hp_image.transform.position = new Vector3(Screen.width * 5 / 10, Screen.height * 19 / 20);
        hp_image2.transform.position = new Vector3(Screen.width * 5 / 10, Screen.height * 19 / 20);



        hp_image.rectTransform.sizeDelta = new Vector2(Screen.width * 2 / 25, Screen.height * 1 / 90);
        hp_image2.rectTransform.sizeDelta = new Vector2(Screen.width * 2 / 25, Screen.height * 1 / 90);
    }



    public void be_hit(float harm)
    {
        health -= harm;
        
    }



    void shoot()
    {
        if (time < 1.2f)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
            GameObject projectile = Instantiate(projectfilePrefab, projectileOrigin.position, Quaternion.LookRotation(povOrigin.forward*-1));
            
        }
        
    }
}
