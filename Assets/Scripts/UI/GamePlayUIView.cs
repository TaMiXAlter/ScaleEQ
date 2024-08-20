using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GamePlayUIView : MonoBehaviour
{
    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
}
