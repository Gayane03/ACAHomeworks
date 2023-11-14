public class User
{
    private int x;

    public int X
    {
        get
        {
            return x;
        }
        set
        {
            if (value >= 0 && value <= 2)
            {
                x = value;

            }
            else
            {
                x = -1;
            }

        }
    }
    private int y;
    public int Y
    {
        get
        {
            return y;
        }
        set
        {
            if (value >= 0 && value <= 2)
            {
                y = value;

            }
            else
            {
                y = -1;
            }
        }
    }
}

