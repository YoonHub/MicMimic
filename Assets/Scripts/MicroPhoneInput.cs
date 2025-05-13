using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MicrophoneInput : MonoBehaviour
{
    public static float Volume { get; private set; }
    [SerializeField] TMP_Dropdown _micList;
    [SerializeField] GameObject _settingsPanel;

    AudioClip _micClip;
    const int _sampleSize = 128;
    string _selectedMic;
    bool _showPanel = true;

    void Start()
    {
        List<string> micOptions = new List<string>(Microphone.devices);
        _micList.ClearOptions();
        _micList.AddOptions(micOptions);

        if (micOptions.Count > 0)
        {
            _selectedMic = micOptions[0];
            StartMic(_selectedMic);
        }

        _micList.onValueChanged.AddListener(OnMicDropdownChanged);
    }

    void OnMicDropdownChanged(int index)
    {
        string newMic = _micList.options[index].text;
        if (newMic != _selectedMic)
        {
            _selectedMic = newMic;
            StopMic();
            StartMic(_selectedMic);
        }
    }

    void StartMic(string micName)
    {
        _micClip = Microphone.Start(micName, true, 1, 44100);
    }

    void StopMic()
    {
        if (Microphone.IsRecording(_selectedMic))
            Microphone.End(_selectedMic);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _showPanel = !_showPanel;
            _settingsPanel.SetActive(_showPanel);
        }

        float[] samples = new float[_sampleSize];
        int micPos = Microphone.GetPosition(null) - _sampleSize;
        if (micPos < 0) return;

        _micClip.GetData(samples, micPos);

        float sum = 0;
        foreach (float sample in samples)
            sum += sample * sample;

        Volume = Mathf.Sqrt(sum / _sampleSize); // RMS °è»ê
    }
}
