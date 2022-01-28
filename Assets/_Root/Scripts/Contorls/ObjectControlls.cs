using UnityEngine;

public class ObjectControlls
{
    public bool active = true; 
    private Transform _objectOfControll;
    private Transform _orignalobject;
    private float _rotationSpeed = 5f;
    private float _movementSpeed = 0.0025f;
    private ControllsType _type = ControllsType.Rotation;
    private Vector2 _xValueMovement;
    private Vector2 _yValueMovement;

    public ObjectControlls(Transform originalControll)
    {
        _objectOfControll = originalControll;
        _orignalobject = originalControll;
    }

    public void Action()
    {
        if (active)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        if (_type == ControllsType.Rotation)
                        {
                            float x = touch.deltaPosition.x * -1 * _rotationSpeed * Time.deltaTime;
                            float y = touch.deltaPosition.y * _rotationSpeed * Time.deltaTime;
                            _objectOfControll.Rotate(0, x, y);
                            _objectOfControll.rotation = Quaternion.Euler(0, _objectOfControll.rotation.eulerAngles.y, _objectOfControll.rotation.eulerAngles.z);
                        }
                        if (_type == ControllsType.Movement)
                        {
                            Vector3 position = _objectOfControll.localPosition;
                            float x = touch.deltaPosition.x * _movementSpeed * Time.deltaTime;
                            float y = touch.deltaPosition.y * _movementSpeed * Time.deltaTime;
                            y += position.y;
                            x += position.x;
                            if ((_xValueMovement.x <= x)&&(x<=_xValueMovement.y))
                            {
                                position.x = x;
                            }
                            if ((_yValueMovement.x <= y) && (y <= _yValueMovement.y))
                            {
                                position.y = y;
                            }
                            _objectOfControll.localPosition = position;
                        }
                        break;
                }// добавить зум и обсудить удобство управления
            }
        }
    }

    public void SetObject(Transform objectOfControll)
    {
        _objectOfControll = objectOfControll;
    }

    public void SetRotation()
    {
        _type = ControllsType.Rotation;
    }
    public void SetMovement(Vector2 x, Vector2 y)
    {
        _xValueMovement = x;
        _yValueMovement = y;

        _type = ControllsType.Movement;
    }
    public void ClearRotation()
    {
        _objectOfControll.rotation = Quaternion.identity;
    }
    public void TurnToBack()
    {
        _objectOfControll.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }
    public void ReturnControllToOriginal()
    {
        _objectOfControll = _orignalobject;
    }
}