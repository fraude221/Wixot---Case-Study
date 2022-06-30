using UnityEngine;
public class SkillPlayerSpeed : Skill
{
    [SerializeField] private MovementController _movementController;
    [SerializeField] private Animator _playerAnim;
    [SerializeField] private float _speedFactor;
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
    protected override void ActivateSkill()
    {
        base.ActivateSkill();
        _movementController.SpeedUp(_speedFactor);
        _playerAnim.speed *= _speedFactor;
    }
    protected override void DeactivateSkill()
    {
        base.DeactivateSkill();
        _movementController.SpeedDown(_speedFactor);
        _playerAnim.speed /= _speedFactor;
    }
}
