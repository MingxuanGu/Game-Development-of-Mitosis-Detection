/**
 * Author: Mingxuan Gu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using Newtonsoft.Json;

public class GetCarrot : MonoBehaviour
{
    public Text Carrot_Text;
    MysqlConnector mysqlConnector = new MysqlConnector();
    // Start is called before the first frame update
    void Start()
    {
        if (Score.score > 0)
        {
            int carrots_get = Convert.ToInt16(Math.Round(Score.score / 1000));
            Carrot_Text.text = carrots_get.ToString();

            //update the json file
            GetInput.Player_Info player_info = Title.getPlayerInfo();
            int newCarrotsNum = carrots_get + player_info.carrots;
            player_info.carrots = newCarrotsNum;
            Title.savePlayerInfo(player_info);

            //update the database
            string query = "update runoob.player_info set carrots = " + newCarrotsNum.ToString() + " where email = \'" + Title.UserEmail + "\';";
            mysqlConnector.Query(query);
        }
            
        else
            Carrot_Text.text = "0";

        // add carrot to user json
    }
}
