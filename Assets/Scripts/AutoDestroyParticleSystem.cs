using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class AutoDestroyParticleSystem : MonoBehaviour {

    private ParticleSystem particlesSystem;

    void Start() {
        particlesSystem = GetComponent<ParticleSystem>();
    }
	// Update is called once per frame
	void Update () {
        if (!particlesSystem.IsAlive()) {
            Destroy(gameObject);
        }
	}
}
