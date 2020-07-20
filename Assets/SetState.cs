using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetState : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    
    void Awake()
    {
        SpriteRenderer.enabled = false;
    }

    public void Set(bool state)
    {
        SpriteRenderer.enabled = state;
    }
}
