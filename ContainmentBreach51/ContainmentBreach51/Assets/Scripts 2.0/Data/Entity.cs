using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {
	public string entity_name;
	public int health;
	public int level;
	public int armor;

	public float range;
	public float attackSpeed;
	public int attackPower;
	public bool taunt;
	public int speed;
	public int maxAttack;
	public float maxRange;	
	public float MaxSpeed;


	public Entity currentTarget;

	public Entity() {

	}

	public Entity(int _health, int _armor, int _level, string _name, float _range, float _attackSpeed, int _attackPower, int _taunt, int _speed, 
		int _maxAttack, float _maxRange, float _MaxSpeed) {
		health = _health;
		armor = _armor;
		level = _level;
		entity_name = _name;
		range = _range;
		attackSpeed = _attackSpeed;
		attackPower = _attackPower;
		speed = _speed;
		maxAttack = _maxAttack;
		maxRange = _maxRange;
		MaxSpeed = _MaxSpeed;

		if (_taunt == 0)
			taunt = false;
		else
			taunt = true;
	}


	public abstract void TakeDamage (int damage);

	public abstract void ChangeTarget (Entity e);

	public abstract void ActivateAbility(Entity target, Ability a);


}
