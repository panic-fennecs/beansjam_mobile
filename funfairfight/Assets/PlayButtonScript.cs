using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    bool Collides(Vector2 touch_pos) {
        Vector2 world_touch = Camera.main.ScreenToWorldPoint(touch_pos);
        return gameObject.GetComponent<BoxCollider2D>().OverlapPoint(world_touch);
    }


    void OnPress() {
        GlobalScript.LoadScene("SampleScene");
    }
}
