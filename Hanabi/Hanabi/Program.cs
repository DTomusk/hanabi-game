using Hanabi;

const int NUMBER_OF_BOARDS = 2;

Console.WriteLine("Welcome to Hanabi");
Console.WriteLine($"{NUMBER_OF_BOARDS} players playing the game");

// Set up game
var game = new Game(NUMBER_OF_BOARDS);

// Play game
game.Play();