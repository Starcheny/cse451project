using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class over : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject boss;
    public Text Timer;
    public GameObject create;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    private void OnTriggerEnter(Collider other)
    {
        
        boss.active = true;
        this.create.GetComponent<Create>().stop_born();
        Timer.gameObject.active = false;
        
    }

}
