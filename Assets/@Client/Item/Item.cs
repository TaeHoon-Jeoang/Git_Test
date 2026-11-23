using UnityEngine;

public class Item : MonoBehaviour
{
    private static readonly int BaseColorId = Shader.PropertyToID("_BaseColor");

    [SerializeField]
    private float healAmount = 30f;

    private bool isConsumed = false;

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어 콜라이더가 여럿(캡슐, 총)이라 같은 프레임에 두 번 들어올 수 있음
        if (isConsumed)
        {
            return;
        }

        Player player = other.GetComponentInParent<Player>();
        if (player == null)
        {
            return;
        }

        isConsumed = true;
        player.Heal(healAmount);
        Destroy(gameObject);
    }

    // 재질 인스턴스를 만들지 않도록 MaterialPropertyBlock으로 색만 덮어쓴다
    public void SetColor(Color color)
    {
        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();
        if (meshRenderer == null)
        {
            return;
        }

        MaterialPropertyBlock block = new MaterialPropertyBlock();
        meshRenderer.GetPropertyBlock(block);
        block.SetColor(BaseColorId, color);
        meshRenderer.SetPropertyBlock(block);
    }
}
