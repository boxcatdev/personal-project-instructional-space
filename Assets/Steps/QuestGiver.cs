using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class QuestGiver : MonoBehaviour
{
    public List<Quest> quests;
    public Quest currentQuest;
    public Player player;

    public GameObject questWindow;
    public TMP_Text titleText;
    public TMP_Text descText;
    public TMP_Text currentStep;

    [SerializeField] Animator _doorOpener;

    public int questIndex = 0;
    public int stepIndex;

    private void Awake()
    {
        foreach (var quest in quests)
        {
            quest.InitializeQuest();
        }
        currentQuest = quests[questIndex];
        //_currentQuest = quest.Peek();
        OpenQuestWindow();
    }

    public void CompleteStep()
    {
        currentQuest.CompleteStep();
    }

    internal void CompleteQuest()
    {
        questIndex++;
        if (questIndex >= quests.Count)
            AllQuestsComplete();
        else
            currentQuest = quests[questIndex];
        Debug.Log("New Quest: " + currentQuest.questTitle);
    }

    private void AllQuestsComplete()
    {
        Debug.LogWarning("Quests Complete!");
        Debug.Log("Open door to ritual room");
        _doorOpener.SetTrigger("Move");
    }

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = currentQuest.questTitle;
        descText.text = currentQuest.description;
        currentStep.text = currentQuest.currentGoal.goalName;
        //currentStep.text = _currentQuest.steps[stepIndex].goalName;
    }

}
