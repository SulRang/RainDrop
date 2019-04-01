using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DestoryArrow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            if (col.gameObject.name.Equals("Arrow(Normal)(Clone)"))
            {
                if(col.GetComponent<ArrowMove>().speed >= 4)
                    AudioManager.Instance.RandomSoundEffect(AudioManager.Instance.RainCol);
            }
            else if(col.gameObject.name.Equals("Arrow(ChangeSpeed)(Clone)"))
            {
                if (col.GetComponent<ArrowChangeSpeedMove>().speed >= 4)
                    AudioManager.Instance.RandomSoundEffect(AudioManager.Instance.RainCol);
            }
            else if (col.gameObject.name.Equals("Arrow(ChangePosition)(Clone)"))
            {
                if (col.GetComponent<ArrowChangePositionMove>().speed >= 4)
                    AudioManager.Instance.RandomSoundEffect(AudioManager.Instance.RainCol);
            }

            Destroy(col.gameObject);
        }
    }
}
