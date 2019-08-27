/**
 * Author: Wenyu Zhang, Mingxuan Gu
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;

public class Title : MonoBehaviour
{
    public Text EmailText;
    public GameObject AlertWindow;
    public Text AlertText;
    public static string UserEmail = "";
    public static string path = "";
    

    void Awake()
    {
        AlertWindow.SetActive(false);
    }

    public void AlertSleep()
    {
        AlertWindow.SetActive(false);
    }

    public void Play()
    {
        UserEmail = EmailText.text;
    //C: \Users\hasee\AppData\LocalLow\DefaultCompany\mitobunny0707\Unity
        path = Application.persistentDataPath + "/Unity/" + UserEmail + ".json";
        if (!Validation.Validation.LocalEmailExistCheck(UserEmail))
        {
            if (!Validation.Validation.ServerEmailExistCheck(UserEmail))
            {
                AlertText.text = "The enter email has not been registered. Please register first.";
                AlertWindow.SetActive(true);
                return;
            }
            else
            {
                MysqlConnector mysqlConnector = new MysqlConnector();
                string query = "select * from runoob.player_info where email = \'" + UserEmail + "\';";
                List<string> result = mysqlConnector.Query(query)[0];
                
                savePlayerInfoWithListString(result);
            }
        }
        LoadingControl.GameStart();

    }
    public static GetInput.Player_Info getPlayerInfo()
    {
        string playerJson = File.ReadAllText(path);
        GetInput.Player_Info player_info = JsonConvert.DeserializeObject<GetInput.Player_Info>(playerJson);
        return player_info;
    }

    public static void savePlayerInfo(GetInput.Player_Info player_info)
    {
        string playerJson = JsonConvert.SerializeObject(player_info, Formatting.Indented);
        File.WriteAllText(path, playerJson);
    }

    public void savePlayerInfoWithListString(List<string> result)
    {
        GetInput.Player_Info player_Info = new GetInput.Player_Info()
        {
            Age = Convert.ToInt16(result[0]),
            City = result[1],
            Country = result[2],
            Email = result[3],
            FamilyName = result[4],
            FirstName = result[5],
            Institution = result[6],
            Level = Convert.ToInt16(result[7]),
            Score = float.Parse(result[8]),
            Sex = result[9],
            password = result[10],
            carrots = Convert.ToInt16(result[11])
        };

        savePlayerInfo(player_Info);
    }
}
