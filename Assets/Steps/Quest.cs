using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Quest", menuName = "Quest", order = 0)]
public class Quest : ScriptableObject
{
    public string questTitle;
    [TextArea(10, 20)]
    public string description;

    public List<string> step;

    public List<string> objectNames;

    public QuestGoal goal;
}
