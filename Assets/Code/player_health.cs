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
    public Image hp_image2;

    
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

        hp_image.transform.position = new Vector3(Screen.width * 1 / 10, Screen.height * 19 / 20);
        hp_image2.transform.position = new Vector3(Screen.width*1/10, Screen.height * 19 / 20);

       

        hp_image.rectTransform.sizeDelta = new Vector2(Screen.width * 1 / 25, Screen.height * 1 / 90);
        hp_image2.rectTransform.sizeDelta = new Vector2(Screen.width * 1 / 25, Screen.height * 1 / 90);

    }


    public void be_hit(float hurt)
    {

        this.health -= hurt;
    }
}
