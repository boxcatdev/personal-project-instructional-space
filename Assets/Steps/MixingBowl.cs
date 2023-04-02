using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingBowl : MonoBehaviour
{
    /// <summary>
    /// Store a list of ingredients
    /// call a function after each ingredient is added
    /// </summary>

    private QuestGiver QuestGiver;

    public bool recipeComplete = false;
    public Ingredient _ingredientInBowl;
    public List<IngredientType> _ingredientOrder;

    private Queue<IngredientType> _ingredientQueue;


    private void Start()
    {
        QuestGiver = FindObjectOfType<QuestGiver>();
        _ingredientQueue = new Queue<IngredientType>(_ingredientOrder);

        Debug.Log(_ingredientQueue.Peek());
    }

    public void TryMix()
    {
        #region Old Mixer Code

        ///check all recipes
        ///if ingredients apply to any recipe
        ///instantiate drink from recipe
        ///empty ingredients after making drink

        /*DrinkRecipeSO drink = null;
        List<Ingredient> usedIngredients = new List<Ingredient>();

        //iterate through each recipe
        foreach (DrinkRecipeSO recipe in _recipes)
        {
            List<Ingredient.IngredientType> ingredientsFromRecipe = new List<Ingredient.IngredientType>(recipe.listOfIngredients);

            foreach (Ingredient ingredient in _ingredientsInMixer)
            {
                if (ingredientsFromRecipe.Contains(ingredient._type))
                {
                    ingredientsFromRecipe.Remove(ingredient._type);
                }
            }

            if (ingredientsFromRecipe.Count == 0)
            {
                drink = recipe;
            }
        }*/

        /*//spawn drink if ingredients exist
        if (_ingredientQueue != null || _ingredientQueue.Count > 0)
        {
            Debug.Log("Make drink: " + drink.recipeName);
            Transform newDrink = Instantiate(drink.outputDrinkPrefab.transform, transform);
            newDrink.position = _spawnDrinkPosition.position;

            //one more loop to empty ingredients used in drink
            List<Ingredient.IngredientType> ingredientsFromRecipe = new List<Ingredient.IngredientType>(drink.listOfIngredients);
            foreach (Ingredient ingredient in _ingredientsInBowl)
            {
                if (ingredientsFromRecipe.Contains(ingredient._type))
                {
                    ingredientsFromRecipe.Remove(ingredient._type);
                    usedIngredients.Add(ingredient);
                }

                if (ingredientsFromRecipe.Count == 0) break;
            }

            foreach (Ingredient i in usedIngredients)
            {
                i.EmptyIngredient();
            }
        }*/
        #endregion

        IngredientType ingredient = _ingredientQueue.Peek();

        //if ingredienttype is next in queue then add to mix
        if (_ingredientInBowl.ingredientType == ingredient)
        {
            //check quest giver if current quest needs this ingredient before mixing
            if (QuestGiver.CompletePlaceStep(ingredient))
            {
                MixThisIngredient(ingredient);
                _ingredientQueue.Dequeue();
                Debug.Log("Mixing " + ingredient.ToString());
            }
        }

    }
    private void MixThisIngredient(IngredientType ingredientType)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Ingredient ingredient = other.GetComponentInParent<Ingredient>();
        if (ingredient != null)
        {
            if (ingredient.isEmpty == false)
            {
                if (_ingredientInBowl == null || _ingredientInBowl != ingredient)
                {
                    _ingredientInBowl = ingredient;
                    TryMix();
                }
            }
            else
            {
                if (_ingredientInBowl == ingredient)
                    _ingredientInBowl = null;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Ingredient ingredient = other.GetComponentInParent<Ingredient>();
        if (ingredient != null)
        {
            if (_ingredientInBowl == ingredient)
                _ingredientInBowl = null;
        }
    }
}
