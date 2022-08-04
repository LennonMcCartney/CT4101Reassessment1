using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectilesHit : MonoBehaviour {
	TextMeshProUGUI myText;

	public Colliders colliders;

	private void Start() {
		myText = GetComponent<TextMeshProUGUI>();
	}

	private void Update() {
		myText.text = "Projectiles Hit: " + colliders.projectilesHit;
	}
}
