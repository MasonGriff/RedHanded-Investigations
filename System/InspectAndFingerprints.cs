using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectAndFingerprints : MonoBehaviour {

    public EvidenceCheck Evidence;
    [Tooltip("Set on for if item uses Inspect Only script")]
    public bool InpsectOnlyCheck;
    public InspectOnly Items;
    

    public void InspectItem()
    {
        if (!InpsectOnlyCheck)
        { Evidence.InspectVoid(); }

        else if (InpsectOnlyCheck)
        {
            { Items.InspectVoid(); }
        }
    }
    public void ScanFingerprints()
    {
        Evidence.FingerprintVoid();
    }

}
