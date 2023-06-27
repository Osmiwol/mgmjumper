using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDissapear : MonoBehaviour
{
    public float DelayInSec;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    DateTime lastDissapear;
    public bool DissapearingMode;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        lastDissapear = DateTime.Now;
        DissapearingMode = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Timer.IsTimePass(lastDissapear, DelayInSec))
        {
            DissapearingMode = !DissapearingMode;
            SetDissapearingMode(DissapearingMode);
            lastDissapear = DateTime.Now;
        }
    }

    void SetDissapearingMode(bool dissapearingMode)
    {
        if (dissapearingMode)
        {
            spriteRenderer.enabled = false;
            boxCollider.enabled = false;
        }
        else
        {
            spriteRenderer.enabled = true;
            boxCollider.enabled = true;
        }
    }

    
}
