using UnityEngine;

public class CircleShower : MonoBehaviour
{
    [SerializeField] private Transform _circle;

    public void ShowCircle(float radius)
    {
        _circle.gameObject.SetActive(true);
        var scale = _circle.transform.localScale;

        scale.x = radius;
        scale.y = radius;

        _circle.transform.localScale = scale;
    }

    public void CloseCircle()
    {
        _circle.gameObject.SetActive(false);
    }
}
