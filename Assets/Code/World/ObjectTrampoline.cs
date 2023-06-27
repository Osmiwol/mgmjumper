using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrampoline : MonoBehaviour
{
    public float PushPower;
    float _currentPushPower;
    DateTime _lastTouch;
    private void Start()
    {
        _lastTouch = DateTime.Now;
        _currentPushPower = PushPower;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            if (Timer.IsTimePass(_lastTouch, 1)) _currentPushPower = PushPower;
            else
            {
                _currentPushPower -= 1;
                if (_currentPushPower < 1) _currentPushPower = 0;
            }

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _currentPushPower, ForceMode2D.Impulse);
            _lastTouch = DateTime.Now;
        }
    }
}
