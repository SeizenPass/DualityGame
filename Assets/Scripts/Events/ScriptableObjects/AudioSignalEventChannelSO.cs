using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Event on which <c>AudioSignal</c> components send a message to play SFX and music. <c>AudioManager</c> listens on these events, and actually plays the sound.
/// </summary>
[CreateAssetMenu(menuName = "Events/AudioSignal Event Channel")]
public class AudioSignalEventChannelSO : EventChannelBaseSO
{
	public AudioSignalPlayAction OnAudioSignalPlayRequested;
	public AudioSignalStopAction OnAudioSignalStopRequested;
	public AudioSignalFinishAction OnAudioSignalFinishRequested;
	public UnityAction<AudioSignalSO, AudioConfigurationSO, Vector3> OnAudioSignalRequested;

	public AudioSignalKey RaisePlayEvent(AudioSignalSO audioSignal, AudioConfigurationSO audioConfiguration, Vector3 positionInSpace = default)
	{
		AudioSignalKey audioSignalKey = AudioSignalKey.Invalid;

		if (OnAudioSignalPlayRequested != null)
		{
			audioSignalKey = OnAudioSignalPlayRequested.Invoke(audioSignal, audioConfiguration, positionInSpace);
		}
		else
		{
			Debug.LogWarning("An AudioSignal play event was requested, but nobody picked it up. " +
				"Check why there is no AudioManager already loaded, " +
				"and make sure it's listening on this AudioSignal Event channel.");
		}

		return audioSignalKey;
	}

	public bool RaiseStopEvent(AudioSignalKey audioSignalKey)
	{
		bool requestSucceed = false;

		if (OnAudioSignalStopRequested != null)
		{
			requestSucceed = OnAudioSignalStopRequested.Invoke(audioSignalKey);
		}
		else
		{
			Debug.LogWarning("An AudioSignal stop event was requested, but nobody picked it up. " +
				"Check why there is no AudioManager already loaded, " +
				"and make sure it's listening on this AudioSignal Event channel.");
		}

		return requestSucceed;
	}

	public bool RaiseFinishEvent(AudioSignalKey audioSignalKey)
	{
		bool requestSucceed = false;

		if (OnAudioSignalStopRequested != null)
		{
			requestSucceed = OnAudioSignalFinishRequested.Invoke(audioSignalKey);
		}
		else
		{
			Debug.LogWarning("An AudioSignal finish event was requested, but nobody picked it up. " +
				"Check why there is no AudioManager already loaded, " +
				"and make sure it's listening on this AudioSignal Event channel.");
		}

		return requestSucceed;
	}
}

public delegate AudioSignalKey AudioSignalPlayAction(AudioSignalSO audioSignal, AudioConfigurationSO audioConfiguration, Vector3 positionInSpace);
public delegate bool AudioSignalStopAction(AudioSignalKey emitterKey);
public delegate bool AudioSignalFinishAction(AudioSignalKey emitterKey);

