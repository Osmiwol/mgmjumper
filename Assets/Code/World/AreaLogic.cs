using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLogic : MonoBehaviour
{
    public Camera m_Camera;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            m_Camera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            m_Camera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

}

