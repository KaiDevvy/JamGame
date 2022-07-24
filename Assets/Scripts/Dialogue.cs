using System;
using System.IO;
using UnityEngine;

[Serializable]
public class Dialogue
{
    public static string StorePath
    {
        get
        {
            return Path.Join(Application.streamingAssetsPath, "/dialogue/");
        }
    }

    public Line[] lines;

    [Serializable]
    public class Line
    {
        public string text = "";
        public float letterDelay = 0.035f;
        public int expression = 0;
        public string eventIdentifier = "";
        public bool flipSprite = false;
        public float autoAfter = 0;
        public bool hideBox = false;
        public float positionX = 7.77f;
        public float positionY = -6.98f;

    }
}
