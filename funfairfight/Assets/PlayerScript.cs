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
        Attack[] attacks = new[] { Attack.AirGun,
                                   Attack.AutoScooter,
                                   Attack.FerrisWheel,
                                   Attack.Grabbler,
                                   Attack.HitTheLukas };

        Buttons = new Sprite[attacks.Length];
        
        float y = -3.5f;
        float y_diff = 7.0f / (attacks.Length - 1);
        float x = (PlayerID - 0.5f)*2.0f*4.5f;

        for (int i = 0; i < attacks.Length; i++)
        {
            Vector3 btn_position = new Vector3(x, y, 0.0f);
            GameObject btn = Instantiate(ButtonPrefab, btn_position, Quaternion.identity);
            btn.GetComponent<AttackButtonScript>().PlayerID = PlayerID;
            btn.GetComponent<AttackButtonScript>().attack = attacks[i];
            Buttons[i] = btn.GetComponent<Sprite>();
            y += y_diff;
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
