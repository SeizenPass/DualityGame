using System.Collections.Generic;

public class SoundEmitterVault
{
	private int _nextUniqueKey = 0;
	private List<AudioSignalKey> _emittersKey;
	private List<SoundEmitter[]> _emittersList;

	public SoundEmitterVault()
	{
		_emittersKey = new List<AudioSignalKey>();
		_emittersList = new List<SoundEmitter[]>();
	}

	public AudioSignalKey GetKey(AudioSignalSO Signal)
	{
		return new AudioSignalKey(_nextUniqueKey++, Signal);
	}

	public void Add(AudioSignalKey key, SoundEmitter[] emitter)
	{
		_emittersKey.Add(key);
		_emittersList.Add(emitter);
	}

	public AudioSignalKey Add(AudioSignalSO Signal, SoundEmitter[] emitter)
	{
		AudioSignalKey emitterKey = GetKey(Signal);

		_emittersKey.Add(emitterKey);
		_emittersList.Add(emitter);

		return emitterKey;
	}

	public bool Get(AudioSignalKey key, out SoundEmitter[] emitter)
	{
		int index = _emittersKey.FindIndex(x => x == key);

		if (index < 0)
		{
			emitter = null;
			return false;
		}

		emitter = _emittersList[index];
		return true;
	}

	public bool Remove(AudioSignalKey key)
	{
		int index = _emittersKey.FindIndex(x => x == key);
		return RemoveAt(index);
	}

	private bool RemoveAt(int index)
	{
		if (index < 0)
		{
			return false;
		}

		_emittersKey.RemoveAt(index);
		_emittersList.RemoveAt(index);

		return true;
	}
}
