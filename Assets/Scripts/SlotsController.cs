using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class SlotsController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _fallGuyPrefabs = null;

    [SerializeField]
    private TextMeshProUGUI _text;

    public void Start()
    {
        Slot[] slots = GetComponentsInChildren<Slot>();
        _numberToChoose = Random.Range(26, 44);
        _numberLeft = slots.Length - _numberToChoose;
        slots = slots.OrderBy(slot => Random.value).ToArray();
        for (int i = 0; i < slots.Length; ++i)
        {
            Slot slot = slots[i];
            
            int index = Random.Range(0, _fallGuyPrefabs.Length);
            GameObject fallGuy = Instantiate(_fallGuyPrefabs[index], slot.FallGuyTarget);
            
            if (i < _numberToChoose)
            {
                slot.OnPushCompleteCallback = OnPusherComplete;
                slot.IsPusher = true;
                Rigidbody rigidBody = fallGuy.GetComponentInChildren<Rigidbody>();
                rigidBody.isKinematic = false;
            }
        }
    }

    private void OnPusherComplete()
    {
        _numberToChoose -= 1;
        _text.text = $"{_numberLeft + _numberToChoose} REMAIN!";
        if (_numberToChoose <= 0)
        {
            Slot[] slots = GetComponentsInChildren<Slot>();
            foreach (Slot slot in slots)
            {
                if (!slot.IsPusher)
                {
                    slot.ShowSuccess();
                }
            }
        }
    }

    private int _numberToChoose;
    private int _numberLeft;
}
