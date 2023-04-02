using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public List<Quest> quests;
    public Quest _currentQuest;
    public Player player;

    public GameObject questWindow;
    public TMP_Text titleText;
    public TMP_Text descText;
    public TMP_Text currentStep;

    public int questIndex = 0;
    public int stepIndex;

    private void Start()
    {
        foreach (var quest in quests)
        {
            quest.InitializeQuest();
        }
        _currentQuest = quests[questIndex];
        //_currentQuest = quest.Peek();
        //OpenQuestWindow();
    }

    /*public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = _currentQuest.questTitle;
        descText.text = _currentQuest.description;
        currentStep.text = _currentQuest.steps.Peek().goalName;
        //currentStep.text = _currentQuest.steps[stepIndex].goalName;
    }*/

    public void CompleteGatherStep(IngredientType ingredientType)
    {
        if(_currentQuest.ingredientType == ingredientType)
        {
            _currentQuest.StepIsComplete();
        }
    }
    public void UndoGatherStep()
    {
        _currentQuest.StepIsIncomplete();
    }
    public bool CompletePlaceStep(IngredientType ingredientType)
    {
        if (ingredientType == _currentQuest.ingredientType)
        {
            //if ingredient type matches next ingredient for recipe
            //CompleteQuest();
            _currentQuest.StepIsComplete();

            TryCompleteQuest();

            return true;
        }
        else
        {
            //if not

            return false;
        }

    }

    /*public void CompleteGrabStep()
    {
        _currentQuest.CompleteStep(true);
    }
    public void UndoGrabStep()
    {
        _currentQuest.CompleteStep(false);
    }*/
    /*public bool CompletePlaceStep(IngredientType ingredientType)
    {
        if(ingredientType == _currentQuest.ingredientType)
        {
            //if ingredient type matches next ingredient for recipe
            CompleteQuest();

            return true;
        }
        else
        {
            //if not

            return false;
        }
    }*/

    private void TryCompleteQuest()
    {
        if (_currentQuest.questComplete)
        {
            //move onto next quest
            questIndex++;
            _currentQuest = quests[questIndex];

            Debug.Log("Quest " + _currentQuest.questTitle + " is complete");
        }
    }
    /*public void CompleteQuest()
    {
        if (_currentQuest.steps.Peek().goalType == GoalType.GatherItem)
        {
            if ((_currentQuest.steps.Count - (stepIndex + 1) <= 0))//if there are no more steps left, finish quest!
            {
                //quest[questIndex].steps[stepIndex].hasItem = false;
                questIndex += 1;
                _currentQuest = quest[questIndex];
                quest[questIndex].steps.Peek().hasItem = false;
            }
            else
            {
                stepIndex++;
            }

        }
        if (_currentQuest.steps.Peek().goalType == GoalType.PlaceItem)
        {
            //item place check (by volume check?)
        }

    }*/

    

}
