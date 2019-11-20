using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    
    public float vitesseGaucheDroite = 3;
    public float vitesseRotationAérienne = 50;
    public bool DéplacementLibre = true;

    public float currentHeight = 0;
    Vector2 angle;
    float currentPosition;
    int currentRoad;

    // Start is called before the first frame update
    void Start()
    {
        int voieCentral = currentRoad = GameSettings.instance.nbRoads / 2;

        currentPosition = GameSettings.getCenterRoad(voieCentral);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHeight == 0)//Si au sol
        {
            if (DéplacementLibre)//Déplacment libre
            {
                currentPosition += Input.GetAxisRaw("Horizontal") * vitesseGaucheDroite * Time.deltaTime;
                currentPosition = Mathf.Clamp(currentPosition, GameSettings.getCenterRoad(0), GameSettings.getCenterRoad(GameSettings.instance.nbRoads - 1));
            }
            else//Déplacement magnétique
            {
                if (Input.GetButtonDown("Horizontal"))
                {
                    if (Input.GetAxisRaw("Horizontal") > 0) currentRoad++;
                    if (Input.GetAxisRaw("Horizontal") < 0) currentRoad--;
                    currentRoad = Mathf.Clamp(currentRoad, 0, GameSettings.instance.nbRoads - 1);
                }
                float DéplacementLibre = GameSettings.getCenterRoad(currentRoad) - currentPosition;
                float Abs = Mathf.Abs(DéplacementLibre);
                float speedMove = vitesseGaucheDroite * Time.deltaTime;
                if (Abs < speedMove) currentPosition = GameSettings.getCenterRoad(currentRoad);
                else
                    currentPosition += DéplacementLibre / Abs * speedMove;

            }
        }else // si dans les aires
        {
            angle.x += Input.GetAxis("Horizontal") * Time.deltaTime * vitesseRotationAérienne;
           angle.y += Input.GetAxis("Vertical") * Time.deltaTime * vitesseRotationAérienne;

            transform.eulerAngles = Vector3.up * angle.x + Vector3.right * angle.y;
        }


        transform.position = currentPosition * Vector3.right + Vector3.up * (currentHeight+.76f);

    }

    private void ResetAngle()
    {
        //while(angle.x)
        
    }

    
}
