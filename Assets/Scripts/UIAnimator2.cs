using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIAnimator2 : MonoBehaviour {

    public UIAnimation[] animations;

    public Dictionary<string, UIAnimation> animationsDictionary = new Dictionary<string, UIAnimation>();

    void Awake() {
        for (int i = 0; i < animations.Length; i++) {
            animationsDictionary.Add(animations[i].name, animations[i]);
        }
    }
    public void StartAnim(string name) {
        StartCoroutine("Animation", name);
    }

    IEnumerator Animation(string name) {
        UIAnimation anim = animationsDictionary[name];

        while (anim.timeElapsed < anim.animDuration) {
            float timePercent = anim.timeElapsed / anim.animDuration;
            float animationCompletionPercent = anim.curve.Evaluate(timePercent);

            anim.element.anchorMin = Vector2.Lerp(anim.startPos, anim.endPos, animationCompletionPercent);
            anim.element.anchorMax = Vector2.Lerp(anim.startSize, anim.endSize, animationCompletionPercent);

            anim.timeElapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        anim.element.anchorMin = anim.endPos;
        anim.element.anchorMax = anim.endSize;
        anim.timeElapsed = 0;

        if (anim.isReversible) {

            Vector2 tmpPos = anim.startPos;
            anim.startPos = anim.endPos;
            anim.endPos = tmpPos;

            Vector2 tmpSize = anim.startSize;
            anim.startSize = anim.endSize;
            anim.endSize = tmpSize;

            anim.isReverted = !anim.isReverted;
        }
    }
}
