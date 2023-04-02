using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Quest", menuName = "Quest", order = 0)]
public class Quest : ScriptableObject
{
    public string questTitle;
    [TextArea(10, 20)]
    public string description;

    //public List<string> objectNames;
    [Space]
    public IngredientType ingredientType;
    public QuestGoal currentGoal;

    public List<QuestGoal> stepsList;
    private Queue<QuestGoal> stepsQueue;
    private QuestGiver QuestGiver;

    public bool questComplete { get; private set; }

    public void InitializeQuest()
    {
        QuestGiver = FindObjectOfType<QuestGiver>();
        foreach (var step in stepsList)
            step.goalComplete = false;
        stepsQueue = new Queue<QuestGoal>(stepsList);
        currentGoal = stepsQueue.Dequeue();
        questComplete = false;
    }
    public void CompleteStep()
    {
        Debug.Log(currentGoal.goalName + " complete");
        currentGoal.goalComplete = true;
        if (stepsQueue.Count > 0)
            currentGoal = stepsQueue.Dequeue();
        else
            QuestGiver.CompleteQuest();
    }
    /*public void StepIsComplete()
    {
        currentGoal.goalComplete = true;

        int nextInt = stepsList.IndexOf(currentGoal) + 1;
        if (nextInt >= stepsList.Count)
            questComplete = true;
        else
            currentGoal = stepsList[nextInt];

        Debug.Log("StepIsComplete()");
    }
    public void StepIsIncomplete()
    {
        int prevInt = stepsList.IndexOf(currentGoal) - 1;
        if (prevInt < 0)
            prevInt = 0;

        currentGoal = stepsList[prevInt];
        currentGoal.goalComplete = false;

        Debug.Log("StepIsIncomplete()");
    }*/
}
