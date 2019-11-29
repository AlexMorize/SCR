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
        if(other.name == "car(Clone)" || other.name == "wall(Clone)")
        {
            Dead(Vector3.forward*180,transform.position);
        }
        else if (other.name == "hole(Clone)")
        {
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
