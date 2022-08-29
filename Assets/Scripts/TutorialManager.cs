using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    public GameObject[] TutorialPopUps;
    private int PopUpIndex = 0;
    public GameObject StartSpawnObstacles;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PopUpIndex += 6;
            for (int i = 0; i < TutorialPopUps.Length; i++)
            {
                TutorialPopUps[i].SetActive(false);
            }
            SpawnObstacles.ShouldSpawnObstacles = true;
        }

        if (PopUpIndex == 0)
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
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)){
                TutorialPopUps[PopUpIndex].SetActive(false);
                PopUpIndex++;
                CameraMovement.Pause = false;
            }
        }
        else if (PopUpIndex == 2)
        {
            TutorialPopUps[PopUpIndex].SetActive(true);
            if ( Input.GetKeyDown(KeyCode.W))
            {
                TutorialPopUps[PopUpIndex].SetActive(false);
                PopUpIndex++;
            }
            SpawnObstacles.ShouldSpawnObstacles = true;
        }
    }
}
