using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [Range(0, 10)]
    public float _speed;
    private void Update()
    {
        if(Vector3.Distance(transform.localPosition, Vector3.zero) > 0.1f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, Time.deltaTime * _speed / 2);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.identity, Time.deltaTime * _speed);
        }
    }
}