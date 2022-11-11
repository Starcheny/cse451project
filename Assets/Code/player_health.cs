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

    public int cur_bullet;
    public int number_of_bullet;
    public bool has_pistol;

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        max_health = 100f;
        has_pistol = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (this.health <= 0)
        {
            SceneManager.LoadScene(1);
        }
        hp_percent = this.health / this.max_health;

        hp_image.fillAmount = hp_percent;

        

    }


    public void be_hit(float hurt)
    {

        this.health -= hurt;
    }
}
