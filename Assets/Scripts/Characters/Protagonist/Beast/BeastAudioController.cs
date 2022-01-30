using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastAudioController : MonoBehaviour
{
    [SerializeField] private AudioSignalEventChannelSO _sfxEventChannel = default;
	[SerializeField] private AudioConfigurationSO _audioConfig = default;

	[SerializeField] private AudioSignalSO footstep, attack, dash, jump;

    private PersonMovementController _personMovementController;

    private void Awake() {
        _personMovementController = GetComponent<PersonMovementController>();
    }

    private void OnEnable() {
        _personMovementController.jumpEvent += PlayJump;
    }

    private void OnDisable() {
        _personMovementController.jumpEvent -= PlayJump;
    }

	public void PlayFootstep() {
        if (_personMovementController.IsGrounded())
            _sfxEventChannel.RaisePlayEvent(footstep, _audioConfig, transform.position);
    }
    public void PlayAttack() => _sfxEventChannel.RaisePlayEvent(attack, _audioConfig, transform.position);
    public void PlayDash() => _sfxEventChannel.RaisePlayEvent(dash, _audioConfig, transform.position);
    public void PlayJump() => _sfxEventChannel.RaisePlayEvent(jump, _audioConfig, transform.position);
}
