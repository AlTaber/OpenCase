
OpenCase game = new OpenCase();
game.Start();

public class Skin
{
    public float skin_float = 0f;
    public bool stat_track = false;
    public string type = "";
    public string wear = "";
    public int price = 0;
}

public class OpenCase
{
    Random random = new Random();

    Dictionary<string, int> stat = new Dictionary<string, int>()
    {
        {"Открыто кейсов:", 0},
            {"С", 0},
            {"Ф", 0},
            {"Р", 0},
            {"К", 0},
            {"З", 0},
            {"ST:", 0},
            {"BS:", 0},
            {"WW:", 0},
            {"FT:", 0},
            {"MW:", 0},
            {"FN:", 0},
    };

    Skin last_drop = new Skin();

    Skin highest_price = new Skin();

    float lowest_float = 1f;
    float highest_float = 0f;

    int money = 0;

    bool open_until = false;
    int goal = 1000;

    List<Skin> board = new List<Skin>();

    Skin Generate_Skin()
    {
        Skin skin = new Skin();

        switch (random.NextDouble())
        {
            case >= 0.7992f + 0.1598f + 0.032f + 0.0064:
                skin.type = "золотое";
                skin.price = random.Next(8000, 15000);
                break;
            case >= 0.7992f + 0.1598f + 0.032f:
                skin.type = "красное";
                skin.price = random.Next(2000, 3000);
                break;
            case >= 0.7992f + 0.1598f:
                skin.type = "розовое";
                skin.price = random.Next(700, 1200);
                break;
            case >= 0.7992f:
                skin.type = "фиолетовое";
                skin.price = random.Next(100, 300);
                break;
            default:
                skin.type = "синее";
                skin.price = random.Next(20, 50);
                break;
        }

        skin.skin_float = (float)random.NextDouble();

        switch (skin.skin_float)
        {
            case >= 0.45f:
                skin.wear = "Закаленное в боях";
                skin.price = (int)Math.Round(skin.price * 0.6, 1);
                break;
            case >= 0.38f:
                skin.wear = "Поношенное";
                skin.price = (int)Math.Round(skin.price * 0.8, 1);
                break;
            case >= 0.15f:
                skin.wear = "После полевых испытаний";
                skin.price = (int)Math.Round(skin.price * 0.9, 1);
                break;
            case >= 0.07f:
                skin.wear = "Немного поношенное";
                skin.price = (int)Math.Round(skin.price * 1.2, 1);
                break;
            default:
                skin.wear = "Прямо с завода";
                skin.price = (int)Math.Round(skin.price * 1.7, 1);
                break;
        }

        if (random.Next(1, 10) == 1)
        {
            skin.stat_track = true;
            skin.price = (int)Math.Round(skin.price * 2.3, 1);
        }

        return skin;
    }

    void Change_Color_By_Skin(Skin skin)
    {
        switch (skin.type)
        {
            case "синее":
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case "фиолетовое":
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                break;
            case "розовое":
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;
            case "красное":
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case "золотое":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
        }
    }

    void Change_Color_By_Wear(Skin skin)
    {
        switch (skin.wear)
        {
            case "Прямо с завода":
                Console.ForegroundColor = ConsoleColor.DarkRed;
                break;
            case "Немного поношенное":
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                break;
            case "После полевых испытаний":
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                break;
            case "Поношенное":
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                break;
            case "Закаленное в боях":
                Console.ForegroundColor = ConsoleColor.DarkGray;
                break;
        }
    }

    void Change_Color_By_ST(Skin skin)
    {
        if (skin.stat_track) Console.ForegroundColor = ConsoleColor.DarkRed;
        else Console.ForegroundColor = ConsoleColor.DarkGray;
    }

    void Change_Color_By_Price(Skin skin)
    {
        switch (skin.price)
        {
            case >= 4000:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case >= 2000:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case >= 500:
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;
            case >= 100:
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                break;
            case >= 50:
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Gray;
                break;
        }
    }

    void Write_Board()
    {
        for(int i = 0; i < 2; i++)
        {
            foreach (Skin skin in board)
            {
                Change_Color_By_Skin(skin);
                Console.Write("■■■■■■ ");
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        foreach (Skin skin in board)
        {
            Change_Color_By_Wear(skin);
            Console.Write("■■■");
            Change_Color_By_ST(skin);
            Console.Write("■■■ ");
        }
        Console.WriteLine();
        Console.ResetColor();

    }

    void Write_Skin_Info(Skin skin)
    {
        Change_Color_By_Skin(skin);
        Console.WriteLine($"Редкость: {skin.type}");

        Change_Color_By_Wear(skin);
        Console.WriteLine($"Износ: {skin.wear}\n" +
            $"Флот: {skin.skin_float}");

        Change_Color_By_ST(skin);
        Console.WriteLine($"Stat Track: {skin.stat_track}");

        Change_Color_By_Price(skin);
        Console.WriteLine($"Стоимость: {skin.price}");
        Console.ResetColor();
    }

    void Write_Menu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"OpenCase by AlTaberOwO https://github.com/AlTaber");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"---------- Статистика ----------");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Количество денег: {money}");
        Console.ResetColor();

        foreach (KeyValuePair<string, int> pair in stat)
        {
            switch (pair.Key)
            {
                case "С":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{pair.Value} \t");
                    Console.ResetColor();
                    break;
                case "Ф":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write($"{pair.Value} \t");
                    Console.ResetColor();
                    break;
                case "Р":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"{pair.Value} \t");
                    Console.ResetColor();
                    break;
                case "К":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{pair.Value} \t");
                    Console.ResetColor();
                    break;
                case "З":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{pair.Value}");
                    Console.ResetColor();
                    break;
                case "Открыто кейсов:":
                    Console.WriteLine($"{pair.Key} {pair.Value}\t");
                    break;
                default:
                    Console.Write($"{pair.Key} {pair.Value}\t");
                    break;
            }
        }
        Console.WriteLine();

        Console.WriteLine($"Наименьший флот: {lowest_float}");
        Console.WriteLine($"Наибольший флот: {highest_float}");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"---------- Лучший Дроп ----------");
        Console.ResetColor();

        Write_Skin_Info(highest_price);

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"---------- Последний Дроп ----------");
        Console.ResetColor();

        Write_Skin_Info(last_drop);

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"---------- Действия ----------");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"Enter - открыть кейс (200 монет)\n" +
            $"\"fast\" + Enter - открыть фастом (200 монет)\n" +
            $"\"reset\" + Enter - сбросить статистику\n" +
            $"\"open_until <цена>\" + Enter - открывать пока не выпадет предмет дороже этой цены");
        Console.ResetColor();

        Console.Write("Действие: ");
    }

    void Stat_Reset()
    {
        stat = new Dictionary<string, int>()
        {
            {"Открыто кейсов:", 0},
            {"С", 0},
            {"Ф", 0},
            {"Р", 0},
            {"К", 0},
            {"З", 0},
            {"ST:", 0},
            {"BS:", 0},
            {"WW:", 0},
            {"FT:", 0},
            {"MW:", 0},
            {"FN:", 0},
        };
    }

    void Add_To_Stat(Skin skin)
    {
        stat["Открыто кейсов:"]++;
        switch (skin.type)
        {
            case "синее":
                stat["С"]++;
                break;
            case "фиолетовое":
                stat["Ф"]++;
                break;
            case "розовое":
                stat["Р"]++;
                break;
            case "красное":
                stat["К"]++;
                break;
            case "золотое":
                stat["З"]++;
                break;
        }
        if (skin.stat_track) stat["ST:"]++;
        switch (skin.wear)
        {
            case "Закаленное в боях":
                stat["BS:"]++;
                break;
            case "Поношенное":
                stat["WW:"]++;
                break;
            case "После полевых испытаний":
                stat["FT:"]++;
                break;
            case "Немного поношенное":
                stat["MW:"]++;
                break;
            case "Прямо с завода":
                stat["FN:"]++;
                break;
        }
        money += skin.price;
    }

    public Skin Open_Case()
    {
        int speed = 20;
        int to_skip = 25;
        board = new List<Skin>();
        for (int i = 0; i < 16; i++) board.Add(Generate_Skin());

        for (int i = 0; i < to_skip; i++)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"OpenCase by AlTaberOwO https://github.com/AlTaber");
            Console.ResetColor();

            Change_Color_By_Skin(board[5]);
            Console.WriteLine($"                                   \\||||/");
            Write_Board();
            Change_Color_By_Skin(board[5]);
            Console.WriteLine($"                                   /||||\\    осталось {to_skip - i - 1}");
            Thread.Sleep(speed);
            speed += (int)Math.Round(Math.Pow(1.145, i));
            board.RemoveAt(0);
            board.Add(Generate_Skin());
        }

        Write_Skin_Info(board[4]);

        Console.Write("Нажмите Enter чтобы продолжить...");
        Console.ReadLine();
        return board[4];
    }

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            Write_Menu();
            string input = "fast";

            if (!open_until) input = Console.ReadLine();

            switch (input)
            {
                case "fast":
                    last_drop = Generate_Skin();
                    if (last_drop.price > highest_price.price) highest_price = last_drop;
                    if (last_drop.skin_float < lowest_float) lowest_float = last_drop.skin_float;
                    if (last_drop.skin_float > highest_float) highest_float = last_drop.skin_float;
                    money -= 200;
                    Add_To_Stat(last_drop);
                    if (last_drop.price >= goal) open_until = false;
                    break;
                case "reset":
                    last_drop = new Skin();
                    money = 0;
                    highest_price = new Skin();
                    lowest_float = 1f;
                    highest_float = 0f;
                    Stat_Reset();
                    break;
                default:
                    if (input.StartsWith("open_until"))
                    {
                        if (Int32.TryParse(input.Split()[^1], out goal))
                        {
                            open_until = true;
                        }
                    }
                    else
                    {
                        last_drop = Open_Case();
                        if (last_drop.price > highest_price.price) highest_price = last_drop;
                        if (last_drop.skin_float < lowest_float) lowest_float = last_drop.skin_float;
                        if (last_drop.skin_float > highest_float) highest_float = last_drop.skin_float;
                        money -= 200;
                        Add_To_Stat(last_drop);
                    }
                    break;
            }
        }
    }
}

