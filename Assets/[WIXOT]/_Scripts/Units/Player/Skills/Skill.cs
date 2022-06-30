using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public abstract class Skill : MonoBehaviour
{
    [SerializeField] private SkillGroup skillGroup;

    [HideInInspector] public bool isActive;

    private Button _skillButton;
    private Image _buttonBackground;

    void Start()
    {
        _skillButton = GetComponent<Button>();
        _buttonBackground = GetComponent<Image>();
        isActive = false;
        skillGroup.SubscribeToGroup(this);
    }
    protected virtual void ActivateSkill()
    {
        isActive = true;
        skillGroup.activeButtonCount++;
        skillGroup.DetermineSkillsInteractable();

        _buttonBackground.color = Color.green;
    }

    protected virtual void DeactivateSkill()
    {
        isActive = false;
        skillGroup.activeButtonCount--;
        skillGroup.DetermineSkillsInteractable();

        _buttonBackground.color = Color.white;
    }

    public void SetSkillButtonInteractable(bool state)
    {
        _skillButton.interactable = state;
    }
}
