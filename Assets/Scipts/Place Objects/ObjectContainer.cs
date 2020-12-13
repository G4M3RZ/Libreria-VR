using UnityEngine;

public class ObjectContainer : MonoBehaviour
{
    private MeshRenderer _render;
    private BoxCollider _collider;

    private void Awake()
    {
        _render = GetComponent<MeshRenderer>();
        _collider = GetComponent<BoxCollider>();
    }
    private void Update()
    {
        bool active = (transform.childCount != 0) ? false : true;
        _render.enabled = _collider.enabled = active;
    }
}