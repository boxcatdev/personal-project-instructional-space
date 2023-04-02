using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public string goalName;
    public GoalType goalType;
    //public IngredientType ingredient;
    //public int requiredAmount = 1;
    //public int currentAmount;
    public bool goalComplete;

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
