/**
 * Author: Mingxuan Gu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private readonly float templateHight = 25f;
    private readonly string query = "select score, firstname, familyname from runoob.player_info order by score desc limit 10";
    MysqlConnector sqlconnector = new MysqlConnector();
    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        //List<string> highscoreentry1 = new List<string>() { "20", "meli", "A" };
        //List<string> highscoreentry2 = new List<string>() { "18", "stefan", "G" };
        //List<string> highscoreentry3 = new List<string>() { "17", "andriod", "F" };
        //List<string> highscoreentry4 = new List<string>() { "15", "winnie", "E" };
        //List<string> highscoreentry5 = new List<string>() { "10", "klaud", "R" };
        //List<string> highscoreentry6 = new List<string>() { "5", "lilly", "T" };
        //List<List<string>> highscoreentry = new List<List<string>>() { highscoreentry1, highscoreentry2, highscoreentry3, highscoreentry4, highscoreentry5, highscoreentry6 };
        List<List<string>> highscoreentry = sqlconnector.Query(query);

        CreateHighScoreEntryTransform(highscoreentry, entryContainer);
    }

    private void CreateHighScoreEntryTransform(List<List<string>> HighScoreEntry, Transform Container)
    {
        for (int i = 0; i < HighScoreEntry.Count; i++)
        {
            Transform entryTranform = Instantiate(entryTemplate, Container);
            RectTransform entryRectTransform = entryTranform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHight * i);
            entryTranform.gameObject.SetActive(true);

            string rankString;
            switch (i + 1)
            {
                default: rankString = i + 1 + "TH"; break;
                case 1: rankString = "1ST"; break;
                case 2: rankString = "2ND"; break;
                case 3: rankString = "3RD"; break;
            }

            entryTranform.Find("RankText").GetComponent<Text>().text = rankString;

            entryTranform.Find("ScoreText").GetComponent<Text>().text = HighScoreEntry[i][0];
            
            entryTranform.Find("NameText").GetComponent<Text>().text = HighScoreEntry[i][1] + " " + HighScoreEntry[i][2];

            entryTranform.Find("SubBackground").gameObject.SetActive(i % 2 != 1);

            switch (i + 1)
            {
                default:
                    entryTranform.Find("Star").gameObject.SetActive(false); break;
                case 1:
                    entryTranform.Find("Star").GetComponent<Image>().color = new Color32(255, 255, 0, 255); break;
                case 2:
                    entryTranform.Find("Star").GetComponent<Image>().color = new Color32(255, 255, 255, 255); break;
                case 3:
                    entryTranform.Find("Star").GetComponent<Image>().color = new Color32(255, 150, 0, 255); break;
            }
            
        }
    }


}
