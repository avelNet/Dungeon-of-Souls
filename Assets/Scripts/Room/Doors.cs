using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Room
{
	public class Doors : MonoBehaviour
	{
		private Collider2D _collider;
        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
			_collider.enabled = false;
        }
        public void Close()
		{
			_collider.enabled = true;
		}
		public void Open()
		{
            Debug.Log("Открываю дверь " + name);
            _collider.enabled = false;
		}
	}
}