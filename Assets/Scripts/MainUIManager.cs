using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainUIManager : MonoBehaviour {

    public static MainUIManager instance;

    public Text distanceText;
    public Text speedText;
    public Text comboText;

    private int distPowIndex;
    private float distance;
    private int speedPowIndex;
    private float speed;

	void Awake () {
        instance = this;
	}

	void Update () {
        Utils.FormatDistance(RessourcesManager.intance.distance, ref distPowIndex, ref distance);
        Utils.FormatDistance(RessourcesManager.intance.smallIdleSpeed + RessourcesManager.intance.bigIdleSpeed, ref speedPowIndex, ref speed);
        distanceText.text = distance.ToString("F1") +Utils.metersPow[distPowIndex];
        speedText.text = speed.ToString("F1") + Utils.metersPow[speedPowIndex] + "/s";
        comboText.text = "x" + RessourcesManager.intance.currentCombo;
	}
}
