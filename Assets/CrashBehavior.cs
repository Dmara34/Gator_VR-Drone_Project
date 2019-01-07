using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CrashBehavior : MonoBehaviour {
GameObject[] CrashObjects;

	void Start(){
		//hide the crash screen
		CrashObjects = GameObject.FindGameObjectsWithTag ("Crash");
		hideCrash();
	}
	void	OnTriggerEnter(Collider other){
		//pause game time and show crash screen
		Time.timeScale = 0;
		showCrash ();
	}
	public void showCrash(){
		foreach(GameObject g in CrashObjects){
			g.SetActive(true);
		}
	}
	//game reset is required to hide crash screen
	public void hideCrash(){
		foreach(GameObject g in CrashObjects){
			g.SetActive(false);
		}
	}
}