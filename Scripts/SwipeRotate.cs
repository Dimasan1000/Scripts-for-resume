using UnityEngine;

public class SwipeRotate : MonoBehaviour
{
    private Touch _touch;
    private Quaternion _nullrotation;
    private Quaternion _rotation;
    private float _rotateSpeedMod=0.2f;

    private void Start()
    {
        _nullrotation = _rotation;
    }
    private void Update ()
    {
     if(Input.touchCount > 0)
        {
            _touch=Input.GetTouch(0);
            Debug.Log(_touch.position);
            if(_touch.phase==TouchPhase.Moved && _touch.position.y>700 && _touch.position.y < 1600)
            {
                _rotation = Quaternion.Euler(0f, -_touch.deltaPosition.x*_rotateSpeedMod,0f);
                transform.rotation=_rotation*transform.rotation;
            }
        }   
    }

}
