using Microsoft.Extensions.Configuration;
using ShipsGame;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var gameConfiguration = new GameConfiguration(); 
config.Bind("GameConfiguration", gameConfiguration);

GameManager gameManager = new(gameConfiguration);

while(!gameManager.IsGameOver())
    gameManager.GameLoop();

gameManager.GameOver();