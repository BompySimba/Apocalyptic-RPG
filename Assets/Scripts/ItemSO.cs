using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatChange statToChange = new StatChange();
    public int amountToChangeStat;

    public AttributeChange atrributeToChange = new AttributeChange();
    public int amountToChangeAttribute;
    
    public enum StatChange {none, health, stamina};
    public enum AttributeChange {none, strength, defense, agility};

    public bool UseItem()
    {
        if (statToChange == StatChange.health)
        {
            PlayerController playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            if(playerHealth.currentHealth >= playerHealth.maxHealth)
            {
                return false;
            }
            else
            {
                playerHealth.HealDamage(amountToChangeStat);
                return true;
            }
        }
        return false;
    }
}
