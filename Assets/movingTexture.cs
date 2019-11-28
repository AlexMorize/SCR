using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingTexture : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.GetComponentInParent<textureManagement>().loose)
        {
            float offset = Time.time * (GameObject.Find("Car").GetComponent<CarMove>().vitesse / 4);
            foreach (var item in GetComponent<Renderer>().materials)
            {
                item.SetTextureOffset("_MainTex", new Vector2(0, offset));
            }
        }
       
    }
}
