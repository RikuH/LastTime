using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public Button StartBtn;
    public Button CreditsBtn;
    public Button BackBtn;
    public Button QuitBtn;

    public FrostEffect Frost;
    public float frostValue = 0.00f;

    public GameObject CreditsPanel;
    public GameObject MainPanel;

    public GameObject tekstiJuttu;
    bool FrostIsStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        StartBtn.onClick.AddListener(StartGame);
        CreditsBtn.onClick.AddListener(CreditsPanelActive);
        BackBtn.onClick.AddListener(BackToMain);
        QuitBtn.onClick.AddListener(QuitGame);
        Screen.SetResolution(1920, 1080, true);
    }

    private void Update()
    {
        if(FrostIsStarted)
        {
        Frost.FrostAmount = frostValue;
        frostValue += 0.0004f;
            if(frostValue >= 1)
            {
                FrostIsStarted = false;
            }
        }
    }

    void StartGame()
    {
        tekstiJuttu.SetActive(true);
        MainPanel.SetActive(false);
        
        StartCoroutine(writeText());
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void CreditsPanelActive()
    {
        CreditsPanel.SetActive(true);
        MainPanel.SetActive(false);

    }

    void BackToMain()
    {
        CreditsPanel.SetActive(false);
        MainPanel.SetActive(true);
    }

    IEnumerator DialogyDealay()
    {
        yield return new WaitForSeconds(3);

        Debug.Log("Aloita");
        //SceneManager.LoadScene("SampleScene");
    }

    float TextDelay = 0.1f;

    int lineIndex = 0;

    string textOne = "We have calcium in our bones, iron in our veins, carbon in our souls and nitrogen in our brains";
    string textTwo = "Our universe contains these same elements";
    string textThree = "Without these elements we might not even exist";
    string textFour = "They say home is where your heart is";
    string textFive = "But what if that place where your heart belong is incapable of surviving there";
    string textSix = "It's been 10 long years since we left the earth";
    string textSeven = "When we escaped and I looked back at the earth I cried";
    string textEight = "We all saw how our beautiful planet lost the fight";
    string textNine = "It's been 10 long years and we are the last humans from the Earth in this solar system";
    string textTen = "People have lived in this ship that we, researchers had built before the new glacial period";
    string textEleven = "It's the only place that we can live now";
    string textTwelve = "We have orbited the Earth 10 years and waited that we get some sign of life from the Earth";
    string textThirdtheen = "But nothing has appeared in a 10 long years";
    string textFourthteen = "Until now";

    string currentText = "";

    public Text Liibalaaba;
    public IEnumerator writeText()
    {
        yield return new WaitForSeconds(2);
        string fullText = "";
        for (int a = 0; a <= lineIndex; a++)
        {
            if (lineIndex == 0)
                fullText = textOne;
            else if (lineIndex == 1)
                fullText = textTwo;
            else if (lineIndex == 2)
                fullText = textThree;
            else if (lineIndex == 3)
                fullText = textFour;
            else if (lineIndex == 4)
                fullText = textFive;
            else if (lineIndex == 5)
                fullText = textSix;
            else if (lineIndex == 6)
                fullText = textSeven;
            else if (lineIndex == 7)
            {
                fullText = textEight;
                FrostIsStarted = true;
            }
            else if (lineIndex == 8)
                fullText = textNine;
            else if (lineIndex == 9)
                fullText = textTen;
            else if (lineIndex == 10)
                fullText = textEleven;
            else if (lineIndex == 11)
                fullText = textTwelve;
            else if (lineIndex == 12)
                fullText = textThirdtheen;
            else if (lineIndex == 13)
                fullText = textFourthteen;



            //Debug.Log(lineIndex);
            for (int i = 0; i <= fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i);
                Liibalaaba.text = currentText;
                yield return new WaitForSeconds(TextDelay);
            }

            yield return new WaitForSeconds(1);
            if (lineIndex < 13)
            {
                lineIndex++;
                Debug.Log(fullText + lineIndex);
            }
        }

        StartCoroutine(DialogyDealay());
    }
}
