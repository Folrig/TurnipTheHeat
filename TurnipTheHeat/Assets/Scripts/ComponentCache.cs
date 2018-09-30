using UnityEngine;

/// <summary>
/// Semi-automated component caching container for quick and safe component caching.
/// 
/// [Example Use] easily giving a MonoBehaviour a cache to its Transform...
/// 
/// ComponentCache<Transform> _transform = new ComponentCache<Transform>();
/// Transform MyTransform {get{return _transform.Get(this);}}
/// -Dorma Oculus
/// </summary>

public class ComponentCache<T> where T : Component {
	#region Members
	private T _cache = null;
	#endregion

	#region Properties
	/// <summary>
	/// Gets a value indicating whether the cache points to anything.
	/// </summary>
	/// <value><c>true</c> if the cache is safe; otherwise, <c>false</c>.</value>
	public bool IsSafe {get{return(_cache != null);}}
	#endregion

	#region Get cache reference
	/// <summary>
	/// Get the cached component from a given MonoBehaviour reference.
	/// Required to be called at least once so a cache can be made from given MonoBehaviour.
	/// </summary>
	/// <param name="mGameObject">M game object.</param>
	public T Get(MonoBehaviour mTarget) {
		if (!_cache)
			LinkCache (mTarget);
		return _cache;
	}

	/// <summary>
	/// Get the cached component.
	/// </summary>
	public T Get() {
		if (!_cache)
			Debug.LogError("Attempted to cache nonexistent component. Get(MonoBehaviour) must be called at least once before Get().");
		return _cache;
	}
	#endregion

	#region Constructors
	/// <summary>
	/// Initializes a new instance of the <see cref="ComponentCache`1"/> class.
	/// </summary>
	public ComponentCache() {}

	/// <summary>
	/// Initializes a new instance of the <see cref="ComponentCache`1"/> class.
	/// Instantly links cache from the given GameObject.
	/// </summary>
	/// <param name="mTarget">M target.</param>
	public ComponentCache(MonoBehaviour mTarget) {
		LinkCache(mTarget);
	}
	#endregion

	#region Link cache
	/// <summary>
	/// Caches the T reference from a given MonoBehaviour
	/// </summary>
	/// <returns><c>true</c>, if cache was linked, <c>false</c> if an error is encountered.</returns>
	/// <param name="mTarget">M target.</param>
	private bool LinkCache(MonoBehaviour mTarget) {
		_cache = mTarget.GetComponent<T>();

		if (!mTarget) {
			Debug.LogError ("Attempted to cache a component " + typeof(T).ToString() + " cache to to null GameObject.");
			return false;
		}
	
		if (!_cache) {
			Debug.LogError("Attempted to cache nonexistent component " + typeof(T).ToString() + " on " + mTarget);
			return false;
		}
		return true;
	}
	#endregion
}
