using System.Collections.Generic;
using UnityEngine;

public class GameDetectorCollider2D : MonoBehaviour
{
    public event System.Action<List<Collider2D>> OnDetectionListChange;
    public event System.Action<Collider2D> OnDetectorDetects;
    public event System.Action<Collider2D> OnDetectorLost;

    [SerializeField] CircleCollider2D circleCollider;
    [SerializeField] float radius;

    private List<Collider2D> myDetections;

    private void Start()
    {
        myDetections = new List<Collider2D>();
    }

    public void Set(CircleCollider2D? circleCollider2D, float? radius)
    {
        this.circleCollider = circleCollider2D ?? this.circleCollider;
        this.radius = radius ?? this.radius;
    }

    public CircleCollider2D GetCollider() => this.circleCollider;
    public float GetRadius() => this.radius;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Collider2D item))
        {
            myDetections.Add(item);
            OnDetectorDetects?.Invoke(item);
            OnDetectionListChange?.Invoke(myDetections);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Collider2D item))
        {
            myDetections.Remove(item);
            OnDetectorLost?.Invoke(item);
            OnDetectionListChange?.Invoke(myDetections);
        }
    }
}
