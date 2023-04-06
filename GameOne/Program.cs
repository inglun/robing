// See https://aka.ms/new-console-template for more information
using GameOne;

Console.WriteLine("Hello, World!");
var io = new GameInputOutputImpl();
var interaction = new Game(io, new Scene(io));
interaction.Run();
