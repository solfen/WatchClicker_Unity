using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopUI : MonoBehaviour {

    public static ShopUI instance;

    public float swipeMinWidth = 50;
    public GameObject availableFeedback;

    private float startX = 0;
    private UIAnimator2 anim;
    [HideInInspector]
    public bool isOpen = false;

    private float clickPowValue;
    private int clickPowIndex;
    private float clickPriceValue;
    private int clickPriceIndex;
    public Text clickPowText;
    public Text clickPriceText;
    public Button clickBuyBtn;
    private float comboPriceValue;
    private int comboPriceIndex;
    public Text comboPowText;
    public Text comboPriceText;
    public Button comboBuyBtn;
    private float smallIdlePowValue;
    private int smallIdlePowIndex;
    private float smallIdlePriceValue;
    private int smallIdlePriceIndex;
    public Text smallIdlePowText;
    public Text smallIdlePriceText;
    public Button smallIdleBuyBtn;
    private float bigIdlePowValue;
    private int bigIdlePowIndex;
    private float bigIdlePriceValue;
    private int bigIdlePriceIndex;
    public Text bigIdlePowText;
    public Text bigIdlePriceText;
    public Button bigIdleBuyBtn;

    void Start() {
        instance = this;
        anim = GetComponent<UIAnimator2>();
    }

	void Update () {
        UpdateValues();
        Swipe();

        if (Input.GetKeyDown(KeyCode.A)) {
            anim.StartAnim("slide");
            isOpen = !isOpen;
        }

	}

    private void UpdateValues() {
        Utils.FormatDistance(RessourcesManager.intance.clicPower, ref clickPowIndex, ref clickPowValue);
        Utils.FormatDistance(RessourcesManager.intance.smallIdleSpeed, ref smallIdlePowIndex, ref smallIdlePowValue);
        Utils.FormatDistance(RessourcesManager.intance.bigIdleSpeed, ref bigIdlePowIndex, ref bigIdlePowValue);

        clickPowText.text = "Cur Pow: " + clickPowValue.ToString("F1") + Utils.metersPow[clickPowIndex];
        comboPowText.text = "Cur Pow: " + "x" + RessourcesManager.intance.maxCombo;
        smallIdlePowText.text = "Cur Pow: " + smallIdlePowValue.ToString("F1") + Utils.metersPow[smallIdlePowIndex];
        bigIdlePowText.text = "Cur Pow: " + bigIdlePowValue.ToString("F1") + Utils.metersPow[bigIdlePowIndex];

        Utils.FormatDistance(RessourcesManager.intance.clicPrice, ref clickPriceIndex, ref clickPriceValue);
        Utils.FormatDistance(RessourcesManager.intance.comboPrice, ref comboPriceIndex, ref comboPriceValue);
        Utils.FormatDistance(RessourcesManager.intance.smallIdlePrice, ref smallIdlePriceIndex, ref smallIdlePriceValue);
        Utils.FormatDistance(RessourcesManager.intance.bigIdlePrice, ref bigIdlePriceIndex, ref bigIdlePriceValue);

        clickPriceText.text = "Price: " + clickPriceValue.ToString("F1") + Utils.metersPow[clickPriceIndex];
        comboPriceText.text = "Price: " + comboPriceValue.ToString("F1") + Utils.metersPow[comboPriceIndex];
        smallIdlePriceText.text = "Price: " + smallIdlePriceValue.ToString("F1") + Utils.metersPow[smallIdlePriceIndex];
        bigIdlePriceText.text = "Price: " + bigIdlePriceValue.ToString("F1") + Utils.metersPow[bigIdlePriceIndex];

        clickBuyBtn.interactable = RessourcesManager.intance.clicPrice <= RessourcesManager.intance.distance;
        comboBuyBtn.interactable = RessourcesManager.intance.comboPrice <= RessourcesManager.intance.distance;
        smallIdleBuyBtn.interactable = RessourcesManager.intance.smallIdlePrice <= RessourcesManager.intance.distance;
        bigIdleBuyBtn.interactable = RessourcesManager.intance.bigIdlePrice <= RessourcesManager.intance.distance;

        availableFeedback.SetActive(clickBuyBtn.interactable || comboBuyBtn.interactable || smallIdleBuyBtn.interactable || bigIdleBuyBtn.interactable);
    }

    private void Swipe() {
        if (Input.touches.Length <= 0) {
            return;
        }

        Touch t = Input.GetTouch(0);
        if (t.phase == TouchPhase.Began) {
            startX = t.position.x;
        }
        else if (t.phase == TouchPhase.Ended) {
            if (t.position.x < startX - swipeMinWidth && !isOpen) {
                anim.StartAnim("slide");
                isOpen = true;
            }
            else if (t.position.x > startX + swipeMinWidth) {
                if (isOpen) {
                    anim.StartAnim("slide");
                    isOpen = false;
                }
                /*else
                    Application.Quit();*/
            }
        }
    }
}
