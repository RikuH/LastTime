using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Birgit : MonoBehaviour
{
    public GameObject Player;
    NavMeshAgent agent;

    public Transform[] Steps;
    int stepIndex = 0;

    bool isGenerating = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(Steps[stepIndex].position);
        stepIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance == 0)
        {

        }

        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if (distance < 2)
        {
            ChargeBattery();
        }
    }

    void ChargeBattery()
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

    void AtStep()
    {

    }
}
