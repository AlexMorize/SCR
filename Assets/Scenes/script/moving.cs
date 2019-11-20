using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{

    public Vector3 positionInitial;
    public float disntanceFinal = -17.32f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        this.transform.position += new Vector3(0, 0, -1 * Time.deltaTime * 5) ;

        Debug.Log(this.transform.position.z);
        if (this.transform.position.z < disntanceFinal)
        {
            Destroy(gameObject);
        }
    }
}
