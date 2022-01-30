using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonAudioController : MonoBehaviour
{
    [SerializeField] private AudioSignalEventChannelSO _sfxEventChannel = default;
	[SerializeField] private AudioConfigurationSO _audioConfig = default;

	[SerializeField] private AudioSignalSO footstep;

	public void PlayFootstep() => _sfxEventChannel.RaisePlayEvent(footstep, _audioConfig, transform.position);
}
