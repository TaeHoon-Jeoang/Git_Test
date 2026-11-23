using UnityEngine;

public class Gun : MonoBehaviour
{
    //���� �߻��ϴ� ������ ������ �־�� ��
    //shootPosition ���Ÿ� ã�Ƽ�
    //bullet�� shootPosition�� ��ȯ

    private ShootPosition shootPosition = null;

    [SerializeField]
    private GameObject bullet = null;

    private AudioSource source=null;

    private void Awake()
    {
        shootPosition
            = GetComponentInChildren<ShootPosition>();
        source = GetComponent<AudioSource>();
    }

    public void Attack()
    {
        //bullet�� shootPosition�� ��ȯ�ϴ� ���
        Instantiate(bullet,
            shootPosition.transform.position,
            shootPosition.transform.rotation);
        source.Stop();
        source.Play();
    }
}
