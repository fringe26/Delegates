using static Delegates.Program;

namespace Delegates;

public class Program
{
    //public delegate bool MyDelegate(int number);
    //public delegate int CallbackDelegate();

    //public static Action<decimal> OnCurrencyChange;
    //public static Func<int,double> Methods;
    //public static Predicate<string> myPredicate;
    
    static void Main(string[] args)
    {

        #region Delegates Intro
        // Declare my Delegate

        //MyDelegate findMoreThan10 = new MyDelegate(MoreThanTen);
        //MyDelegate isEvenmethod = new MyDelegate(IsEven);


        //List<int> list  = new List<int> { 1,2,3,4,5,56,7,7,5,5434,4};
        //FilterList(list, findMoreThan10);
        //Console.WriteLine("-------------------------------------------");
        //FilterList(list, isEvenmethod);
        #endregion

        #region MultiCast Delegates
        //CallbackDelegate callbackMethod = new CallbackDelegate(OnStart);
        //callbackMethod += OnLoaded;
        ////callbackMethod -= OnStart;
        ////callbackMethod -= OnLoaded;
        ////callbackMethod = null;


        //LoadWeb loadingPage = new LoadWeb();
        //loadingPage.PageLoading(callbackMethod);
        #endregion

        #region Default Delegates

        //OnCurrencyChange += DollarChange;

        //Bank(OnCurrencyChange);


        //myPredicate += FindByName;

        //List<string> list = new List<string>()
        //{
        //    "Tural",
        //    "Orxan",
        //    "Faiq",
        //    "Samir",
        //    "Jale",
        //    "Efsane"
        //};

        //List<string> newList = list.Where(x => x.Length >10).ToList();

        //FilterList(list, myPredicate);
        #endregion

        #region Events Intro
        Player player = new Player()
        {
            Health = 100,
            Score = 0
        };

        GameUI gameUI = new GameUI(player);

        while (true)
        {
            Console.WriteLine(new String('-', 100));
            player.TakeDamage(5);
            Thread.Sleep(3000);
            Console.WriteLine(new String('-',100));
            player.CollectCoin();
            Thread.Sleep(2000);
            Console.WriteLine(new String('-', 100));
        }

        #endregion



    }


    //private static void FilterList(List<string> list,string searchName,Predicate<string> predicate)
    //{
    //    foreach (var item in list)
    //    {
    //        bool? isPredicate = predicate?.Invoke(item,searchName);
    //        if (isPredicate.Value)
    //        {
    //            Console.WriteLine(item);
    //        }


    //    }
    //}
    //private static bool FindByName(string name,string searchName)
    //{
    //    if(name == searchName)
    //    {
    //        return true;
    //    }
    //    return false;
    //}

    //private static void Bank(Action<decimal> callback)
    //{
    //    decimal dollar = 1.7m;
    //    while (true)
    //    {
    //        Thread.Sleep(3000);
    //        callback?.Invoke(dollar);
    //        dollar = 1 + (decimal)new Random().NextDouble();

    //    }
    //}

    //private static void EuroChange(decimal euro)
    //{
    //    Console.WriteLine($"Euro now is - {euro}");
    //    Console.WriteLine(new String('-',50));
    //}

    //private static void DollarChange(decimal dollar)
    //{
    //    Console.WriteLine($"Dollar now is - {dollar}");
    //    Console.WriteLine(new String('-', 50));


    //}



    //public static void Loading(Action mycallback)
    //{
    //    Console.WriteLine("Loading....");
    //    Thread.Sleep(2000);


    //    mycallback?.Invoke();
    //}

    //private static void PopUpView()
    //{
    //    Console.WriteLine("Popup started");
    //}

    //private static void PageLoaded()
    //{
    //    Console.WriteLine("Start Banner");
    //}
}

//    private static int OnStart()
//    {
//        Console.WriteLine("Page has been Loaded");
//        Console.WriteLine("Your Shipping has been arrived. Please rate us\n" +
//            "link below");
//        Console.WriteLine(new String('-', 100));
//        return 20;

//    }
//    private static int OnLoaded()
//    {
//        Console.WriteLine("Page has been Loaded");
//        Console.WriteLine("You win discount card!!! Congrats!");
//        Console.WriteLine(new String('-',100));
//        return 10;
//    }

//    //private static void FilterList(List<int> list,MyDelegate predicate)
//    //{

//    //    foreach(int item in list)
//    //    {
//    //        if (predicate(item))
//    //        {
//    //            Console.WriteLine(item);
//    //        }
//    //    }
//    //}

//    //private static bool MoreThanTen(int number)
//    //{
//    //    return number > 10;
//    //}
//    //private static bool IsEven(int number)
//    //{
//    //    return number % 2 == 0;
//    //}
//}


//public class LoadWeb
//{
//    public void PageLoading(CallbackDelegate callback)
//    {
//        Console.WriteLine(new String('-', 100));

//        Console.WriteLine("Page Loading...");
//        Console.WriteLine(new String('-', 100));

//        Thread.Sleep(5000);
//        int? number = callback?.Invoke();
//    }
//}




public class Player
{
    public event Action<int> OnScoreChange;
    public event Action<int> OnHealthChange;
    //public Action<int> OnPlayerDie;


    public int Score { get; set; }
    public int Health { get; set; }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        
        OnHealthChange?.Invoke(Health);
    }

    public void CollectCoin()
    {
        Score++;
        OnScoreChange?.Invoke(Score);
    }
}

public class GameUI
{
    public int ScoreUI { get; set; }
    public int HealthUI { get; set; }

    private Player _player;

    public GameUI(Player player)    {
        ScoreUI = player.Score;
        HealthUI = player.Health;
        _player = player;

        _player.OnScoreChange += ChangeScore;
        _player.OnHealthChange += ChangeHealth;
        ShowUIElements();

    }


    private void ShowUIElements()
    {
        Console.Clear();
        Console.WriteLine($"Player Score: {ScoreUI}\n" +
            $"Player Health: {HealthUI}");
    }

    private void ChangeHealth(int health)
    {
        HealthUI = health;
        ShowUIElements();
    }

    private void ChangeScore(int score)
    {
        ScoreUI = score;
        ShowUIElements();
    }
}