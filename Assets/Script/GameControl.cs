using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static event Action HandlePulled = delegate { };

    [SerializeField]
    public Text prize;

    [SerializeField]
    public Row[] rows;

    [SerializeField]
    public Transform handle;

    public int Prize;

    public bool resultChecked = false;


     void Update()
    {
        if (!rows[0].RowStopped || !rows[1].RowStopped || !rows[2].RowStopped)
        {
            Prize = 0;
            prize.enabled = false;
            resultChecked = false;
        }
        if (rows[0].RowStopped && rows[1].RowStopped && rows[2].RowStopped && !resultChecked)
        {
            CheckResults();
            prize.enabled = true;
            prize.text = "Prize: " + Prize;
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("mouse clicked");
        if (rows[0].RowStopped && rows[1].RowStopped && rows[2].RowStopped)
            StartCoroutine("Pull");
    }
    private IEnumerator Pull()
    {
        for (int i = 0; i < 15; i += 5)
        {
            handle.Rotate(0f, 0f, i);
            yield return new WaitForSeconds(0.1f);
        }
        HandlePulled();

        for (int i = 0; i < 15; i += 5)
        {
            handle.Rotate(0f, 0f, -i);
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void CheckResults()
    {
        if (rows[0].StoppedSlot == "Diamond"
            && rows[1].StoppedSlot == "Diamond"
            && rows[2].StoppedSlot == "Diamond")

            Prize = 200;
        else if (rows[0].StoppedSlot == "Crown"
            && rows[1].StoppedSlot == "Crown"
            && rows[2].StoppedSlot == "Crown")

            Prize = 400;
        else if (rows[0].StoppedSlot == "Melon"
            && rows[1].StoppedSlot == "Melon"
            && rows[2].StoppedSlot == "Melon")

            Prize = 600;
        else if (rows[0].StoppedSlot == "Bar"
            && rows[1].StoppedSlot == "Bar"
            && rows[2].StoppedSlot == "Bar")

            Prize = 800;
        else if (rows[0].StoppedSlot == "Seven"
            && rows[1].StoppedSlot == "Seven"
            && rows[2].StoppedSlot == "Seven")

            Prize = 1000;
        else if (rows[0].StoppedSlot == "Cherry"
            && rows[1].StoppedSlot == "Cherry"
            && rows[2].StoppedSlot == "Cherry")

            Prize = 1200;
        else if (rows[0].StoppedSlot == "Lemon"
            && rows[1].StoppedSlot == "Lemon"
            && rows[2].StoppedSlot == "Lemon")

            Prize = 1400;

        else if (((rows[0].StoppedSlot == rows[1].StoppedSlot)
            && (rows[0].StoppedSlot == "Diamond"))

            || ((rows[0].StoppedSlot == rows[2].StoppedSlot)
            && (rows[0].StoppedSlot == "Diamond"))

            || ((rows[1].StoppedSlot == rows[2].StoppedSlot)
            && (rows[1].StoppedSlot == "Diamond")))


            Prize = 100;

        else if (((rows[0].StoppedSlot == rows[1].StoppedSlot)
            && (rows[0].StoppedSlot == "Crown"))

            || ((rows[0].StoppedSlot == rows[2].StoppedSlot)
            && (rows[0].StoppedSlot == "Crown"))

            || ((rows[1].StoppedSlot == rows[2].StoppedSlot)
            && (rows[1].StoppedSlot == "Crown")))


            Prize = 200;


        else if (((rows[0].StoppedSlot == rows[1].StoppedSlot)
            && (rows[0].StoppedSlot == "Melon"))

            || ((rows[0].StoppedSlot == rows[2].StoppedSlot)
            && (rows[0].StoppedSlot == "Melon"))

            || ((rows[1].StoppedSlot == rows[2].StoppedSlot)
            && (rows[1].StoppedSlot == "Melon")))


            Prize = 300;


        else if (((rows[0].StoppedSlot == rows[1].StoppedSlot)
            && (rows[0].StoppedSlot == "Bar"))

            || ((rows[0].StoppedSlot == rows[2].StoppedSlot)
            && (rows[0].StoppedSlot == "Bar"))

            || ((rows[1].StoppedSlot == rows[2].StoppedSlot)
            && (rows[1].StoppedSlot == "Bar")))


            Prize = 300;


        else if (((rows[0].StoppedSlot == rows[1].StoppedSlot)
            && (rows[0].StoppedSlot == "Seven"))

            || ((rows[0].StoppedSlot == rows[2].StoppedSlot)
            && (rows[0].StoppedSlot == "Seven"))

            || ((rows[1].StoppedSlot == rows[2].StoppedSlot)
            && (rows[1].StoppedSlot == "Seven")))


            Prize = 400;


        else if (((rows[0].StoppedSlot == rows[1].StoppedSlot)
            && (rows[0].StoppedSlot == "Cherry"))

            || ((rows[0].StoppedSlot == rows[2].StoppedSlot)
            && (rows[0].StoppedSlot == "Cherry"))

            || ((rows[1].StoppedSlot == rows[2].StoppedSlot)
            && (rows[1].StoppedSlot == "Cherry")))


            Prize = 500;


        else if (((rows[0].StoppedSlot == rows[1].StoppedSlot)
            && (rows[0].StoppedSlot == "Lemon"))

            || ((rows[0].StoppedSlot == rows[2].StoppedSlot)
            && (rows[0].StoppedSlot == "Lemon"))

            || ((rows[1].StoppedSlot == rows[2].StoppedSlot)
            && (rows[1].StoppedSlot == "Lemon")))


            Prize = 600;
        resultChecked = true;
    }
}
