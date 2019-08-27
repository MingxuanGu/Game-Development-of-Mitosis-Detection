/**
 * Author: Wenyu Zhang, Mingxuan Gu, Zhaoya Pan
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BarControll : MonoBehaviour
{
    public GameObject AlertWindow;
    public float max_hp = 60;
    float hp = 0;
    public GameObject hp_bar;
    public Button yes_button;
    public Button no_button;

    void Awake()
    {
        AlertWindow.SetActive(false);
    }

    public void AlertSleep()
    {
        AlertWindow.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        hp = max_hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp > 0)
        {
            hp -= 1 * Time.deltaTime;
        }
        if (hp <= 0)
        {
            hp = 0;
            if (CarrotNum.carrot_number > 0)
            {
                AlertWindow.SetActive(true);
                yes_button.interactable = false;
                no_button.interactable = false;
            }
            else SceneManager.LoadScene("TryAgain");
            

        }

        hp_bar.transform.localScale = new Vector3((hp / max_hp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }
    public void yesButton()
    {
        // get image label
        string label = LoadImages.filenames[LoadImages.index][1];
        // add time if made right decision
        if (label == "1")
        {
            hp += (float)10 * Time.deltaTime;
        }
        else
        {
            hp -= 10 * Time.deltaTime;
        }
    }

    public void noButton()
    { 
        // get image label
        string label = LoadImages.filenames[LoadImages.index][1];
        // add time if made right decision
        if (label == "0")
        {
            hp += (float)10 * Time.deltaTime;
        }
        else
        {
            hp -= 10 * Time.deltaTime;
        }
    }

    public void restore()
    {
        //cost 1 carrot to restore
        CarrotNum.carrot_number -= 1;
        hp = max_hp;
        AlertSleep();
        yes_button.interactable = true;
        no_button.interactable = true;
    }

    public void no_restore()
    {
        SceneManager.LoadScene("Congratulation");
    }
}
