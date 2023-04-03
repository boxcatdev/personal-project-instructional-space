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
    private void Update()
    {
        if(QuestGiver.allQuestsComplete == true && ingredientInBowl != null)
        {
            Debug.LogWarning("Clearing Mixing Bowl");
            Destroy(ingredientInBowl.gameObject);
        }
    }
    public void TryMix()
    {
        IngredientType ingredient = ingredientQueue.Peek();

        //if ingredienttype is next in queue then add to mix
        if (ingredientInBowl.ingredientType == ingredient)
        {
            //mixing logic
            MixThisIngredient(ingredient);
        }

    }
    private void MixThisIngredient(IngredientType ingredientType)
    {
        Debug.Log("Mixing " + ingredientType.ToString());
        ingredientQueue.Dequeue();

        if (fillLevel < fillMeshes.Count)
        {
            fillMeshes[fillLevel].gameObject.SetActive(true);
            fillLevel++;
        }

        //check quest giver if current quest needs this ingredient before mixing
        ingredientInBowl.PutIngredientInBowl();
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
