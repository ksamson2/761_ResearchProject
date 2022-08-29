using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayGoal : MonoBehaviour
{
    public GameObject GoalCanvas;
    public Text CollectFlowersTotal;
    // Start is called before the first frame update

    public float Rate; 
    void Update()
    {
        if(Time.timeSinceLevelLoadAsDouble < Rate)
        {
            var TotalFlowers = PlayerPrefs.GetFloat("FlowerBadgesTotal");
            if (TotalFlowers <= 10)
            {
                CollectFlowersTotal.text = "10";
            }
            else
            {
                TotalFlowers++;
                CollectFlowersTotal.text = TotalFlowers.ToString();
            } 
            GoalCanvas.SetActive(true);
        } else
        {
            GoalCanvas.SetActive(false);
        }
    }
}
