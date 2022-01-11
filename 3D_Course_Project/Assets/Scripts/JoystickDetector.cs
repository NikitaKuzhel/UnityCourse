using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickDetector : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IMovable
{
    [SerializeField] private Transform _background;
    [SerializeField] private Transform _thumble;

    [SerializeField] private float _radius = 128f;

    private Vector3 _joystickVector;

    public bool IsMoved { get; private set; }

    public Vector3 MotionVector => _joystickVector;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _background.position = eventData.position; // джойстик появится в месте нажатия
        _thumble.position = eventData.position;    // кнопка появится в месте нажатия
        ShowBackground();
        IsMoved = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var distance = Vector3.Distance(_background.position, eventData.position); // расстояние от кнопки до края джойстика
        var direction = (new Vector3(eventData.position.x, eventData.position.y) - _background.position).normalized;
        distance = Mathf.Clamp(distance, 0, _radius);
        var normalizedDistance = distance / _radius;
        _joystickVector = direction * normalizedDistance;
        _thumble.position = _background.position + direction * _radius * normalizedDistance;
        Debug.Log($"Joystick vector {_joystickVector}");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        IsMoved = false;
        HideBackground();
    }

    // Start is called before the first frame update
    void Start()
    {
        HideBackground();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowBackground()
    {
        _background.gameObject.SetActive(true);
    }

    private void HideBackground()
    {
        _background.gameObject.SetActive(false);
    }
}

public interface IMovable
{
    bool IsMoved { get; }
    Vector3 MotionVector { get; }
}
