using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolQueue : MonoBehaviour
{
    public Queue<GameObject> objQueue = new Queue<GameObject>(); // 오브젝트들이 들어갈 큐

    public GameObject objPrefabs; // 생성할 오브젝트
    public Transform parent; // 계층 구조상 들어갈 부모 오브젝트

    private void Start()
    {
        CreateObject();
    }

    private void CreateObject()
    {
        for (int i = 0; i < 30; i++)
        {
            GameObject obj = Instantiate(objPrefabs, parent); // 오브젝트를 생성하고, 계층구조를 parent의 자식으로 변경
            EnqueueObject(obj);
        }
    }

    public void EnqueueObject(GameObject newObj)
    {
        newObj.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        newObj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        objQueue.Enqueue(newObj);
        newObj.SetActive(false);
    }

    public GameObject DequeueObject()
    {
        if (objQueue.Count < 5)
            CreateObject();

        GameObject obj = objQueue.Dequeue();
        obj.SetActive(true);

        return obj;
    }
}
