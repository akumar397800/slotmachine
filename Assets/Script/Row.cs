using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int randomValue;
    private float timeInter;

    public bool RowStopped;
    public string StoppedSlot;                               

    void Start()
    {
        RowStopped = true;
        GameControl.HandlePulled += StartRot;
    }

    void StartRot()
    {
        StoppedSlot = "";
        StartCoroutine("Rotatee");
    }

    private IEnumerator Rotatee()
    {
        RowStopped = false;
        timeInter = 0.025f;
        for (int i = 0; i < 30; i++)
        {
            if (transform.position.y <= -3.5f)
                transform.position = new Vector2(transform.position.x, 1.75f);
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);
            yield return new WaitForSeconds(timeInter);
        }
        randomValue = Random.Range(60, 100);
        switch (randomValue % 3)
        {
            case 1:
                randomValue += 2;
                break;
            case 2:
                randomValue += 1;
                break;
        }
        for (int i = 0; i < randomValue; i++)
        {
            if (transform.position.y <= -3.5f)
                transform.position = new Vector2(transform.position.x, 1.75f);
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);

            if (i > Mathf.RoundToInt(randomValue * 0.25f))
                timeInter = 0.05f;
            if (i > Mathf.RoundToInt(randomValue * 0.5f))
                timeInter = 0.1f;
            if (i > Mathf.RoundToInt(randomValue * 0.75f))
                timeInter = 0.15f;
            if (i > Mathf.RoundToInt(randomValue * 0.95f))
                timeInter = 0.2f;
            yield return new WaitForSeconds(timeInter);
        }
        if (transform.position.y == -3.5f)
            StoppedSlot = "Diamond";
        else if (transform.position.y == -2.75f)
            StoppedSlot = "Crwon";
        else if (transform.position.y == -2f)
            StoppedSlot = "Melon";
        else if (transform.position.y == -1.25f)
            StoppedSlot = "Bar";
        else if (transform.position.y == -0.5f)
            StoppedSlot = "Seven";
        else if (transform.position.y == -0.25)
            StoppedSlot = "Cherry";
        else if (transform.position.y == -1f)
            StoppedSlot = "Lemon";
        else if (transform.position.y == -1.75f)
            StoppedSlot = "Diamond";

        RowStopped = true;
    }
    private void OnDestroy()
    {
        GameControl.HandlePulled -= StartRot;
    }
}