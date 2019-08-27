/**
 * Author: Wenyu Zhang
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionControl : MonoBehaviour
{
    public float delay = 8f;
    private float time = 0;
    public string sceneNameToLoad = "Loading1";
    // Update is called once per frame
    void Update()
    {
        if (sceneNameToLoad == "")
        {
            return;
        }
		if (Input.GetMouseButtonDown(1))
		{
			SceneManager.LoadScene(sceneNameToLoad);
			print("mouse");
			
		}
        time += Time.deltaTime;
        if (time > delay)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
		
		
    }
}
