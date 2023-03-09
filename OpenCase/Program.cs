
OpenCase game = new OpenCase();
game.Start();

public class Skin
{
    public float skin_float = 0f;
    public bool stat_track = false;
    public string type = "";
    public string wear = "";
}

public class OpenCase
{
    Random random = new Random();

    Dictionary<string, int> stat = new Dictionary<string, int>()
    {
        {"Открыто кейсов:", 0},
        {"Синих:", 0},
        {"Фиолетовых:", 0},
        {"Розовых:", 0},
        {"Красных:", 0},
        {"Золотых:", 0},
        {"Со стат треком:", 0},
        {"Закаленного в боях:", 0},
        {"Поношенного:", 0},
        {"После полевых:", 0},
        {"Немного поношенного:", 0},
        {"Прямо с завода:", 0},
    };

    Skin last_drop = new Skin();

    List<Skin> board = new List<Skin>();

    Skin Generate_Skin()
    {
        Skin skin = new Skin();

        switch (random.NextDouble())
        {
            case >= 0.7992f + 0.1598f + 0.032f + 0.0064:
                skin.type = "золотое";
                break;
            case >= 0.7992f + 0.1598f + 0.032f:
                skin.type = "красное";
                break;
            case >= 0.7992f + 0.1598f:
                skin.type = "розовое";
                break;
            case >= 0.7992f:
                skin.type = "фиолетовое";
                break;
            default:
                skin.type = "синее";
                break;
        }

        skin.skin_float = (float)random.NextDouble();

        switch (skin.skin_float)
        {
            case >= 0.45f:
                skin.wear = "Закаленное в боях";
                break;
            case >= 0.38f:
                skin.wear = "Поношенное";
                break;
            case >= 0.15f:
                skin.wear = "После полевых испытаний";
                break;
            case >= 0.07f:
                skin.wear = "Немного поношенное";
                break;
            default:
                skin.wear = "Прямо с завода";
                break;
        }

        if (random.Next(1, 10) == 1) skin.stat_track = true;

        return skin;
    }

    void Change_Color(Skin skin)
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
    
    void Write_Board()
    {
        for (int i = 0; i < 2; i++)
        {
            foreach (Skin skin in board)
            {
                Change_Color(skin);
                Console.Write("■■");
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }

    void Write_Menu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"OpenCase by AlTaberOwO https://github.com/AlTaber");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"---------- Статистика ----------");
        Console.ResetColor();

        foreach (KeyValuePair<string, int> pair in stat)
        {
            Console.Write($"{pair.Key} ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{pair.Value}");
            Console.ResetColor();
        }

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"---------- Последний Дроп ----------");
        Console.ResetColor();

        Change_Color(last_drop);
        Console.WriteLine($"Редкость: {last_drop.type}\n" +
            $"Износ: {last_drop.wear}\n" +
            $"Флот: {last_drop.skin_float}\n" +
            $"Stat Track: {last_drop.stat_track}");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"---------- Действия ----------");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Enter - открыть кейс\n" +
            $"\"fast\" + Enter - открыть фастом\n" +
            $"\"reset\" + Enter - сбросить статистику");
        Console.ResetColor();

        Console.Write("Действие: ");
    }

    void Stat_Reset()
    {
        stat = new Dictionary<string, int>()
        {
            {"Открыто кейсов:", 0},
            {"Синих:", 0},
            {"Фиолетовых:", 0},
            {"Розовых:", 0},
            {"Красных:", 0},
            {"Золотых:", 0},
            {"Со стат треком:", 0},
            {"Закаленного в боях:", 0},
            {"Поношенного:", 0},
            {"После полевых:", 0},
            {"Немного поношенного:", 0},
            {"Прямо с завода:", 0},
        };
    }

    void Add_To_Stat(Skin skin)
    {
        stat["Открыто кейсов:"]++;
        switch (skin.type)
        {
            case "синее":
                stat["Синих:"]++;
                break;
            case "фиолетовое":
                stat["Фиолетовых:"]++;
                break;
            case "розовое":
                stat["Розовых:"]++;
                break;
            case "красное":
                stat["Красных:"]++;
                break;
            case "золотое":
                stat["Золотых:"]++;
                break;
        }
        if (skin.stat_track) stat["Со стат треком:"]++;
        switch (skin.wear)
        {
            case "Закаленное в боях":
                stat["Закаленного в боях:"]++;
                break;
            case "Поношенное":
                stat["Поношенного:"]++;
                break;
            case "После полевых испытаний":
                stat["После полевых:"]++;
                break;
            case "Немного поношенное":
                stat["Немного поношенного:"]++;
                break;
            case "Прямо с завода":
                stat["Прямо с завода:"]++;
                break;
        }
    }

    public Skin Open_Case()
    {
        int speed = 20;
        int to_skip = 25;
        board = new List<Skin>();
        for (int i = 0; i < 21; i++) board.Add(Generate_Skin());

        for (int i = 0; i < to_skip; i++)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"OpenCase by AlTaberOwO https://github.com/AlTaber");
            Console.ResetColor();

            Change_Color(board[6]);
            Console.WriteLine($"           \\||/");
            Write_Board();
            Change_Color(board[6]);
            Console.WriteLine($"           /||\\    осталось {to_skip - i - 1}");
            Thread.Sleep(speed);
            speed += (int)Math.Round(Math.Pow(1.145, i));
            board.RemoveAt(0);
            board.Add(Generate_Skin());
        }

        Change_Color(board[5]);
        Console.WriteLine($"Редкость: {board[5].type}\n" +
            $"Износ: {board[5].wear}\n" +
            $"Флот: {board[5].skin_float}\n" +
            $"Stat Track: {board[5].stat_track}");
        Console.ResetColor();
        Console.Write("Нажмите Enter чтобы продолжить...");
        Console.ReadLine();
        return board[5];
    }

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            Write_Menu();

            string input = Console.ReadLine();
            switch (input)
            {
                case "fast":
                    last_drop = Generate_Skin();
                    Add_To_Stat(last_drop);
                    break;
                case "reset":
                    last_drop = new Skin();
                    Stat_Reset();
                    break;
                default:
                    last_drop = Open_Case();
                    Add_To_Stat(last_drop);
                    break;
            }
        }
    }
}

