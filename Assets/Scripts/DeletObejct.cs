using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeletObejct : MonoBehaviour
{
    private SpriteRenderer SR;

    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (SR.sprite.name == "bomb_7")
            Destroy(this.gameObject);
    }
}
