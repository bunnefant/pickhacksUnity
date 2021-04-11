using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    /*public Image EMF;
    public Image Salt;
    public Image UV;
    public Image Spiritbox;*/

    public Image[] Tools;
    public Image[] Clues;

    public static int[] toolsArr = new int[4]; // [1,0,0]
    public static int[] cluesArr = new int[4]; // [1,0,0]

    // Start is called before the first frame update
    void Start()
    {
        Tools[0].enabled = true;
        Tools[1].enabled = true;
        Tools[2].enabled = true;
        Tools[3].enabled = false;
        foreach (Image image in Clues)
        {
            image.enabled = false;
        }
        //toolsArr = new int[4];
        //cluesArr = new int[4];
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < toolsArr.Length; i++)
        {
            if (toolsArr[i] == 1)
            {
                Tools[i].enabled = true;
            }
        }

        for (int i = 0; i < cluesArr.Length; i++)
        {
            if (cluesArr[i] == 1)
            {
                Clues[i].enabled = true;
            }
        }


        /*if ()    //tool is clicked or found
        {
            Tools[0].enabled = true;
        }
        else if ()
        {
            Tools[1].enabled = true;
        }
        else if ()
        {
            Tools[2].enabled = true;
        }
        else if ()
        {
            Tools[3].enabled = true;
        }*/
    }


    public static void updateTool(int tool)
    {
        toolsArr[tool] = 1;
    }

    public static void updateClue(int clue)
    {
        cluesArr[clue] = 1;
    }
}
