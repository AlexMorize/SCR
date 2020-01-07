using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    CarMove car;
    public float Score;


    // Start is called before the first frame update
    void Start()
    {
        car = FindObjectOfType<CarMove>();

    }

    // Update is called once per frame
    void Update()
    {
        Score += car.vitesse * Time.deltaTime;
    }
}
