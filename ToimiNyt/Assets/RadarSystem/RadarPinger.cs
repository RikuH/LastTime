using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarPinger : MonoBehaviour
{
    public GameObject PingSphereRed;
    public GameObject PingSphereBlue;
    public GameObject PingSphereGreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Instantiate(PingSphereGreen, other.transform.position, new Quaternion(0, 0, 0, 0));
        }
        else if(other.tag == "NPC")
        {
            Instantiate(PingSphereBlue, other.transform.position, new Quaternion(0, 0, 0, 0));
        }

        else if(other.tag == "Goal")
        {
            Instantiate(PingSphereRed, other.transform.position, new Quaternion(0, 0, 0, 0));
        }
    }
}
