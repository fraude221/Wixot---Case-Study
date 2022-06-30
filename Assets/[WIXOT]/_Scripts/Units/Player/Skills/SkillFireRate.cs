public class SkillFireRate : Skill
{
    public void OnButtonSelected()
    {
        if (isActive)
        {
            DeactivateSkill();
        }
        else
        {
            ActivateSkill();
        }
    }
}
