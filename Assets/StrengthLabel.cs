using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StrengthLabel : MonoBehaviour
{
    float strengthStat = 0f;
    void Awake() {
        GameEvents.StatIncrease += OnStatIncrease;
    }

    void OnStatIncrease(object sender, StatEventArgs args){
        if (args.statType == "strength"){
            strengthStat += args.statIncrease;
        } 
    }

    void Update()
    {
            GetComponent<TextMeshProUGUI>().text = "Strength: " + strengthStat.ToString();
    }
}
