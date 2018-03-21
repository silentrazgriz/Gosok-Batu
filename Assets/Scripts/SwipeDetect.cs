using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwipeDetect : MonoBehaviour {
	public bool isStart;
	public Vector2 lastNormalized = Vector2.zero;
	public Vector2 lastPosition = Vector2.zero;
	public float lastDirection = 0f;
	public int swipe = 0;
	public Text countText;

	void Start () {
		Debug.Log (Vector2.Angle(new Vector2(200, 100), new Vector2(100, 100)));
		Debug.Log (Vector2.Angle(new Vector2(100, 100), new Vector2(150, 150)));
		Debug.Log (Vector2.Angle(new Vector2(150, 100), new Vector2(100, 150)));
		Debug.Log (Vector2.Angle(new Vector2(1, 1), new Vector2(2, 2)));
	}

	void Update () {
		/*if (Input.touches.Length > 0) {
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
 		}*/

		if (Input.GetMouseButtonDown (0)) {
			isStart = true;	
		} else if (Input.GetMouseButtonUp (0)) {
			isStart = false;
			swipe++;
		}

		if (isStart) {
			float currentDirection = angle (lastPosition, Input.mousePosition);
			if (!inDirection(currentDirection, lastDirection)) {
				swipe++;
				Debug.Log (currentDirection);
			}
			lastDirection = currentDirection;
			lastPosition = Input.mousePosition;
		}

		countText.text = swipe.ToString ();
	}

	float angle(Vector2 a, Vector2 b) { 
		Vector2 v2 = (a - b).normalized;
		float angle = Mathf.Atan2(v2.y, v2.x)*Mathf.Rad2Deg;
		if (angle < 0) {
			angle = 180 + angle;
		}
		return angle;
	}

	bool inDirection(float a, float b) {
		return Mathf.Abs(a - b) < 90f;
	}
}
