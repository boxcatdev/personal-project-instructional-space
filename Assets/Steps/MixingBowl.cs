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

    public Ingredient ingredientInBowl;
    public List<IngredientType> ingredientOrder;

    [SerializeField] private List<MeshRenderer> fillMeshes;
    public int fillLevel = 0;
    public bool recipeComplete = false;

    private Queue<IngredientType> ingredientQueue;


    private void Start()
    {
        QuestGiver = FindObjectOfType<QuestGiver>();
        ingredientQueue = new Queue<IngredientType>(ingredientOrder);
        foreach (var mesh in fillMeshes)
        {
            mesh.gameObject.SetActive(false);
        }

        //Debug.Log(_ingredientQueue.Peek());
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

        IngredientType ingredient = ingredientQueue.Peek();

        //if ingredienttype is next in queue then add to mix
        if (ingredientInBowl.ingredientType == ingredient)
        {
            //check quest giver if current quest needs this ingredient before mixing
            ingredientInBowl.PutIngredientInBowl();

            //mixing logic
            MixThisIngredient(ingredient);
            
        }

    }
    private void MixThisIngredient(IngredientType ingredientType)
    {
        ingredientQueue.Dequeue();
        Debug.Log("Mixing " + ingredientType.ToString());

        if (fillLevel < fillMeshes.Count)
        {
            fillMeshes[fillLevel].gameObject.SetActive(true);
            fillLevel++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Ingredient ingredient = other.GetComponentInParent<Ingredient>();
        if (ingredient != null)
        {
            if (ingredientInBowl == null || ingredientInBowl != ingredient)
            {
                ingredientInBowl = ingredient;
                TryMix();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Ingredient ingredient = other.GetComponentInParent<Ingredient>();
        if (ingredient != null)
        {
            if (ingredientInBowl == ingredient)
                ingredientInBowl = null;
        }
    }
}
