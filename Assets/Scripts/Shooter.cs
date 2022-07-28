using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shooter : MonoBehaviour {
    FireProjectile fireProjectile;

    Vec3 pos;
    Vec3 eulerAngles;

    GameObject target;

    public List<Projectile> projectiles;

    int counter;
    int threshold;

    void Start() {
        counter = 0;
        threshold = 50;

        pos = new Vec3(transform.position);
        eulerAngles = new Vec3(transform.eulerAngles);
        fireProjectile = GetComponent<FireProjectile>();
    }

    void FixedUpdate() {
        pos = new Vec3(transform.position);
        eulerAngles = new Vec3(transform.eulerAngles);

        projectiles = new List<Projectile>();
        List<GameObject> projObjs = GameObject.FindGameObjectsWithTag("TrapProj").ToList();

        for ( int i = 0; i < projObjs.Count; i++ ) {
            projectiles.Add(projObjs[i].GetComponent<Projectile>());
        }

        if ( projectiles.Count > 0 ) {
            int closestDistIndex = 0;
            float closestDistSqrd = 9999999;
            for ( int i = 0; i < projectiles.Count; i++ ) {
                if ( !projectiles[i].colliderM.collided ) {
                    float newDistSqrd = Vec3.DistanceSqrd( pos, projectiles[i].colliderM.pos );
                    if ( newDistSqrd < closestDistSqrd ) {
                        closestDistIndex = i;
                        closestDistSqrd = newDistSqrd;
                    }
                }
            }
            Vec3 targetDisplacement = pos - projectiles[closestDistIndex].colliderM.pos;
            float radiansY = 1.5f * Mathf.PI - Mathf.Atan2( targetDisplacement.z, targetDisplacement.x );
            float otherY = 0.5f * Mathf.PI + Mathf.Atan2( targetDisplacement.z, targetDisplacement.x );;
            float degreesY = radiansY * Mathf.Rad2Deg;
            SetRotation( 0, degreesY, 0 );

            counter++;
            if ( counter > threshold ) {
                //Vec3 forwardVec = new Vec3( 0, 10, 45 );
                float targetDistance = Vec3.DistanceXZ( pos, projectiles[closestDistIndex].colliderM.pos );
                Vec3 forwardVec = new Vec3( 0, targetDisplacement.y / 0.7f, Mathf.Abs(targetDisplacement.z) / 0.7f );
                Vec3 testVec = new Vec3( forwardVec.x * Mathf.Cos(otherY) - forwardVec.z * Mathf.Sin(otherY), forwardVec.y, forwardVec.x * Mathf.Sin(otherY) + forwardVec.z * Mathf.Cos(otherY) );
                //testVec.Log();
                counter = 0;
                fireProjectile.Fire( testVec );
            }
        }

        transform.eulerAngles = eulerAngles.Unity();
    }

    void SetRotation( float aX, float aY, float aZ ) {
        eulerAngles = new Vec3( aX, aY, aZ );
    }
}