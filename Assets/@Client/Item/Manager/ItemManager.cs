using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private GameObject healItemPrefab = null;
    [SerializeField]
    private Collider floor = null;
    [SerializeField]
    private int spawnCount = 5;
    // 바닥 가장자리(벽)에서 띄울 거리. 플레이어가 아이템 옆에 설 수 있는 여유
    [SerializeField]
    private float edgeMargin = 2f;
    // 아이템끼리 최소 간격
    [SerializeField]
    private float minItemDistance = 3f;

    private const int MaxTryCount = 50;
    private const float GoldenRatio = 0.618034f;

    private readonly List<Item> itemList = new List<Item>();
    private float hue = 0f;

    public void Init()
    {
        hue = Random.value;
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnHealItem();
        }
    }

    private void SpawnHealItem()
    {
        Vector3 halfExtents = GetItemHalfExtents();
        if (!TryGetSpawnPosition(halfExtents, out Vector3 position))
        {
            Debug.LogWarning("ItemManager: 아이템을 놓을 빈 자리를 찾지 못했습니다.");
            return;
        }

        GameObject go
            = Instantiate(healItemPrefab, position, Quaternion.identity, this.transform);

        Item item = go.GetComponent<Item>();
        if (item != null)
        {
            item.SetColor(GetNextColor());
            itemList.Add(item);
        }
    }

    // 프리팹 박스 콜라이더 기준 절반 크기
    private Vector3 GetItemHalfExtents()
    {
        BoxCollider box = healItemPrefab.GetComponent<BoxCollider>();
        if (box == null)
        {
            return Vector3.one * 0.5f;
        }
        Vector3 scale = healItemPrefab.transform.lossyScale;
        return Vector3.Scale(box.size, scale) * 0.5f;
    }

    // floor 영역 안, 벽·플레이어·다른 아이템과 겹치지 않는 위치
    private bool TryGetSpawnPosition(Vector3 halfExtents, out Vector3 position)
    {
        Bounds bounds = floor.bounds;
        float reach = Mathf.Max(halfExtents.x, halfExtents.z) + edgeMargin;

        for (int i = 0; i < MaxTryCount; i++)
        {
            float x = Random.Range(bounds.min.x + reach, bounds.max.x - reach);
            float z = Random.Range(bounds.min.z + reach, bounds.max.z - reach);
            // 바닥 윗면에 아이템 아랫면이 닿게
            Vector3 candidate = new Vector3(x, bounds.max.y + halfExtents.y, z);

            if (IsFarFromItems(candidate) && IsFree(candidate, halfExtents))
            {
                position = candidate;
                return true;
            }
        }

        position = default;
        return false;
    }

    private bool IsFarFromItems(Vector3 candidate)
    {
        foreach (Item item in itemList)
        {
            if (item == null) continue;
            if ((item.transform.position - candidate).sqrMagnitude
                < minItemDistance * minItemDistance)
            {
                return false;
            }
        }
        return true;
    }

    // 후보 위치에 바닥 말고 다른 콜라이더(벽, 플레이어 등)가 없는지
    private bool IsFree(Vector3 candidate, Vector3 halfExtents)
    {
        Collider[] hits = Physics.OverlapBox(
            candidate,
            halfExtents * 0.95f,
            Quaternion.identity,
            ~0,
            QueryTriggerInteraction.Ignore);

        foreach (Collider hit in hits)
        {
            if (hit != floor)
            {
                return false;
            }
        }
        return true;
    }

    // 황금비만큼 색상을 돌려 매번 눈에 띄게 다른 색
    private Color GetNextColor()
    {
        hue = Mathf.Repeat(hue + GoldenRatio, 1f);
        return Color.HSVToRGB(hue, 0.85f, 1f);
    }
}
