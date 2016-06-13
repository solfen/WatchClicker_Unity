using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Effects : MonoBehaviour {

    public static Effects instance;

    public Image bg1;
    public Image bg2;
    public float bgSpeed;
    public List<Image> trails;
    public float bgChangePercent = 1;
    public List<Sprite> bgSprites;

    public GameObject particles;

    private RectTransform bg1Transform;
    private RectTransform bg2Transform;

    private float lastDistance;
    private float currentPosX;
    private float goalPosX;

	void Awake () {
        instance = this;
        bg1Transform = bg1.GetComponent<RectTransform>();
        bg2Transform = bg2.GetComponent<RectTransform>();
	}

	void Update () {
        Paralax();
        Particles();
	}

    private void Paralax() {
        goalPosX += RessourcesManager.intance.distance - lastDistance;
        currentPosX = Mathf.Lerp(currentPosX, goalPosX * bgSpeed, Time.deltaTime);
        lastDistance = RessourcesManager.intance.distance;

        bg1.sprite = bg1Transform.position.x - 5 <= -320 && Random.Range(0, 100) < bgChangePercent ? bgSprites[Random.Range(0, bgSprites.Count)] : bg1.sprite;
        bg2.sprite = bg2Transform.position.x - 5 <= -320 && Random.Range(0, 100) < bgChangePercent ? bgSprites[Random.Range(0, bgSprites.Count)] : bg2.sprite;

        bg1Transform.position = new Vector3(320 + (-currentPosX - 320) % 640, 0, 0);
        bg2Transform.position = new Vector3(320 + -currentPosX % 640, 0, 0);
    }

    private void Particles() {
        if (Input.GetMouseButtonUp(0) && !ShopUI.instance.isOpen) {
            Instantiate(particles, new Vector3(Input.mousePosition.x, Input.mousePosition.y, -5), Quaternion.identity);
        }

        if (Input.touches.Length <= 0 || ShopUI.instance.isOpen) {
            return;
        }

        Touch t = Input.GetTouch(0);
        if (t.phase == TouchPhase.Ended) {
            Instantiate(particles, t.position, Quaternion.identity);
        }
        
    }
}
