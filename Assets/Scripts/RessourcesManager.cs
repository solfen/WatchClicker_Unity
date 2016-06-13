using UnityEngine;
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
    public float initialClicPower = 1f;
    public float initialClicPowerMultiplier = 1.1f;
    public float initialClicPrice = 10f;
    public float initialClicPriceMultiplier = 1.5f;
    public float initialResetComboInterval = 2f;
    public float initialClicToComboNb = 10f;
    public float initialMaxCombo = 1f;
    public float initialComboMultiplier = 2f;
    public float initialComboPrice = 100f;
    public float initialComboPriceMultiplier = 20f;
    public float initialSmallIdleSpeed = 1f;
    public float initialSmallIdleSpeedMultiplier = 1.15f;
    public float initialSmallIdlePrice = 100f;
    public float initialSmallIdlePriceMultiplier = 1.35f;
    public float initialBigIdleSpeed = 15f;
    public float initialBigIdleSpeedMultiplier = 1.25f;
    public float initialBigIdlePrice = 1000f;
    public float initialBigIdlePriceMultiplier = 1.4f;

    private float clicPower, clicPowerMultiplier, clicPrice, clicPriceMultiplier, resetComboInterval, clicToComboNb, maxCombo, comboMultiplier, comboPrice, comboPriceMultiplier, smallIdleSpeed, smallIdleSpeedMultiplier, smallIdlePrice, smallIdlePriceMultiplier, bigIdleSpeed, bigIdleSpeedMultiplier, bigIdlePrice, bigIdlePriceMultiplier;

	public float ClicPower
	{
		get
		{
			return clicPower;
		}

		set
		{
			clicPower = value;
		}
	}

	public float ClicPowerMultiplier
	{
		get
		{
			return clicPowerMultiplier;
		}

		set
		{
			clicPowerMultiplier = value;
		}
	}

	public float ClicPrice
	{
		get
		{
			return clicPrice;
		}

		set
		{
			clicPrice = value;
		}
	}

	public float ClicPriceMultiplier
	{
		get
		{
			return clicPriceMultiplier;
		}

		set
		{
			clicPriceMultiplier = value;
		}
	}

	public float ResetComboInterval
	{
		get
		{
			return resetComboInterval;
		}

		set
		{
			resetComboInterval = value;
		}
	}

	public float ClicToComboNb
	{
		get
		{
			return clicToComboNb;
		}

		set
		{
			clicToComboNb = value;
		}
	}

	public float MaxCombo
	{
		get
		{
			return maxCombo;
		}

		set
		{
			maxCombo = value;
		}
	}

	public float ComboMultiplier
	{
		get
		{
			return comboMultiplier;
		}

		set
		{
			comboMultiplier = value;
		}
	}

	public float ComboPrice
	{
		get
		{
			return comboPrice;
		}

		set
		{
			comboPrice = value;
		}
	}

	public float ComboPriceMultiplier
	{
		get
		{
			return comboPriceMultiplier;
		}

		set
		{
			comboPriceMultiplier = value;
		}
	}

	public float SmallIdleSpeed
	{
		get
		{
			return smallIdleSpeed;
		}

		set
		{
			smallIdleSpeed = value;
		}
	}

	public float SmallIdleSpeedMultiplier
	{
		get
		{
			return smallIdleSpeedMultiplier;
		}

		set
		{
			smallIdleSpeedMultiplier = value;
		}
	}

	public float SmallIdlePrice
	{
		get
		{
			return smallIdlePrice;
		}

		set
		{
			smallIdlePrice = value;
		}
	}

	public float SmallIdlePriceMultiplier
	{
		get
		{
			return smallIdlePriceMultiplier;
		}

		set
		{
			smallIdlePriceMultiplier = value;
		}
	}

	public float BigIdleSpeed
	{
		get
		{
			return bigIdleSpeed;
		}

		set
		{
			bigIdleSpeed = value;
		}
	}

	public float BigIdleSpeedMultiplier
	{
		get
		{
			return bigIdleSpeedMultiplier;
		}

		set
		{
			bigIdleSpeedMultiplier = value;
		}
	}

	public float BigIdlePrice
	{
		get
		{
			return bigIdlePrice;
		}

		set
		{
			bigIdlePrice = value;
		}
	}

	public float BigIdlePriceMultiplier
	{
		get
		{
			return bigIdlePriceMultiplier;
		}

		set
		{
			bigIdlePriceMultiplier = value;
		}
	}

	void Awake () {
        intance = this;
        firstSmallIdle = SmallIdleSpeed;
        firstBigIdle = BigIdleSpeed;
        SmallIdleSpeed = BigIdleSpeed = 0;

        distance = PlayerPrefs.GetFloat("distance", distance);
        ClicPower = PlayerPrefs.GetFloat("clicPower", initialClicPower);
        ClicPrice = PlayerPrefs.GetFloat("clicPrice", initialClicPrice);
        MaxCombo = PlayerPrefs.GetFloat("maxCombo", initialMaxCombo);
        ComboPrice = PlayerPrefs.GetFloat("comboPrice", initialComboPrice);
        SmallIdleSpeed = PlayerPrefs.GetFloat("smallIdleSpeed", initialSmallIdleSpeed);
        SmallIdlePrice = PlayerPrefs.GetFloat("smallIdlePrice", initialSmallIdlePrice);
        BigIdleSpeed = PlayerPrefs.GetFloat("bigIdleSpeed", initialBigIdleSpeed);
        BigIdlePrice = PlayerPrefs.GetFloat("bigIdlePrice", initialBigIdlePrice);

        StartCoroutine(Save());
	}
	
	// Update is called once per frame
	void Update () {
        distance += (SmallIdleSpeed + BigIdleSpeed) * currentCombo * Time.deltaTime;

        if (resetComboTimer < 0) {
            currentCombo = 1;
            currentComboClicks = 0;
            resetComboTimer = ResetComboInterval;
        }

        resetComboTimer -= Time.deltaTime;
	}

    public void Tap() {
        currentComboClicks++;
        if (currentCombo < MaxCombo && currentComboClicks >= ClicToComboNb) {
            currentCombo++;
            currentComboClicks = 0;
        }

        distance += ClicPower * currentCombo;
        resetComboTimer = ResetComboInterval;
    }

    public void BuyClic() {
        distance -= ClicPrice;
        ClicPower *= ClicPowerMultiplier;
        ClicPrice *= ClicPriceMultiplier;
    }
    public void BuyCombo() {
        distance -= ComboPrice;
        MaxCombo *= ComboMultiplier;
        ComboPrice *= ComboPriceMultiplier;
    }
    public void BuySmallIdle() {
        if (firstSmallIdle != 0) {
            SmallIdleSpeed = firstSmallIdle;
            firstSmallIdle = 0;
        }

        distance -= SmallIdlePrice;
        SmallIdleSpeed *= SmallIdleSpeedMultiplier;
        SmallIdlePrice *= SmallIdlePriceMultiplier;
    }
    public void BuyBigIdle() {
        if (firstBigIdle != 0) {
            BigIdleSpeed = firstBigIdle;
            firstBigIdle = 0;
        }

        distance -= BigIdlePrice;
        BigIdleSpeed *= BigIdleSpeedMultiplier;
        BigIdlePrice *= BigIdlePriceMultiplier;
    }

    IEnumerator Save() {
        while (true) {
            yield return new WaitForSeconds(1);

            PlayerPrefs.SetFloat("distance", distance);
            PlayerPrefs.SetFloat("clicPower", ClicPower);
            PlayerPrefs.SetFloat("clicPrice", ClicPrice);
            PlayerPrefs.SetFloat("maxCombo", MaxCombo);
            PlayerPrefs.SetFloat("comboPrice", ComboPrice);
            PlayerPrefs.SetFloat("smallIdleSpeed", SmallIdleSpeed);
            PlayerPrefs.SetFloat("smallIdlePrice", SmallIdlePrice);
            PlayerPrefs.SetFloat("bigIdleSpeed", BigIdleSpeed);
            PlayerPrefs.SetFloat("bigIdlePrice", BigIdlePrice);

            PlayerPrefs.Save();
        }
    }

	public void ResetTheGame ()
	{
		PlayerPrefs.SetFloat("distance", distance = 0);
		PlayerPrefs.SetFloat("clicPower", ClicPower = initialClicPower);
		PlayerPrefs.SetFloat("clicPrice", ClicPrice = initialClicPrice);
		PlayerPrefs.SetFloat("maxCombo", MaxCombo = initialMaxCombo);
		PlayerPrefs.SetFloat("comboPrice", ComboPrice = initialComboPrice);
		PlayerPrefs.SetFloat("smallIdleSpeed", SmallIdleSpeed = initialSmallIdleSpeed);
		PlayerPrefs.SetFloat("smallIdlePrice", SmallIdlePrice = initialSmallIdlePrice);
		PlayerPrefs.SetFloat("bigIdleSpeed", BigIdleSpeed = initialBigIdleSpeed);
		PlayerPrefs.SetFloat("bigIdlePrice", BigIdlePrice = initialBigIdlePrice);

		PlayerPrefs.Save();
	}
}
