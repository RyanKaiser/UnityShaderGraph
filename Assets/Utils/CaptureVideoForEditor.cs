using UnityEngine;
using System;

#if UNITY_EDITOR
using System.IO;
using UnityEditor.Recorder;
using UnityEditor.Recorder.Input;
using static UnityEditor.Recorder.MovieRecorderSettings;
#endif

public class CaptureVideoForEditor : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] string _filePath = "../CapturedScreens/";
    MovieRecorderSettings _movieRecorderSettings;
    RecorderController _recorderController;
    bool _isRecording = false;

    private void Awake()
    {
        enabled = true;
        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        Debug.Log("Video recorder is enabled");
        try
        {
            if (!Directory.Exists(_filePath))
            {
                Directory.CreateDirectory(_filePath);
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }


        RecorderOptions.VerboseMode = true;

        var controllerSettings = ScriptableObject.CreateInstance<RecorderControllerSettings>();
        _recorderController = new RecorderController(controllerSettings);

        _movieRecorderSettings = ScriptableObject.CreateInstance<MovieRecorderSettings>();
        _movieRecorderSettings.name = "My Video Recorder";
        _movieRecorderSettings.Enabled = true;

        _movieRecorderSettings.OutputFormat = VideoRecorderOutputFormat.MP4;
        _movieRecorderSettings.VideoBitRateMode = UnityEditor.VideoBitrateMode.High;

        _movieRecorderSettings.ImageInputSettings = new GameViewInputSettings
        {
            OutputWidth = Screen.width >> 1 << 1,
            OutputHeight = Screen.height >> 1 << 1
        };

        _movieRecorderSettings.AudioInputSettings.PreserveAudio = true;

        controllerSettings.AddRecorderSettings(_movieRecorderSettings);
        controllerSettings.SetRecordModeToFrameInterval(0, 60 * 60 * 10); // 
        controllerSettings.FrameRate = 60;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote) && Input.GetKey(KeyCode.LeftControl))
        {
            _isRecording = !_isRecording;

            if (_isRecording)
                StartRecording();
            else
            {
                _recorderController.StopRecording();
                Debug.Log("Stop Recording.");
            }
        }
        else if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            string filename = _filePath + "Screenshot" + DateTime.Now.Second + DateTime.Now.Millisecond + ".png";
            ScreenCapture.CaptureScreenshot(filename);
            Debug.Log($"Screenshot {filename} is created");
        }
    }

    public void StartRecording()
    {
        string filename = _filePath + "Video" + DateTime.Now.ToString("MMddyyyyHHmmss") + DateTime.Now.Millisecond;
        _movieRecorderSettings.OutputFile = filename;

        _recorderController.PrepareRecording();
        _recorderController.StartRecording();
        Debug.Log("Start Recording: " + filename);
    }
#endif
}

