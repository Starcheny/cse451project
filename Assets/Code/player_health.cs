using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_health : MonoBehaviour
{

    public float health;
    private float max_health;
   
    float hp_percent;
    public Image hp_image;

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        max_health = 100f;

    }

    // Update is called once per frame
    void Update()
    {
        if (this.health <= 0)
        {
            SceneManager.LoadScene(0);
        }
        hp_percent = this.health / this.max_health;

        hp_image.fillAmount = hp_percent;

        Debug.Log(hp_percent);

    }


    public void be_hit(float hurt)
    {

        this.health -= hurt;
    }
}