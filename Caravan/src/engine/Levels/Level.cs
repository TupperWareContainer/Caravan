using CaravanEngine;
using CaravanEngine.Entities;
using CaravanEngine.Animation;
using CaravanEngine.UI;
using Caravan;
using System.Numerics;

namespace CaravanEngine{
    /// <summary>
    /// <h1>Level.cs</h1>
    /// <para>Contains all geometry, entity, and ui data necessary to represent a level</para>
    /// </summary>
    public class Level{
        private string _name; 

        private EntityHandler _entityHandler; 

        private UIHandler _uiHandler; 

        private Tilemap _tilemap; 

        private Player _playerInstance;

        

        /// <summary>
        /// Generates a level using pre-instantiated parameters
        /// </summary>
        /// <param name="name"></param> the name of the level
        /// <param name="entityHandler"></param> the entityHandler for the level, contains all entities in the level
        /// <param name="uIHandler"></param> the uiHandler for the level
        /// <param name="playerPosition"></param> the player's position within the level
        /// <param name="tilemap"></param> the tilemap used to represent the level
        public Level(string name, EntityHandler entityHandler, UIHandler uIHandler, Vector2 playerPosition, Tilemap tilemap){
            _name = name;
            _entityHandler = entityHandler; 
            _uiHandler = uIHandler; 
            _tilemap = tilemap;
            if(Player.PlayerInstance != null){
                _playerInstance = Player.PlayerInstance; 
                _playerInstance.SetPosition(playerPosition);
            }
            else{
                _playerInstance = Player.CreatePlayerInstance(playerPosition); 
            }
        }


    }


}