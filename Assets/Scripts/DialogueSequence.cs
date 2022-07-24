using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class DialogueSequence
{
    public Queue<Dialogue.Line> queue;


    public bool IsComplete() =>
        queue == null || queue.Count == 0;

    public DialogueSequence(string dialogName)
    {

        string rawJson = File.ReadAllText(Path.Join(Dialogue.StorePath, $"/{dialogName}.json"));

        if (string.IsNullOrEmpty(rawJson))
            return;

        Dialogue dialogue = JsonUtility.FromJson<Dialogue>(rawJson);

        queue = new Queue<Dialogue.Line>(dialogue.lines);

    }

    public Dialogue.Line Next()
    {
        return queue.Dequeue();
    }


}

