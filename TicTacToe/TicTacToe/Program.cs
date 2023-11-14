char[,] game = new char[3, 3] { { '-', '-', '-' }, { '-', '-', '-' }, { '-', '-', '-' } };

bool next = true;

User gamer1 = new();
User gamer2 = new();

string tempAnswer;
Console.WriteLine("Game start!");
while (true)
{
    if (next)
    {
        bool enter = true;
        while (enter)
        {
            Console.Clear();
            Console.Write($"Gamer1 kordinat \nX : ");
            gamer1.X = int.Parse(Console.ReadLine());

            while (gamer1.X.Equals(-1))
            {
                Console.Clear();
                Console.Write($"Gamer1 kordinat \nX : ");
                gamer1.X = int.Parse(Console.ReadLine());
            }

            Console.Write("Y : ");
            gamer1.Y = int.Parse(Console.ReadLine());
            while (gamer1.Y == -1)
            {
                Console.Clear();
                Console.Write($"Gamer1 kordinat \nX : {gamer1.X}\nY :   ");
                gamer1.Y = int.Parse(Console.ReadLine());
            }
         

            if (game[gamer1.X, gamer1.Y] == '-')
            {
                enter = false;
            }
        }
        game[gamer1.X, gamer1.Y] = 'X';
        next = false;
    }
    else
    {
        bool enter = true;
        while (enter)
        {
            Console.Clear();
            Console.Write($"Gamer2 kordinat \nX : ");
            gamer2.X = int.Parse(Console.ReadLine());

            while (gamer2.X.Equals(-1))
            {
                Console.Clear();
                Console.Write($"Gamer2 kordinat \nX : ");
                gamer2.X = int.Parse(Console.ReadLine());
            }
            Console.Write("Y : ");
            gamer2.Y = int.Parse(Console.ReadLine());
            while (gamer2.Y == -1)
            {
                Console.Clear();
                Console.Write($"Gamer1 kordinat \nX : {gamer2.X}\nY :   ");
                gamer2.Y = int.Parse(Console.ReadLine());
            }
            
            if (game[gamer2.X, gamer2.Y] == '-')
            {
                enter = false;
            }
        }
        game[gamer2.X, gamer2.Y] = 'Y';
        next = true;
    }
    Console.WriteLine();
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write(game[i, j] + " ");
        }
        Console.WriteLine();
    }
    
    if (!Winner(in game, out tempAnswer))
    {
        Console.WriteLine(tempAnswer);
        break;
    }
    else if(tempAnswer== "continue") 
    { 
        Console.WriteLine(tempAnswer);
    }
    else
    {
        Console.WriteLine(tempAnswer);
        break;
    }

    Console.WriteLine();
    Console.ReadLine();
}

static bool Winner(in char[,] game,out string tempAnswer)
{
   
    if(game[1, 1] != '-' && ((game[0,0]==game[1,1] && game[1,1]==game[2,2]) || (game[0, 2] == game[1, 1] && game[1, 1] == game[2, 0])))
    {
        if (game[1, 1] == 'X')
        {
            tempAnswer= "Congratulations the gamer1 wins!";
            return true;
        }
        else
        { tempAnswer= "Congratulations the gamer2 wins!";
            return true ;
        }
    } 
    for (int i = 0; i < 3; i++)
    {
        if (game[i,0]!='-' && game[i, 0] == game[i, 1] && game[i, 1] == game[i, 2])
        {
            if (game[i, 0] == 'X')
            {
                tempAnswer="Congratulations the gamer1 wins!";
                return true;
            }
            else
            { tempAnswer= "Congratulations the gamer2 wins!";
                return true ;
            }
        }

    }
    for (int i = 0; i < 3; i++)
    {
        if (game[0,i]!='-' && game[0, i] == game[1, i] && game[1, i] == game[2, i])
        {
            if (game[0, i] == 'X')
            {
                tempAnswer= "Congratulations the gamer1 wins!";
                return true;
            }
            else
            { tempAnswer= "Congratulations the gamer2 wins!"; }
            return true;
        }
    }
   
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
           if(game[i,j]=='-')
            {
                tempAnswer ="continue";
                return true;
            }
        } 
    }
    tempAnswer = "NoWinner";
    return false;
}

