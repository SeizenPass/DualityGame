using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple implementation of a MonoBehaviour that is able to request a sound being played by the <c>AudioManager</c>.
/// It fires an event on an <c>AudioSignalEventSO</c> which acts as a channel, that the <c>AudioManager</c> will pick up and play.
/// </summary>
public class AudioSignal : MonoBehaviour
{
	[Header("Sound definition")]
	[SerializeField] private AudioSignalSO _audioSignal = default;
	[SerializeField] private bool _playOnStart = false;

	[Header("Configuration")]
	[SerializeField] private AudioSignalEventChannelSO _audioSignalEventChannel = default;
	[SerializeField] private AudioConfigurationSO _audioConfiguration = default;

	private AudioSignalKey controlKey = AudioSignalKey.Invalid;

	private void Start()
	{
		if (_playOnStart)
			StartCoroutine(PlayDelayed());
	}

	private void OnDisable()
	{
		_playOnStart = false;
	}

	private IEnumerator PlayDelayed()
	{
		//The wait allows the AudioManager to be ready for play requests
		yield return new WaitForSeconds(.1f);

		//This additional check prevents the AudioSignal from playing if the object is disabled or the scene unloaded
		//This prevents playing a looping AudioSignal which then would be never stopped
		if (_playOnStart)
			PlayAudioSignal();
	}

	public void PlayAudioSignal()
	{
		controlKey = _audioSignalEventChannel.RaisePlayEvent(_audioSignal, _audioConfiguration, transform.position);
	}

	public void StopAudioSignal()
	{
		if (controlKey != AudioSignalKey.Invalid)
		{
			if (!_audioSignalEventChannel.RaiseStopEvent(controlKey))
			{
				controlKey = AudioSignalKey.Invalid;
			}
		}
	}

	public void FinishAudioSignal()
	{
		if (controlKey != AudioSignalKey.Invalid)
		{
			if (!_audioSignalEventChannel.RaiseFinishEvent(controlKey))
			{
				controlKey = AudioSignalKey.Invalid;
			}
		}
	}
}
