// See https://aka.ms/new-console-template for more information
using GameOne;

Console.WriteLine("Hello, World!");
var io = new InteractionInputOutputImpl();
var interaction = new Interaction(io, new Scene(io));
interaction.Run();
