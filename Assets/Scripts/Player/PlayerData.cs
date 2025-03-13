using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "PlayerData") ]
public class PlayerData : ScriptableObject
{
    [Header("Health")]
    public int currentHealth;
    public int maxHealth;
    public float healthRegenRate;
    [Header("Statistics")] 
    public float speedPlayer;
    public float jumpHeight;
    [Header("Camera")] 
    public float sensitivity;
    public float maxAngle;
    public float smoothing;

}