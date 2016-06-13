using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image))]
public class Blink : MonoBehaviour {

	// Use this for initialization
    public float blinkInterval;
    private float timer;
    private Image img;

    void Start() {
        timer = blinkInterval;
        img = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {

        if (timer < 0) {
            img.enabled = !img.enabled;
            timer = blinkInterval;
        }

        timer -= Time.unscaledDeltaTime;
	}
}
