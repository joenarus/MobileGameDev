using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Entity {


	public Ability passive;
	int levelPassive = 0;
	int levelActive = 0;
	public Ability activateable;


	public Tower(int _health, int _armor, int _level, string _name, float _range, float _attackSpeed, int _attackPower, int _taunt, int _speed, int _maxAttack, float _maxRange, float _MaxSpeed)
		: base(_health,_armor,_level, _name, _range, _attackSpeed, _attackPower, _taunt, _speed, _maxAttack, _maxRange, _MaxSpeed) {
		
	}

	#region implemented abstract members of Entity

	public override void TakeDamage (int damage)
	{
		health -= (damage - armor);
	}

	public override void ChangeTarget (Entity e)
	{
		
	}

	public void addAbility(Ability a, int level) {
		activateable = a;
		levelActive = level;
	}

	public void addPassive(Ability a, int level) {
		passive = a;
		levelPassive = level;
	}

	public override void ActivateAbility(Entity target, Ability a) {

	}
		

	#endregion
}
