using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Controller : MonoBehaviour
{
    public GameObject Player;
    NavMeshAgent agent;

    bool isGeneratingNewPath = false;

    Vector3 currentPosition;
    Vector3 lastPosition;

    public Transform[] Steps;
    int stepsIndex = 0;

    bool doOnce = true;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if(gameObject.name == "Birgit")
        {
            BirgitFunction();
        }
        if(gameObject.name == "James")
        {

        }


    void BirgitFunction()
    {

            float distance = Vector3.Distance(Player.transform.position, transform.position);
            if (!isGeneratingNewPath)
            {
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

                    //Generating new destination
                    isGeneratingNewPath = true;
                    Debug.Log("Generating new destination to " + gameObject.name);

                    if (doOnce)
                    {
                        if (agent.remainingDistance == 0)
                        {
                            Debug.Log("täällä");
                            stepsIndex++;
                            Debug.Log(gameObject.name + " : " + stepsIndex);
                            doOnce = false;
                        }
                    }

                    int rnd = Random.Range(3, 15);

                    StartCoroutine(WaitAMoment(rnd, stepsIndex));
                }
            }
            else
            {
                isGeneratingNewPath = false;
            }
        }

    }
    void JamesFunction()
    {

    }

    IEnumerator WaitAMoment(int rnd, int i)
    {
        yield return new WaitForSeconds(rnd / 2);
    
        if (Player.gameObject.GetComponent<CharacterAnimation>().isCrouching == false)
        {
            yield return new WaitForSeconds(4.5f);
            //Goes to new destination
            Vector3 newDestination = new Vector3(Steps[i].position.x + rnd , 0, Steps[i].position.z + rnd);
            agent.SetDestination(newDestination);
            doOnce = true;

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
