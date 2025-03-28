using UnityEngine;
using UnityEngine.Pool;

public class Square : MonoBehaviour
{
    /*
    기존 코드
    void Start()
    {
        float x = Random.Range(-3.0f, 3.0f);
        float y = Random.Range(3.0f, 5.0f);
        float size = Random.Range(0.5f, 1.5f);

        transform.position = new Vector2(x, y);
        transform.localScale = new Vector2(size, size);
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    */

    private void Update()
    {
        if (this.transform.position.y < -5)
        {
            ObjectPoolManager.instance.ReleaseObject(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }
}
