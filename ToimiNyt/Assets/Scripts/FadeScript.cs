using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FadeScript : MonoBehaviour
{
    public Image startImage;
    public Animator anim;
    void Start()
    {
        //Alku animaatio
        anim = GetComponent<Animator>();
        anim.SetBool("StartFadeToGame", true);
    }
}
