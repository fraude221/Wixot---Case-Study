using UnityEngine;

public class SkillBulletSpeed : Skill
{
    [SerializeField] private BulletProperties _bulletProperties;
    [SerializeField] private float _speedFactor;

    private float _initialBulletSpeed;
    private void Awake() => _initialBulletSpeed = _bulletProperties.speed;
    private void OnDestroy() => _bulletProperties.speed = _initialBulletSpeed;

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
        _bulletProperties.speed *= _speedFactor;
    }
    protected override void DeactivateSkill()
    {
        base.DeactivateSkill();
        _bulletProperties.speed /= _speedFactor;
    }
}
