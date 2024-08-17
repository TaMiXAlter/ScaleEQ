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
    public float[] controlPointsValue = new float[3];
    [SerializeField]
    private float RightEdge, LeftEdge,TopEdge,BottomEdge;
    [SerializeField]
    EQControllPoint SpawnControlPoint;
    
    private SpriteShapeController _spriteShapeController;

    private void Awake() {
        _spriteShapeController = GetComponent<SpriteShapeController>();
    }

    void Start() {
        TrySpawnControlPoint(this.MoveControlPoint1,LeftEdge,0);
        TrySpawnControlPoint(this.MoveControlPoint2,(RightEdge+LeftEdge)/2,1);
        TrySpawnControlPoint(this.MoveControlPoint3,RightEdge,2);
    }

    void TrySpawnControlPoint(UnityAction<Vector3> DragEvent,float InitPosition,int index) {
        EQControllPoint controlPoint = Instantiate(SpawnControlPoint,transform);
        Vector3 postion = new Vector3(InitPosition, (TopEdge-BottomEdge)/2, -9);
        controlPoint.transform.position = postion;
        _spriteShapeController.spline.SetPosition(index, postion);
        controlPoint.MouseDrag.AddListener(DragEvent);
    }

    private void MoveControlPoint1(Vector3 postion) {
        _spriteShapeController.spline.SetPosition(0, postion);
        float gain = Mathf.Lerp(0, 3,   Mathf.Abs(postion.y/(TopEdge-BottomEdge)));
        controlPointsValue[0] = gain;
        AudioManager.Instance.SetEQ("Gain1",gain);
    }
    private void MoveControlPoint2(Vector3 postion) {
        _spriteShapeController.spline.SetPosition(1, postion);
        float gain = Mathf.Lerp(0, 3,   Mathf.Abs(postion.y/(TopEdge-BottomEdge)));
        controlPointsValue[1] = gain;
        AudioManager.Instance.SetEQ("Gain2",gain);
    }
    private void MoveControlPoint3(Vector3 postion) {
        _spriteShapeController.spline.SetPosition(2, postion);
        float gain = Mathf.Lerp(0, 3,   Mathf.Abs(postion.y/(TopEdge-BottomEdge)));
        controlPointsValue[2] = gain;
        AudioManager.Instance.SetEQ("Gain3",gain);
    }
    
}
