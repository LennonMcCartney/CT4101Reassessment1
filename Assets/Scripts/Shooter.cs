using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	public FireProjectile fireProjectile;

	public Trap target;

	Vec3 pos;
	Vec3 eulerAngles;

	public List<Projectile> projectiles;

	//public bool fire;

	public int closestDistIndex;
	float closestDistSqrd;
	float fireY;

	int counter;
	int threshold;

	void Awake() {
		counter = 0;
		threshold = 20;

		// Set index to -1 to indicate it has not been assigned yet
		closestDistIndex = -1;

		pos = new Vec3(transform.position);
		eulerAngles = new Vec3(transform.eulerAngles);
		fireProjectile = GetComponent<FireProjectile>();
	}

	void FixedUpdate() {
		//Debug.Log(fire);

		//counter = target.counter;
		//threshold = target.threshold;

		closestDistIndex = -1;

		pos = new Vec3(transform.position);
		eulerAngles = new Vec3(transform.eulerAngles);

		projectiles = new List<Projectile>();
		List<GameObject> projObjs = GameObject.FindGameObjectsWithTag("TrapProj").ToList();

		for (int i = 0; i < projObjs.Count; i++) {
			if ( !projObjs[i].GetComponent<ColliderM>().collided ) {
				projectiles.Add(projObjs[i].GetComponent<Projectile>());
			}
		}

		if (projectiles.Count > 0) {
			//closestDistIndex = -1;
			closestDistSqrd = 9999999;
			for (int i = 0; i < projectiles.Count; i++) {
				if (!projectiles[i].colliderM.collided) {
					float newDistSqrd = Vec3.DistanceSqrd(pos, projectiles[i].colliderM.pos);
					if (newDistSqrd < closestDistSqrd) {
						closestDistIndex = i;
						closestDistSqrd = newDistSqrd;
					}
				}
			}
			Vec3 targetDisplacement = pos - projectiles[closestDistIndex].colliderM.pos;
			float radiansY = 1.5f * Mathf.PI - Mathf.Atan2(targetDisplacement.z, targetDisplacement.x);
			fireY = 0.5f * Mathf.PI + Mathf.Atan2(targetDisplacement.z, targetDisplacement.x) - ( 0.028f * projectiles[closestDistIndex].velocity.x ) ;
			float degreesY = radiansY * Mathf.Rad2Deg;
			SetRotation(0, degreesY, 0);

			counter++;
			
			if (counter > threshold) {
				counter = 0;
				Fire();
			}
		}

		transform.eulerAngles = eulerAngles.Unity();
	}

	void SetRotation(float aX, float aY, float aZ) {
		eulerAngles = new Vec3(aX, aY, aZ);
	}

	public void Fire() {
		float targetDistXZ = Vec3.DistanceXZ(pos, projectiles[closestDistIndex].colliderM.pos);
		//float targetDistY = Vec3.DistanceYZ(pos, projectiles[closestDistIndex].colliderM.pos);

		Vec3 testVec = projectiles[closestDistIndex].colliderM.pos - pos;
		Vec3 forwardVec = new Vec3( 0, 2.8f * testVec.y + 0.9f * projectiles[closestDistIndex].velocity.y, targetDistXZ * 2.9f );
		Vec3 forwardRotated = new Vec3(forwardVec.x * Mathf.Cos(fireY) - forwardVec.z * Mathf.Sin(fireY), forwardVec.y, forwardVec.x * Mathf.Sin(fireY) + forwardVec.z * Mathf.Cos(fireY));

		//Debug.Log(projectiles[closestDistIndex].velocity.y);

		//Vec3 forwardVec = new Vec3(0, targetDistY / 2.0f, Mathf.Abs(targetDistX) * 3.0f);
		//Vec3 forwardRotated = new Vec3(forwardVec.x * Mathf.Cos(fireY) - forwardVec.z * Mathf.Sin(fireY), forwardVec.y, forwardVec.x * Mathf.Sin(fireY) + forwardVec.z * Mathf.Cos(fireY));
		//counter = 0;
		fireProjectile.Fire(forwardRotated);
	}
}