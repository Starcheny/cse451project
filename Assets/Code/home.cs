using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class home : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public float max_health;
    public Text armor_numbers;
    float hp_percent;
    public Image hp_image;
    public Image hp_image2;

    // Start is called before the first frame update
    void Start()
    {
        

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


        hp_image.transform.position = new Vector3(Screen.width * 1 / 10, Screen.height * 9/10);
        hp_image2.transform.position = new Vector3(Screen.width * 1 / 10, Screen.height * 9 / 10);

        armor_numbers.transform.position = new Vector3(Screen.width * 19 / 20, Screen.height * 19 / 20);
        armor_numbers.rectTransform.sizeDelta = new Vector2(Screen.width * 1 / 10, Screen.height * 1 / 10);

        hp_image.rectTransform.sizeDelta = new Vector2(Screen.width * 1 / 25, Screen.height * 1 / 90);
        hp_image2.rectTransform.sizeDelta = new Vector2(Screen.width * 1 / 25, Screen.height * 1 / 90);


    }


    public void be_hit(float hurt)
    {

        this.health -= hurt;
    }
}
