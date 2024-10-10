using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UimageLogic : MonoBehaviour
{
    public GameObject imageToToggle;

    public void ShowImage()
    {
        imageToToggle.SetActive(true);
    }


    public void HideImage()
    {
        imageToToggle.SetActive(false);
    }

    public void OnHitButtonCLick()
    {
        HideImage();
    }
}
