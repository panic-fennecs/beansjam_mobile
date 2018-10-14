using System.Collections.Generic;
using UnityEngine;

public class AttackButtonScript : MonoBehaviour
{
    public int PlayerID;
    public Attack attack;
	private bool visible = true;

    void Start()
    {
        AppearReleased();
    }

    void Update()
    {
		if (visible) {
			if (Input.mousePresent) {
				if (Input.GetMouseButtonDown(0) && Collides(Input.mousePosition)) {
					OnPress();
				}
			}

			for (int i = 0; i < Input.touchCount; i++) {
				Touch t = Input.GetTouch(i);

				Vector2 position_past = t.position - t.deltaPosition;
				Vector2 position_present = t.position;

				bool collides_past = Collides(position_past);
				bool collides_present = Collides(position_present);

				if (t.phase == TouchPhase.Began) { 
					if (collides_present) {
						OnPress();
					}
				}
			}

			if (attack == GameManagerScript.Instance.player_choices[PlayerID]) {
				AppearPressed();
			} else {
				AppearReleased();
			}
		}
    }

    void OnPress()
    {
        GameManagerScript.Instance.PlayerAttackChoice(PlayerID, attack);
    }

    void AppearPressed() {
		SpriteRenderer r = GetComponent<SpriteRenderer>();
		if (attack == Attack.FerrisWheel) {
			r.sprite = GameManagerScript.Instance.PressedFerrisWheel;
		} else if (attack == Attack.HitTheLukas) {
			r.sprite = GameManagerScript.Instance.PressedHitTheLukas;
		} else if (attack == Attack.AutoScooter) {
			r.sprite = GameManagerScript.Instance.PressedAutoScooter;
		} else if (attack == Attack.Grabbler) {
			r.sprite = GameManagerScript.Instance.PressedGrabbler;
		} else if (attack == Attack.AirGun) {
			r.sprite = GameManagerScript.Instance.PressedAirGun;
		}
    }

    void AppearReleased() {
		SpriteRenderer r = GetComponent<SpriteRenderer>();
		if (attack == Attack.FerrisWheel) {
			r.sprite = GameManagerScript.Instance.ReleasedFerrisWheel;
		} else if (attack == Attack.HitTheLukas) {
			r.sprite = GameManagerScript.Instance.ReleasedHitTheLukas;
		} else if (attack == Attack.AutoScooter) {
			r.sprite = GameManagerScript.Instance.ReleasedAutoScooter;
		} else if (attack == Attack.Grabbler) {
			r.sprite = GameManagerScript.Instance.ReleasedGrabbler;
		} else if (attack == Attack.AirGun) {
			r.sprite = GameManagerScript.Instance.ReleasedAirGun;
		}
    }

    bool Collides(Vector2 touch_pos) {
        Vector2 world_touch = Camera.main.ScreenToWorldPoint(touch_pos);
        return gameObject.GetComponent<BoxCollider2D>().OverlapPoint(world_touch);
    }

	public void Show() {
		if (!visible) {
			GetComponent<SpriteRenderer>().enabled = true;
			visible = true;
		}
	}

	public void Hide() {
		if (visible) {
			GetComponent<SpriteRenderer>().enabled = false;
			visible = false;
		}
	}
}
