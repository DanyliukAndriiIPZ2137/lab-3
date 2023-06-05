using Lab3Library;
using System.Data;
using System.Reflection;

Console.WriteLine("1. Factory method\n2. Abstract Factory\n3. Singelton\n4. Prototype\n5. Builder");
int choiseTask = Int32.Parse(Console.ReadLine());
switch (choiseTask)
{
    case 1:
        WebSite website = new WebSite();
        MobileApp mobileApp = new MobileApp();
        ManagerCall managerCall = new ManagerCall();

        Subscription domesticSubscription = website.CreateSubscription(1);
        Subscription educationalSubscription = managerCall.CreateSubscription(3);
        Subscription premiumSubscription = mobileApp.CreateSubscription(2);

        Console.WriteLine("Domestic Subscription:");
        Console.WriteLine($"Monthly fee: {domesticSubscription.MonthlyFee}");
        Console.WriteLine($"Minimum period: {domesticSubscription.MinimumPeriod} month");
        Console.WriteLine("Features:");
        foreach (string feature in domesticSubscription.Features())
        {
            Console.WriteLine(feature);
        }
        Console.WriteLine();

        Console.WriteLine("Educational Subscription:");
        Console.WriteLine($"Monthly fee: {educationalSubscription.MonthlyFee}");
        Console.WriteLine($"Minimum period: {educationalSubscription.MinimumPeriod} month(s)");
        Console.WriteLine("Features:");
        foreach (string feature in educationalSubscription.Features())
        {
            Console.WriteLine(feature);
        }
        Console.WriteLine();

        Console.WriteLine("Premium Subscription:");
        Console.WriteLine($"Monthly fee: {premiumSubscription.MonthlyFee}");
        Console.WriteLine($"Minimum period: {premiumSubscription.MinimumPeriod} month(s)");
        Console.WriteLine("Features:");
        foreach (string feature in premiumSubscription.Features())
        {
            Console.WriteLine(feature);
        }
        Console.WriteLine();
        break;
    case 2:
        Client men = new Client(new MenClothingFactory());
        Client women = new Client(new WomenClothingFactory());
        Client child = new Client(new ChildrenClothingFactory());

        Console.WriteLine("Men clothing");
        men.MakeOrder();
        Console.WriteLine("\nWomen clothing");
        women.MakeOrder();
        Console.WriteLine("\nChildren clothing");
        child.MakeOrder();
        break;
    case 3:
        DatabaseRespository instance1 = DatabaseRespository.GetInstance();
        DatabaseRespository instance2 = DatabaseRespository.GetInstance();
        if (instance1 == instance2)
        {
            Console.WriteLine("GetInstance() method returns the same instance.");
        }
        else
        {
            Console.WriteLine("GetInstance() method returns different instances.");
        }
        break;
    case 4:
        var mainVirus = new Virus(34, 4, "Covid-19", "Covidius");
        var cloneMainVirus = (Virus)mainVirus.Clone();
        var childVirus = new VirusChild(44, 1, "Covid-20", "Covidius", DateTime.Now, (Virus)mainVirus);
        var childCloneVirus = (VirusChild)childVirus.Clone();
        Console.WriteLine(mainVirus.ToString());
        Console.WriteLine();
        Console.WriteLine(cloneMainVirus.ToString());
        Console.WriteLine();
        Console.WriteLine(childVirus.ToString());
        Console.WriteLine();
        Console.WriteLine(childCloneVirus.ToString());
        break;
    case 5:
        List<String> heroInventory = new List<String>() { "Heal", "extra armor" };
        List<String> enemyInventory = new List<String>() { "Heal" };
        var heroBuilder = new HeroBuilder();
        var enemyBuilder = new EnemyBuilder();

        var directorHero = new CharacterDirector(heroBuilder);
        var directorEnemy = new CharacterDirector(enemyBuilder);

        directorHero.Build(1.81, "Athletic", "Black", "Green", "Iron armor", heroInventory, "AR-15");
        directorEnemy.Build(1.45, "Weak", "Green", "Red", "Leather armor", enemyInventory, "AWP");

        var hero = heroBuilder.GetResult();
        var enemy = enemyBuilder.GetResult();

        hero.ShowInfo();
        Console.WriteLine();
        enemy.ShowInfo();
        break;
    default:
        break;
}