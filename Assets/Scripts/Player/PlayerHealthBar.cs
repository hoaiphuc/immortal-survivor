using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Vector3 offset = new Vector3(0f, -0.7f, 0f);

    void Awake()
    {
        GetComponent<Canvas>().sortingOrder = 10;
    }

    void LateUpdate()
    {
        transform.position = playerHealth.transform.position + offset;
        fillImage.fillAmount = playerHealth.CurrentHp / playerHealth.MaxHp;
    }
}
