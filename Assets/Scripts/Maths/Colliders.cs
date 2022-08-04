using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Colliders : MonoBehaviour
{
	public List<ColliderM> colliders;

	public int projectilesHit;

	private void Start() {
		projectilesHit = 0;
	}

	void FixedUpdate() {
		UpdateList();

		for (int i = 0; i < colliders.Count; i++) {
			//Debug.Log("colliders.Count >> " + colliders.Count + ", i >> " + i);
			//bool collided = false;
			int otherIndex;
			for (int j = 0; j < colliders.Count; j++) {
				//Debug.Log( "i >> " + i + ", j >> " + j );
				if (i != j) {
					bool collided = colliders[i].pos.x + colliders[i].dimensions.x > colliders[j].pos.x - colliders[j].dimensions.x && colliders[i].pos.x - colliders[i].dimensions.x < colliders[j].pos.x + colliders[j].dimensions.x
								 && colliders[i].pos.y + colliders[i].dimensions.y > colliders[j].pos.y - colliders[j].dimensions.y && colliders[i].pos.y - colliders[i].dimensions.y < colliders[j].pos.y + colliders[j].dimensions.y
								 && colliders[i].pos.z + colliders[i].dimensions.z > colliders[j].pos.z - colliders[j].dimensions.z && colliders[i].pos.z - colliders[i].dimensions.z < colliders[j].pos.z + colliders[j].dimensions.z;
					colliders[i].Collided( collided, colliders[j] );

					if ( collided ) {
						if ( ( colliders[i].gameObject.tag == "ShooterProj" && colliders[j].gameObject.tag == "TrapProj") || ( colliders[j].gameObject.tag == "TrapProj" && colliders[i].gameObject.tag == "ShooterProj" ) ) {
							projectilesHit++;
						}
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