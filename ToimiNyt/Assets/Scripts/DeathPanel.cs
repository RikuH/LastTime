using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathPanel : MonoBehaviour
{
    public GameObject panel;
    public Button batotomenu;
    // Start is called before the first frame update
    void Start()
    {
        batotomenu.onClick.AddListener(backtomenumeth);
    }

    void backtomenumeth()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
