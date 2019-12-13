using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleGenerator : MonoBehaviour
{

    public List<GameObject> obstacles;

    public float eachSeconds = 5;

    public int random = 10;

    public int old_numVoie = 1;
    public int old_numVoieSecondObject = 1;
    public int numVoie;

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
        int randomNumber = Random.Range(0, random);
        int randomNumber2 = Random.Range(0, 3);
        numVoie = Random.Range(0, 3);
        int numVoieSecondObject = CalculRandomNumVoie(numVoie);
        Debug.Log(numVoie);

        if((old_numVoie == 0 || old_numVoieSecondObject == 0) && (numVoie == 2 || numVoieSecondObject == 2) || (old_numVoie == 2 || old_numVoieSecondObject == 2) && (numVoie == 0 || numVoieSecondObject == 0))
        {
            numVoie = 0;
            numVoieSecondObject = 2;
        }

        old_numVoie = numVoie;
        old_numVoieSecondObject = numVoieSecondObject;


        // Obstacles
        if (randomNumber == 0)
        {
            int typeObstacles = Random.Range(0, 3);
            Instantiate(obstacles[typeObstacles], new Vector3(GameSettings.getCenterRoad(numVoie), 0, 50), Quaternion.identity);
        }

        if(randomNumber2 == 0)
        {
            int typeObstacles = Random.Range(0, 3);
            Instantiate(obstacles[typeObstacles], new Vector3(GameSettings.getCenterRoad(numVoieSecondObject), 0, 50), Quaternion.identity);
        }
        
    }


    int CalculRandomNumVoie(int numVoie)
    {
        int numVoieSecondObject = 0;

        if(numVoie == 0)
        {
            numVoieSecondObject = Random.Range(1, 3);
        } 
        else if (numVoie == 1)
        {
            int pivot = Random.Range(0, 2);
            if(pivot == 0)
            {
                numVoieSecondObject = 0;
            }
            else
            {
                numVoieSecondObject = 2;
            }
        }
        else
        {
            int pivot = Random.Range(0, 2);
            if (pivot == 0)
            {
                numVoieSecondObject = 0;
            }
            else
            {
                numVoieSecondObject = 1;
            }
        }
        return numVoieSecondObject;
    }
    
}
