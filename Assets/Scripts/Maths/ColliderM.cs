using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderM : MonoBehaviour {

    public Vec3 position;
    public Vec3 scale;
    public Vec3 dimensions;

    void Start() {
        position = new Vec3( transform.position );
        scale = new Vec3 ( transform.localScale );
        dimensions = scale / 2;
    }

    void FixedUpdate() {
    }
}