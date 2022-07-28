using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    int lifespan;
    int counter;

    Vec3 acceleration;
    Vec3 velocity;

    public ColliderM colliderM;

    void Awake() {
        velocity = new Vec3();
        acceleration = new Vec3();
        lifespan = 700;
        counter = 0;
        colliderM = GetComponent<ColliderM>();
    }

    void FixedUpdate() {
        colliderM.pos = new Vec3(transform.position);

        if ( colliderM.collided ) {
            velocity = new Vec3();
            acceleration = new Vec3();

            if ( colliderM.other != null ) {
                switch ( colliderM.other.gameObject.tag ) {
                    case "TrapProj":
                        Debug.Log("TrapProj");
                        break;
                    case "ShooterProj":
                        Debug.Log("ShooterProj");
                        break;
                    case "Floor":
                        Debug.Log("Floor");
                        break;
                    default:
                        Debug.Log("Nothing");
                        break;
                }
            }
            
            //Debug.Log( "tag >> " + colliderM.other.gameObject.tag );

            if ( colliderM.pos.y < ( colliderM.dimensions.y - 0.005f ) ) {
                colliderM.pos.y = colliderM.dimensions.y - 0.005f;
            }
        } else {
            acceleration = new Vec3( 0, -9.8f, 0 );

            colliderM.pos += (velocity * Time.deltaTime) + (0.5f * acceleration * Time.deltaTime * Time.deltaTime);
        }

        counter++;

        if ( counter > lifespan ) {
            //Destroy(gameObject);
        }

        velocity += acceleration * Time.deltaTime;

        transform.position = colliderM.pos.Unity();
    }

    public void AddVelocity( Vec3 aVelocity ) {
        if (velocity == null) {
            Debug.Log("Velocity is null");
        }
        else {
            velocity += aVelocity;
        }
    }
}

// suvat
// s = u * t + 1/2 * a * t^2