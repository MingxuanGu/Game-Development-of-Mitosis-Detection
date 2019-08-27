/**
 * Author: Mingxuan Gu
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using UnityEngine;
using UnityEngine.UI;

class MysqlConnector
{
    //public GameObject AlertWindow;
    //public Text AlertText;
    public static string connstring;
    private string Server;
    private string Port;
    private string Database;
    private string UserName;
    private string Password;
    public MySqlConnection conn;
    public MySqlCommand command;

    //void Awake()
    //{
    //    AlertWindow.SetActive(false);
    //}
    //public void AlertSleep()
    //{
    //    AlertWindow.SetActive(false);
    //}
    public MysqlConnector()
    {
        Server = "127.0.0.1";
        Port = "3306";
        Database = "runoob";
        UserName = "root";
        Password = "1234";
        connstring = "Server=" + Server + ";port=" + Port + ";Database=" + Database + ";Username=" + UserName + ";password=" + Password + ";";
        conn = new MySqlConnection(connstring);
        command = conn.CreateCommand();
    }
    public List<List<string>> Query(string query)
    {
        List<List<string>> result = new List<List<string>>();
        command.CommandText = query;
        try
        {
            conn.Open();
            //AlertText.text = "Connection open!";
            //AlertWindow.SetActive(true);
            Debug.Log("Connection open!");
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new List<string>());
                int Count = reader.FieldCount;
                for (int i = 0; i < Count; i++)
                {
                    Debug.Log(reader.GetString(i));
                    result.Last().Add(reader.GetString(i));
                }

            }
            reader.Close();
            conn.Close();
        }
        catch (Exception ex)
        {
            //AlertWindow.SetActive(true);
            //AlertText.text = ex.Message;
            Debug.Log(ex.Message);
        }
        return result;
    }
        
}

