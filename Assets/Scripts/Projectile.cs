using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    Vec3 acceleration;

    ColliderM colliderM;

    bool falling;

    void Start() {
        falling = true;

        colliderM = GetComponent<ColliderM>();
        colliderM.position = new Vec3(transform.position);
    }

    void FixedUpdate() {
        colliderM.position += acceleration;

        //position = new Vec3(transform.position);
        transform.position = colliderM.position.Unity();
    }
}

// suvat
// 