public class SkillDoubleShooting : Skill
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
