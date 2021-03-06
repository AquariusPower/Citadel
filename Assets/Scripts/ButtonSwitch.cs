﻿using UnityEngine;
using System.Collections;

public class ButtonSwitch : MonoBehaviour {
	public int securityThreshhold = 100; // if security level is not below this level, this is unusable
	public GameObject target;
	public GameObject target1;
	public GameObject target2;
	public GameObject target3;
	public string message;
	public float delay = 0f;
	public Material mainSwitchMaterial;
	public Material alternateSwitchMaterial;
	public AudioClip SFX;
	public float tickTime = 1.5f;
	public bool active;
	public bool blinkWhenActive;
	private float delayFinished;
	private float tickFinished;
	private GameObject player;
	private AudioSource SFXSource;
	private bool alternateOn;
	private MeshRenderer mRenderer;

	void Awake () {
		SFXSource = GetComponent<AudioSource>();
		mRenderer = GetComponent<MeshRenderer>();
	}

	public void Use (GameObject owner) {
		if (LevelManager.a.levelSecurity[LevelManager.a.currentLevel] > securityThreshhold) {
			MFDManager.a.BlockedBySecurity();
			return;
		}

		player = owner;  // set playerCamera to owner of the input (always should be the player camera)
		SFXSource.PlayOneShot(SFX);
		if (message != null && message != "") Const.sprint(message,owner);
		if (delay > 0) {
			delayFinished = Time.time + delay;
		} else {
			UseTargets();
		}
	}

	public void UseTargets () {
		if (target != null) {
			target.SendMessageUpwards("Targetted", player);
		}
		if (target1 != null) {
			target.SendMessageUpwards("Targetted", player);
		}
		if (target2 != null) {
			target.SendMessageUpwards("Targetted", player);
		}
		if (target3 != null) {
			target.SendMessageUpwards("Targetted", player);
		}
			
		active = !active;
		alternateOn = active;
		if (blinkWhenActive) {
			if (alternateOn) mRenderer.material = alternateSwitchMaterial;
			else mRenderer.material = mainSwitchMaterial;
			if (active) tickFinished = Time.time + tickTime;
		}
	}

	void Update () {
		if ((delayFinished < Time.time) && delayFinished != 0) {
			delayFinished = 0;
			UseTargets();
		}

		// blink the switch when active
		if (blinkWhenActive) {
			if (active) {
				if (tickFinished < Time.time) {
					if (alternateOn) {
						mRenderer.material = mainSwitchMaterial;
					} else {
						mRenderer.material = alternateSwitchMaterial;
					}
					alternateOn = !alternateOn;
					tickFinished = Time.time + tickTime;
				}
			}
		}
	}
}
