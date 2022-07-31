using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Trap : MonoBehaviour
{
	FireProjectile fireProjectile;

	public int counter;
	public int threshold;

	void Start() {
		counter = 0;
		threshold = RandNum.RandInt(System.DateTime.Now.Millisecond, 50, 150);

		fireProjectile = GetComponent<FireProjectile>();
	}

	void FixedUpdate() {
		if (counter > threshold) {
			fireProjectile.Fire(new Vec3(RandNum.RandInt(System.DateTime.Now.Millisecond, 23, 27), RandNum.RandInt(System.DateTime.Now.Millisecond, 5, 15), 0));
			counter = 0;
			threshold = RandNum.RandInt(System.DateTime.Now.Millisecond, 50, 150);
		}
		counter++;
	}
}