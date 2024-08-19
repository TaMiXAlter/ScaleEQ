using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class EQ_ControlPoint_v2 : MonoBehaviour
{
    public float ControlX,ControlY;
    [SerializeField]
    private float Multiplier = 1;
    
    [SerializeField]
    private float RightEdge,LeftEdge,TopEdge,BottomEdge;
    
    bool isDragging = false;
    Vector3 offset = Vector3.zero;
    
    private void Update()
    {
        if(!isDragging) return;
       
        Vector3 TargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (TargetPosition.x > LeftEdge && TargetPosition.x < RightEdge) {
            if (TargetPosition.y > BottomEdge && TargetPosition.y < TopEdge) {
                transform.position = TargetPosition + offset;
                
                ControlX = Mathf.Lerp(LeftEdge,RightEdge,transform.position.x);
                ControlY = Mathf.Lerp(BottomEdge,TopEdge,transform.position.y);
                //Audio Manager
                AudioManager.Instance.SetEQ(ControlX,ControlY *Multiplier);
            }
        }
        
    }

    private void OnMouseDown() {
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
