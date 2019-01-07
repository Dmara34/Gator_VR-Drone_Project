using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Screenshot : MonoBehaviour {
	private int count;
	public RawImage photo;
	ArrayList photos = new ArrayList();
	public Texture photo1;
//save screenshots to folder
//can be used to practice drone camera skills
void LateUpdate() {
		if (Input.GetAxis ("Camera")!=0) {
			Debug.Log ("Screenshot captured");
			if (count == 0) {
				ScreenCapture.CaptureScreenshot (Application.dataPath+"/Photos/Photo.png");
			} 
			else {
				ScreenCapture.CaptureScreenshot (Application.dataPath+"/Photos/Photo"+"("+count+")"+".png");
			}
			count++;
		}
	}
}
