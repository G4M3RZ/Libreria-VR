using System.Collections;
using UnityEngine;

public class HandsDetector : MonoBehaviour
{
    public GvrReticlePointer _reticle;
    [Range(0, 5)] public float _selectionSpeed;

    public Transform _obj;

    private void Awake()
    {
        _reticle.reticleGrowthSpeed = _selectionSpeed * 2;
    }

    #region Character Actions
    public void GrabObject(Transform Object)
    {
        StartCoroutine(GrabingObject(Object));
    }
    public void DropObject(Transform Place)
    {
        StartCoroutine(DropingObject(Place));
    }
    public void StopGrabing()
    {
        StopAllCoroutines();
        _obj = null;
    }
    #endregion

    IEnumerator GrabingObject(Transform Obj)
    {
        _obj = Obj;
        yield return new WaitUntil(() => _reticle.ReticleInnerDiameter >= 0.025f);
        _obj.parent = transform;
    }
    IEnumerator DropingObject(Transform Container)
    {
        yield return new WaitUntil(() => _reticle.ReticleInnerDiameter >= 0.025f);
        _obj.parent = Container;
        _obj = null;
    }
}