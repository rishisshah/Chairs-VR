using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

	public int score = 0;

	public AudioClip clip;
	public AudioSource audioSource;

	public GameObject explosionPrefab;
	public ParticleSystem explosionAnimation;
	public Transform camera; 

	private float fireRate = .15F;
	private float nextFire = 0.0F;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = clip; 
		explosionAnimation = GetComponent<ParticleSystem> (); 
		explosionAnimation.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (OVRInput.Get (OVRInput.Button.One) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;

			RaycastGun ();
			audioSource.Play ();
		}
	}

	private void RaycastGun() {

		Vector3 fwd = camera.TransformDirection (Vector3.forward);

		RaycastHit hit;

		if (Physics.Raycast (camera.position, fwd, out hit)) {

			if (hit.rigidbody.gameObject != null) //TRy to fix null error thing
			{
				if (hit.rigidbody.gameObject.CompareTag ("Enemy")) {
					Instantiate (explosionPrefab, hit.point, Quaternion.identity);
					hit.rigidbody.gameObject.SetActive (false);
					score++;
				}
			}
		}
	}
}
