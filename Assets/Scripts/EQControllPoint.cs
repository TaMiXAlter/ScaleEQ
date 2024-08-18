using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EQControllPoint : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;
    public UnityEvent<Vector3> MouseDrag;
    
    float LeftLimit,RightLimit;

    public void SetLimit(float leftLimit, float rightLimit) {
        LeftLimit = leftLimit;
        RightLimit = rightLimit;
    }

    private void Update() {
        if(!dragging) return;
       
        Vector3 TargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(TargetPosition.x >LeftLimit && TargetPosition.x < RightLimit) transform.position = TargetPosition + offset;
    }

    private void OnMouseDown() {
        dragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp() {
        dragging = false;
    }

    private void OnMouseDrag() {
        MouseDrag?.Invoke(transform.position);
    }
}
