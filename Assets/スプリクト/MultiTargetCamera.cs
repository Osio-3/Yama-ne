using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 複数キャラを常に画面に収める2Dカメラ
/// </summary>
[RequireComponent(typeof(Camera))]
public class MultiTargetCamera : MonoBehaviour
{
    [Header("追跡対象（キャラ）")]
    public List<Transform> targets = new List<Transform>();

    [Header("オフセット設定")]
    public Vector3 offset = new Vector3(0, 0, -10);

    [Header("カメラ移動スムーズさ")]
    public float smoothSpeed = 2f;

    [Header("ズーム設定")]
    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float zoomLimiter = 50f;

    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (targets.Count == 0) return;

        Move();
        Zoom();
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smoothSpeed);
    }

    void Zoom()
    {
        float greatestDistance = GetGreatestDistance();
        float newZoom = Mathf.Lerp(maxZoom, minZoom, greatestDistance / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime * smoothSpeed);
    }

    float GetGreatestDistance()
    {
        if (targets.Count == 1) return 0;

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        foreach (var t in targets)
            bounds.Encapsulate(t.position);

        return Mathf.Max(bounds.size.x, bounds.size.y);
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
            return targets[0].position;

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        foreach (var t in targets)
            bounds.Encapsulate(t.position);

        return bounds.center;
    }
}
