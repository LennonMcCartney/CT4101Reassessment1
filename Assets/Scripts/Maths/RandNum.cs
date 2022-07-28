using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandNum {

    public static int RandInt( int seed, int min, int max ) {
        int randInt = seed;
        randInt += min;
        randInt %= max;

        return randInt;
    }

}