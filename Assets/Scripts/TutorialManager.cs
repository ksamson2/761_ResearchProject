using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] TutorialPopUps;
    private int PopUpIndex = 0;
    public float WaitTime = 2f;
    public GameObject StartSpawnObstacles;

    // Update is called once per frame
    void Update()
    {

        if(PopUpIndex == 0)
        {
            TutorialPopUps[PopUpIndex].SetActive(true);
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.KeypadEnter)){
                TutorialPopUps[PopUpIndex].SetActive(false);
                PopUpIndex++;
            }
        }
        else if (PopUpIndex == 1)
        {
            TutorialPopUps[PopUpIndex].SetActive(true);
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.KeypadEnter)){
                TutorialPopUps[PopUpIndex].SetActive(false);
                PopUpIndex++;
            }
        }
        else if (PopUpIndex == 2)
        {
            TutorialPopUps[PopUpIndex].SetActive(true);
            //if (WaitTime < 0 )
            //{
            //    StartSpawnObstacles.SetActive(true);
            //} else
            //{
            //    WaitTime -= Time.deltaTime; 
            //}
            if ( Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.W))
            {
                TutorialPopUps[PopUpIndex].SetActive(false);
                PopUpIndex++;
            }
        }
        else if (PopUpIndex == 3)
        {
            TutorialPopUps[PopUpIndex].SetActive(true);
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                TutorialPopUps[PopUpIndex].SetActive(false);
                PopUpIndex++;
            }
        }
    }
}
