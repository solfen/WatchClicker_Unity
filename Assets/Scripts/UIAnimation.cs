using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class UIAnimation {

    public string name;
    public AnimationCurve curve;
    public RectTransform element;
    public Vector2 startPos = new Vector2(0, 0);
    public Vector2 endPos = new Vector2(0, 0);
    public Vector2 startSize = new Vector2(0, 0);
    public Vector2 endSize = new Vector2(0, 0);
    public float animDuration = 0; // in seconds
    public bool isReversible = true;

    [HideInInspector]
    public float timeElapsed = 0;
    [HideInInspector]
    public bool isReverted = false;
}

[System.Serializable]
public class UIAnimationVerticalLayout {

    public string name;
    public AnimationCurve curve;
    public LayoutElement element;
    public Vector2 startPreferedSize = new Vector2(0, 0);
    public Vector2 endPreferedSize = new Vector2(0, 0);
    public float animDuration = 0; // in seconds
    public bool isReversible = true;

    [HideInInspector]
    public float timeElapsed = 0;
    [HideInInspector]
    public bool isReverted = false;
}
