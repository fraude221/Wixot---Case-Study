using System.Collections.Generic;
using UnityEngine;

public class SkillGroup : MonoBehaviour
{
    private List<Skill> _skillList;
    [HideInInspector] public int activeButtonCount = 0;

    private void Awake() => _skillList = new List<Skill>();

    public void SubscribeToGroup(Skill skill)
    {
        _skillList.Add(skill);
    }
    public void DetermineSkillsInteractable()
    {
        if(activeButtonCount >= 3)
        {
            foreach (var skillButton in _skillList)
            {
                if (!skillButton.isActive)
                {
                    skillButton.SetSkillButtonInteractable(false);
                }
            }
        }
        else
        {
            foreach (var skillButton in _skillList)
            {
                skillButton.SetSkillButtonInteractable(true);
            }
        }
    }
}
