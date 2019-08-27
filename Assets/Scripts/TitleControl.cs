/**
 * Author: Wenyu Zhang
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleControl : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        //print("Start Game");
        SceneManager.LoadScene("WelcomeScene");
        
        
    }
}
