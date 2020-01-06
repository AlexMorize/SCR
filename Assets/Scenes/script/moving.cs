using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{

    public Vector3 positionInitial;
    public float disntanceFinal = -17.32f;
    public float vitesse = 5;
    public CarMove car;

    private Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.FindObjectOfType<CarMove>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (car)
        {
            rigid.velocity = -Vector3.forward * car.vitesse;
            //this.transform.position += new Vector3(0, 0, -1 * Time.deltaTime * car.GetComponent<CarMove>().vitesse);
        }
        
        if ( this.gameObject.CompareTag("obstacle") && this.transform.position.z < disntanceFinal)
        {
            Destroy(gameObject);
        }
    }
}
