INCLUDE globals.ink

EXTERNAL increaseEtica(value)

Eae meu nobre! #speaker:NPC
{ pokemon_name == "": -> main | -> already_chose}

=== main ===
Which pokemon do you choose?
    + [Charmander]
        ~ increaseEtica(10.0)
        -> chosen("Charmander")
    + [Bulbasaur]
        ~ increaseEtica(20.0)
        -> chosen("Bulbasaur")
    + [Squirtle]
        ~ increaseEtica(30.0)
        -> chosen("Squirtle")
        
=== chosen(pokemon) ===
~ pokemon_name = pokemon
You chose {pokemon}!
-> END

=== already_chose ===
You already chose {pokemon_name}!
-> END