using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class arm : MonoBehaviour
{

    private Text armor;
    private GameObject game_player;
    // Start is called before the first frame update
    void Start()
    {
        this.game_player = GameObject.FindGameObjectWithTag("Player");
        this.armor = GameObject.FindGameObjectWithTag("armor").GetComponent<Text>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.game_player.GetComponent<player_health>().number_of_bullet += 5;
            armor.text = this.game_player.gameObject.GetComponent<player_health>().cur_bullet + "/" + this.game_player.gameObject.GetComponent<player_health>().number_of_bullet;
            Destroy(this);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
