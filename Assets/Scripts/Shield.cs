using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //���콺�� ��ġ�� ������Ʈ �̵�
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }
}
