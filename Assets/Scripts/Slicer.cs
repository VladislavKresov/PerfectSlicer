using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BzKovSoft.ObjectSlicer;
using DG.Tweening;
using BzKovSoft.ObjectSlicerSamples;

public class Slicer : MonoBehaviour
{
    [SerializeField] private GameObject _knife;
    [SerializeField] private float _sliceDuration;
    [SerializeField] private float _sliceDistanceY;

    private float _timeAfterSlice = 0;
    private BzKnife _blade;
    private void Start()
    {
        _blade = _knife.GetComponentInChildren<BzKnife>();
    }

    private void Update()
    {
        _timeAfterSlice += Time.deltaTime;

        if(Input.GetMouseButton(0) && _timeAfterSlice >= _sliceDuration * 2)
        {
            _blade.BeginNewSlice();
            _knife.transform.DOMoveY(_knife.transform.position.y - _sliceDistanceY, _sliceDuration).SetLoops(2,LoopType.Yoyo);
            _timeAfterSlice = 0;
        }

    }
}
