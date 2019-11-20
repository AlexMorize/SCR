﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleGenerator : MonoBehaviour
{

    public List<GameObject> obstacles;

    public float eachSeconds = 5;

    public int random = 10;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateObstacles", 0, eachSeconds);
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

    void InstantiateObstacles()
    {
        int randomNumber = Random.Range(0, random);
        
        // Obstacles
        if (randomNumber == 0)
        {
            Instantiate(obstacles[0], new Vector3(-7.57f, 0.79f, 17.66f), Quaternion.identity);
        }
        if (randomNumber == 1)
        {
            Instantiate(obstacles[0], new Vector3(-0.44f, 0.79f, 17.66f), Quaternion.identity);
        }
        if (randomNumber == 2)
        {
            Instantiate(obstacles[0], new Vector3(6.69f, 0.79f, 17.66f), Quaternion.identity);
        }
        
        // hole
        if(randomNumber == 4)
        {
            Instantiate(obstacles[1], new Vector3(-7.57f, 0.201f, 17.66f), Quaternion.identity);
        }
        if (randomNumber == 5)
        {
            Instantiate(obstacles[1], new Vector3(-0.44f, 0.201f, 17.66f), Quaternion.identity);
        }
        if (randomNumber == 6)
        {
            Instantiate(obstacles[1], new Vector3(6.69f, 0.201f, 17.66f), Quaternion.identity);        
        }

        // AI car
        if (randomNumber == 7)
        {
            Instantiate(obstacles[2], new Vector3(-7.57f, 0.201f, 17.66f), Quaternion.identity);
        }
        if (randomNumber == 8)
        {
            Instantiate(obstacles[2], new Vector3(-0.44f, 0.201f, 17.66f), Quaternion.identity);
        }
        if (randomNumber == 9)
        {
            Instantiate(obstacles[2], new Vector3(6.69f, 0.201f, 17.66f), Quaternion.identity);
        }

    }
}
