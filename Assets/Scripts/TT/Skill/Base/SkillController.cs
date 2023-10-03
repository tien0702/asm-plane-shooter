using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    ICondition[] conditions;
    IResetCondition[] resetConditions;

    private void Start()
    {
        
    }

    void OnSuitableCondition(ICondition condition)
    {
        if (!CheckSuitableConditions()) return;

        ResetConditions();
    }

    bool CheckSuitableConditions()
    {
        return !conditions.Any(conditon => !conditon.IsSuitable);
    }

    void ResetConditions()
    {
        foreach(IResetCondition reset in resetConditions)
        {
            reset.ResetCondition();
        }
    }
}
