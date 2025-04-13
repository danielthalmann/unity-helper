using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : PointOfInterestAbstract
{
    private ActionTrigger action;

    // Start is called before the first frame update
    void Start()
    {

        if (this.GetComponent<Collider>() == null)
        {
            Debug.LogError("PointOfInterest need one collider to work correctly.");
        }

       action = this.GetComponent<ActionTrigger>();

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + offset, .05f);

        if (activeDestination)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(GetPointOfInterestDestination(), .05f);
        }

    }

    private void OnMouseEnter()
    {
        if (action != null)
        {
            enabled = action.enabled;
        }

        if (enabled)
        {
            PointOfInterestManager.getInstance().setPointOfInterest(this);
            PointOfInterestManager.getInstance().ShowPointOfInterest();
        }

    }

    public Vector3 GetPointOfInterestDestination()
    {
        return transform.position + destination;
    }

    private void OnMouseExit()
    {
        if (enabled)
        {
            PointOfInterestManager.getInstance().HidePointOfInterest();
        }
    }

}
