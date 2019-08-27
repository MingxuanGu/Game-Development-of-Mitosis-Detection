/**
 * Author: Zhaoya Pan
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;

public class LoadImages : MonoBehaviour
{
    public static int index = 0;  // store current image index
    public Image img;
    public static List<List<string>> filenames = new List<List<string>>() { };  // storing image names and labels

    //public List<string> filenames = new List<string> {
    //    "Images/H03_00Aa_1",
    //    "Images/H03_00Aa_2",
    //    "Images/H03_00Aa_3",
    //    "Images/H03_00Aa_4",
    //    "Images/H03_00Aa_5",
    //    "Images/H03_00Aa_6",
    //    "Images/H03_00Aa_7",
    //    "Images/H03_00Aa_8",
    //};
    //public string name1 = "Images/H03_00Aa_1";
    //public List<string> filenames; // store all the image file names from Resources/Images

    // Start is called before the first frame update
    void Start()
    {
        getShuffledFileNames();
        Sprite sprite = Resources.Load<Sprite>(filenames[index][0]);
        img.sprite = sprite;

        //img.sprite = Resources.Load("Images/H03_00Aa_1", typeof(Sprite)) as Sprite;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    getImage();
    //}

    void getImage()
    {
        img.sprite = Resources.Load(filenames[index][0], typeof(Sprite)) as Sprite;
        //img.sprite = Resources.Load("Images/H03_00Aa_1", typeof(Sprite)) as Sprite;
    }



    public void Button()
    {
        index += 1;
        getImage();
    }

    //public void yesButton()
    //{
    //    // get label from current imaged
    //    string label = filenames[index][1];
    //    if (label == "1")
    //    {
    //        index += 1;
    //        getImage();
    //    }
    //}

    //public void noButton()
    //{
    //    string label = filenames[index][1];
    //    if (label == "0")
    //    {
    //        index += 1;
    //        getImage();
    //    }
    //}

    public void getShuffledFileNames()
    {
        string path_mitosis = Application.dataPath + "/Resources/mitosis";
        string path_no_mitosis = Application.dataPath + "/Resources/no_mitosis";

        var mitosisJPG = Directory.EnumerateFiles(path_mitosis, "*.jpg");
        foreach (string fullpath in mitosisJPG) {
            List<string> temp = new List<string>() { };
            string name = fullpath.Replace(path_mitosis, "");
            temp.Add("mitosis/" + name.Substring(1, name.Length - 5));
            temp.Add("1");
            filenames.Add(temp);
        }

        var no_mitosisJPG = Directory.EnumerateFiles(path_no_mitosis, "*.jpg");
        foreach (string fullpath in no_mitosisJPG) {
            List<string> temp = new List<string>() { };
            string name = fullpath.Replace(path_no_mitosis, "");
            temp.Add("no_mitosis/" + name.Substring(1, name.Length - 5));
            temp.Add("0");
            filenames.Add(temp);
        }

        filenames.Shuffle();

        //shuffle List



        //var jpgFiles = Directory.EnumerateFiles(path, "*.jpg");
        //jpgFiles = jpgFiles.Randomize();
        //foreach (string fullpath in jpgFiles)
        //{
        //    string name = fullpath.Replace(path, "");
        //    filenames.Add("Images/" + name.Substring(1, name.Length - 5));
        //}
    }
}

public static class IListExtensions
{
    /// <summary>
    /// Shuffles the element order of the specified list.
    /// </summary>
    public static void Shuffle<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}

//public static class EnumerableExtentions
//{
//    public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
//    {
//        var range = new System.Random();
//        return source.Randomize(range);
//    }

//    private static IEnumerable<T> Randomize<T>(this IEnumerable<T> source, System.Random range)
//    {
//        if (source == null) throw new ArgumentNullException("source");
//        if (range == null) throw new ArgumentNullException("range");

//        return source.RandomizeAlgorithm(range);
//    }

//    private static IEnumerable<T> RandomizeAlgorithm<T>(this IEnumerable<T> source, System.Random range)
//    {
//        var temp = source.ToList();

//        for (int i = 0; i < temp.Count; i++)
//        {
//            int j = range.Next(i, temp.Count);
//            yield return temp[j];

//            temp[j] = temp[i];
//        }
//    }
//}
