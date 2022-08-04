using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandNum {

	static long seed;

	// Values taken from Microsoft Visual C++ compiler
	static int a = 214013;
	static int c = 2531011;
	static long m = 4294967296;

	public static void SetSeed( int aSeed ) {
		seed = aSeed;
	}

	public static long NextRand() {
		seed = ( a * seed + c ) % m;
		return seed;
	}

}