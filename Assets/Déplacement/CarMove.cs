using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{

    public float vitesse = 5;
    public float vitesseGaucheDroite = 3;
    public float vitesseRotationAérienne = 50;
    public float vitesseRotationSol = 720;
    public bool DéplacementLibre = true;
    public bool AssistForLandscape = true;
    public float angleRotation = 5;
    public Camera cam;

    public float currentHeight = 0;

    float heightSpeed;
    Vector3 angle = new Vector3();
    Vector3 DesiredAngle = new Vector3();
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
        Vector3 camPos = cam.transform.position;
        camPos.y = currentHeight + 5;
        cam.transform.position = camPos;


        if (DéplacementLibre)//Déplacment libre
        {
            currentPosition += Input.GetAxisRaw("Horizontal") * vitesseGaucheDroite * Time.deltaTime;
            DesiredAngle.y = Input.GetAxisRaw("Horizontal") * angleRotation;
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
            if (Abs < speedMove)
            {
                currentPosition = GameSettings.getCenterRoad(currentRoad);
                DesiredAngle.y = 0;
            }
            else
            {
                currentPosition += DéplacementLibre / Abs * speedMove;
                DesiredAngle.y = DéplacementLibre / Abs * 5;
            }

        }
        if (currentHeight == 0)//Si au sol
        {
            ResetAngle();
            
        }else // si dans les aires
        {
            heightSpeed -= GameSettings.instance.GravityAcceleration * Time.deltaTime;

           

            Vector3 previousAngle = angle;
            angle.z += Input.GetAxisRaw("Horizontal") * Time.deltaTime * vitesseRotationAérienne;
           angle.x += Input.GetAxisRaw("Vertical") * Time.deltaTime * vitesseRotationAérienne;

            if (angle != previousAngle)
                transform.eulerAngles = Vector3.forward * angle.z + Vector3.right * angle.x;
            else if (AssistForLandscape) ResetAngle();

        }

        currentHeight += heightSpeed * Time.deltaTime;

        if (currentHeight < 0)
        {
            heightSpeed = 0;
            currentHeight = 0;
        }



        //Chute
        transform.position = currentPosition * Vector3.right + Vector3.up * (currentHeight+.76f);

    }

    private void ResetAngle()
    {
        Quaternion TargetRotation = Quaternion.Euler(DesiredAngle);

        float vitesseRotation = currentHeight > 0 ? vitesseRotationAérienne : vitesseRotationSol;

        float indiceRotation = vitesseRotation / (Vector3.Angle(Vector3.up, transform.up) + Vector3.Angle(Vector3.forward, transform.forward));
        indiceRotation *= Time.deltaTime;
        if (indiceRotation > 1) indiceRotation = 1;
        

        transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, indiceRotation);

        angle = transform.rotation.eulerAngles;
        

        /*if ((DesiredAngle - angle).magnitude < vitesseRotationAérienne * Time.deltaTime) DesiredAngle = Vector2.zero;
        else angle += DesiredAngle - angle / angle.magnitude * vitesseRotationAérienne * Time.deltaTime;*/
    }

    public void DoJump()
    {
        heightSpeed = vitesse / 3;
    }

    
}
