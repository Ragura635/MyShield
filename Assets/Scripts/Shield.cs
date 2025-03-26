using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //마우스의 위치로 오브젝트 이동
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }
}
