using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public string goalName;
    public GoalType goalType;
    //public int requiredAmount = 1;
    //public int currentAmount;
    public bool hasItem;

   //public bool IsReached()
   //{
   //    return (currentAmount >= requiredAmount);
   //}
}

public enum GoalType
{
    GatherItem,
    PlaceItem
}
