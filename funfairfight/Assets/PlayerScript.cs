﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerScript : MonoBehaviour
{
	private const int MAX_HEALTH = 3;

    public GameObject ButtonPrefab;
    public int PlayerID;
    private Sprite[] Buttons;
    private GameObject[] HealthMarks = new GameObject[MAX_HEALTH];
	private int Health = MAX_HEALTH;

    private const int NUM_BUTTONS = 5;
    private const float BUTTON_POSITION = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Attack[] attacks = new[] { Attack.AirGun,
                                   Attack.AutoScooter,
                                   Attack.FerrisWheel,
                                   Attack.Grabbler,
                                   Attack.HitTheLukas };
		for (int i = 0; i < MAX_HEALTH; i++) {
			HealthMarks[i] = Instantiate(GameManagerScript.Instance.HealthPrefab, GetHealthMarkPosition(i), Quaternion.identity);
		}

        Buttons = new Sprite[attacks.Length];
        
        for (int i = 0; i < attacks.Length; i++)
        {
            GameObject btn = Instantiate(ButtonPrefab, GetAttackButtonPosition(i), Quaternion.identity);
            btn.GetComponent<AttackButtonScript>().PlayerID = PlayerID;
            btn.GetComponent<AttackButtonScript>().attack = attacks[i];
            Buttons[i] = btn.GetComponent<Sprite>();
        }
    }

    public void DecLivePoints()
    {
		if (Health > 0) {
			Health--;
			Destroy(HealthMarks[Health]);
			HealthMarks[Health] = null;
		}
    }

    // Update is called once per frame
    void Update()
    {

    }

	float Factor() {
		return (Camera.main.WorldToViewportPoint(new Vector3(1, 0, 0)) - Camera.main.WorldToViewportPoint(new Vector3(0, 0, 0))).magnitude;
	}

	Vector3 GetHealthMarkPositionViewport(int i) {
		float size = Factor() * GameManagerScript.Instance.HealthPrefab.transform.lossyScale.x;

		float x = 0.5f - (size + i * 3.0f*size/2.0f);
		float y = 1.0f - (3.0f * size / 2.0f);
		if (PlayerID == 1) {
			x = 1.0f - x;
		}
		return new Vector3(x, y, 0.0f);
	}

	Vector3 GetAttackButtonPositionViewport(int i) {
		float size = Factor() * GameManagerScript.Instance.PressedAutoScooter.bounds.size.x;

		float x = 1.0f * size / 2.0f;
		if (PlayerID == 1) {
			x = 1.0f - x;
		}
		float y = i*((1.0f-2.0f*size) / (NUM_BUTTONS - 1)) + size;

		return new Vector3(x, y, 0.0f);
	}

	Vector3 GetHealthMarkPosition(int i) {
		var v = Camera.main.ViewportToWorldPoint(GetHealthMarkPositionViewport(i));
		v.z = 0;
		return v;
	}

	Vector3 GetAttackButtonPosition(int i) {
		var v = Camera.main.ViewportToWorldPoint(GetAttackButtonPositionViewport(i));
		v.z = 0;
		return v;
	}
}
