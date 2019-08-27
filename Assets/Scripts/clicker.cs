using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class clicker : MonoBehaviour
{
    // Start is called before the first frame update

    public Image bunny;
    public Canvas canvas;
    int index = 1;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
                    
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity);

            var point = mousePos;
            
            if (point.x >= -3.5 && point.x <=7.3 && point.y >= -4.7 && point.y <= 4.7)

            {
                if (point.x < -2.1 && point.y < -3.2)
                    return;

                if (point.x > 5.6 && point.y < -3.2)
                    return;

                Image tmp = Instantiate(bunny, canvas.transform);
                tmp.tag = "Player";
                tmp.gameObject.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
                print(Input.mousePosition);

                //tmp.gameObject.transform.position = new Vector3(point.x, point.y, point.z);

                string path = "/Users/umer/Desktop/coordinates.txt";
                if (!File.Exists(path))
                {
                    using (StreamWriter writer = File.CreateText(path))
                    {
                        writer.Write("Image: " + index + "     ");
                        writer.Write(point.x + "     ");
                        writer.WriteLine(point.y);
                        index++;
                    }
                }
                else
                {
                    using (StreamWriter writer = File.AppendText(path))
                    {
                        writer.Write("Image: " + index + "     ");
                        writer.Write(point.x + "     ");
                        writer.WriteLine(point.y);
                        index++;
                    }
                }



            }

        }
    }


    public double minmax(double x, double max, double min, double new_max, double new_min)
    {

        x = (x - min) * (new_max - new_min) / (max - min) + new_min;
        return x;


    }





}

