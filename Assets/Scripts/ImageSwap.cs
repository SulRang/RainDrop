using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwap : MonoBehaviour
{
    public Sprite[] Source;
    public Image image;
    private bool swap = false;

    public void SwapImage()
    {
        if (swap) { image.sprite = Source[0]; swap = !swap; }
        else { image.sprite = Source[1]; swap = !swap; }
    }
}
