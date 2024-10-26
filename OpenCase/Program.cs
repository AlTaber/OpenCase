
using System.ComponentModel.Design;

OpenCase game = new OpenCase();
game.Start();

public class Skin
{
    public float skin_float = 0f;
    public bool stat_track = false;
    public byte type = 0;
    public byte wear = 0;
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
    bool fast_open_until = false;
    int goal = 1000;

    int case_price = 500;

    List<Skin> board = new List<Skin>();

    Skin Generate_Skin()
    {
        Skin skin = new Skin();

        switch (random.NextDouble())
        {
            case >= 0.7992f + 0.1598f + 0.032f + 0.0064:
                skin.type = 5;
                skin.price = random.Next(10000, 100000);
                break;
            case >= 0.7992f + 0.1598f + 0.032f:
                skin.type = 4;
                skin.price = random.Next(2000, 25000);
                break;
            case >= 0.7992f + 0.1598f:
                skin.type = 3;
                skin.price = random.Next(700, 15000);
                break;
            case >= 0.7992f:
                skin.type = 2;
                skin.price = random.Next(100, 2500);
                break;
            default:
                skin.type = 1;
                skin.price = random.Next(10, 70);
                break;
        }

        skin.skin_float = (float)random.NextDouble();

        switch (skin.skin_float)
        {
            case >= 0.45f:
                skin.wear = 1;
                skin.price = (int)Math.Round(skin.price * 0.6, 1);
                break;
            case >= 0.38f:
                skin.wear = 2;
                skin.price = (int)Math.Round(skin.price * 0.8, 1);
                break;
            case >= 0.15f:
                skin.wear = 3;
                skin.price = (int)Math.Round(skin.price * 0.9, 1);
                break;
            case >= 0.07f:
                skin.wear = 4;
                skin.price = (int)Math.Round(skin.price * 1.2, 1);
                break;
            default:
                skin.wear = 5;
                skin.price = (int)Math.Round(skin.price * 1.7, 1);
                int top_float = -2;
                float float_copy = skin.skin_float;

                while (float_copy < 1)
                {
                    top_float++;
                    float_copy *= 10;
                }
                skin.price = (int)Math.Round(skin.price * Math.Pow(1.25, top_float), 1);
                break;
        }

        if (random.Next(1, 10) == 1)
        {
            skin.stat_track = true;
            skin.price = (int)Math.Round(skin.price * 2.3, 1);
        }

        skin.price = (int)Math.Round(skin.price * (case_price / 500.0), 1);

        return skin;
    }

    void Change_Color_By_Skin(Skin skin)
    {
        switch (skin.type)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case 5:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
        }
    }

    void Change_Color_By_Wear(Skin skin)
    {
        switch (skin.wear)
        {
            case 5:
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Gray;
                break;
            case 1:
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
            case >= 50000:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case >= 20000:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case >= 10000:
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;
            case >= 1000:
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                break;
            case >= 200:
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Gray;
                break;
        }
    }

    void Write_Skin_Info(Skin skin)
    {
        Change_Color_By_Skin(skin);
        Console.Write($"] Редкость: ");
        switch (skin.type)
        {
            case 1:
                Console.WriteLine("Армейское");
                break;
            case 2:
                Console.WriteLine("Запрещённое");
                break;
            case 3:
                Console.WriteLine("Засекреченное");
                break;
            case 4:
                Console.WriteLine("Тайное");
                break;
            case 5:
                Console.WriteLine("*");
                break;
            default:
                Console.WriteLine("-");
                break;
        }

        Change_Color_By_Wear(skin);
        Console.Write($"] Износ: ");
        switch (skin.wear)
        {
            case 1:
                Console.WriteLine("Закалённое в боях");
                break;
            case 2:
                Console.WriteLine("Поношенное");
                break;
            case 3:
                Console.WriteLine("После полевых испытаний");
                break;
            case 4:
                Console.WriteLine("Немного поношенное");
                break;
            case 5:
                Console.WriteLine("Прямо с завода");
                break;
            default:
                Console.WriteLine("-");
                break;
        }
        Console.WriteLine($"] Флот: {skin.skin_float}");

        Change_Color_By_ST(skin);
        Console.WriteLine($"] Stat Track: {skin.stat_track}");

        Change_Color_By_Price(skin);
        Console.WriteLine($"] Стоимость: {skin.price}");
        Console.ResetColor();
    }

    void Write_Menu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"] OpenCase by AlTaberOwO https://github.com/AlTaber");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($">>>    < <<- Статистика ->> >    <<<");
        Console.ResetColor();

        foreach (KeyValuePair<string, int> pair in stat)
        {
            switch (pair.Key)
            {
                case "С":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"\t<{pair.Value}> \t");
                    Console.ResetColor();
                    break;
                case "Ф":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write($"<{pair.Value}> \t");
                    Console.ResetColor();
                    break;
                case "Р":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"<{pair.Value}> \t");
                    Console.ResetColor();
                    break;
                case "К":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"<{pair.Value}> \t");
                    Console.ResetColor();
                    break;
                case "З":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"<{pair.Value}>");
                    Console.ResetColor();
                    break;
                case "Открыто кейсов:":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"] {pair.Key} ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"{pair.Value}");
                    break;
                case "ST:":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"{pair.Key} {pair.Value}\t");
                    break;
                case "BS:":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"{pair.Key} {pair.Value}\t");
                    break;
                case "WW:":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"{pair.Key} {pair.Value}\t");
                    break;
                case "FT:":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write($"{pair.Key} {pair.Value}\t");
                    break;
                case "MW:":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write($"{pair.Key} {pair.Value}\t");
                    break;
                case "FN:":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write($"{pair.Key} {pair.Value}\t");
                    break;
                default:
                    Console.Write($"{pair.Key} {pair.Value}\t");
                    break;
            }
        }
        Console.ResetColor();
        Console.WriteLine();

        Console.WriteLine($"] Наименьший флот: {lowest_float}");
        Console.WriteLine($"] Наибольший флот: {highest_float}");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($">>>  <<< <<- Лучший дроп ->> >>>  <<<");
        Console.ResetColor();

        Write_Skin_Info(highest_price);

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine($">>>     <- Последний дроп ->     <<<");
        Console.ResetColor();

        Write_Skin_Info(last_drop);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"---------- Действия ----------");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write($"] Количество денег: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{money}\n");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write($"Enter - открыть кейс (");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(case_price);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write($" монет)\n" +
            $"\"f <количество>\" + Enter - открыть фастом (можно не указывать количество)(");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(case_price);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($" монет)\n" +
            $"\"r\" + Enter - сбросить статистику\n" +
            $"\"ou <цена>\" + Enter - открывать пока не выпадет предмет дороже этой цены\n" +
            $"\"fou <цена>\" + Enter - команда выше только без визуала\n" +
            $"\"<цена>\" + Enter - сменить стоимость кейса (цены предметов пропорциональны цене кейса)");
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
            case 1:
                stat["С"]++;
                break;
            case 2:
                stat["Ф"]++;
                break;
            case 3:
                stat["Р"]++;
                break;
            case 4:
                stat["К"]++;
                break;
            case 5:
                stat["З"]++;
                break;
        }
        if (skin.stat_track) stat["ST:"]++;
        switch (skin.wear)
        {
            case 1:
                stat["BS:"]++;
                break;
            case 2:
                stat["WW:"]++;
                break;
            case 3:
                stat["FT:"]++;
                break;
            case 4:
                stat["MW:"]++;
                break;
            case 5:
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
            Console.Write(String.Concat(Enumerable.Repeat("\n", 30)));

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"] OpenCase by AlTaberOwO https://github.com/AlTaber");
            Console.ResetColor();

            Change_Color_By_Skin(board[5]);
            Console.WriteLine($"                               ↓↓↓↓");
            Write_Board();
            Change_Color_By_Skin(board[5]);
            Console.WriteLine($"                               ↑↑↑↑");
            Thread.Sleep(speed);
            speed += (int)Math.Round(Math.Pow(1.2, i));
            board.RemoveAt(0);
            board.Add(Generate_Skin());
        }

        Write_Skin_Info(board[4]);

        Console.Write("Нажмите Enter чтобы продолжить...");
        Console.ReadLine();
        return board[4];
    }
    void Write_Board()
    {
        for (int i = 0; i < 2; i++)
        {
            foreach (Skin skin in board)
            {
                Change_Color_By_Skin(skin);
                Console.Write("[████]");
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        foreach (Skin skin in board)
        {
            Change_Color_By_Wear(skin);
            Console.Write("[■■");
            Change_Color_By_ST(skin);
            Console.Write("■■]");
        }
        Console.WriteLine();
        Console.ResetColor();

    }

    public void Start()
    {
        while (true)
        {
            if (!open_until)
            {
                Console.Clear();
                Write_Menu();
            }
            string input = "f";

            if (!open_until) input = Console.ReadLine();

            switch (input)
            {
                case "f":
                    last_drop = Generate_Skin();
                    if (last_drop.price > highest_price.price) highest_price = last_drop;
                    if (last_drop.skin_float < lowest_float) lowest_float = last_drop.skin_float;
                    if (last_drop.skin_float > highest_float) highest_float = last_drop.skin_float;
                    money -= case_price;
                    Add_To_Stat(last_drop);
                    if (!fast_open_until && open_until)
                    {
                        Change_Color_By_Skin(last_drop);
                        Console.Write("█");
                    }
                    if (last_drop.price >= goal)
                    {
                        open_until = false;
                        fast_open_until = false;
                    }
                    break;
                case "r":
                    last_drop = new Skin();
                    money = 0;
                    highest_price = new Skin();
                    lowest_float = 1f;
                    highest_float = 0f;
                    Stat_Reset();
                    break;
                case "фыр":
                    Console.Clear();
                    for (int i = 0; i < 395; i++)
                    {
                        Console.Write("ФырФырФыр");
                        Thread.Sleep(1);
                    }
                    break;
                default:
                    if (input.StartsWith("f "))
                    {
                        if (Int32.TryParse(input.Split()[^1], out int n))
                        {
                            n = Math.Abs(n);
                            for (int i = 0; i < n; i++)
                            {
                                last_drop = Generate_Skin();
                                if (last_drop.price > highest_price.price) highest_price = last_drop;
                                if (last_drop.skin_float < lowest_float) lowest_float = last_drop.skin_float;
                                if (last_drop.skin_float > highest_float) highest_float = last_drop.skin_float;
                                money -= case_price;
                                Add_To_Stat(last_drop);
                            }
                        }
                    }
                    else if (input.StartsWith("ou"))
                    {
                        if (Int32.TryParse(input.Split()[^1], out goal))
                        {
                            goal = Math.Abs(goal);
                            open_until = true;
                            Console.Clear();
                        }
                    }
                    else if (input.StartsWith("fou"))
                    {
                        if (Int32.TryParse(input.Split()[^1], out goal))
                        {
                            goal = Math.Abs(goal);
                            open_until = true;
                            fast_open_until = true;
                            Console.Clear();
                        }
                    }
                    else if (input != "")
                    {
                        if (Int32.TryParse(input.Split()[^1], out case_price))
                        {
                            case_price = Math.Abs(case_price);
                        }
                    }
                    else
                    {
                        last_drop = Open_Case();
                        if (last_drop.price > highest_price.price) highest_price = last_drop;
                        if (last_drop.skin_float < lowest_float) lowest_float = last_drop.skin_float;
                        if (last_drop.skin_float > highest_float) highest_float = last_drop.skin_float;
                        money -= case_price;
                        Add_To_Stat(last_drop);
                    }
                    break;
            }
        }
    }
}

