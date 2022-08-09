using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int LeavesTotal;

    public Image[] Leaves;
    public Sprite FullLeaf;
    public Sprite LeafOutline;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Leaves.Length; i++)
        {
            if(i < PlayerCollision.MarshmallowPoints)
            {
                Leaves[i].sprite = FullLeaf;
            }
            else
            {
                Leaves[i].sprite = LeafOutline;
             
            }
            if(i < LeavesTotal)
            {
                Leaves[i].enabled = true;
            } else
            {
                Leaves[i].enabled = false;
            }
        }
    }
}
