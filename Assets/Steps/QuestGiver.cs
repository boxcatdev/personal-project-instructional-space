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
        currentStep.text = _currentQuest.step[stepIndex];
    }

    public void CompleteQuest()
    {
        if (quest[questIndex].goal.goalType == GoalType.GatherItem)
        {
            if (quest[questIndex].goal.hasItem)
            {
                quest[questIndex].goal.hasItem = false;
                questIndex += 1;
                _currentQuest = quest[questIndex];
                quest[questIndex].goal.hasItem = false;
            }
        }

    }

    private void Start()
    {
        _currentQuest = quest[questIndex];
        OpenQuestWindow();
    }

}
