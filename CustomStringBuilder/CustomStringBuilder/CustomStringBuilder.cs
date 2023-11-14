public class CustomStringBuilder
{ 
    public Chunk? head;
    private int length = 0;
   
    public int Length
    {
        get => length;
        init { }
    }
    

    public CustomStringBuilder  Append(string element)
    {
        char[] temp = element.ToCharArray();
        length += element.Length;

        if (head == null)
        {
            head = new Chunk();
            head.data = temp;
        }
        else
        {
            Chunk tempChunk = head;

            while (tempChunk.Next != null)
            {
                tempChunk = tempChunk.Next;
            }
            tempChunk.Next = new Chunk();
            tempChunk.Next.data = temp;

        }
        return this;
    }

    public override string ToString()
    {  
        return new string(ToCharArray());
    }

    public void InsertAt(string insertString, int index)
    {
        if (index<0 || head == null || index > length)
            return;

        length += insertString.Length;//insertic heto zangvaci erkarutyun@

        int tempLength = 0;//@ntaciq erkarutyun@ amen angam datayi erkarutyun avelacnelis
        int tempLenghtPrevious = 0;//naxord tempLengthi arjeq@
        int leng = 0;//insert linox stringi  erkarutyan hamar field

        Chunk temp = head;
        while (temp != null)
        {
            tempLenghtPrevious = tempLength;
            tempLength += temp.data.Length;
            char[] result;

            if (index >= tempLenghtPrevious && index < tempLength)
            {
                result = new char[temp.data.Length + insertString.Length];
                for (int i = 0; i < result.Length; i++)
                {

                    if (tempLenghtPrevious + i >= index && leng != insertString.Length)
                    {
                        result[i] = insertString[leng];
                        ++leng;
                    }
                    else if (tempLenghtPrevious + i > index)
                    {
                        result[i] = temp.data[i - insertString.Length];
                    }
                    else
                    {
                        result[i] = temp.data[i];
                    }
                }
                temp.data = result;
            }

            temp = temp.Next;
        }

    }

    public void RemoveDuplicates()
    {
        char[] result = new char[length];
        int count = 0;
        

        if (head == null)
        {
            return;
        }
        //result[0] = head.data[0];
        Chunk tempChunk = head;

        int leng = 0;
        while (tempChunk != null)
        {
            for (int i = 0; i < tempChunk.data.Length; i++)
            {
                for (int j = 0; j < leng; i++)
                {
                     if (tempChunk.data[i] != result[j])
                    {
                        ++count;  
                    }
                    else
                        break;
                }
                if (count == leng)
                {
                    result[leng] = tempChunk.data[i];
                    ++leng;
                }
                count = 0;
            }
            tempChunk = tempChunk.Next;
        }

        head = new Chunk();
        head.data = result;

    }


    public char[] ToCharArray()
    {
        char[] charResult = new char[length];
        
        Chunk? temp = head;
        int count=0;

        while (temp != null)
        {
            for (int i = 0; i < temp.data.Length; i++)
            {
                charResult[count] = temp.data[i];
                ++count;
            }
            temp = temp.Next;
        }
       
        return charResult;
    }
    public void RemoveWhitespaces()
    {
        Chunk? tempChunk = head;

        while (tempChunk != null)
        {
            char[] temp = tempChunk.data;
            int count = temp.Length;

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == ' ')
                {
                    --count;
                }
            }
            char[] result = new char[count];
            count = 0;

            for (int i = 0; i < temp.Length; i++)
            {
                if (Char.IsWhiteSpace(temp[i]))
                {
                    result[count] = temp[i];
                    ++count;
                }
            }
            tempChunk.data = result;
            tempChunk = tempChunk.Next;
        }


    }
    public bool IsBlank()
    {
        if (head == null)
        {
            return true;
        }

        string tempString = this.ToString();
        this.RemoveWhitespaces();
        if (tempString == null || tempString.Length == 0)
            return true;

        return false;
    }

    public string Onblank(string answer)
    {
        if (!IsBlank())
            return this.ToString();
        else
            return answer;
    }
}
