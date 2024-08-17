
using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

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
    private float XKnotStartPoint ;
    [SerializeField]
    private float XSpaceing ;
    [SerializeField]
    private float YModifier ;
    
    private SplineContainer splineContainer;
    
    private void Awake() => instance = this;
    private void Start() {
        InitialSpline();
    }

    private void Update() {
        UpdateSpline(AudioManager.Instance._bandBuffer);
    }

    void InitialSpline() {
        splineContainer = GetComponent<SplineContainer>();
        Spline _terrainSpline = splineContainer.AddSpline();
        float[] freqBand = AudioManager.Instance._bandBuffer;
        for (int i = 0; i < freqBand.Length; i++) {
            _terrainSpline.Add(new BezierKnot(new Vector3(XKnotStartPoint+i*XSpaceing, 0, 0)), TangentMode.AutoSmooth);
        }
    }
    
    void UpdateSpline(float[] freqBand) {
        Spline spline = splineContainer[0];
        for (int i = 0; i < freqBand.Length; i++) {
            float refPoint = freqBand[i];
            BezierKnot controlKnot = new BezierKnot(new Vector3(XKnotStartPoint+i*XSpaceing, YModifier* refPoint, 0));
            spline[i] = controlKnot;
        }
    }
    
}
