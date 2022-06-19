using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handTrack : MonoBehaviour
{
    // Start is called before the first frame update

    public UDPReceive udpReceiver;
    public GameObject[] handPoints;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        string data = udpReceiver.data;
        data = data.Remove(0,1);
        data = data.Remove(data.Length - 1, 1);
        string[] points = data.Split(',');

        for(int i = 0; i < 41; i++){

              float x = float.Parse(points[i*3])/80-8;;
              float y = float.Parse(points[i*3+1])/80-5;
              float z = float.Parse(points[i*3+2])/80;
              

              handPoints[i].transform.localPosition = new Vector3(-x,y,-z);


        }
        


    }
}
