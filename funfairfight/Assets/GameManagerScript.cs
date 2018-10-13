using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public enum Attack
{
    Unselected,
    FerrisWheel,
    AirGun,
    HitTheLukas,
    AutoScooter,
    Grabbler,
}

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance;

    public Sprite PressedFerrisWheel, ReleasedFerrisWheel;
    public Sprite PressedAirGun, ReleasedAirGun;
    public Sprite PressedHitTheLukas, ReleasedHitTheLukas;
    public Sprite PressedAutoScooter, ReleasedAutoScooter;
    public Sprite PressedGrabbler, ReleasedGrabbler;

    public GameObject[] Players;
    public Text ShowText;

    private Attack[] player_choices;
    private bool round_running;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
    }

    // Shows the Countdown
    IEnumerator StartRound()
    {
        ShowText.text = "5";
        yield return new WaitForSeconds(1.0f);
        ShowText.text = "4";
        yield return new WaitForSeconds(1.0f);
        ShowText.text = "Fun";
        yield return new WaitForSeconds(0.5f);
        ShowText.text = "Fair";
        yield return new WaitForSeconds(0.5f);
        ShowText.text = "Fight";
        Fight();
        yield return new WaitForSeconds(0.5f);
        ShowText.text = "";
        PlayAnimation();
        yield return new WaitForSeconds(2.0f);
        round_running = false;
    }

    void PlayAnimation()
    {
        // TODO
    }

    public void PlayerAttackChoice(int player_id, Attack attack)
    {
        if (player_id >= 0 && player_id < 2)
        {
            player_choices[player_id] = attack;
        } else {
            Debug.Log("ERROR: player_id = " + player_id.ToString());
        }
    }

    void Fight()
    {
        int winner = GetWinner(player_choices[0], player_choices[1]);
        if (winner != -1) {
            int looser = 1 - winner;
            Players[looser].GetComponent<PlayerScript>().DecLivePoints();
        }
    }

    // returns the Attacks, which loose against <attack>
    Attack[] GetLosingAttacks(Attack attack)
    {
        switch (attack)
        {
            case Attack.AirGun:
                return new[] { Attack.FerrisWheel, Attack.Grabbler };
            case Attack.Grabbler:
                return new[] { Attack.AutoScooter, Attack.FerrisWheel };
            case Attack.AutoScooter:
                return new[] { Attack.AirGun, Attack.HitTheLukas };
            case Attack.HitTheLukas:
                return new[] { Attack.AirGun, Attack.Grabbler };
            case Attack.FerrisWheel:
                return new[] { Attack.HitTheLukas, Attack.AutoScooter };
        }

        return new Attack[0];
    }

    // if the first attack wins: 0
    // if second attack wins: 1
    // if draw: -1
    int GetWinner(Attack first_attack, Attack second_attack)
    {
        if (first_attack == second_attack)
        {
            return -1;
        } else {
            Attack[] loosing_attacks = GetLosingAttacks(first_attack);
            foreach (Attack a in loosing_attacks)
            {
                // If the second player chosen a losing attack
                if (second_attack == a)
                {
                    // First player wins
                    return 0;
                }
            }
            // Otherwise the second player wins
            return 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetPlayerChoices();
        round_running = false;
    }

    void ResetPlayerChoices()
    {
        player_choices = new[] { Attack.Unselected, Attack.Unselected };
    }

    // Update is called once per frame
    void Update()
    {
        if (!round_running)
        {
            round_running = true;
            ResetPlayerChoices();
            
            StartCoroutine("StartRound");
        }
    }
}
