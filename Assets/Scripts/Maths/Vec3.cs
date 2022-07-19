using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vec3 {
    public float x;
    public float y;
    public float z;

    public Vec3() {
        x = 0;
        y = 0;
        z = 0;
    }

    public Vec3( float aX, float aY, float aZ ) {
        x = aX;
        y = aY;
        z = aZ;
    }

    public Vec3( Vector3 aVector ) {
        x = aVector.x;
        y = aVector.y;
        z = aVector.z;
    }

    public static Vec3 operator +( Vec3 a, Vec3 b )
    => new Vec3( a.x + b.x, a.y + b.y, a.z + b.z );

    public static Vec3 operator -( Vec3 a, Vec3 b )
    => new Vec3( a.x - b.x, a.y - b.y, a.z - b.z );

    public static Vec3 operator *( Vec3 a, Vec3 b )
    => new Vec3( a.x * b.x, a.y * b.y, a.z * b.z );

    public static Vec3 operator *( Vec3 a, float b )
    => new Vec3( a.x * b, a.y * b, a.z * b );

    public static Vec3 operator /( Vec3 a, Vec3 b )
    => new Vec3( a.x / b.x, a.y / b.y, a.z / b.z );

    public static Vec3 operator /( Vec3 a, float b )
    => new Vec3( a.x / b, a.y / b, a.z / b );

    public Vector3 Unity() {
        return new Vector3( x, y, z );
        }
}
