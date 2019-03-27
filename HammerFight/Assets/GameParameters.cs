using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class GameParameters : ScriptableObject
{
    public float oneHitDamage;
    public float minDamageSpeed;
    public Vector3 leftForce;
    public Vector3 rightForce;
}