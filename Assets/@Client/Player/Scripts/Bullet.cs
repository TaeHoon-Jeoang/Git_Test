using UnityEngine;

public class Bullet : MonoBehaviour
{
    //��ȯ������, ������ ���󰡱⸸ �ϸ� ��
    private Rigidbody rb = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.AddForce(transform.forward * 20f,
            ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageableObject =
            other.gameObject.GetComponent<IDamageable>();

        if (damageableObject != null)
        {
            damageableObject.TakeDamage(100f);
        }

        Destroy(gameObject);
    }
}
