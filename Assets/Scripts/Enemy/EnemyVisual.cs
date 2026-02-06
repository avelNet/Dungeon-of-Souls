using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Enemy
{
	public class EnemyVisual : MonoBehaviour
	{
		public void FlipXEnemy(Vector2 dir)
		{
			if(dir.x > 0)
			{
				transform.localScale = new Vector3(1, 1, 1);
			}
			else if(dir.x < 0)
			{
				transform.localScale = new Vector3(-1, 1, 1);
			}
		}
	}
}