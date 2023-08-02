using StarterAssets;

public class UiPlayerHealthBar : UiHealthBar{
    private FirstPersonController player => FirstPersonController.Instance;
    private void Awake(){
        GameEvents.Player.onPlayerTakeTamage += TakeDamage;
    }
    private void OnDestroy(){
        GameEvents.Player.onPlayerTakeTamage -= TakeDamage;
    }

    private void TakeDamage(float damage){
        var maxHealth = player.health.maxHealth;
        var currentHealth = player.health.currentHealth;
        SetupBar((float)maxHealth,(float)currentHealth);
    }

 
}