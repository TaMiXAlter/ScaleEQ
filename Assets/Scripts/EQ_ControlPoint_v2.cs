using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public class EQ_ControlPoint_v2 : MonoBehaviour
{
    public float ControlX = 0.5f;
    public float ControlY = 0.5f;
    [SerializeField]
    private float Multiplier = 1;
    
    [SerializeField]
    private float RightEdge,LeftEdge,TopEdge,BottomEdge;
    
    Vector3 offset = Vector3.zero;

    private void Awake()
    {
        Cursor.visible = true;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
       
        Vector3 ScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 TargetPosition = new Vector3(ScreenPosition.x, ScreenPosition.y, -5f);

        transform.position = TargetPosition;
        
                
        ControlX = (transform.position.x - LeftEdge)/(RightEdge - LeftEdge);
        ControlY = (transform.position.y - BottomEdge)/(TopEdge - BottomEdge);
        //Audio Manager 
        float gain = Mathf.Lerp(0,2,ControlY);
        float freq = (Mathf.Pow(ControlX,2f)*40484f) + 20f;
        AudioManager.Instance.SetEQ(freq,gain *Multiplier);
        
    }

    
}
