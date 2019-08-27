/**
 * Author: Mingxuan Gu
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Text.RegularExpressions;
namespace Validation
{
    class Validation:MonoBehaviour
    {
        //Validation check for Email
        public static Boolean EmailCheck(string input)
        {
            string pattern = @"^[a-zA-Z0-9_-]+.?[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(.[a-zA-Z0-9_-]+)+$";
            MatchCollection mc = Regex.Matches(input, pattern);
            if (mc.Count == 1)
            {
                return true;
            }
            else
            {
                //Console.WriteLine("Please enter a valid Email address.");
                return false;
            }

        }
        //Validation check for Names
        public static Boolean NameCheck(string name)
        {
            string pattern = @"^[a-zA-Z][a-zA-Z ,'.-]*[a-zA-Z.]$";
            MatchCollection mc = Regex.Matches(name, pattern);
            if (mc.Count == 1)
            {
                //Console.WriteLine("Succeed.");
                return true;
            }
            else
            {
                //Console.WriteLine("Please enter a valid Name.");
                return false;
            }
        }
        //Validation check for Age
        public static Boolean AgeCheck(int age)
        {
            if (age >= 7 && age <= 100) return true;
            else return false;
        }

        //Validation check for City
        public static Boolean CityCheck(string city)
        {
            string pattern = @"^[a-zA-Z][a-zA-Z '.-]*[a-zA-Z.]$";
            MatchCollection mc = Regex.Matches(city, pattern);
            if (mc.Count == 1)
            {
                //Console.WriteLine("Succeed.");
                return true;
            }
            else
            {
                //Console.WriteLine("Please enter a valid Email address.");
                return false;
            }
        }

        //Validation check for Country
        public static Boolean CountryCheck(string country)
        {
            string pattern = @"^[a-zA-Z][a-zA-Z '.-]*[a-zA-Z.]$";
            MatchCollection mc = Regex.Matches(country, pattern);
            if (mc.Count == 1)
            {
                //Console.WriteLine("Succeed.");
                return true;
            }
            else
            {
                //Console.WriteLine("Please enter a valid Email address.");
                return false;
            }
        }

        //Validation check for Institution
        public static Boolean InstitutionCheck(string institution)
        {
            string pattern = @"^[a-zA-Z][a-zA-Z '.-_]*[a-zA-Z.]$";
            MatchCollection mc = Regex.Matches(institution, pattern);
            if (mc.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean LocalEmailExistCheck(string email)
        {
            string JsonPath = Application.persistentDataPath + "/Unity/" + email + ".json";
            
            if (System.IO.File.Exists(JsonPath))
            {
                
                return true;
            }
            else return false;
        }

        public static Boolean ServerEmailExistCheck(string email)
        {
            MysqlConnector mysqlConnector = new MysqlConnector();
            string query = "select count(Email) from runoob.player_info where Email = \"" + email + "\"";
            List<List<string>> result = mysqlConnector.Query(query);
            if (result.Count > 0)
            {
                if (result[0][0] == "0")
                return false;
                return true;
            }
                
            else return false;
        }

    }
}
