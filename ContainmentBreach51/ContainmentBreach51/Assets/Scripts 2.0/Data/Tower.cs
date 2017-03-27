using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Entity {


	public Ability passive;
	public Ability activateable;


	public Tower(int _health, int _armor, int _level, string _name, float _range, float _attackSpeed, int _attackPower, int _taunt, int _speed)
		: base(_health,_armor,_level, _name, _range, _attackSpeed, _attackPower, _taunt, _speed) {
		
	}

	#region implemented abstract members of Entity

	public override void TakeDamage (int damage)
	{
		health -= (damage - armor);
	}

	public override void ChangeTarget (Entity e)
	{
		
	}

	public override void ActivateAbility (Entity target, Ability a)
	{
		
	}


	#endregion
}
