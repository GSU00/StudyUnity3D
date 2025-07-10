using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private ObjectPoolQueue pool;

    public float bulletSpeed = 10f;

    void Awake()
    {
        pool = FindFirstObjectByType<ObjectPoolQueue>();
    }

    void OnEnable()
    {
        Invoke("ReturnPool", 3f);
    }

    void Update()
    {
        transform.position += Vector3.back * Time.deltaTime * bulletSpeed;
    }

    private void ReturnPool()
    {
        pool.EnqueueObject(gameObject);
    }
}
