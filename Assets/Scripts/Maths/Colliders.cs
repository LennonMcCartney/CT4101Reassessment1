using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Colliders : MonoBehaviour
{
	public List<ColliderM> colliders;

	void FixedUpdate() {
		UpdateList();

		//Debug.Log(colliders.Count);

		for (int i = 0; i < colliders.Count; i++) {
			//Debug.Log("colliders.Count >> " + colliders.Count + ", i >> " + i);
			bool collided = false;
			int otherIndex;
			for (int j = 0; j < colliders.Count; j++) {
				//Debug.Log( "i >> " + i + ", j >> " + j );
				if (i != j) {
					collided = colliders[i].pos.x + colliders[i].dimensions.x > colliders[j].pos.x - colliders[j].dimensions.x && colliders[i].pos.x - colliders[i].dimensions.x < colliders[j].pos.x + colliders[j].dimensions.x
							&& colliders[i].pos.y + colliders[i].dimensions.y > colliders[j].pos.y - colliders[j].dimensions.y && colliders[i].pos.y - colliders[i].dimensions.y < colliders[j].pos.y + colliders[j].dimensions.y
							&& colliders[i].pos.z + colliders[i].dimensions.z > colliders[j].pos.z - colliders[j].dimensions.z && colliders[i].pos.z - colliders[i].dimensions.z < colliders[j].pos.z + colliders[j].dimensions.z;
					colliders[i].Collided( collided, colliders[j] );

					if (collided ) {
						otherIndex = j;
						break;
					}
				}
			}
		}
	}

	void UpdateList() {
		colliders = FindObjectsOfType<ColliderM>().ToList();
	}
}