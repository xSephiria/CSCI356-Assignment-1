using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundSliderBehaviour : MonoBehaviour, IEndDragHandler
{
    public MainMenu mainMenuScript;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuScript = GameObject.FindObjectOfType<MainMenu>();
        if (mainMenuScript == null)
        {
            Debug.LogError("main menu script not found");
        }

    }

    public void OnEndDrag(PointerEventData data)
    {
        mainMenuScript.PlaySFX();
    }
}
