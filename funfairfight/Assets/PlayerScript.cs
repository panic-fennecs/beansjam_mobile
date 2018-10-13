using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerScript : MonoBehaviour
{
    public GameObject ButtonPrefab;
    public int PlayerID;
    private Sprite[] Buttons;
    private GameObject[] HealthMarks;
	private int Health;

    private const int NUM_BUTTONS = 5;
	private const int MAX_HEALTH = 3;

    // Start is called before the first frame update
    void Start()
    {
        Attack[] attacks = new[] { Attack.AirGun, Attack.AutoScooter, Attack.FerrisWheel, Attack.Grabbler, Attack.HitTheLukas };
		HealthMarks = new GameObject[MAX_HEALTH];
		for (int i = 0; i < MAX_HEALTH; i++) {
			HealthMarks[i] = Instantiate(GameManagerScript.Instance.HealthPrefab, new Vector3(PlayerID*4.0f-2f + i, 4.0f, 0.0f), Quaternion.identity);
		}
		Health = MAX_HEALTH;

        Buttons = new Sprite[attacks.Length];

        for (int i = 0; i < attacks.Length; i++)
        {
            GameObject btn = Instantiate(ButtonPrefab, new Vector3(PlayerID*3.0f-1.5f, i*0.8f, 0.0f), Quaternion.identity);
            btn.GetComponent<AttackButtonScript>().PlayerID = PlayerID;
            btn.GetComponent<AttackButtonScript>().attack = attacks[i];
            Buttons[i] = btn.GetComponent<Sprite>();
        }
    }

    public void DecLivePoints()
    {
		if (Health > 0) {
			Destroy(HealthMarks[--Health]);
			HealthMarks[Health] = null;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
