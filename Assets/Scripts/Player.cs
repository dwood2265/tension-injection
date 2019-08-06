using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {

	//Variables pertaining to jumping
	public float maxJumpHeight = 4;
	public float minJumpHeight = 1;
	public float timeToJumpApex = .4f;
	float maxJumpVelocity;
	float minJumpVelocity;
	float jumpCharge;
	Vector2 jumpDirection;


	//Variables pertaining to Player velocity and acceleration
	float accelerationTimeAirborne = 5f;
	float accelerationTimeGrounded = 0.5f;
	float moveSpeed = 0.7f;
	float gravity;
	Vector3 velocity;
	float velocityXSmoothing;


	//Variables pertaining to Wall climbing and jumping (Note: wall jumping is disabled as of August 6, 2019)
	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;
	public float wallSlideSpeedMax = 3;
	public float wallStickTime = .25f;
	float timeToWallUnstick;


	//Variables pertaining to input from other scripts
	Controller2D controller;
	Vector2 directionalInput;

	void Start() {
		//Assign the controller component of the player
		controller = GetComponent<Controller2D> ();

		//Calculate Gravity and Jumping velocity based on the time to the apex of the jump and the max jump height
		gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);
	}

	void Update() {
		//Update the player's velocity and move the player based on directionalInput
		CalculateVelocity ();
		controller.Move (velocity * Time.deltaTime, directionalInput);

		if (controller.collisions.above || controller.collisions.below) {
			if (controller.collisions.slidingDownMaxSlope) {
				velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
			} else {
				velocity.y = 0;
			}
		}
	}

	public void SetDirectionalInput (Vector2 input) {
		directionalInput = input;
	}

	public void OnJumpInputDown() {

		jumpCharge = minJumpVelocity;
	}

	public void OnJumpInputHold() {
		Debug.Log(jumpCharge);
		SetDirectionalInput (Vector2.zero);
		if (jumpCharge < maxJumpVelocity){
			jumpCharge += Time.deltaTime*1f;
		} else {
			jumpCharge = maxJumpVelocity;
		}

	}
	public void OnJumpInputUp() {
		if (controller.collisions.below) {
			if (controller.collisions.slidingDownMaxSlope) {
				if (directionalInput.x != -Mathf.Sign (controller.collisions.slopeNormal.x)) { // not jumping against max slope
					velocity.y = jumpCharge * controller.collisions.slopeNormal.y;
					velocity.x = jumpCharge * controller.collisions.slopeNormal.x;
				}
			} else {
				velocity.y = jumpCharge;
				velocity.x = jumpCharge * directionalInput.x;
			}
		}
	}
		

	void CalculateVelocity() {
		float targetVelocityX = directionalInput.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
	}
}
