using System.Collections.Generic;
using UnityEngine;

public class AttackButtonScript : MonoBehaviour
{
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++) {
            Touch t = Input.GetTouch(i);

            Vector2 position_past = t.position - t.deltaPosition;
            Vector2 position_present = t.position;

            bool collides_past = Collides(position_past);
            bool collides_present = Collides(position_present);

            if (t.phase == TouchPhase.Began) {
                if (collides_present) {
                    AppearPressed();
                }
            }
            if (t.phase == TouchPhase.Moved) {
                if (collides_past && !collides_present) {
                    AppearReleased();
                }
            }
            if (t.phase == TouchPhase.Ended) {
                if (collides_present) {
                    AppearReleased();
                }
            }
        }
    }

    void AppearPressed() {
        Debug.Log("pressed");
    }

    void AppearReleased() {
        Debug.Log("released");
    }

    bool Collides(Vector2 touch_pos) {
        Vector2 world_touch = Camera.main.ScreenToWorldPoint(touch_pos);
        return gameObject.GetComponent<BoxCollider2D>().OverlapPoint(world_touch);
    }
}
