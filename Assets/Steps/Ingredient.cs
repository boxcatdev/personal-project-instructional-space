using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientType { Flour, Baking_Powder, Salt, Butter, Sugar, Eggs, Milk, Bowl }

public class Ingredient : MonoBehaviour
{
    private QuestGiver questGiver;

    public bool isHover = false;
    public IngredientType ingredientType;
    public bool hasBeenGrabbed { get; private set; }
    //public bool isEmpty { get; private set; }

    private FloatingIcon icon;

    private void Start()
    {
        questGiver = FindObjectOfType<QuestGiver>();
        hasBeenGrabbed = false;
        icon = GetComponentInChildren<FloatingIcon>();
        //ToggleIcon(false);
        CheckIconStatus();

    }
    private void Update()
    {
        if(icon != null)
            CheckIconStatus();
    }
    public void GrabIngredient()
    {
        hasBeenGrabbed = true;
        if(questGiver.currentQuest.currentGoal.goalType == GoalType.GatherItem)
        {
            if(ingredientType == questGiver.currentQuest.ingredientType)
            {
                Debug.Log("GrabIngredient()");
                questGiver.currentQuest.CompleteStep();
                questGiver.OpenQuestWindow();
            }
        }
    }
    public void PutIngredientInBowl()
    {
        if (hasBeenGrabbed != true) return;
        if (questGiver.currentQuest.currentGoal.goalType == GoalType.PlaceItem)
        {
            if (ingredientType == questGiver.currentQuest.ingredientType)
            {
                Debug.Log("PutIngredientInBowl()");
                questGiver.currentQuest.CompleteStep();
                questGiver.OpenQuestWindow();

                Destroy(gameObject);
            }
        }
        CheckIconStatus();
    }
    private void CheckIconStatus()
    {
        Quest currentQuest = questGiver.currentQuest;
        if (/*currentQuest.currentGoal.goalType == GoalType.GatherItem
            && */currentQuest.ingredientType == ingredientType)
        {
            //ToggleIcon(true);

            if (isHover) ToggleIcon(false);
            else ToggleIcon(true);
            //else if (!isHover && !icon.gameObject.activeInHierarchy) ToggleIcon(true);
        }
        else
        {
            ToggleIcon(false);
        }

    }
    public void ToggleIcon(bool active)
    {
        if(active == true)
        {
            if (icon.gameObject.activeInHierarchy == false)
                icon.gameObject.SetActive(true);
        }
        else
        {
            if (icon.gameObject.activeInHierarchy == true)
                icon.gameObject.SetActive(false);
        }
    }
    public void IsHover(bool isBool)
    {
        isHover = isBool;
    }
}
