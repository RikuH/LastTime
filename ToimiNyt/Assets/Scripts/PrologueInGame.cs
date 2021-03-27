using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrologueInGame : MonoBehaviour
{

    public GameObject tekstiJuttu;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    private void Update()
    {
    }

    void StartGame()
    {
        StartCoroutine(delay());

    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(2);
        tekstiJuttu.SetActive(true);
        StartCoroutine(writeText());
    }

    IEnumerator DialogyDealay()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Aloita pelaaminen");
        tekstiJuttu.SetActive(false);
    }

    float TextDelay = 0.1f;

    int lineIndex = 0;

    string textOne = "James: In your hand is monitor where you can see the locate of the signal. Got it?";
    string textTwo = "Birgit: In your helmet you can see your suit battery.";
    string textThree = "Birgit: You can charge your suit by coming to me or to James.";
    string textFour = "Birgit: If your suit battery runs out of power you have 10 seconds to charge your suit or you will freeze to death.";
    string textFive = "Birgit: Understood?";
    string textSix = "James: Okey, let's find that source.";

    string currentText = "";

    public Text Liibalaaba;
    public IEnumerator writeText()
    {

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



            //Debug.Log(lineIndex);
            for (int i = 0; i <= fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i);
                Liibalaaba.text = currentText;
                yield return new WaitForSeconds(TextDelay);
            }

            yield return new WaitForSeconds(0.5f);
            if (lineIndex < 5)
            {
                lineIndex++;
                Debug.Log(fullText + lineIndex);
            }
        }

        StartCoroutine(DialogyDealay());
    }
}
