using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public QuestGiver _questGiver;

    public void GrabbedObject(GameObject _obj)
    {
        /*for (int i = 0; i <= _questGiver._currentQuest.objectNames.Count - 1; i++)
        {
            if (_questGiver._currentQuest.objectNames[i] == _obj.name)
            {
                _questGiver.CompleteQuest();
                Debug.Log("Complete Quest");
                //_questGiver._currentQuest.steps[_questGiver.stepIndex].currentAmount++;
                //_questGiver._currentQuest.steps[_questGiver.stepIndex].hasItem = true;
            }
        }*/
    }
}
