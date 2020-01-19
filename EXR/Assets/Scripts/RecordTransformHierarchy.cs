using UnityEngine;
using UnityEditor.Animations;
using UnityEngine.UI;

public class RecordTransformHierarchy : MonoBehaviour
{
    public AnimationClip clip;
    public AnimationClip clip2;
    private GameObjectRecorder m_Recorder;
    public Button b;
    public Button b1;
    private bool button_state=false;
    
    void Start()
    {
        // Create recorder and record the script GameObject.
        m_Recorder = new GameObjectRecorder(gameObject);

        // Bind all the Transforms on the GameObject and all its children.
//        m_Recorder.BindComponentsOfType<Transform>(gameObject, true);
    }

    void Update()
    {
        b.onClick.AddListener(TaskOnClick);
        b1.onClick.AddListener(TaskOnClick2);
        
    }

    public void TaskOnClick()
    {
        if (button_state == false)
        {
            print("starts");
            m_Recorder.BindComponentsOfType<Transform>(gameObject, true);
            button_state = true;
            string t= b.GetComponent<Text>().text ;
            t = "Stop";

        }
        else
        {
            print("Stops");
            OnDisable();
            button_state = false;
            string t= b.GetComponent<Text>().text ;
            t = "start";        }
           }

    public void TaskOnClick2()
    {
        print("play doubt");
//        this.GetComponent<Animation>().animation = clip2;
    }
    void LateUpdate()
    {
        if (clip == null)
            return;

        // Take a snapshot and record all the bindings values for this frame.
        m_Recorder.TakeSnapshot(Time.deltaTime);
        print(m_Recorder.isRecording);
    }

    void OnDisable()
    {
        if (clip == null)
            return;

        if (m_Recorder.isRecording)
        {
            // Save the recorded session to the clip.
            m_Recorder.SaveToClip(clip2);
        }
    }
}