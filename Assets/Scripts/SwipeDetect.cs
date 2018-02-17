using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeDetect : MonoBehaviour {
	public bool isStart;
	public Vector2 lastNormalized = Vector2.zero;
	public int swipe = 0;
	public Text countText;

	void Update () {
		if (Input.touches.Length > 0) {
			Touch touch = Input.touches [0];
			if (touch.phase == TouchPhase.Began) {
				isStart = true;
			} else if (touch.phase == TouchPhase.Moved) {
				if (lastNormalized == Vector2.zero && isStart) {
					isStart = false;
					lastNormalized = touch.deltaPosition.normalized;
				} else if (!inDirection (lastNormalized, touch.deltaPosition.normalized) && touch.deltaPosition.magnitude > 10f) {
					lastNormalized = touch.deltaPosition.normalized;
					swipe++;
				}
			}
 		}

		countText.text = swipe.ToString ();
	}

	bool inDirection(Vector2 from, Vector2 to) {
		float deltaX = Mathf.Abs(from.x - to.x);
		float deltaY = Mathf.Abs(from.y - to.y);
		return deltaX <= 0.2f && deltaY <= 0.2f;
	}
}
