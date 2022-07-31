using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
	public GameObject projectilePrefab;
	private GameObject projectileClone;

	public void Fire(Vec3 aVelocity) {
		projectileClone = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
		projectileClone.GetComponent<Projectile>().AddVelocity(aVelocity);
	}
}
