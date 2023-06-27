using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectDeleter : MonoBehaviour
{
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player") SceneManager.LoadScene("SampleScene");
        else
        {
            var go = collision.transform.gameObject;  
            Destroy(go);
        }
    }
}
