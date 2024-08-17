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

    private void Update() {
        if(dragging) transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }

    private void OnMouseDown() {
        dragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp() {
        dragging = false;
    }

    private void OnMouseDrag()
    {
        MouseDrag?.Invoke(transform.position);
    }
}
