


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pin.Liveports.Console.Domain;
using Pin.LiveSports.Core.Data;
using Pin.LiveSports.Core.Entities;
using Pin.LiveSports.Core.Services;
using Pin.LiveSports.Core.Services.Interfaces;
using Pin.LiveSports.Utilities;

var services = new ServiceCollection();
services.AddDbContext<FencingDbContext>(options =>
    options
        .UseSqlServer("Server = localhost,1433;Database=FencingDb;User=sa;Password=Salenbien13&"));


services.AddTransient<ICrudService<Team>, TeamService>();
services.AddTransient<ICrudService<Fencer>, PlayerService>();

var serviceProvider = services.BuildServiceProvider();
var serviceTeam = serviceProvider.GetService<ICrudService<Team>>();


//=================================      USE OF COLLECTION EXPRESSIONS       ==========================================

//VOORDELEN:
//Als ik alle schermers aan een toernooi wil toevoegen, kan ik dat nu met één regel code doen,
//dankzij de collection expressions en de spread operator in C# 12. Dit stelt me in staat om de elementen van
//meerdere teams efficiënt en duidelijk samen te voegen. Het gebruik van de spread operator [..]
//maakt het gemakkelijk om de lijsten in één stap samen te voegen, wat de code beknopt en gemakkelijk te begrijpen maakt.
//Dit elimineert de noodzaak voor meer complexe methoden zoals lussen of het aanroepen van AddRange,
//en vermindert de kans op fouten die kunnen ontstaan bij het handmatig samenvoegen van collecties.

// NADELEN:
// Het gebruik van collection expressions kan in sommige situaties nadelig zijn.
// Wanneer collecties bijvoorbeeld bestaan uit een groot aantal objecten,
// kan de performance afnemen. Dit komt doordat het samenvoegen van collecties met de spread operator het systeem vereist om
// door alle elementen van elke collectie te itereren 
// en deze toe te voegen aan een nieuwe collectie. Dit iteratieproces verbruikt aanzienlijke rekenkracht,
// wat vooral merkbaar is bij grote collecties.


var teams =  serviceTeam.GetAllAsync().Result;

List<Fencer> fencersOfMuskeeters = teams
    .Where(t => t.Name == GlobalConstants.MUSKEETERS)
    .SelectMany(t => t.Players).ToList();

List<Fencer> fencersOfScreeners = teams
    .Where(t => t.Name == GlobalConstants.SCREENERS)
    .SelectMany(t => t.Players).ToList();

List<Fencer> fencersOfIronMeiden = teams
    .Where(t => t.Name == GlobalConstants.MAIDEN_WARRIOR)
    .SelectMany(t => t.Players).ToList();

List<Fencer> ironScreeners = new();

ironScreeners = [..fencersOfScreeners,..fencersOfIronMeiden];

Console.WriteLine("============ Fencers of the new team ===============");

foreach (var fencer in ironScreeners){
    Console.WriteLine(fencer.Name);
}


List<FencerModel> fencersOfScreenersModel = 
    fencersOfScreeners
        .Select(f => new FencerModel(f.Name, f.Rating, f.TeamId,"")).ToList();
List<FencerModel> fencersOfMusketeersModel = 
    fencersOfMuskeeters
        .Select(f => new FencerModel(f.Name, f.Rating, f.TeamId,"")).ToList();
TournamentModel tournament = new TournamentModel();
    tournament.Participants = [..fencersOfScreenersModel,..fencersOfMusketeersModel];

Console.WriteLine("============ All the participants of the tournaments ===============");

foreach (var fencer in tournament.Participants){
    Console.WriteLine(fencer.Name);
}


Console.WriteLine("============ Sum points of all male fencers ===============");

var pointsScreeners = fencersOfScreeners
    .Select(f => f.Rating).ToArray();
var pointsMuskeeters = fencersOfMuskeeters
    .Select(f => f.Rating).ToArray();

int [] totalPointsMaleFencers = [..pointsScreeners, ..pointsMuskeeters];
Console.WriteLine($"Total points of male fencers : {totalPointsMaleFencers.Sum()}");


//=================================      USE OF PRIMARY CONSTRUCTOR       ==========================================


//VOORDELEN:
//Door een primary constructor te gebruiken, elimineer ik de noodzaak om een aparte constructor te schrijven waarin
//ik elk veld handmatig moet toewijzen. Dit vermindert de hoeveelheid code die ik moet schrijven en onderhouden,
//wat leidt tot een directe besparing van tijd en inspanning.
//Bovendien maakt de definitie van mijn klasse met een primary constructor het voor andere ontwikkelaars,
//en voor mijzelf in de toekomst, veel duidelijker om in één oogopslag te zien welke gegevens nodig zijn om bijvoorbeeld
//een FencerModel object te maken. Dit alles verbetert de leesbaarheid en begrijpelijkheid van mijn code aanzienlijk

// NADELEN:
// Hoewel een primary constructor de code vereenvoudigt, kan deze ook beperkingen opleggen aan de flexibiliteit van objectconstructie.
// Complexe objecten die conditionele logica of meerdere configuratiestappen vereisen tijdens de initialisatie,
// kunnen moeilijker te implementeren zijn met een enkele primary constructor.


FencerModel Mulan = new FencerModel("Mulan", 2000,Guid.Empty,"Female");
FencerModel Brave = new FencerModel("Brave", 700,Guid.Empty,"Female");
FencerModel DartVader = new FencerModel("Darth Vader", 1000,Guid.Empty,"Male");


TeamModel girlPowerTeam = new TeamModel("GirlPower",new List<FencerModel>{Mulan,Brave});
TeamModel starWarsTeam = new TeamModel("StarWars",new List<FencerModel>{DartVader});

foreach (var fencer in girlPowerTeam.Players){
    fencer.TeamId = girlPowerTeam.Id;
}
DartVader.TeamId = starWarsTeam.Id;


Console.WriteLine("============ Sum points of all female fencers ===============");

var pointsGirlPower = girlPowerTeam.Players.Select(f => f.Rating).ToArray();
    
var pointsIronMainder = fencersOfIronMeiden
    .Select(f => f.Rating).ToArray();

int [] totalPointsFemaleFencers = [..pointsGirlPower, ..pointsIronMainder];
Console.WriteLine($"Total points of female fencers : {totalPointsFemaleFencers.Sum()}");


//=================================      USE OF DEFAULT LAMBDA PARAMETERS    ==========================================  

//VOORDELEN:
//Ik heb een standaardwaarde ingesteld voor de drempel die typisch geldt voor mannelijke schermers,
//gezien zij de meerderheid vormen in de competities waar ik mee werk.
//Deze standaardwaarde wordt echter overschreven als de schermer een vrouw is,
//om rekening te houden met de verschillende competitieve niveaus tussen geslachten

// NADELEN:
// Hoewel het instellen van een standaardwaarde voor lambda parameters het gebruiksgemak kan vergroten,
// kan het ook leiden tot verwarring en fouten.
// Dit komt doordat ontwikkelaars mogelijk niet onmiddellijk opmerken dat er een standaardwaarde is ingesteld,
// vooral in een teamomgeving waar niet iedereen even bekend is met de codebasis.


var isStrongFencer = ( FencerModel fencer, int minimumRating = 850) => fencer.Rating >= minimumRating;

Console.WriteLine("============ Check for Ranking List ===============");

Console.WriteLine($"{DartVader.Name} {(isStrongFencer(DartVader) ? "remains in the ranking list" : "does not remain in the ranking list")}");
bool isWomanStrongFencer = isStrongFencer(Brave, 750); 
Console.WriteLine($"{Brave.Name} {(isWomanStrongFencer ? "remains in the ranking list" : "does not remain in the ranking list")}");







