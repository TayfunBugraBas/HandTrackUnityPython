using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCode : MonoBehaviour
{

    LineRenderer lnRender;

    public Transform origin;
    public Transform destination;



    // Start is called before the first frame update
    void Start()
    {

        lnRender = GetComponent<LineRenderer>();
        lnRender.startWidth = 0.1f;
        lnRender.endWidth = 0.1f;


        
    }

    // Update is called once per frame
    void Update()
    {
        lnRender.SetPosition(0,origin.position);
        lnRender.SetPosition(1,destination.position);
        

        
    }
}
