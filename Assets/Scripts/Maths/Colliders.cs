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

		// Loop through each collider
		for (int i = 0; i < colliders.Count; i++) {
			//int otherIndex;
			// Loop through each collider, comparing each collider to every other collider
			for (int j = 0; j < colliders.Count; j++) {
				// If comparing different colliders
				if (i != j) {
					// collided = result of Axis Aligned Bounding Box collision
					bool collided = colliders[i].pos.x + colliders[i].dimensions.x > colliders[j].pos.x - colliders[j].dimensions.x && colliders[i].pos.x - colliders[i].dimensions.x < colliders[j].pos.x + colliders[j].dimensions.x
								 && colliders[i].pos.y + colliders[i].dimensions.y > colliders[j].pos.y - colliders[j].dimensions.y && colliders[i].pos.y - colliders[i].dimensions.y < colliders[j].pos.y + colliders[j].dimensions.y
								 && colliders[i].pos.z + colliders[i].dimensions.z > colliders[j].pos.z - colliders[j].dimensions.z && colliders[i].pos.z - colliders[i].dimensions.z < colliders[j].pos.z + colliders[j].dimensions.z;
					// Collide colliders[i] with colliders[j], if collided is false colliders[i].collided will be set to false
					colliders[i].Collided( collided, colliders[j] );

					if ( collided ) {
						// If shooter projectile is colliding with trap projectile, incrememnt number of projectiles hit
						if ( colliders[i].gameObject.tag == "ShooterProj" && colliders[j].gameObject.tag == "TrapProj" ) {
							projectilesHit++;
						}
						//otherIndex = j;
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