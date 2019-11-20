using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings instance { get; private set; }

    public int nbRoads = 3;
    public float widthRoads = 3;

    public static float getCenterRoad(int numRoad)
    {
        return (.5f + numRoad) * instance.widthRoads;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

}
