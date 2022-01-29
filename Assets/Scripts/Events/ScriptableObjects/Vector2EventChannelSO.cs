using UnityEngine.Events;
using UnityEngine;

/// <summary>
/// This class is used for Events that have a Vector2 argument.
/// Example: An event to toggle a UI interface
/// </summary>

[CreateAssetMenu(menuName = "Events/Vector2 Event Channel")]
public class Vector2EventChannelSO : EventChannelBaseSO
{
	public UnityAction<Vector2> OnEventRaised;
	public void RaiseEvent(Vector2 value)
	{
		if (OnEventRaised != null)
			OnEventRaised.Invoke(value);
	}
}
