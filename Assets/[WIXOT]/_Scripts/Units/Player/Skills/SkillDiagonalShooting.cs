public class SkillDiagonalShooting : Skill
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
