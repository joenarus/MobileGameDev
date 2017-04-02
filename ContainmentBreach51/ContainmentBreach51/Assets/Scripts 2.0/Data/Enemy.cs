using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {

	public Ability passive;
	public int value;
	public Enemy() {

	}

	public Enemy(int _health, int _armor, int _level, string _name, float _range, float _attackSpeed, int _attackPower, int _taunt, int _speed, int _value, int _maxAttack, float _maxRange, float _MaxSpeed) 
		: base(_health,_armor,_level, _name, _range, _attackSpeed, _attackPower, _taunt, _speed, _maxAttack, _maxRange, _MaxSpeed){
		value = _value;

	}

	public override void TakeDamage (int damage)
	{
		health -= (damage - armor);
	}

	public override void ChangeTarget (Entity e)
	{
		currentTarget = e;
	}

	public override void ActivateAbility (Entity target, Ability a)
	{

	}
}
