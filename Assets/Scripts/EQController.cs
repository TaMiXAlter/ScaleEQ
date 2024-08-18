using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines.Interpolators;
using UnityEngine.U2D;

public class EQController : MonoBehaviour
{
    [NonSerialized]
    public float[] controlPointsValue = new float[3]{.5f,.5f,.5f};
    [SerializeField]
    private float RightEdge,LeftEdge,TopEdge,BottomEdge;

    [Header("Spline")] 
    [SerializeField] private float SplineLeft;
    [SerializeField] private float SplineRight;
    
    private float Height,Width;
    [SerializeField]
    GameObject SpawnControlPoint;
    
    private SpriteShapeController _spriteShapeController;

    private void Awake() {
        _spriteShapeController = GetComponent<SpriteShapeController>();
        Height =  TopEdge - BottomEdge;
        Width = LeftEdge-RightEdge;
    }

    void Start() {
        TrySpawnControlPoint(this.MoveControlPoint1,SplineRight,0);
        TrySpawnControlPoint(this.MoveControlPoint2,(SplineRight+SplineLeft)/2,1);
        TrySpawnControlPoint(this.MoveControlPoint3,SplineLeft,2);
    }

    void TrySpawnControlPoint(UnityAction<Vector3> DragEvent,float InitPosition,int index) {
        GameObject SpawnGameObject = Instantiate(SpawnControlPoint,transform);
        Vector3 postion = new Vector3(InitPosition, transform.position.y, -9);
        SpawnGameObject.transform.position = postion;
        _spriteShapeController.spline.SetPosition(index, postion);
        
        EQControllPoint controllPoint = SpawnGameObject.GetComponent<EQControllPoint>();
        float Range = (RightEdge - LeftEdge)/3;
        controllPoint.SetLimit(LeftEdge+index*Range,LeftEdge + (index+1)*Range);
        controllPoint.MouseDrag.AddListener(DragEvent);
    }

    private void MoveControlPoint1(Vector3 postion) {
        _spriteShapeController.spline.SetPosition(0, postion);
        float gain = Mathf.Lerp(0, 1,   (postion.y-BottomEdge)/Height);
        controlPointsValue[0] = gain;
        AudioManager.Instance.SetEQ("Gain1",gain*2);
    }
    private void MoveControlPoint2(Vector3 postion) {
        _spriteShapeController.spline.SetPosition(1, postion);
        float gain = Mathf.Lerp(0, 1,   (postion.y-BottomEdge)/Height);
        controlPointsValue[1] = gain;
        AudioManager.Instance.SetEQ("Gain2",gain*2);
    }
    private void MoveControlPoint3(Vector3 postion) {
        _spriteShapeController.spline.SetPosition(2, postion);
        float gain = Mathf.Lerp(0, 1,   (postion.y-BottomEdge)/Height);
        controlPointsValue[2] = gain;
        AudioManager.Instance.SetEQ("Gain3",gain*2);
    }
    
}
