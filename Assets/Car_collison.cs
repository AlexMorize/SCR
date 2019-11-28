using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_collison : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.name == "car(Clone)")
        {
            this.GetComponent<CarMove>().vitesse = 0;
            this.transform.rotation = Quaternion.Euler(0, 0, 180);
            Destroy(this.GetComponent<CarMove>());
            Destroy(GameObject.Find("obstacleGenerator"));
            GameObject.Find("road").GetComponent<textureManagement>().loose = true;
        }
        if (other.name == "hole(Clone)")
        {
            this.GetComponent<CarMove>().vitesse = 0;
            this.transform.rotation = Quaternion.Euler(90, 0, 0);
            this.transform.position = new Vector3(other.transform.position.x , other.transform.position.y, other.transform.position.z); 
            Destroy(this.GetComponent<CarMove>());
            Destroy(GameObject.Find("obstacleGenerator"));
            GameObject.Find("road").GetComponent<textureManagement>().loose = true;
        }
        if (other.name == "wall(Clone)")
        {
            this.GetComponent<CarMove>().vitesse = 0;
            this.transform.rotation = Quaternion.Euler(0, 0, 180);
            Destroy(this.GetComponent<CarMove>());
            Destroy(GameObject.Find("obstacleGenerator"));
            GameObject.Find("road").GetComponent<textureManagement>().loose = true;
        }
        
    }
}
