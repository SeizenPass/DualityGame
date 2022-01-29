using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Float Event Channel")]
public class FloatEventChannelSO : EventChannelBaseSO
{
    public UnityAction<float> OnEventRaised;
	public void RaiseEvent(float value)
	{
		if (OnEventRaised != null)
			OnEventRaised.Invoke(value);
	}
}
