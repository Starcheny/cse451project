using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public float attackDamage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "enemy")
        {

            collision.gameObject.GetComponent<bone>().be_hit(attackDamage);
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "enemy2")
        {

            collision.gameObject.GetComponent<raser>().be_hit(attackDamage);
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "enemy3")
        {

            collision.gameObject.GetComponent<bone2>().be_hit(attackDamage);
            Destroy(this.gameObject);

        }

        else if (collision.gameObject.tag == "enemy4")
        {

            collision.gameObject.GetComponent<split>().be_hit(attackDamage);
            Destroy(this.gameObject);

        }


        else if (collision.gameObject.tag == "missle")
        {

            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }

        else if (collision.gameObject.tag == "boss")
        {

            collision.gameObject.GetComponent<boss>().be_hit(attackDamage);
            Destroy(this.gameObject);

        }

        else
        {
            Destroy(this.gameObject);
        }
    }
}
