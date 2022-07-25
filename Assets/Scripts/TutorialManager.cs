using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] TutorialPopUps;
    private int PopUpIndex;
    public float WaitTime = 2f;
    public GameObject StartSpawnObstacles;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < TutorialPopUps.Length; i++)
        {
            if(i == PopUpIndex)
            {
                TutorialPopUps[PopUpIndex].SetActive(true);
            }
            else
            {
                TutorialPopUps[PopUpIndex].SetActive(false);
            }
        }

        if(PopUpIndex == 0)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){
                PopUpIndex++;
            }
        }
        else if (PopUpIndex == 1)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){
                PopUpIndex++;
            }
        }
        //else if (PopUpIndex == 2)
        //{
        //    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        //    {
        //        PopUpIndex++;
        //    }
        //}
        else if (PopUpIndex == 2)
        {
            if(WaitTime < 0 )
            {
                StartSpawnObstacles.SetActive(true);
            } else
            {
                WaitTime -= Time.deltaTime; 
            }
        }
    }
}
