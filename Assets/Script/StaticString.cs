using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticString : MonoBehaviour
{
    public static string Car1 = "fantasy car";
    public static string Car2 = "hover rocket bike";
    public static string Car3 = "Space Bike";
    public static string LoadingScreenLevelName = "loading";
    public static string BaseMapLevelName = "BaseMap";
    public static string LevelScreenlevelName = "levels";
    public static string CarSelectionlevelName = "Vehciile Selection";
    public static string WebViewLevelName = "UniWebViewDemo";
    public static string IntroLevelName = "IntroStoryScene";
    public static string WebURLThumbnails = "https://raykindle.com/content/thumbnails/";
    public static string WebURLLesson = "https://raykindle.com/content/";
    public static bool NewStart = false;
    public static bool End=false;
    public static string GetCarName()
    {
        return PlayerPrefs.GetString("vehicle");
    }

    public static int GetLessonStatus(string lesson)
    {
        return PlayerPrefs.GetInt(lesson);
    }
    public static void SetLessonStatus(string lesson,int c)
    {
         PlayerPrefs.SetInt(lesson,c);
        PlayerPrefs.Save();
    }
    public static int GetPodChildStatus(string[] lesson)
    {
        int d =0;
        foreach(string c in lesson)
        {
            if (!string.IsNullOrEmpty(c))
            {
                d += PlayerPrefs.GetInt(c);
            }
          
        }
        return d;
    }

    public static int GetMaxValue(string[] lesson)
    {
        int d = 0;
        foreach (string c in lesson)
        {
            if (!string.IsNullOrEmpty(c))
            {
                d += 1;
            }

        }
        return d;
    }
}
