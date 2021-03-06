﻿using UnityEngine;
using System.Collections;

public class DroneMovementScript : MonoBehaviour {

	Rigidbody ourDrone;

	void Awake(){
		ourDrone = GetComponent<Rigidbody> ();
	}

	void FixedUpdate(){
		MovementUpDown();
		MovementForward();
		Rotation();
		ClampingSpeedValues();
		Swirl ();

		ourDrone.AddRelativeForce (Vector3.up * upForce);
		ourDrone.rotation = Quaternion.Euler(
			new Vector3(titlAmountForward, currentYRotation, tiltAmountSideways)
		);
	}

	public float upForce;
	public float Speed;

	void MovementUpDown(){
		// Set keyboard inputs for drone to lift-off and go down
		if (Input.GetAxis ("VerticalR") < 0){
			upForce = 20f*Input.GetAxis ("VerticalR");
		} 
		else if (Input.GetAxis ("VerticalR") > 0){
			upForce = 20f*Input.GetAxis ("VerticalR");
		} 
	}

	private float movementForwardSpeed = 16.0f;
	private float titlAmountForward = 0;

	void MovementForward(){
		if (Input.GetAxis ("VerticalL") != 0) {
			ourDrone.AddRelativeForce (Vector3.forward * Input.GetAxis ("VerticalL") * movementForwardSpeed);
			titlAmountForward = Mathf.SmoothDamp (titlAmountForward, 20 * Input.GetAxis ("VerticalL"), ref titlVelocityForward, 0.1f);

		}
	}
	private float wantedYRotation;
	[HideInInspector]public float currentYRotation;
	private float rotateAmountByKeys = 2.5f;
	private float rotationYVelocity;
	void Rotation(){
		if (Input.GetAxis ("HorizontalR")!=0) {
			wantedYRotation += (Input.GetAxis("HorizontalR")*rotateAmountByKeys);


		}
		currentYRotation = Mathf.SmoothDamp (currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f);
	}

	private Vector3 velocityToSmoothDampToZero;
	void ClampingSpeedValues(){
		if (Mathf.Abs (Input.GetAxis ("VerticalL")) > 0.2f && Mathf.Abs (Input.GetAxis ("HorizontalL")) > 0.2f) {
			ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
		}
		if (Mathf.Abs (Input.GetAxis ("VerticalL")) > 0.2f && Mathf.Abs (Input.GetAxis ("HorizontalL")) < 0.2f) {
			ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
		}
		if (Mathf.Abs (Input.GetAxis ("VerticalL")) < 0.2f && Mathf.Abs (Input.GetAxis ("HorizontalL")) > 0.2f) {
			ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
		}
		if (Mathf.Abs (Input.GetAxis ("VerticalL")) < 0.2f && Mathf.Abs (Input.GetAxis ("HorizontalL")) < 0.2f) {
			ourDrone.velocity = Vector3.SmoothDamp(ourDrone.velocity, Vector3.zero, ref velocityToSmoothDampToZero, 0.95f);
		}
	}

	private float sideMovementAmount = 16.0f;
	private float tiltAmountSideways;
	private float tiltAmountVelocity;
	void Swirl(){
		if (Mathf.Abs (Input.GetAxis ("HorizontalL")) > 0.2f) {
			ourDrone.AddRelativeForce (Vector3.right * Input.GetAxis ("HorizontalL") * sideMovementAmount);
			tiltAmountSideways = Mathf.SmoothDamp (tiltAmountSideways, -20 * Input.GetAxis ("HorizontalL"), ref tiltAmountVelocity, 0.1f);
		} 
		else {
			tiltAmountSideways = Mathf.SmoothDamp (tiltAmountSideways, 0, ref tiltAmountVelocity, 0.1f);
		}
	}
}
