using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWind : MonoBehaviour
{
    public float WindPower;

    Vector3 WindDirection;
    private void Update()
    {
        WindDirection = transform.TransformDirection(Vector3.up);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(WindDirection * WindPower,ForceMode2D.Force);
        }
    }


}
