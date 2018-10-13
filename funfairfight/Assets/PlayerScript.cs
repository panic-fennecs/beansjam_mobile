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
    private int LivePoints;

    public Text LiveText;

    private const int NUM_BUTTONS = 5;

    // Start is called before the first frame update
    void Start()
    {
        LivePoints = 3;
        Attack[] attacks = new[] { Attack.AirGun, Attack.AutoScooter, Attack.FerrisWheel, Attack.Grabbler, Attack.HitTheLukas };

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
        LivePoints--;
        LiveText.text = LivePoints.ToString();
    }

    public int GetLivePoints()
    {
        return LivePoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
