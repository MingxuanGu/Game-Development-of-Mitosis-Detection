/**
 * Author: Wenyu Zhang
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotDisappear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "rabbit")
        {
            ///print(collision.gameObject.name);
            Destroy(this.gameObject);
        }
    }
}
