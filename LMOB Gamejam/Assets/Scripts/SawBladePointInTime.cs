using UnityEngine;

public class SawBladePointInTime
{

	public Vector3 position;
	public Quaternion rotation;
	public bool going;

	public SawBladePointInTime(Vector3 _position, Quaternion _rotation, bool _going)
	{
		position = _position;
		rotation = _rotation;
		going = _going;
	}

}
