/**
 * Author: Wenyu Zhang
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movebunny : MonoBehaviour
{
    public float speed = 0.02f;
    public float force = 0.5f;
    int num_carrots = 0;
    public Rigidbody2D rigid2D;
	private float time = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        //print("Start");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
		if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position -= new Vector3(speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigid2D.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }
		this.gameObject.transform.position += new Vector3(speed* time, 0, 0);

        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "carrot")
        {
            num_carrots += 1;
            //print(num_carrots);


        }
    }
}
