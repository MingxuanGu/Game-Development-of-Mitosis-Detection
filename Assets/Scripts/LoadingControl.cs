/**
 * Author: Wenyu Zhang, Mingxuan Gu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 3f;
    private float time = 0;
    public string sceneNameToLoad = "UI1";
    // Update is called once per frame
    void Update()
    {
        if (sceneNameToLoad != "")
        {
            time += Time.deltaTime;
            if (time > delay)
            {
                SceneManager.LoadScene(sceneNameToLoad);
            }
        }
        	
    }
	public static void GameStart()
    {
        ///print("Start Game");
        SceneManager.LoadScene("WelcomeScene");
        
        
    }
	
	public void LoadRegistration()
	{

        SceneManager.LoadScene("Registration");
	}
	
	public void LoadTitle()
	{

        SceneManager.LoadScene("Title");
	}

    public void LoadLeaderBoard()
    {
        SceneManager.LoadScene("LeaderBoard");
    }

    public void LoadUI1()
    {
        SceneManager.LoadScene("UI1");
    }
}
