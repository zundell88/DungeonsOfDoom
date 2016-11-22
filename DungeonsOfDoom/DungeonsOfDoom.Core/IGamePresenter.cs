using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core
{
    interface IGamePresenter
    {     
        void DisplayWorld(Player player,Room[,] rooms);
        void DisplayPlayerInfo(Player player,string lastStatusEnemy, string lastStatusItem);
        void StartMeny();
        void LevelComplete();
        void GameOver();
        void ShowStory();
        void CheckInventory(Player player);
        void QuitGame();
        bool AskPlayAgain();
    }
}
