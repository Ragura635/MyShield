using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    public IObjectPool<GameObject> objectPool { get; private set; }
    public static ObjectPoolManager instance;

    //풀링할 오브젝트 프리팹
    [SerializeField] private GameObject prefab; 

    //초기 풀 크기
    private const int defaultCapacity = 5;
    //풀 최대 크기
    private const int maxSize = 10;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        objectPool = new ObjectPool<GameObject>(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, false, defaultCapacity, maxSize);
    }

    //새로운 오브젝트 생성
    private GameObject createFunc()
    {
        return Instantiate(prefab);
    }

    //objectPool.Get(obj) 하면 실행
    private void actionOnGet(GameObject obj)
    {
        obj.SetActive(true);
    }

    //objectPool.Release(obj) 하면 실행
    private void actionOnRelease(GameObject obj)
    {
        obj.SetActive(false);
    }

    //풀에서 삭제될 때 실행할 함수
    private void actionOnDestroy(GameObject obj)
    {
        Destroy(obj);
    }

    void Update()
    {
        //미리 오브젝트 생성해두기
        for (int i = 0; i < defaultCapacity; i++)
        {
            GameObject obj = createFunc();
            obj.transform.position = new Vector3(0, 0, 0);
            actionOnRelease(obj);
        }
    }
}