/***
 * Author: Mingxuan Gu, Wenyu Zhang
 **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using Newtonsoft.Json;
//using UnityEditor;
//using MySql.Data.MySqlClient;

using SimpleJSON;


public class GetInput : MonoBehaviour
{
    public Text inputFirstName;
    public Text inputFamilyName;
    public Text inputAge;
    public Text inputCity;
    public Text inputCountry;
    public Text inputEmail;
    public Text inputInstitution;
    public GameObject inputMale;

    public GameObject AlertWindow;
    public Text AlertText;
    public GameObject AlertWindow2;
    public string FirstName = "";
    public string FamilyName = "";
    public int Age = 0;
    public string City = "";
    public string Country = "";
    public string Email = "";
    public string Institution = "";
    public int Level = 0;
    public int Score = 0;
    public bool ifMale = true;
    public List<string> sexchoice = new List<string>() { "Male", "Female" };


    void Awake()
    {
        AlertWindow.SetActive(false);
        AlertWindow2.SetActive(false);
    }

    public void AlertSleep()
    {
        AlertWindow.SetActive(false);
    }

    ///Get information from users from the inputfields. 
    public void InputFirstName()
    {

        FirstName = inputFirstName.text;
    }
    public void InputFamilyName()
    {
        FamilyName = inputFamilyName.text;
    }

    public void InputAge()
    {
        Age = Convert.ToInt16(inputAge.text);
    }

    public void InputCity()
    {
        City = inputCity.text;
    }


    public void InputCountry()
    {
        Country = inputCountry.text;
    }

    public void InputEmail()
    {
        Email = inputEmail.text;
    }

    public void InputInstitution()
    {
        Institution = inputInstitution.text;
    }

    public void InputMale()
    {
        ifMale = inputMale.GetComponent<Toggle>().isOn;
        //print(Male);
    }

    //// Save and load the information of users in a jason file.
    public void Save()
    {
        string Sex = sexchoice[0];
        if (!ifMale) Sex = sexchoice[1];
        Player_Info _data = new Player_Info()
        {
            Email = Email,
            FirstName = FirstName,
            FamilyName = FamilyName,
            Age = Age,
            Sex = Sex,
            City = City,
            Country = Country,
            Institution = Institution,
            Score = Score,
            Level = Level
        };
        string playerJson = JsonConvert.SerializeObject(_data, Formatting.Indented);
        string UserPath = Application.persistentDataPath + "/Unity/" + Email + ".json";
        //save the player information to the local Json file
        try
        {
            File.WriteAllText(UserPath, playerJson);
            AlertWindow2.SetActive(true);
        }
        catch (Exception ex)
        {
            AlertText.text = ex.Message;
            AlertWindow.SetActive(true);

        }

        //save the player information to the database
        string query = @"insert into runoob.player_info
        (age, city, country, email, familyname, firstname, institute, level, score, sex, password, carrots) values
        (" + Age + ", \"" + City + "\", '" + Country + "', '" + Email + "', '" + FamilyName + "', '" + FirstName + "', '" 
        + Institution + "', " + Level + ", " + Score + ", '" + Sex + "', '" + _data.password + "', " + 
        _data.carrots + ")";
        Debug.Log(query);
        MysqlConnector mysqlConnector = new MysqlConnector();
        mysqlConnector.Query(query);


    }


    public void Load()
    {
        //Player_Info pi = JsonConvert.DeserializeObject<Player_Info>(playerJson);
        //Debug.Log(pi.Email);
        //string UserPath = Application.dataPath + "/PlayerData/" + Email + ".json";
        //string jsonString = File.ReadAllText(UserPath);
        //JSONObject playerJson = (JSONObject)JSON.Parse(jsonString);
        //FirstName = playerJson["playerJson"];
        //FamilyName = playerJson["FamilyName"];
        //Age = playerJson["Age"];
        //City = playerJson["City"];
        //Country = playerJson["Country"];
        //Email = playerJson["Email"];
        //Institution = playerJson["Institution"];
        //Level = playerJson["Level"];
        ////Carrots = playerJson["Carrots"];
        ////HP = playerJson["HP"];
        //Score = playerJson["Score"];  
    }

    public void Submission()
    {
        if (!Validation.Validation.EmailCheck(Email))
        {
            AlertText.text = "Please enter a valid Email address.\ne.g. abcdef.fh@gmail.com";
            AlertWindow.SetActive(true);
            return;
        }

        if (Validation.Validation.LocalEmailExistCheck(Email))
        {
            AlertText.text = "The Email address has existed. Please log in.";
            AlertWindow.SetActive(true);
            return;
        }
        else if (Validation.Validation.ServerEmailExistCheck(Email))
        {
            AlertText.text = "The Email address has existed. Please log in.";
            AlertWindow.SetActive(true);
            return;
        }

        if (!Validation.Validation.NameCheck(FirstName))
        {
            AlertText.text = "Please enter a valid FirstName. \nFirstName should only contain these charaters: a-z'.-";
            AlertWindow.SetActive(true);
            return;
        }

        if (!Validation.Validation.NameCheck(FamilyName))
        {
            AlertText.text = "Please enter a valid FamilyName. \nFamilyName should only contain these charaters: a-z'.-";
            AlertWindow.SetActive(true);
            return;
        }

        if (!Validation.Validation.AgeCheck(Age))
        {
            AlertText.text = "Please enter a valid Age(7~100).";
            AlertWindow.SetActive(true);
            return;
        }


        if (!Validation.Validation.CityCheck(City))
        {
            AlertText.text = "Please enter a valid City.";
            AlertWindow.SetActive(true);
            return;
        }

        if (!Validation.Validation.CountryCheck(Country))
        {
            AlertText.text = "Please enter a valid Country.";
            AlertWindow.SetActive(true);
            return;
        }

        if (!Validation.Validation.InstitutionCheck(Institution))
        {
            AlertText.text = "Please enter a valid Institution.";
            AlertWindow.SetActive(true);
            return;
        }

        Save();


    }


    [Serializable]
    public class Player_Info
    {
        public string Email;
        public string password = "";
        public string FirstName;
        public string FamilyName;
        public int Age = 0;
        public string Sex;
        public string City;
        public string Country;
        public string Institution;
        public float Score = 0;
        public int Level = 0;
        public int carrots = 5;
    }


}
