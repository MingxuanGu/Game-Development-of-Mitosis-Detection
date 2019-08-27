/**
 * Author: Wenyu Zhang
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            print("Game has quit");
        }
    }
    public void exit()
    {
        Application.Quit();
        print("Game has quit");

    }

}
