using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    private TextMeshPro text;

    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
    }

    public void SetDamageText(int damage)
    {
        text.text = damage.ToString();
        Destroy(gameObject, 1f); 
    }

    private void Update()
    {
        transform.position += Vector3.up * Time.deltaTime;
    }
}