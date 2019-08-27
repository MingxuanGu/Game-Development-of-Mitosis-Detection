using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ImageLoad : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Image;
    private RectTransform ImageTransform;
    private bool Up = true;
    void Awake()
    {
        //print("start");
        //, SearchOption.TopDirectoryOnly
        //string[] filePaths = Directory.GetFiles(Application.dataPath+"/Resources/", "*.jpg", SearchOption.AllDirectories);
        //List<string> pathlist = new List<string>();
        //foreach (string path in filePaths)
        //{

        //    pathlist.Add(Path.GetFileNameWithoutExtension(path));
        //}
        //string image_path = "image/" + Path.GetFileNameWithoutExtension(pathlist[0]);
        //print(image_path);
        //Sprite sprite = Resources.Load<Sprite>(image_path);

        //Image.GetComponent<Image>().sprite = sprite;
        //ImageTransform = transform.Find("Image").GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Up)
    //    {
    //        ImageTransform.anchoredPosition = new Vector2(0, -0.1f);
    //        Up = false;
    //    }
    //    else
    //    {
    //        ImageTransform.anchoredPosition = new Vector2(0, 0.1f);
    //        Up = true;
    //    }
    //}
}
