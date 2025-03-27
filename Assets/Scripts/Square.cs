using UnityEngine;
using UnityEngine.Pool;

public class Square : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float x = Random.Range(-3.0f, 3.0f);
        float y = Random.Range(3.0f, 5.0f);
        float size = Random.Range(0.5f, 1.5f);

        transform.position = new Vector2(x, y);
        transform.localScale = new Vector2(size, size);

        Invoke("SelfDestroy", 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    public void DestroyBSelfDestroyullet()
    {
        ObjectPoolManager.instance.objectPool.Release(this.gameObject);
    }
}
