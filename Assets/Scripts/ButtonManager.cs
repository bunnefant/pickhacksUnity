using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private static string lastScene;
    private static int pickedUpEMR = 0;

    public void goToInventory(string scene)
    {
        lastScene = scene;
        SceneManager.LoadScene("Inventory");
    }

    public void goBack()
    {
        SceneManager.LoadScene(lastScene);
    }

    public void goToScene(string scene)
    {
        System.Random rand = new System.Random();
        int prob = rand.Next(1, 10);
        Debug.Log(scene);
        if (scene == "Bathroom" && pickedUpEMR == 0)
        {
            pickedUpEMR = 1;
            Debug.Log(pickedUpEMR);
            SceneManager.LoadScene("Bathroom_Don");
        }
        else if (prob <= 3 && (scene == "Stairs" || scene == "Elevators" || scene == "Underground" || scene == "Couches"))
        {
            //Debug.Log((scene == "Stairs" || scene == "Elevators" || scene == "Underground" || scene == "Couches"));
            SceneManager.LoadScene(scene + "_ghost");
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);  //Allow this object to persist between scene changes
    }
}
