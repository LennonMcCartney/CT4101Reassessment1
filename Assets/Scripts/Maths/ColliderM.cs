using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderM : MonoBehaviour
{

	public Vec3 pos;
	public Vec3 scale;
	public Vec3 dimensions;

	public bool collided;
	public ColliderM other;

	void Awake() {
		pos = new Vec3(transform.position);
		scale = new Vec3(transform.localScale);
		dimensions = scale / 2;
	}

	public void SetPos(Vec3 aPos) {
		pos = aPos;
	}

	public void Collided(bool aCollided, ColliderM aOther) {
		collided = aCollided;

		if (collided) {
			//if (gameObject.tag != "Floor" && aOther.gameObject.tag != "Floor") {
				//Debug.Log("Collision");
				other = aOther;
			//}
		}
		else {
			other = null;
		}
	}
}