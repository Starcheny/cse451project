using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickup : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pistol;
    public GameObject current;
    public GameObject armor;
    public GameObject aim;

    public GameObject game_player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            pistol.SetActive(true);
            armor.SetActive(true);
            aim.SetActive(true);
            armor.GetComponent<Text>().text = this.game_player.gameObject.GetComponent<player_health>().cur_bullet + "/" + this.game_player.gameObject.GetComponent<player_health>().number_of_bullet;

            game_player.GetComponent<player_health>().has_pistol = true;
            Destroy(current);
        }
    }
}
