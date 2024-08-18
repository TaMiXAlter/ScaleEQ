
using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;
using UnityEngine.Serialization;
using UnityEngine.U2D;
using Spline = UnityEngine.Splines.Spline;

[RequireComponent(typeof(SpriteShapeController))]
public class SplineCreater : MonoBehaviour
{
    #region Singleton

    private static SplineCreater instance;

    public static SplineCreater Instance {
        get {
            if (instance == null) {
                instance = GameObject.FindObjectOfType<SplineCreater>();
            }
            return instance;
        }
    }

    #endregion

    [SerializeField]
    private EQController eqController;
    
    [SerializeField] 
    private float XKnotStartPoint ;
    [SerializeField]
    private float XSpaceing ;
    [SerializeField]
    private float YAduioModifier = 1f ;
    [SerializeField]
    private float YControllerModifier=1f ;
    
    private SpriteShapeController _spriteShapeController;
    Vector3[] _currentPositions = new Vector3 [8];

    
    
    private void Awake() => instance = this;
    private void Start() {
        InitSpriteSpline();
        if(!eqController) Debug.LogError("eqController is null");
    }

    private void Update() {
        UpdateSpriteSpline();
    }

    void InitSpriteSpline()
    {
        _spriteShapeController = GetComponent<SpriteShapeController>();
        float[] freqBand = AudioManager.Instance.GetAudioBuffer();
        for (int i = 0; i < freqBand.Length; i++) {
            _spriteShapeController.spline.SetPosition(i,(new Vector3(GetKnotXPosition(i), 0, 0)));
            _spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
        }
    }
    void UpdateSpriteSpline()
    {
        float[] freqBand = AudioManager.Instance.GetAudioBuffer();
        for (int i = 0; i < freqBand.Length; i++) {
            float Audio = freqBand[i] * YAduioModifier;
            float EQM = GetEQMultiplyer(i) * YControllerModifier;
            float UpdatePositionY = Audio + EQM;
            
            Vector3 targetPosition = new Vector3(GetKnotXPosition(i), UpdatePositionY, 0);
            _currentPositions[i] = Vector3.Lerp(_currentPositions[i], targetPosition, Time.deltaTime);
        
            _spriteShapeController.spline.SetPosition(i, _currentPositions[i]);
        }
    }

    float GetEQMultiplyer(int index)
    {
        float G2Scale = ((-1f / 12f) * Mathf.Pow(index, 2) + (7f / 12f) * index);
        float G1Scale = 0,G3Scale = 0 ;
        if (index < 3.5) {
            G1Scale = 1 - G2Scale;
            G3Scale = 0;
        }
        if (index > 3.5) {
            G3Scale = 1 - G2Scale;
            G1Scale = 0 ;
        }
        
        float G1 = G1Scale  * eqController.controlPointsValue[0];
        float G2 =  G2Scale * eqController.controlPointsValue[1] ;
        float G3 = G3Scale  * eqController.controlPointsValue[2];
        float value = G1 + G2 + G3 ;
        return value;
    }
    
    float GetKnotXPosition(int index) {
        return XKnotStartPoint + index * XSpaceing;
    }
}
