using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{

    public bool canMove = false;
    public string Canmove = "";
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Canmove == "Yes")
        {        
            gameObject.transform.position = transform.position + new Vector3(0,2,0);
        }
    }
}
