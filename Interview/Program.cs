Console.WriteLine("İki string arasındaki farklılık: " + FindDifference("abcd", "abcde"));
string[] source1 = { "/*Test program */", "int main()", "{ ", "  // variable declaration ", 
                    "int a, b, c;", "/* This is a test", "   multiline  ", "   comment for ", 
                    "   testing */", "a = b + c;", "}" };
string[] source2 = { "a/*comment", "line", "more_comment*/b" };
var result1 = RemoveComments(source1);
var result2 = RemoveComments(source2);


string FindDifference(string s, string t)
{
    string difference = "";

    // İki string arasındaki farkı buluyoruz
    int minLength = Math.Min(s.Length, t.Length);
    for (int i = 0; i < minLength; i++)
    {
        if (s[i] != t[i])
        {
            difference += t[i];
        }
    }

    if (s.Length > t.Length)
    {
        difference += s[t.Length..];
    }
    else if (t.Length > s.Length)
    {
        difference += t[s.Length..];
    }

    return difference;
}

 static string[] RemoveComments(string[] source)
{
    List<string> output = new List<string>();
    bool insideComment = false;
    string currentString = "";

    foreach (string line in source)
    {
        for (int i = 0; i < line.Length; i++)
        {
            if (!insideComment && line.Length > i + 1 && line[i] == '/' && line[i + 1] == '*')
            {
                insideComment = true;
                i++;
            }
            else if (insideComment && line.Length > i + 1 && line[i] == '*' && line[i + 1] == '/')
            {
                insideComment = false;
                i++;
            }
            else if (!insideComment && line.Length > i && line[i] == '/')
            {
                if (line.Length > i + 1 && line[i + 1] == '/')
                {
                    break;
                }
                currentString += line[i];
            }
            else if (!insideComment)
            {
                currentString += line[i];
            }
        }
        if (!insideComment && currentString != "")
        {
            output.Add(currentString);
            currentString = "";
        }
    }
    return output.ToArray();
}

