using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability  {

	string ability_name;

	public string Ability_name {
		get {
			return ability_name;
		}
		set {
			ability_name = value;
		}
	}

	int damagepower;
	public int Damagepower {
		get {
			return damagepower;
		}
		set {
			damagepower = value;
		}
	}

 //amount the ability damages target
	int healPower;
	public int HealPower {
		get {
			return healPower;
		}
		set {
			healPower = value;
		}
	}

 //amount the ability heals target
	float range;
	public float Range {
		get {
			return range;
		}
		set {
			range = value;
		}
	}

 //range of the ability
	bool taunt;
	public bool Taunt {
		get {
			return taunt;
		}
		set {
			taunt = value;
		}
	}

 //does the ability taunt

	float cooldown;
	public float Cooldown {
		get {
			return cooldown;
		}
		set {
			cooldown = value;
		}
	}

	int aoe;

	public int Aoe {
		get {
			return aoe;
		}
		set {
			aoe = value;
		}
	}

//time until ability is refreshed

	int level;

	public int Level {
		get {
			return level;
		}
		set {
			level = value;
		}
	}

 


	public Ability(string _name, int damage, int heal, float _range, int _taunt, int _aoe) {
		ability_name = _name;
		damagepower = damage;
		healPower = heal;
		range = _range;
		aoe = _aoe;
		if (_taunt == 0)
			taunt = false;
		else
			taunt = true;
	}

		
	public void updateAbility(int _level) {
		

	}

		

}
