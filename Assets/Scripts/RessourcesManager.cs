﻿using UnityEngine;
using System.Collections;

public class RessourcesManager : MonoBehaviour {

    public static RessourcesManager intance;

    [HideInInspector]
    public float distance;
    [HideInInspector]
    public int currentCombo;

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


    
	void Awake () {
        intance = this;
        firstSmallIdle = smallIdleSpeed;
        firstBigIdle = bigIdleSpeed;
        smallIdleSpeed = bigIdleSpeed = 0;
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

}