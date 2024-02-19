using Villamlas;

List<Adatok> villamAdatok = new List<Adatok>();
int nap = 1;

using StreamReader sr = new StreamReader(@"../../../src/villam.txt");
while (!sr.EndOfStream)
{
    villamAdatok.Add(new Adatok(nap, sr.ReadLine()));
    nap++;
}

foreach (var item in villamAdatok)
{
    Console.WriteLine(item);
}

Console.WriteLine("Feladat 3.:");
var legtobbVillam = villamAdatok.Select(adatok => adatok.orankentiAdatok.Max()).Max();
var legtobbVillamNap = villamAdatok
               .Select(adat => new { Nap = adat.nap, VillamCount = adat.orankentiAdatok.Count(x => x == legtobbVillam) })
               .OrderByDescending(x => x.VillamCount)
               .FirstOrDefault();

Console.WriteLine($"A legtöbb villám a {legtobbVillamNap.Nap}. napon volt: {legtobbVillam} villám.");

Console.WriteLine("Feladat 4.:");
Console.WriteLine("Kiírás.");
var result = villamAdatok.Select(adat =>
{
    var elsoVillam = adat.orankentiAdatok.Select((villam, index) => new { Ora = index + 1, Villam = villam })
        .FirstOrDefault(x => x.Villam != 0);

    if (elsoVillam != null)
        return $"{adat.nap}. {elsoVillam.Ora}";
    else
        return $"{adat.nap}. null";
});

using StreamWriter writer = new StreamWriter(@"../../../src/elsoVillamAdatok.txt");
foreach (var item in result)
{
    writer.WriteLine(item);
}

Console.WriteLine("Feladat 5.:");
var villamCount = villamAdatok.Select(adat => adat.orankentiAdatok.Count(x => x != 0));
Console.WriteLine(villamCount.Sum());


Console.WriteLine("Feladat 6.:");
var villam200alat = villamAdatok
               .Select(adat => new { Nap = adat.nap, VillamCount = adat.orankentiAdatok.Sum() })
               .Where(villamCount => villamCount.VillamCount < 200)
               .FirstOrDefault();
Console.WriteLine(villam200alat.Nap);

var villamMentesNap = villamAdatok
               .Select(adat => new { Nap = adat.nap, VillamCount = adat.orankentiAdatok.Sum() })
               .Where(villamCount => villamCount.VillamCount == 0)
               .FirstOrDefault();
Console.WriteLine("Feladat 7.:");
if (villamMentesNap.Nap == null)
{
    Console.WriteLine("Nincs olyan nap amikor nem villámlott.");
}
else
{
    Console.WriteLine($"{villamMentesNap.Nap}. napon nem volt villámlás.");
}


Console.WriteLine();
Console.WriteLine("----------Haladó Feladatok----------");
Console.WriteLine();

Console.WriteLine("Feladat 8.:");
var Reggel2Sum = villamAdatok.Select(adat => adat.orankentiAdatok.Take(2).Sum());
Console.WriteLine(Reggel2Sum.Sum());

Console.WriteLine("Feladat 9.:");
var villamSum = villamAdatok.Select(adat => adat.orankentiAdatok.Sum()).Take(20);
Console.WriteLine(villamSum.Sum());




Console.WriteLine("Feladat 10.:");
int compare = 20000;
for (int i = 0; i < 23; i++)
{
    var temp = villamAdatok.Select(adat => adat.orankentiAdatok[i]).Sum();
    if (temp < compare) compare = temp;
}
Console.WriteLine(compare);





Console.WriteLine("Feladat 11.:");
var legtobbVillam7 = villamAdatok
    .Select((villam, index) => new { Nap = villam.nap, VillamCount = villam.orankentiAdatok.Max(), Ora = index + 1 })
    .Where(villamCount => villamCount.Nap == 7);
foreach (var item in legtobbVillam7)
{
    Console.WriteLine(item.VillamCount);
}