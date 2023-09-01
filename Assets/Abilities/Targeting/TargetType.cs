namespace Abilities {
    public enum TargetType {
        self = 1,
        neutral = 1 << 1,


        


    }
}



/*Flame Aura

Create an aura around The player.
It should stay on permanently 
Damage enemies every X seconds
It should have a radius of Y

list enemiesInRange; 
oncolenter(colld){
    enemiesInRange.push(colld.getComponent<hpcomp>);


}

oncolexit(colld){
    enemiesInRange.remove(colld.getcomp<hpcomp>)
}


update () {
    if (Time.DeltaTime > TickRate){
        foreach enemy in enemiesInRange {
            enemy.dealdmg();
        }
    }
}


*/