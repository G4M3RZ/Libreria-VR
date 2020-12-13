using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    public Transform _hands;
    public List<string> _text;
    public TextMeshProUGUI _tmp;

    public void ReadingBook()
    {
        if (_hands.childCount != 0)
            StartCoroutine(ShowBookInfo());
    }
    public void StopReadingBook()
    {
        if (_hands.childCount != 0)
            StopAllCoroutines();
    }
    IEnumerator ShowBookInfo()
    {
        for (int i = 0; i < _text.Count; i++)
        {
            _tmp.text = "";
            for (int e = 0; e < _text[i].Length; e++)
            {
                string text = _text[i];
                _tmp.text = _tmp.text + text[e];
                yield return new WaitForSeconds(0.01f);
            }

            yield return waitForKeyPress("Fire1");
        }
    }
    IEnumerator waitForKeyPress(string _inputName)
    {
        bool done = false;
        while (!done)
        {
            if (Input.GetAxis(_inputName) != 0)
                done = true;

            yield return null;
        }
    }
}