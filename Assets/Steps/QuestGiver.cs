using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public List<Quest> quest;
    public Quest _currentQuest;
    public Player player;

    public GameObject questWindow;
    public TMP_Text titleText;
    public TMP_Text descText;
    public TMP_Text currentStep;

    public int questIndex = 0;
    public int stepIndex;

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = _currentQuest.questTitle;
        descText.text = _currentQuest.description;
        currentStep.text = _currentQuest.steps[stepIndex].goalName;
    }

    public void CompleteQuest()
    {
        if (_currentQuest.steps[stepIndex].goalType == GoalType.GatherItem)
        {
            if (_currentQuest.steps[stepIndex].hasItem)
            {
                if ((_currentQuest.steps.Count - (stepIndex + 1) <= 0))//if there are no more steps left, finish quest!
                {
                    quest[questIndex].steps[stepIndex].hasItem = false;
                    questIndex += 1;
                    _currentQuest = quest[questIndex];
                    quest[questIndex].steps[stepIndex].hasItem = false;
                }
                else
                {
                    stepIndex++;
                }
                
            }
        }
        if (_currentQuest.steps[stepIndex].goalType == GoalType.PlaceItem)
        {
            //item place check (by volume check?)
        }

    }

    private void Start()
    {
        _currentQuest = quest[questIndex];
        OpenQuestWindow();
    }

}
