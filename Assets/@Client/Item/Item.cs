using UnityEngine;

public class Item : MonoBehaviour
{
    private static readonly int BaseColorId = Shader.PropertyToID("_BaseColor");

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
