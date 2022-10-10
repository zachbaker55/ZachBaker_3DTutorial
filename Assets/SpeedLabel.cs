using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedLabel : MonoBehaviour
{
    float speedStat = 0f;
    void Awake() {
        GameEvents.StatIncrease += OnStatIncrease;
    }

    void OnStatIncrease(object sender, StatEventArgs args){
        if (args.statType == "speed"){
            speedStat += args.statIncrease;
        } 
    }

    void Update()
    {
            GetComponent<TextMeshProUGUI>().text = "Speed: " + speedStat.ToString();
    }
}
