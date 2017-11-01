using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCollider: MonoBehaviour {
public Color Safe_Radius_1_Color;
public Color Safe_Radius_2_Color;
public Color Safe_Radius_3_Color;
public Color Safe_Radius_Default;
	public GameObject capsule;
	public Color Current_Capsule_Color;
	void Start(){
		//Capsule = RC_Quadcopter_FBX.Find("Capsule").GameObject;
	capsule.GetComponent<Renderer> ().material.color		 = Safe_Radius_Default;	}
//changes the color of the capsule
void	OnTriggerEnter(Collider other){
		if (capsule.GetComponent<Renderer> ().material.color == Safe_Radius_Default) {
			capsule.GetComponent<Renderer> ().material.color = Safe_Radius_3_Color;
			return;
	}
		if(capsule.GetComponent<Renderer> ().material.color ==Safe_Radius_3_Color){
			capsule.GetComponent<Renderer> ().material.color = Safe_Radius_2_Color;
			return;
	}
		if(capsule.GetComponent<Renderer> ().material.color ==Safe_Radius_2_Color){
			capsule.GetComponent<Renderer> ().material.color = Safe_Radius_1_Color;
			return;
	}
	
}
	void	OnTriggerExit(Collider other){
		if (capsule.GetComponent<Renderer> ().material.color == Safe_Radius_1_Color) {
			capsule.GetComponent<Renderer> ().material.color = Safe_Radius_2_Color;
			return;
		}
		if(capsule.GetComponent<Renderer> ().material.color ==Safe_Radius_2_Color){
			capsule.GetComponent<Renderer> ().material.color = Safe_Radius_3_Color;
			return;
		}
		if(capsule.GetComponent<Renderer> ().material.color ==Safe_Radius_3_Color){
			capsule.GetComponent<Renderer> ().material.color = Safe_Radius_Default;
			return;
		}
	}
}
