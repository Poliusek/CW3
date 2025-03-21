using CW3;
using CW3.Data;
using CW3.Kontenery;

Kontener k1 = new KontenerNaGaz(40);
Kontener k2 = new KontenerNaPlyny();
Kontener k3 = new KontenerNaGaz(100);
Kontener k4 = new KontenerNaPlyny();
Kontener k5 = new KontenerChlodniczy(Items.Butter);
Kontener k6 = new KontenerChlodniczy(Items.Chocolate);

k1.Load(500, "Azot");
k3.Load(900, "Hel");
k2.Load(450, "Paliwo");
k4.Load(300, "Rtęć");
k5.Load(1000, "Butter");
k6.Load(500, "Fish");


Console.WriteLine(k1);
Console.WriteLine(k2);
Console.WriteLine(k3);
Console.WriteLine(k4);
Console.WriteLine(k5);
Console.WriteLine(k6);

Kontenerowiec kontenerowiec = new Kontenerowiec(40, 400, 1000000);
Kontenerowiec kontenerowiec2  = new Kontenerowiec(30, 300, 750000);

kontenerowiec.Load(k1);
kontenerowiec.Load([k2,k3]);
kontenerowiec2.Load(k4);
kontenerowiec2.Load([k5,k6]);

Console.WriteLine(kontenerowiec);
Console.WriteLine();

Console.WriteLine(kontenerowiec2);
Console.WriteLine();

kontenerowiec.SwitchShip(kontenerowiec._containers.First(), kontenerowiec2);

Console.WriteLine(kontenerowiec2);

kontenerowiec2.Unload(kontenerowiec2._containers.First());

Console.WriteLine(kontenerowiec2);

Kontener replace = new KontenerNaPlyny();
replace.Load(50, "Mleko");

kontenerowiec2.SwitchContainer("KON-G-0", replace);

Console.WriteLine(kontenerowiec2);

var a = kontenerowiec2.UnloadAll();

Console.WriteLine(kontenerowiec2);

