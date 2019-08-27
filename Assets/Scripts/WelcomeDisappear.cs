/**
 * Author: Wenyu Zhang
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeDisappear : MonoBehaviour
{
    // Start is called before the first frame update
	public float delay = 1f;
    private float time = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
	
    void Update()
    {
		time += Time.deltaTime;
        if (time > delay)
        {
            Destroy(this.gameObject);
        }
        
    }
}
