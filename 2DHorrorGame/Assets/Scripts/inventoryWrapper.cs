using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryWrapper : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        //inventory.updateTool(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click(int clue)
    {
        inventory.updateTool(clue);
    }
}
