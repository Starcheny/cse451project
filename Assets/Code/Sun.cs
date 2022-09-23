using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public Transform sunPos;
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
            Debug.Log("sun is day");
            Debug.Log(timerReached);

        }
        else if(sunPos.position.y < 0)
        {
            timerReached = true;
            Debug.Log("sun is night");
            Debug.Log(timerReached);
        }
        transform.RotateAround(Vector3.zero, Vector3.right, 10f * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }

}
