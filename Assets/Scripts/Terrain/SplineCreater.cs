
using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;
using UnityEngine.U2D;
using Spline = UnityEngine.Splines.Spline;

[RequireComponent(typeof(SplineContainer))]
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
    private float YModifier ;
    
    private SplineContainer splineContainer;
    private SpriteShapeController _spriteShapeController;
    
    private void Awake() => instance = this;
    private void Start() {
        InitSpriteSpline();
        if(!eqController) Debug.LogError("eqController is null");
    }

    private void Update() {
        UpdateSpriteSpline(AudioManager.Instance.GetAudioBuffer());
    }

    void InitSpriteSpline()
    {
        _spriteShapeController = GetComponent<SpriteShapeController>();
        float[] freqBand = AudioManager.Instance.GetAudioBuffer();
        for (int i = 0; i < freqBand.Length; i++) {
            _spriteShapeController.spline.SetPosition(i,(new Vector3(XKnotStartPoint+i*XSpaceing, 0, 0)));
            _spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
        }
    }
    
    void UpdateSpriteSpline(float[] freqBand)
    {
        for (int i = 0; i < freqBand.Length; i++) {
            float refPoint = freqBand[i];
            float EQM = GetEQMultiplyer(i);
            _spriteShapeController.spline.SetPosition(i,new Vector3(XKnotStartPoint+i*XSpaceing, YModifier*EQM* refPoint, 0));
        }
    }

    float GetEQMultiplyer(int index)
    {
        float G1 = 1f -(index /7f) * eqController.controlPointsValue[0];
        float G2 = 0.5f + (3.5f - Mathf.Abs(index-3.5f)) * 0.5f * eqController.controlPointsValue[1];
        float G3 = index/7f * eqController.controlPointsValue[2];
        float value = G1 + G2 + G3 ;
        return value;
    }
}
