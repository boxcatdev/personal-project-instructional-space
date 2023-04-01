using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public enum IngredientType { Flour, Baking_Powder, Salt, Butter, Sugar, Eggs, Milk }

    public IngredientType ingredientType;
    public bool isEmpty { get; private set; }
    private void Start()
    {
        isEmpty = false;
    }
}
