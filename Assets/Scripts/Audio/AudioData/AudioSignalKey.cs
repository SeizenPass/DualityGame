using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct AudioSignalKey
{
	public static AudioSignalKey Invalid = new AudioSignalKey(-1, null);

	internal int Value;
	internal AudioSignalSO AudioSignal;

	internal AudioSignalKey(int value, AudioSignalSO audioSignal)
	{
		Value = value;
		AudioSignal = audioSignal;
	}

	public override bool Equals(Object obj)
	{
		return obj is AudioSignalKey x && Value == x.Value && AudioSignal == x.AudioSignal;
	}
	public override int GetHashCode()
	{
		return Value.GetHashCode() ^ AudioSignal.GetHashCode();
	}
	public static bool operator ==(AudioSignalKey x, AudioSignalKey y)
	{
		return x.Value == y.Value && x.AudioSignal == y.AudioSignal;
	}
	public static bool operator !=(AudioSignalKey x, AudioSignalKey y)
	{
		return !(x == y);
	}
}
