using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [System.Serializable]
    public struct WheelInfo
    {
        public Transform visualWheel;
        public WheelCollider wheelCollider;
    }

    [SerializeField]
    private AudioSource _idleSourse, _movementSourse, _nitroSourse, _brakeSourse;

    [SerializeField]
    private List<ParticleSystem> _brakeParticles = new List<ParticleSystem>();

    [SerializeField]
    private List<ParticleSystem> _nitroParticles = new List<ParticleSystem> ();

    [SerializeField]
    private float _motor = 800f, _steer = 50f, _brake = 440f, _motorNitro = 1200f;

    [SerializeField]
    private WheelInfo _FL, _FR, _BL, _BR;

    private float _vert;
    private float _horz;

    private Vector3 _position;
    private Quaternion _rotation;


    void Update()
    {
        _vert = (Input.GetAxis("Vertical"));
        _horz = (Input.GetAxis("Horizontal"));

        if(_vert != 0)
        {
            _idleSourse.Pause();
            _movementSourse.UnPause();
        }
        else
        {
            _idleSourse.UnPause();
            _movementSourse.Pause();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _motor = _motorNitro;
            for (int i = 0; i < _nitroParticles.Count; i++)
            {
                _nitroParticles[i].Play();
            }

        }

            else
            {
                _motor = _motor;
                for (int i = 0; i < _nitroParticles.Count; i++)
                {
                    _nitroParticles[i].Stop();
                }
            }

        if (Input.GetKey(KeyCode.Space)) 
        { 
        _FL.wheelCollider.brakeTorque = _brake;
        _FR.wheelCollider.brakeTorque = _brake;
        _BL.wheelCollider.brakeTorque = _brake;
        _BR.wheelCollider.brakeTorque = _brake;
            if (!_brakeSourse.isPlaying)
            {
                _brakeSourse.PlayOneShot(_brakeSourse.clip);
            }

            for (int i = 0; i < _brakeParticles.Count; i++)
            {
                _brakeParticles[i].Play();
            }
        }
        else
        {
            _FL.wheelCollider.brakeTorque = 0;
            _FR.wheelCollider.brakeTorque = 0;
            _BL.wheelCollider.brakeTorque = 0;
            _BR.wheelCollider.brakeTorque = 0;
            for (int i = 0; i < _brakeParticles.Count; i++)
            {
                _brakeParticles[i].Stop();
            }

        }

        _FL.wheelCollider.steerAngle = _horz * _steer;
        _FR.wheelCollider.steerAngle = _horz * _steer;
        _BL.wheelCollider.motorTorque = _vert * _motor;
        _BR.wheelCollider.motorTorque = _vert * _motor;

       UpdateVisualWheels();
    }
    void UpdateVisualWheels()
        {
            _FL.wheelCollider.GetWorldPose(out _position, out _rotation);
            _FL.visualWheel.position = _position;
            _FL.visualWheel.rotation = _rotation;

            _FR.wheelCollider.GetWorldPose(out _position, out _rotation);
            _FR.visualWheel.position = _position;
            _FR.visualWheel.rotation = _rotation;

            _BL.wheelCollider.GetWorldPose(out _position, out _rotation);
            _BL.visualWheel.position = _position;
            _BL.visualWheel.rotation = _rotation;

            _BR.wheelCollider.GetWorldPose(out _position, out _rotation);
            _BR.visualWheel.position = _position;
            _BR.visualWheel.rotation = _rotation;
        }

}
