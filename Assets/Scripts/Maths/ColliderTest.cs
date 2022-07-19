using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour {
    public ColliderTest other;

    Vec3 pos;
    Vec3 scale;
    Vec3 dimensions;

    void Start() {
        pos = new Vec3( transform.position );

        scale = new Vec3( transform.localScale );
        dimensions = scale / 2;
    }

    void FixedUpdate() {
        pos = new Vec3( transform.position );

        if ( Collided() ) {
            Debug.Log("Collided!");
        }
    }

    bool Collided() {
        bool collided = pos.x + dimensions.x > other.pos.x - other.dimensions.x && pos.x - dimensions.x < other.pos.x + other.dimensions.x
                     && pos.y + dimensions.y > other.pos.y - other.dimensions.y && pos.y - dimensions.y < other.pos.y + other.dimensions.y
                     && pos.z + dimensions.z > other.pos.z - other.dimensions.z && pos.z - dimensions.z < other.pos.z + other.dimensions.z;

        return collided;
    }
}