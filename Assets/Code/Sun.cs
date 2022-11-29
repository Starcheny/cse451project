using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public Transform sunPos;
    //public GameObject[] myObjects;
    public GameObject myObjects;
    bool timerReached = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (sunPos.position.y >= 0)
        {
            timerReached = false;
            if (timerReached) { }
            // STOP GENERATE MONSTERS
            //Debug.Log("sun is day");
            //Debug.Log(timerReached);

        }
        else if(sunPos.position.y < 0)
        {
            timerReached = true;
            //GENERATE MONSTERS
            int randomIndex =  Random.Range(0,1000);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-2,-4),0,Random.Range(10,15));
            // Instantiate(myObjects,randomSpawnPosition,Quaternion.identity);
            //Debug.Log("sun is night");
            //Debug.Log(timerReached);
            //Debug.Log(randomSpawnPosition);
        }
        transform.RotateAround(Vector3.zero, Vector3.right, 10f * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }

}
