namespace GameJam.Battle
{
    public class DamageData
    {
        public float damage;
        public DamageType damageType;

        public DamageData(float _damage, DamageType _damageType)
        {
            damage = _damage;
            damageType = _damageType;
        }
    }
}