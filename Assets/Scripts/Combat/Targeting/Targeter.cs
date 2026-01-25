using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    public List<Target> targets=new List<Target>();
    
    public Target currentTarget;    

    private void OnTriggerEnter(Collider other)
    {
       other.TryGetComponent<Target>(out Target target);
        if (target != null && !targets.Contains(target))
        {
            targets.Add(target);
        }
    }
    private void OnTriggerExit(Collider other)
    {
     other.TryGetComponent<Target>(out Target target);
        if (target != null && targets.Contains(target))
        {
            targets.Remove(target);
        }
    }
    public bool SelectTarget()
    {
        if (targets.Count == 0) return false;

        currentTarget = targets[0];
        return true;
    }
    public void Cancel()
    {
        currentTarget = null;
    }

}
