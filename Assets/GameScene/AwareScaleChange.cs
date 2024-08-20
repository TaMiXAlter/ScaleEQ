using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwareScaleChange : MonoBehaviour
{
    public float MaxScale = 2f;
    public float scaleChangeDuration = 0f;

    public float ChangeToFireWorkTime = 0f;
    public float FireWorkLifeTime = 0f;

    public GameObject FireWork;
    public GameObject AwareObj;
    void Start()
    {
        InitRangeDamage();
    }
    public void InitRangeDamage()
    {

        AwareObj.transform.localScale = Vector3.zero;
        FireWork.SetActive(false);
        StartCoroutine(ScaleChange());
    }
    private IEnumerator ScaleChange()
    {
        float elapsedTime = 0f;

        while (elapsedTime < scaleChangeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / scaleChangeDuration;
            AwareObj.transform.localScale = Vector3.one * Mathf.Lerp(0f, MaxScale, t);
            yield return null;
        }

        AwareObj.transform.localScale = Vector3.one * MaxScale;

        yield return new WaitForSeconds(ChangeToFireWorkTime);
        Destroy(AwareObj.gameObject);

        FireWork.SetActive(true);
        yield return new WaitForSeconds(FireWorkLifeTime);

        Destroy(FireWork.gameObject);
    }
}
