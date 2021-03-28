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
    bool isCrouched = false;

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
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if (agent.remainingDistance == 0)
        {
            AtStep(distance);
        }

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
            isCrouched = true;
        }
        else
        {
            GetComponent<CharacterAnimation>().isCrouching = false;
            isCrouched = false;
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

    void AtStep(float distance)
    {
        Debug.Log("Perillä");
        //Wait for the player
        if (distance < 2 && !isGenerating)
        {
            isGenerating = true;
            StartCoroutine(WaitForPlayer());
        }
    }

    IEnumerator GetUp()
    {
        yield return new WaitForSeconds(4.5f);
    }
    IEnumerator WaitForPlayer()
    {
        Debug.Log("Laskee viiteen");
        yield return new WaitForSeconds(5);
        if (!isCrouched)
        {
            yield return new WaitForSeconds(4.5f);
            agent.SetDestination(Steps[stepIndex].position);
            stepIndex++;

            Debug.Log("Uusimääränpää " + stepIndex);

            if (agent.remainingDistance > 0)
            {
                isGenerating = false;
            }
        }
        else
        {
            isGenerating = false;
        }
    }
}
