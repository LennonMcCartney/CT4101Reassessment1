using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetSpeed : MonoBehaviour {
	TextMeshProUGUI myText;

	public Shooter shooter;

	private void Start() {
		myText = GetComponent<TextMeshProUGUI>();
	}

	private void Update() {
		if ( shooter.closestDistIndex > -1 ) {
			myText.text = "Target Speed: " + shooter.projectiles[shooter.closestDistIndex].velocity.x;
		}
		//Debug.Log( shooter.projectiles[shooter.closestDistIndex].velocity.z );
	}
}
