using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperScrapHandler : MonoBehaviour
{
    [SerializeField] PaperScrap[] paperScraps;

    public void OnScrapDrop()
    {
        StartCoroutine(WaitForPhysics());
    }

    IEnumerator WaitForPhysics()
    {
        yield return new WaitForSeconds(.5f);
        //looks for lined up colliders
        for (int i = 0; i < paperScraps.Length - 1; i++)
        {
            for (int c = 0; c < 3; c++)
            {
                if (!paperScraps[i].positionColliders[c].IsTouching(paperScraps[i + 1].positionColliders[c]))
                {
                    Debug.Log("Failure");
                    yield break;
                }
            }
        }
        //we have all colliders aligned
        Debug.Log("puzzle done");
    }
}
