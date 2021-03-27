using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Animator anim;

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
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);

        }
        lastPosition = currentPosition;

        if (isCrouching)
        {
            anim.SetBool("isCoruching", true);
            GameObject.FindGameObjectWithTag("Neck").GetComponent<MouseLook>().mouseEnabled = false;
        }
        else
        {
            anim.SetBool("isCoruching", false);
            GameObject.FindGameObjectWithTag("Neck").GetComponent<MouseLook>().mouseEnabled = true;

        }
    }
}
