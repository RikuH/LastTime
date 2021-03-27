using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    Animator anim;

    Vector3 currentPosition;
    Vector3 lastPosition;

    public bool isCrouching = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        lastPosition = currentPosition;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        if(currentPosition != lastPosition)
        {
            Debug.Log("Kavelee");
            anim.SetBool("isWalking", true);
        }
        else
        {
            Debug.Log("ei Kavelee");
            anim.SetBool("isWalking", false);

        }
        lastPosition = currentPosition;

        if (isCrouching)
        {
            anim.SetBool("isCoruching", true);
            GameObject.Find("mixamorig_Neck").GetComponent<MouseLook>().mouseEnabled = false;
        }
        else
        {
            anim.SetBool("isCoruching", false);
            GameObject.Find("mixamorig_Neck").GetComponent<MouseLook>().mouseEnabled = true;

        }
    }
}
