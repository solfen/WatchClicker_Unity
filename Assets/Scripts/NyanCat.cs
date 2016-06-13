using UnityEngine;
using System.Collections;

public class NyanCat : MonoBehaviour {

    private float lastDistance;
    private float currentSpeed;
    private float goalPosX;
    private Animator anim;

    public float maxDist = 10;
    public float speedMultiplier = 0.001f;

	// Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();

        StartCoroutine(UpdateSpeed());
    }

    // Update is called once per frame
    IEnumerator UpdateSpeed() {
        while (true) {
            yield return new WaitForSeconds(1f);
            anim.speed = (RessourcesManager.intance.distance / (Time.time + RessourcesManager.intance.previousGameTime) * speedMultiplier);
        }
    }
}
