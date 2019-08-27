/**
 * Author: Zhaoya Pan, Mingxuan Gu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using Newtonsoft.Json;

public class GetScore : MonoBehaviour
{
    public Text Score_Text;
    
    MysqlConnector mysqlConnector = new MysqlConnector();
    // Start is called before the first frame update
    void Start()
    {
        Score_Text.text = Score.score.ToString();


        //update the json file
        GetInput.Player_Info player_info = Title.getPlayerInfo();
        float newScore = Math.Max(Score.score, player_info.Score);
        player_info.Score = newScore;
        Title.savePlayerInfo(player_info);

        //update the database
        string query = @"update runoob.player_info set score = " + newScore.ToString() + " where email = \'"+ Title.UserEmail +"\';";
        mysqlConnector.Query(query);
    }
    
}
