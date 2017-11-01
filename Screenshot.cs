using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour {

void Update() {
		if (Input.GetKeyDown ("space")) {
			Debug.Log ("Screenshot captured");
			ScreenCapture.CaptureScreenshot ("Screenshot.png");
		}
	}
}
