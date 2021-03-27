using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    float BatteryCharge;

    public bool batteryIsDraining = true;
    public bool batteryIsCharging = false;
    int BatteryPercentage;

    public Text BatteryText;
    float RedValue = 0f;

    public Sprite[] BatteryImages;
    public Image bImage;
    int BatteryImageIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        BatteryCharge = 101f;
    }

    // Update is called once per frame
    void Update()
    {
        if (batteryIsCharging && BatteryCharge <= 100)
        {
            BatteryCharge += 0.05f;
            RedValue -= 0.05f;
            batteryIsDraining = false;
        }

        if (batteryIsDraining && BatteryCharge >= 0)
        {
            BatteryCharge -= 0.005f;
            RedValue += 0.005f;
        }

        BatteryPercentage = (int)BatteryCharge;
        BatteryText.text = BatteryPercentage.ToString() + "%";
        BatteryText.GetComponent<Text>().color = new Color(RedValue / 2 / 100, BatteryCharge / 2 / 100, BatteryCharge / 100, 1);
  

        if (BatteryCharge > 75)
            BatteryImageIndex = 0;
        else if (BatteryCharge > 50)
            BatteryImageIndex = 1;
        else if (BatteryCharge > 25)
            BatteryImageIndex = 2;
        else if (BatteryCharge > 10)
            BatteryImageIndex = 3;
        else if (BatteryCharge < 2)
            BatteryImageIndex = 4;


        bImage.sprite = BatteryImages[BatteryImageIndex];
    }
}
