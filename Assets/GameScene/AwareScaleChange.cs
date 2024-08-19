using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwareScaleChange : MonoBehaviour
{
    public float MaxScale = 2f;
    public float scaleCangeDuration = 0f;

    public GameObject FireWork;
    public void InitRangeDamage()
    {

        transform.localScale = Vector3.zero;
        FireWork.SetActive(false);
        StartCoroutine(ScaleChange());
    }
    private IEnumerator ScaleChange()
    {
        float elapsedTime = 0f;

        while (elapsedTime < scaleCangeDuration)
        {
            elapsedTime += Time.deltaTime;
            transform.localScale = new Vector3(Mathf.Lerp(0f, MaxScale, elapsedTime / scaleCangeDuration),
            Mathf.Lerp(0f, MaxScale, elapsedTime / scaleCangeDuration),
            Mathf.Lerp(0f, MaxScale, elapsedTime / scaleCangeDuration));
            yield return null;
        }
        transform.localScale = new Vector3(MaxScale, MaxScale, MaxScale);
        yield return new WaitForSeconds(2);
        Destroy(gameObject, 3);
        FireWork.SetActive(true);
    }
}
