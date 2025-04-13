using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : ActionTrigger
{
    public Dialogue dialogue;
    public bool RepeatDialog = true;

    public bool readed = false;

    PointOfInterest poi;

    void Start()
    {
        poi = GetComponent<PointOfInterest>();
    }

    public override void Trigger()
    {
        if (!enabled)
        {
            return;
        }

        if (RepeatDialog)
        {
            FindFirstObjectByType<DialogManager>().StartDialogue(dialogue);
        } else
        {
            if (!readed)
            {
                FindFirstObjectByType<DialogManager>().StartDialogue(dialogue);
                readed = true;
                enabled = false;
                if(poi)
                {
                    poi.enabled = false;
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Trigger();
    }
}
