/**
 * Author: Zhaoya Pan
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarrotNum : MonoBehaviour
{
    
    public Text Carrot_number;
    public static int carrot_number = 5; // initially set to 5, should be get from user json
    // Start is called before the first frame update
    void Start()
    {
        GetInput.Player_Info player_info = Title.getPlayerInfo();
        carrot_number = player_info.carrots;
        DisplayCarrot();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCarrot();
    }

    public void DisplayCarrot()
    {
        Carrot_number.text = carrot_number.ToString();
    }

    //get number of carrot from database
    public void getCarrot()
    {
    }
}
