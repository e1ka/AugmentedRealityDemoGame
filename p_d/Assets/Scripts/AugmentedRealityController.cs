using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AugmentedRealityController : MonoBehaviour {
    public bool c1, c2, c3, c4, startField;
    Transform c1Trans, c2Trans, c3Trans, c4Trans, startTrans;
    public void OnMarkerDetection(string mName, Transform mTrans)
    {
        switch (mName)
        {
            case "r1":
                c1 = true;
                c1Trans = mTrans;
                break;
            case "r2":
                c2 = true;
                c2Trans = mTrans;
                break;
            case "r3":
                c3 = true;
                c3Trans = mTrans;
                break;
            case "r4":
                c4 = true;
                c4Trans = mTrans;
                break;
            case "start":
                startField = true;
                startTrans = mTrans;
                break;
        }
    }
    public void OnMarkerLost(string mName)
    {
        switch (mName)
        {
            case "r1":
                c1 = false;
                break;
            case "r2":
                c2 = false;
                break;
            case "r3":
                c3 = false;
                break;
            case "r4":
                c4 = false;
                break;
            case "start":
                startField = false;
                break;
        }
    }

    public bool CheckCornersMarkers() 
    {
        if (c1 && c2 && c3 && c4 && startField)
            return true;
        else
            return false;
    }

    public void GetStartTransform(ref Transform _startTrans)
    {
        _startTrans = startTrans;
    }

    public void GetTransforms(ref Transform _c1Trans, ref Transform _c2Trans, ref Transform _c3Trans, ref Transform _c4Trans)
    {
        _c1Trans = c1Trans;
        _c2Trans = c2Trans;
        _c3Trans = c3Trans;
        _c4Trans = c4Trans;
    }
}
