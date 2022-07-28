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

    public static float DistanceSqrd( Vec3 a, Vec3 b ) {
        float distanceSqrd = (a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y) + (a.z - b.z) * (a.z - b.z);
        return distanceSqrd;
    }

    public static float Distance( Vec3 a, Vec3 b ) {
        float distance = Mathf.Sqrt( (a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y) + (a.z - b.z) * (a.z - b.z) );
        return distance;
    }

    // Distance in XZ plane ignoring Y
    public static float DistanceXZ( Vec3 a, Vec3 b ) {
        float distance = Mathf.Sqrt( (a.x - b.x) * (a.x - b.x) + (a.z - b.z) * (a.z - b.z) );
        return distance;
    }

    public static Vec3 operator +( Vec3 a, Vec3 b )
    => new Vec3( a.x + b.x, a.y + b.y, a.z + b.z );

    public static Vec3 operator -( Vec3 a, Vec3 b )
    => new Vec3( a.x - b.x, a.y - b.y, a.z - b.z );

    public static Vec3 operator *( Vec3 a, Vec3 b )
    => new Vec3( a.x * b.x, a.y * b.y, a.z * b.z );

    public static Vec3 operator *( Vec3 a, float b )
    => new Vec3( a.x * b, a.y * b, a.z * b );

    public static Vec3 operator *( float a, Vec3 b )
    => new Vec3( b.x * a, b.y * a, b.z * a );

    public static Vec3 operator /( Vec3 a, Vec3 b )
    => new Vec3( a.x / b.x, a.y / b.y, a.z / b.z );

    public static Vec3 operator /( Vec3 a, float b )
    => new Vec3( a.x / b, a.y / b, a.z / b );

    public void Log() {
        Debug.Log( "x >> " + x + ", y >> " + y + ", z >> " + z );
    }

    public Vector3 Unity() {
        return new Vector3( x, y, z );
        }
}
