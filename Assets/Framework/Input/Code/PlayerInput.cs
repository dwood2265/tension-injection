using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

	Player player;

	//ControlMapping
	KeyCode jumpButton = KeyCode.Space;
	KeyCode ability1Button = KeyCode.Alpha1;
	KeyCode ability2Button = KeyCode.Alpha2;
	KeyCode ability3Button = KeyCode.Alpha3;
	KeyCode ability4Button = KeyCode.Alpha4;

	void Start () {
		player = GetComponent<Player> ();
	}

	void Update () {
		Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		player.SetDirectionalInput (directionalInput);

		//Jumping Input
		if (Input.GetKeyDown (jumpButton)) {
			player.OnJumpInputDown ();
		}
		if (Input.GetKey (jumpButton)) {
			player.OnJumpInputHold ();
		}
		if (Input.GetKeyUp (jumpButton)) {
			player.OnJumpInputUp ();
		}

		//Ability 1 Input
		if(Input.GetKeyDown (ability1Button)) {
			player.onAbility1InputDown ();
		}

		//Ability 2 Input
		if(Input.GetKeyDown (ability1Button)) {
			player.onAbility2InputDown ();
		}

		//Ability 3 Input
		if(Input.GetKeyDown (ability1Button)) {
			player.onAbility3InputDown ();
		}

		//Ability 4 Input
		if(Input.GetKeyDown (ability1Button)) {
			player.onAbility4InputDown ();
		}
	}
}
