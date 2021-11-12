using UnityEngine;

public class PartRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 5f;
    private Vector2 _touchStartPoint;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _touchStartPoint = touch.position;
                    break;
                case TouchPhase.Moved:
                    float x = touch.deltaPosition.x * -1 * _rotationSpeed * Time.deltaTime;
                    float y = touch.deltaPosition.y * _rotationSpeed * Time.deltaTime; 
                    transform.Rotate(y, x, 0);
                    break;
            }
        }
    }
}