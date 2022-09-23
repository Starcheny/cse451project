using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maiCam : MonoBehaviour
{

    public Transform targetPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.LookAt(new Vector3(targetPos.position.x, 0f, targetPos.position.z));   
    }
}
