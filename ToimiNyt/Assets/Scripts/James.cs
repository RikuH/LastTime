using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class James : MonoBehaviour
{
    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if (distance < 2)
        {
            if (Player.gameObject.GetComponent<CharacterAnimation>().isCrouching == true)
            {
                GetComponent<CharacterAnimation>().isCrouching = true;
            }
            else
            {
                GetComponent<CharacterAnimation>().isCrouching = false;
            }

            if (Player.gameObject.GetComponent<CharacterAnimation>().isCrouching == false)
            {
                if (Player.GetComponent<Battery>().batteryIsCharging == true)
                {
                    Player.GetComponent<Battery>().batteryIsCharging = false;
                    Player.GetComponent<Battery>().batteryIsDraining = true;
                }
            }
            else
            {
                Debug.Log("NPC jäi odottamaan");
                Player.GetComponent<Battery>().batteryIsCharging = true;
            }
        }
    }
}
