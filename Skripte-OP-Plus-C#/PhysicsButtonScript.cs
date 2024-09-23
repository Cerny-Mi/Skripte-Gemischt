using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButtonScript : MonoBehaviour
{

   // public UnityEvent onPressed, onReleased;
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.25f;
    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;


    //SOUND///
    AudioSource source1;
    public  AudioClip clip1;



    // Start is called before the first frame update
    void Start()
    {
        source1 = this.GetComponent<AudioSource>();
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 1)
            Pressed();

        if( _isPressed && GetValue() - threshold <= 0)
            Released(); 
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;
        if (Mathf.Abs(value) < deadZone)
            value = 0;
        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed() {
        _isPressed = true;
        if (!source1.isPlaying)
        {       //spielt Sound nur ab wenn kein Sound bereits läuft. Verhindert Dopplungen. Danke, Internet!
            source1.PlayOneShot(clip1);
        }
        Debug.Log("is pressed");
    }
    private void Released() {
        _isPressed = false;
        // onReleased.Invoke();
       // source1.Stop();
        Debug.Log("is released");
    }

}
