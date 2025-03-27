using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    public IObjectPool<GameObject> objectPool { get; private set; }
    public static ObjectPoolManager instance;

    //Ǯ���� ������Ʈ ������
    [SerializeField] private GameObject prefab; 

    //�ʱ� Ǯ ũ��
    private const int defaultCapacity = 5;
    //Ǯ �ִ� ũ��
    private const int maxSize = 10;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        objectPool = new ObjectPool<GameObject>(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, false, defaultCapacity, maxSize);
    }

    //���ο� ������Ʈ ����
    private GameObject createFunc()
    {
        return Instantiate(prefab);
    }

    //objectPool.Get(obj) �ϸ� ����
    private void actionOnGet(GameObject obj)
    {
        obj.SetActive(true);
    }

    //objectPool.Release(obj) �ϸ� ����
    private void actionOnRelease(GameObject obj)
    {
        obj.SetActive(false);
    }

    //Ǯ���� ������ �� ������ �Լ�
    private void actionOnDestroy(GameObject obj)
    {
        Destroy(obj);
    }

    void Update()
    {
        //�̸� ������Ʈ �����صα�
        for (int i = 0; i < defaultCapacity; i++)
        {
            GameObject obj = createFunc();
            obj.transform.position = new Vector3(0, 0, 0);
            actionOnRelease(obj);
        }
    }
}