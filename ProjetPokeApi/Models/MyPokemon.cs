using System;
using System.Collections.Generic;
using System.Text;
using PokeApiNet;
using SQLite;

namespace ProjetPokeApi.Models
{
    [Table("Pokemons")]
    public class MyPokemon
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpeAttack { get; set; }
        public int SpeDefense { get; set; }
        public int Speed { get; set; }

    }
}

