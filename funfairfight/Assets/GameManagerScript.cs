using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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

    public Sprite[] CountdownSprites;
    public GameObject CountdownShowSprite;

	public GameObject HealthPrefab;

    public GameObject[] Players;
    private Animator[] animators;

    public Attack[] player_choices;
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
        SpriteRenderer r = CountdownShowSprite.GetComponent<SpriteRenderer>();
        Debug.Log(r.size);
        r.size = new Vector2(2.0f, 2.0f);
        r.sprite = CountdownSprites[0];
        r.enabled = true;
        yield return new WaitForSeconds(1.0f);
        r.sprite = CountdownSprites[1];
        yield return new WaitForSeconds(1.0f);
        r.sprite = CountdownSprites[2];
        yield return new WaitForSeconds(0.5f);
        r.sprite = CountdownSprites[3];
        yield return new WaitForSeconds(0.5f);
        r.sprite = CountdownSprites[4];
        yield return new WaitForSeconds(0.1f);
		HideButtons();
        r.enabled = false;
        PlayAnimation();
        yield return new WaitForSeconds(2.0f);
        Fight();
        ResetAllAnimations();
        yield return new WaitForSeconds(0.5f);
        round_running = false;
    }

    void PlayAnimation()
    {
        switch (player_choices[0])
        {
            case Attack.Unselected:
                switch (player_choices[1])
                {
                    case Attack.FerrisWheel:
                        animators[1].SetBool("IsFerrisAttack", true);
                        break;
                    case Attack.AirGun:
                        animators[0].SetBool("IsShot", true);
                        animators[1].SetBool("IsShooting", true);
                        break;
                    case Attack.HitTheLukas:
                        animators[0].SetBool("IsShot", true);
                        // RikkeHammer werfen
                        break;
                    case Attack.AutoScooter:
                        // Ken getroffen werden
                        // Rikke fährt um
                        break;
                    case Attack.Grabbler:
                        // GrabblerAttack
                        animators[0].SetBool("IsGrabbled", true);
                        break;
                }

                break;
            case Attack.FerrisWheel:
                switch (player_choices[1])
                {
                    case Attack.Unselected:
                        animators[0].SetBool("IsFerrisAttack", true);
                        // Rikke getroffen werden
                        break;
                    case Attack.FerrisWheel:
                        animators[0].SetBool("IsFerrisWheelBasic", true);
                        animators[1].SetBool("IsFerrisWheelBasic", true);
                        break;
                    case Attack.AirGun:
                        // Ken Ferris Wheel getroffen werden
                        // AirGun schießt ab
                        break;
                    case Attack.HitTheLukas:
                        animators[1].SetBool("IsFerrisAttack", true);
                        break;
                    case Attack.AutoScooter:
                        // Ken chillt
                        break;
                    case Attack.Grabbler:
                        // 
                        break;
                }
                break;
            case Attack.AirGun:
                switch (player_choices[1])
                {
                    case Attack.Unselected:
                        animators[0].SetBool("IsShooting", true);
                        animators[1].SetBool("IsShot", true);
                        break;
                    case Attack.FerrisWheel:
                        animators[0].SetBool("IsShooting", true);
                        break;
                    case Attack.AirGun:
                        // Beide schießen sich ab
                        break;
                    case Attack.HitTheLukas:
                        // Rikke Hammer werfen
                        animators[0].SetBool("IsShot", true);
                        break;
                    case Attack.AutoScooter:
                        // 
                        break;
                    case Attack.Grabbler:
                        break;
                }
                break;
            case Attack.HitTheLukas:
                switch (player_choices[1])
                {
                    case Attack.Unselected:
                        animators[0].SetBool("IsHammerAttack", true);
                        break;
                    case Attack.FerrisWheel:
                        animators[1].SetBool("IsFerrisAttack", true);
                        break;
                    case Attack.AirGun:
                        animators[0].SetBool("IsHammerAttack", true);
                        break;
                    case Attack.HitTheLukas:
                        animators[0].SetBool("IsHittingLukasBasic", true);
                        break;
                    case Attack.AutoScooter:
                        break;
                    case Attack.Grabbler:
                        animators[0].SetBool("IsHammerAttack", true);
                        break;
                }
                break;
            case Attack.AutoScooter:
                switch (player_choices[1])
                {
                    case Attack.Unselected:
                        break;
                    case Attack.FerrisWheel:
                        animators[0].SetBool("IsScooterCrash", true);
                        animators[1].SetBool("IsFerrisWheelBasic", true);
                        break;
                    case Attack.AirGun:
                        break;
                    case Attack.HitTheLukas:
                        animators[0].SetBool("IsHittingLukasBasic", true);
                        break;
                    case Attack.AutoScooter:
                        break;
                    case Attack.Grabbler:
                        animators[0].SetBool("IsScooterCrash2", true);
                        animators[1].SetBool("IsGrabbled", true);
                        break;
                }
                break;
            case Attack.Grabbler:
                break;
        }
    }

    void ResetAllAnimations()
    {
        foreach (var animator in animators)
        {
            animator.SetBool("IsShooting", false);
            animator.SetBool("IsShot", false);
            animator.SetBool("IsGrabbled", false);
            animator.SetBool("IsHittingLukasBasic", false);
            animator.SetBool("IsFerrisWheelBasic", false);
            animator.SetBool("IsScooterCrash", false);
            animator.SetBool("IsScooterCrash2", false);
            animator.SetBool("IsGrabbled", false);
            animator.SetBool("IsFerrisAttack", false);
            animator.SetBool("IsHammerAttack", false);
        }
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
        if (first_attack == second_attack) {
            return -1;
        } else if (first_attack == Attack.Unselected) {
            return 1;
        } else if (second_attack == Attack.Unselected) {
            return 0;
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
        animators = new[] {Players[0].GetComponent<Animator>(), Players[1].GetComponent<Animator>()};
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
			ShowButtons();
            
            StartCoroutine("StartRound");
        }
    }

	void ShowButtons() {
		for (int i = 0; i < 2; i++) {
			Players[i].GetComponent<PlayerScript>().ShowButtons();
		}
	}

	void HideButtons() {
		for (int i = 0; i < 2; i++) {
			Players[i].GetComponent<PlayerScript>().HideButtons();
		}
	}
}
