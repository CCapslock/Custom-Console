using UnityEngine;

public class PartControll
{
    private Transform _rotationObject;
    private float _rotationSpeed = 5f;
    private Vector2 _touchStartPoint;

    public PartControll(Transform rotationObject)
    {
        _rotationObject = rotationObject;
    }

    public void Action()
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
                    _rotationObject.Rotate(y, x, 0);
                    break;
            }// добавить зум и обсудить удобство управления
        }
    }
}