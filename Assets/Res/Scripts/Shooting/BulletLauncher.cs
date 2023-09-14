using UnityEngine;

public class BulletLauncher : MonoBehaviour, ILauncher{
    public ParticlePlayer _particlePlayer;
    [SerializeField] private ParticleSystem hitParticle;
    public void Launch(NormalWeapon weapon){
        RaycastHit hit;
        if (Physics.Raycast(weapon._camera.transform.position, weapon._camera.transform.forward, out hit, 100f)){
            var target = hit.transform.GetComponent<ITargetable>();
            if (target != null){
                target.Hit(weapon.shootingStatsSo.bulletDamage);
                PlayerParticles(hitParticle, hit);
            }
        }
        PlayerParticles(weapon);
    }

    private void PlayerParticles(ParticleSystem particleSystem, RaycastHit raycastHit){
        _particlePlayer.PlayerParticleInPosition(particleSystem,raycastHit.point);
    }

    private void PlayerParticles(NormalWeapon weapon){
        _particlePlayer.PlayParticle(weapon.shootingStatsSo.particleShoot);
    }
}