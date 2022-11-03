using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class bone : MonoBehaviour
{


    //health
    private float health;

    //animator
    private Animator animator;

    //audio source
    private AudioSource audio_source;

    [Header(" Automatic path finding controller")]
    public NavMeshAgent nav;

    private Text armor;


    //is it around the player
    private bool is_around_the_player = false;


    // the game object of player
    private GameObject game_player;

    //the crystal
    private GameObject home;

    [Header("Target point range")]
    public float target_range;

    public float check_range;
    private int enemy_statu;

    // Start is called before the first frame update
    void Start()
    {
        //find animator
        this.animator = this.GetComponent<Animator>();

        //find audio source
        this.audio_source = this.GetComponent<AudioSource>();

        //find the player
        this.game_player = GameObject.FindGameObjectWithTag("Player");

        this.home = GameObject.FindGameObjectsWithTag("Home")[0];


        this.health = 100;

        this.enemy_statu = 0;

        this.change_to_running();

        //this.nav.SetDestination(this.game_player.transform.position);

        //this.armor = GameObject.FindGameObjectWithTag("armor").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        if (this.health <= 0)
        {
            this.nav.isStopped = true;
            this.game_player.GetComponent<player_health>().number_of_bullet += 5;
            if (game_player.GetComponent<player_health>().has_pistol)
            {
                this.armor = GameObject.FindGameObjectWithTag("armor").GetComponent<Text>();
                armor.text = this.game_player.gameObject.GetComponent<player_health>().cur_bullet + "/" + this.game_player.gameObject.GetComponent<player_health>().number_of_bullet;

            }
            Destroy(this.gameObject);
            
        }
        else
        {
            if (Vector3.Distance(this.transform.position, this.home.transform.position) < this.check_range)
            {

                if (Vector3.Distance(this.transform.position, this.home.transform.position) < this.target_range)
                {

                    change_to_attackhome();
                    this.is_around_the_player = true;
                }
                this.nav.SetDestination(this.home.transform.position);
            }
            else
            {
                if (this.is_around_the_player == false)
                {
                    if (this.enemy_statu == 0)
                    {
                        if (Vector3.Distance(this.transform.position, this.game_player.transform.position) < this.target_range)
                        {
                            this.change_to_attack();
                            this.is_around_the_player = true;
                        }


                        this.nav.SetDestination(this.game_player.transform.position);
                    }


                }
                else
                {

                    if (this.enemy_statu == 1)
                    {
                        if (Vector3.Distance(this.transform.position, this.game_player.transform.position) >= this.target_range)
                        {
                            this.change_to_running();
                            this.is_around_the_player = false;
                        }


                        this.transform.LookAt(new Vector3(this.game_player.transform.position.x, 0, this.game_player.transform.position.z));
                    }
                }
            }
        }
        
        
    }

    

    public void change_to_attack()
    {
        if (this.enemy_statu == 1)
            return;

        // Stop wayfinding
        this.nav.isStopped = true;

        //Face the crystal
        this.transform.LookAt(this.game_player.transform.position);

        //Play the beaten animation
        this.animator.SetBool("attack", true);

        //Modify status
        this.enemy_statu = 1;

        
    }

    public void change_to_attackhome()
    {
        if (this.enemy_statu == 1)
            return;

        // Stop wayfinding
        this.nav.isStopped = true;

        //Face the crystal
        this.transform.LookAt(this.home.transform.position);

        //Play the beaten animation
        this.animator.SetBool("attack", true);

        //Modify status
        this.enemy_statu = 1;
        


    }


    //change_to_running
    public void change_to_running()
    {

        this.animator.SetBool("attack", false);

        //this.nav.SetDestination(GameObject.FindGameObjectWithTag("crystal").transform.position);

        // Keep on wayfinding
        this.nav.isStopped = false;

        // Modify status
        this.enemy_statu = 0;


    }
    //get damage.
    public void be_hit(float hurt)
    {
        this.health -= hurt;
    }


    #region     

    public void attack_start()
    {
        
        if (Vector3.Distance(this.transform.position, this.game_player.transform.position) < this.target_range)
        {
            this.audio_source.Play();
            this.game_player.GetComponent<player_health>().be_hit(10f);
        }

        if (Vector3.Distance(this.transform.position, this.home.transform.position) < this.target_range)
        {
            this.audio_source.Play();
            this.home.GetComponent<home>().be_hit(10f);
        }
    }

    #endregion
}
