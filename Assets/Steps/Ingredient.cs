using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientType { Flour, Baking_Powder, Salt, Butter, Sugar, Eggs, Milk }

public class Ingredient : MonoBehaviour
{
    private QuestGiver questGiver;

    public IngredientType ingredientType;
    public bool isEmpty { get; private set; }
    private void Start()
    {
        questGiver = FindObjectOfType<QuestGiver>();
        isEmpty = false;
    }

    public void PickupStep()
    {
        questGiver.CompleteGatherStep(ingredientType);
    }
    public void UndoPickupStep()
    {
        questGiver.UndoGatherStep();
    }
}
