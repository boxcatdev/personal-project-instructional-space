using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.XR.Interaction.Toolkit;

public class QuestGiver : MonoBehaviour
{
    public List<Quest> quests;
    public Quest currentQuest;
    public Player player;
    public MixingBowl _mixingBowl;

    public GameObject questWindow;
    public TMP_Text titleText;
    public TMP_Text descText;
    public TMP_Text currentStep;

    [SerializeField] Animator _doorOpener;

    public int questIndex = 0;
    public int stepIndex;

    public bool allQuestsComplete {get; private set;}

    private void Awake()
    {
        allQuestsComplete = false;

        foreach (var quest in quests)
        {
            quest.InitializeQuest();
        }
        currentQuest = quests[questIndex];
        //_currentQuest = quest.Peek();
        OpenQuestWindow();
    }

    /*public void CompleteStep()
    {
        currentQuest.CompleteStep();
        OpenQuestWindow();
    }*/

    internal void CompleteQuest()
    {
        Debug.Log("CompleteQuest()");

        questIndex++;
        if (questIndex >= quests.Count)
        {
            allQuestsComplete = true;

            AllQuestsComplete();
        }
        else
        {
            currentQuest = quests[questIndex];
            Debug.Log("New Quest: " + currentQuest.questTitle);
        }
    }

    private void AllQuestsComplete()
    {
        Debug.Log("Quests Complete!");
        Debug.Log("Open door to ritual room");

        OpenQuestWindow();

        if (_doorOpener != null)
            _doorOpener.SetTrigger("Move");
        else
            Debug.LogWarning("No '_doorOpener'");
        _mixingBowl.GetComponent<XRGrabInteractable>().enabled = true;
        _mixingBowl.GetComponent<Rigidbody>().isKinematic = false;

    }

    public void OpenQuestWindow()
    {
        if(allQuestsComplete == false)
        {
            if (!questWindow.activeInHierarchy)
                questWindow.SetActive(true);

            titleText.text = currentQuest.questTitle;
            descText.text = currentQuest.description;
            currentStep.text = currentQuest.currentGoal.goalName;
            //currentStep.text = _currentQuest.steps[stepIndex].goalName;
        }
        else
        {
            if (!questWindow.activeInHierarchy)
                questWindow.SetActive(true);

            titleText.text = "Recipe Complete!";
            descText.text = "";
            currentStep.text = "";
        }
    }

}
