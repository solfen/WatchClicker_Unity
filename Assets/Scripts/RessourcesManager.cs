using UnityEngine;
using System.Collections;

public class RessourcesManager : MonoBehaviour {

    public static RessourcesManager intance;

    [HideInInspector]
    public float distance;
    [HideInInspector]
    public int currentCombo;
    [HideInInspector]
    public float previousGameTime;

    private float resetComboTimer;
    private int currentComboClicks;
    private float firstSmallIdle;
    private float firstBigIdle;

    [Header("Power Ups")]
    public float clicPower;
    public float clicPowerMultiplier = 1.25f;
    public float clicPrice;
    public float clicPriceMultiplier = 1.3f;
    public float resetComboInterval = 2;
    public int clicToComboNb = 10;
    public float maxCombo = 1;
    public float comboMultiplier = 1.25f;
    public float comboPrice;
    public float comboPriceMultiplier = 1.3f;
    public float smallIdleSpeed;
    public float smallIdleSpeedMultiplier = 1.25f;
    public float smallIdlePrice;
    public float smallIdlePriceMultiplier = 1.3f;
    public float bigIdleSpeed;
    public float bigIdleSpeedMultiplier = 1.25f;
    public float bigIdlePrice;
    public float bigIdlePriceMultiplier = 1.3f;

    public float initClicPower;
    public float initClicPrice;
    public float initMaxCombo;
    public float initComboPrice;
    public float initSmallIdleSpeed;
    public float initSmallIdlePrice;
    public float initBigIdleSpeed;
    public float initBigIdlePrice;


    
	void Awake () {
        intance = this;
        firstSmallIdle = smallIdleSpeed;
        firstBigIdle = bigIdleSpeed;
        smallIdleSpeed = bigIdleSpeed = 0;

        initClicPower = clicPower;
        initClicPrice = clicPrice;
        initMaxCombo = maxCombo;
        initComboPrice = comboPrice;
        initSmallIdleSpeed = smallIdleSpeed;
        initSmallIdlePrice = smallIdlePrice;
        initBigIdleSpeed = bigIdleSpeed;
        initBigIdlePrice = bigIdlePrice;

        distance = PlayerPrefs.GetFloat("distance", distance);
        clicPower = PlayerPrefs.GetFloat("clicPower", clicPower);
        clicPrice = PlayerPrefs.GetFloat("clicPrice", clicPrice);
        maxCombo = PlayerPrefs.GetFloat("maxCombo", maxCombo);
        comboPrice = PlayerPrefs.GetFloat("comboPrice", comboPrice);
        smallIdleSpeed = PlayerPrefs.GetFloat("smallIdleSpeed", smallIdleSpeed);
        smallIdlePrice = PlayerPrefs.GetFloat("smallIdlePrice", smallIdlePrice);
        bigIdleSpeed = PlayerPrefs.GetFloat("bigIdleSpeed", bigIdleSpeed); 
        bigIdlePrice = PlayerPrefs.GetFloat("bigIdlePrice", bigIdlePrice);
        previousGameTime = PlayerPrefs.GetFloat("previousGameTime", previousGameTime);

        StartCoroutine(Save());
	}
	
	// Update is called once per frame
	void Update () {
        distance += (smallIdleSpeed + bigIdleSpeed) * currentCombo * Time.deltaTime;

        if (resetComboTimer < 0) {
            currentCombo = 1;
            currentComboClicks = 0;
            resetComboTimer = resetComboInterval;
        }

        resetComboTimer -= Time.deltaTime;
	}

    public void Tap() {
        currentComboClicks++;
        if (currentCombo < maxCombo && currentComboClicks >= clicToComboNb) {
            currentCombo++;
            currentComboClicks = 0;
        }

        distance += clicPower * currentCombo;
        resetComboTimer = resetComboInterval;
    }

    public void BuyClic() {
        distance -= clicPrice;
        clicPower *= clicPowerMultiplier;
        clicPrice *= clicPriceMultiplier;
    }
    public void BuyCombo() {
        distance -= comboPrice;
        maxCombo *= comboMultiplier;
        comboPrice *= comboPriceMultiplier;
    }
    public void BuySmallIdle() {
        if (firstSmallIdle != 0) {
            smallIdleSpeed = firstSmallIdle;
            firstSmallIdle = 0;
        }

        distance -= smallIdlePrice;
        smallIdleSpeed *= smallIdleSpeedMultiplier;
        smallIdlePrice *= smallIdlePriceMultiplier;
    }
    public void BuyBigIdle() {
        if (firstBigIdle != 0) {
            bigIdleSpeed = firstBigIdle;
            firstBigIdle = 0;
        }

        distance -= bigIdlePrice;
        bigIdleSpeed *= bigIdleSpeedMultiplier;
        bigIdlePrice *= bigIdlePriceMultiplier;
    }

    IEnumerator Save() {
        while (true) {
            yield return new WaitForSeconds(1);

            PlayerPrefs.SetFloat("distance", distance);
            PlayerPrefs.SetFloat("clicPower", clicPower);
            PlayerPrefs.SetFloat("clicPrice", clicPrice);
            PlayerPrefs.SetFloat("maxCombo", maxCombo);
            PlayerPrefs.SetFloat("comboPrice", comboPrice);
            PlayerPrefs.SetFloat("smallIdleSpeed", smallIdleSpeed);
            PlayerPrefs.SetFloat("smallIdlePrice", smallIdlePrice);
            PlayerPrefs.SetFloat("bigIdleSpeed", bigIdleSpeed);
            PlayerPrefs.SetFloat("bigIdlePrice", bigIdlePrice);
            PlayerPrefs.SetFloat("previousGameTime", Time.time);

            PlayerPrefs.Save();
        }
    }

    public void Reset() {
        PlayerPrefs.SetFloat("distance", 0);
        PlayerPrefs.SetFloat("clicPower", initClicPower);
        PlayerPrefs.SetFloat("clicPrice", initClicPrice);
        PlayerPrefs.SetFloat("maxCombo", initMaxCombo);
        PlayerPrefs.SetFloat("comboPrice", initComboPrice);
        PlayerPrefs.SetFloat("smallIdleSpeed", initSmallIdleSpeed);
        PlayerPrefs.SetFloat("smallIdlePrice", initSmallIdlePrice);
        PlayerPrefs.SetFloat("bigIdleSpeed", initBigIdleSpeed);
        PlayerPrefs.SetFloat("bigIdlePrice", initBigIdlePrice);
        PlayerPrefs.SetFloat("previousGameTime", 0);

        distance = 0;
        clicPower = initClicPower;
        clicPrice = initClicPrice;
        maxCombo = initMaxCombo;
        comboPrice = initComboPrice;
        smallIdleSpeed = initSmallIdleSpeed;
        smallIdlePrice = initSmallIdlePrice;
        bigIdleSpeed = initBigIdleSpeed;
        bigIdlePrice = initBigIdlePrice;
        previousGameTime = 0;

        PlayerPrefs.Save();
    }

}
