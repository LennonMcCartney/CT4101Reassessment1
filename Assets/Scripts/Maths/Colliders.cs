using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Colliders : MonoBehaviour {
    private static List<ColliderM> colliders;

    void Start() {
        colliders = FindObjectsOfType<ColliderM>().ToList();
    }

    void FixedUpdate() {
        for ( int i = 0; i < colliders.Count - 1; i++ ) {
            // Check collision
            //Debug.Log("colliders[i]   >> " + colliders[i]);
            //Debug.Log("colliders[i+1] >> " + colliders[i+1]);
            if ( colliders[i+1].position.x + (colliders[i+1].scale.x / 2) > colliders[i].position.x - (colliders[i].scale.x / 2) && colliders[i+1].position.x - (colliders[i+1].scale.x / 2) < colliders[i].position.x + (colliders[i].scale.x / 2) && colliders[i+1].position.y + (colliders[i+1].scale.y / 2) > colliders[i].position.y - (colliders[i].scale.y / 2) && colliders[i+1].position.y - (colliders[i+1].scale.y / 2) < colliders[i].position.y + (colliders[i].scale.y / 2) ) {
                Debug.Log("Collision!!");
            }

        }
    }
}