using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_collison : MonoBehaviour
{

    public float crashForceRotation;
    public float crashForcePosition;
    public float crashUpPostion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (!enabled) return;
        Debug.Log(other.gameObject.name);
        if(other.gameObject.tag == "obstacle")
        {
            Debug.Log(" sa passe pas creme");
            CarMove car = GetComponent<CarMove>();
            Rigidbody rigid = GetComponent<Rigidbody>();
            rigid.constraints = RigidbodyConstraints.None;
            //rigid.velocity = Vector3.forward * car.vitesse + Vector3.up * 10;
            //rigid.angularVelocity = Vector3.right * 360 * car.vitesse /10 ; 
            //car.vitesse = 0;
            //rigid.constraints = RigidbodyConstraints.FreezePositionY;
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
            Debug.Log(car.vitesse);
            rigid.AddForce(Vector3.forward * car.vitesse * crashForcePosition);
            rigid.AddForce(Vector3.up * car.vitesse * crashUpPostion);
            rigid.AddTorque(Vector3.right * car.vitesse * crashForceRotation);
            Dead(transform.eulerAngles, transform.position);
            car.enabled = false;
            Destroy(this);
        }
        else if (other.gameObject.tag == "hole")
        {
            Debug.Log("sa passe creme");
            Dead(Vector3.right * 90, other.transform.position);
        }

    }

    private void Dead(Vector3 rotation , Vector3 position)
    {
        this.GetComponent<CarMove>().vitesse = 0;
        this.transform.rotation = Quaternion.Euler(rotation);
        //this.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z);
        this.transform.position = position;
        this.GetComponent<CarMove>().enabled = false;
        Destroy(GameObject.Find("obstacleGenerator"));
        GameObject.Find("road").GetComponent<textureManagement>().loose = true;
    }
}
