using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public GameObject damageTextPrefab; 
    public Transform damageTextPosition; 

    public void ShowDamage(int damage)
    {
        Vector3 position = damageTextPosition != null ? damageTextPosition.position : transform.position;
        GameObject damageTextInstance = Instantiate(damageTextPrefab, position, Quaternion.identity);
        DamageText damageText = damageTextInstance.GetComponent<DamageText>();
        damageText.SetDamageText(damage);
    }
}