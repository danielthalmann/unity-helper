using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PointOfInterestManager : MonoBehaviour
{

    [Header("UI")]
    public GameObject UiBox = null;
    public TMP_Text UiTitle = null;
    public Vector3 offset;

    [Header("Events")]
    public UnityEvent onShow;
    public UnityEvent onHide;

    [Header("Translate")]
    public PointOfInterestTranslate translate;

    private PointOfInterestAbstract pointOfInterest;

    private static PointOfInterestManager instance;

    public static PointOfInterestManager getInstance()
    {
        if (instance == null)
        {
            instance = FindAnyObjectByType<PointOfInterestManager>();
        }

        return instance;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one PointOfInterestManager in the scene.");
        }

        instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        UiBox.SetActive(false);
    }

    public void setPointOfInterest(PointOfInterestAbstract poi)
    {
        pointOfInterest = poi;
    }


    public void ShowPointOfInterest()
    {
        if ( !enabled )
        {
            return;
        }

        Vector3 vscreen = Camera.main.WorldToScreenPoint(pointOfInterest.transform.position + pointOfInterest.offset);
        UiBox.transform.position = vscreen + offset;

        if (translate)
        {
            UiTitle.text = translate.Translate(pointOfInterest.title);
        } else
        {
            UiTitle.text = pointOfInterest.title;
        }

        UiBox.SetActive(true);
        onShow.Invoke();

    }

    public void HidePointOfInterest()
    {
        UiBox.SetActive(false);
        onHide.Invoke();
    }

}
