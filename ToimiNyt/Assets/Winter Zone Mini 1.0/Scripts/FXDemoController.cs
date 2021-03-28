using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FXDemoController : MonoBehaviour
{
    public GameObject fx_Snow;
    public GameObject fx_audio;

    void Update()
    {       
            Snow();
    }




    public void Snow()
    {
        fx_Snow.SetActive(true);
        Debug.Log("Snow");
    }

}
