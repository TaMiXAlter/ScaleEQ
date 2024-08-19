using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ChargeArrow : MonoBehaviour
{
     public void Move(Vector2 delta)
    {
        transform.localPosition = new Vector3(delta.x,delta.y,0) ;
    }

    public void Reset()
    {
        transform.localPosition = Vector3.zero;
    }
}
