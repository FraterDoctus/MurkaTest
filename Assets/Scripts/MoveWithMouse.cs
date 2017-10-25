using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    private void Update()
    {
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(position.x, position.y, 0f);
    }
}