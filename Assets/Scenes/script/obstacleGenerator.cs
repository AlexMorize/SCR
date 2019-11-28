using System.Collections;
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

    void randomObstacles()
    {



    }
    void InstantiateObstacles()
    {
        int randomNumber = Random.Range(0, 5);
        int randomNumber2 = Random.Range(0, 5);

       

        //
        Debug.Log(GameSettings.getCenterRoad(1));

        // Obstacles
        if (randomNumber == 0)
        {
            int typeObstacles = Random.Range(0, 3);
            int numVoie = Random.Range(0, 3);
            // Vector3 newPosition = currentPosition * Vector3.right + Vector3.up * (currentHeight + .76f);
            Instantiate(obstacles[typeObstacles], new Vector3(GameSettings.getCenterRoad(numVoie), 0.19f, 50), Quaternion.identity);
        }

        if(randomNumber2 == 0)
        {
            int typeObstacles = Random.Range(0, 3);
            int numVoie = Random.Range(0, 3);
            // Vector3 newPosition = currentPosition * Vector3.right + Vector3.up * (currentHeight + .76f);
            Instantiate(obstacles[typeObstacles], new Vector3(GameSettings.getCenterRoad(numVoie), 0.19f, 50), Quaternion.identity);
        }
        
        // hole
/*        if(randomNumber == 4)
        {
            Instantiate(obstacles[1], new Vector3(GameSettings.getCenterRoad(0), 0.19f, 50), Quaternion.identity);
        }
        if (randomNumber == 5)
        {
            Instantiate(obstacles[1], new Vector3(GameSettings.getCenterRoad(1), 0.19f, 50), Quaternion.identity);
        }
        if (randomNumber == 6)
        {
            Instantiate(obstacles[1], new Vector3(GameSettings.getCenterRoad(2), 0.19f, 50), Quaternion.identity);        
        }

        // AI car
        if (randomNumber == 7)
        {
            Instantiate(obstacles[2], new Vector3(GameSettings.getCenterRoad(0), 0.19f, 50), Quaternion.identity);
        }
        if (randomNumber == 8)
        {
            Instantiate(obstacles[2], new Vector3(GameSettings.getCenterRoad(1), 0.19f, 50), Quaternion.identity);
        }
        if (randomNumber == 9)
        {
            Instantiate(obstacles[2], new Vector3(GameSettings.getCenterRoad(2), 0.19f, 50), Quaternion.identity);
        }*/


        

    }


    void GetCurrentPosition(int currentRoad)
    {

        Debug.Log(GameSettings.getCenterRoad(1));
/*
        currentRoad = Mathf.Clamp(currentRoad, 0, GameSettings.instance.nbRoads - 1);
        
        float DéplacementLibre = GameSettings.getCenterRoad(currentRoad) - currentPosition;
        float Abs = Mathf.Abs(DéplacementLibre);
        float speedMove = vitesseGaucheDroite * Time.deltaTime;
        if (Abs < speedMove)
        {
            currentPosition = GameSettings.getCenterRoad(currentRoad);
            DesiredAngle.y = 0;
        }
        else
        {
            currentPosition += DéplacementLibre / Abs * speedMove;
            DesiredAngle.y = DéplacementLibre / Abs * 5;
        }*/
    }
}
