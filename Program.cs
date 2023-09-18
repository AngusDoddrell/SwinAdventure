using System.Runtime.CompilerServices;

namespace SwinAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //creates an example player and prints out the full description - only used for personal testing
            Player playerOne = new Player("ExamplePlayerName", "Player 1");

            String[] identsOne = { "ExampleWeapon", "ExampleSword" };
            Item _exampleWeapon = new Item(new string[] {"Sword", "Blade"}, "A sword", "This is just a regular sword");

            playerOne.Inventory.Put(_exampleWeapon);

            Console.WriteLine(playerOne.FullDescription);
        }
    }
}