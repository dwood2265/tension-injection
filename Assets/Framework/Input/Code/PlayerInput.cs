using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

	Player player;

	//ControlMapping
	KeyCode jumpButton = KeyCode.Space;

	void Start () {
		player = GetComponent<Player> ();
	}

	void Update () {
		Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		player.SetDirectionalInput (directionalInput);

		if (Input.GetKeyDown (jumpButton)) {
			player.OnJumpInputDown ();
		}
		if (Input.GetKey (jumpButton)) {
			player.OnJumpInputHold ();
		}
		if (Input.GetKeyUp (jumpButton)) {
			player.OnJumpInputUp ();
		}
	}
}
