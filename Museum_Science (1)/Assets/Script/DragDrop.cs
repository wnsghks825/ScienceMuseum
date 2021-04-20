using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour
{
    [SerializeField]
    Transform[] Conductor;
    public GameObject dropPosition;
    public GameObject dropPosition2;
    public GameObject[] others;
    //public bool allowBeginDrag;

    private IEnumerator Back;

    public Image[] star;

    float timer;
    float distance, distance2;

    bool exception;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        EventTrigger eventTrigger = gameObject.AddComponent<EventTrigger>();

        distance = Vector2.Distance(this.transform.position, dropPosition.transform.position);
        distance2 = Vector2.Distance(this.transform.position, dropPosition2.transform.position);
        i = 0;

        EventTrigger.Entry entry_Drag = new EventTrigger.Entry();
        entry_Drag.eventID = EventTriggerType.Drag;
        entry_Drag.callback.AddListener((data) => { OnDrag((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_Drag);

        EventTrigger.Entry entry_EndDrag = new EventTrigger.Entry();
        entry_EndDrag.eventID = EventTriggerType.EndDrag;
        entry_EndDrag.callback.AddListener((data) => { OnEndDrag((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_EndDrag);

    }

    private void OnEndDrag(PointerEventData data)
    {
        float distance = Vector2.Distance(this.transform.position, dropPosition.transform.position);

        print("distance : " + distance);

        if (distance < 50)
        {
            this.transform.position = dropPosition.transform.position;
            if (CompareTag("Electricity"))
            {
                //transform.gameObject.tag = "Non_Elec";
                star[i].gameObject.SetActive(true);
                i++;
            }
        }
    }

    private void OnDrag(PointerEventData data)
    {
        gameObject.transform.position = Input.mousePosition;
        for (int i = 0; i < others.Length - 1; i++)
        {
            others[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Return();
    }

    public void Return()
    {
        distance = Vector2.Distance(this.transform.position, dropPosition.transform.position);
        distance2 = Vector2.Distance(this.transform.position, dropPosition2.transform.position);

        if (distance < 50f && CompareTag("Electricity"))
        {
            Invoke("ElectricReturn", 2.0f);

        }

        if (distance < 50f && CompareTag("Non_Elec"))
        {
            Invoke("ElectricReturn", 2.0f);

        }

    }

    void ElectricReturn()
    {
        this.transform.position = Vector2.Lerp(this.transform.position, dropPosition2.transform.position, Time.deltaTime * 4.0f);
        if (distance2 < 50f)
        {
            this.transform.position = dropPosition2.transform.position;
            for (int i = 0; i < others.Length - 1; i++)
            {
                others[i].SetActive(true);
            }

        }
    }

}
