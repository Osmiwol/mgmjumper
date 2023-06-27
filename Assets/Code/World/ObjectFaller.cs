using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFaller : MonoBehaviour
{
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision != null && collision.transform.tag == "Player")
        {
            Debug.Log("Collision Exit");
            rb.isKinematic = false;
        }
    }
}
