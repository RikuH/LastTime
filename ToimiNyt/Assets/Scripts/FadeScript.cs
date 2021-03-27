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
    public Image endImage;
    public Image startImage;
    public Animator anim;
    void Start()
    {
        //Alku animaatio
        anim = GetComponent<Animator>();
        anim.SetBool("StartFadeToGame", true);
    }

    private void Update()
    {
    }

    IEnumerator PrologyTimer()
    {
        yield return new WaitForSeconds(23);
        //player.gameObject.SetActive(true);
        //animationGirl.SetActive(false);
        //BedroomLight.SetActive(true);
        //prologyIsOver = true;
        //player.agent.enabled = true;
    }

    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2);
        anim.SetBool("EndImageFade", true);
        //SceneManager.LoadScene("MainMenu");
    }

}
