
var s = "racecar"; var t = "carrace";

Console.WriteLine(IsAnagram(s,t));
bool IsAnagram(string s, string t)
{
    var dictionary = new Dictionary<char, int>();
    foreach(var character in s)
    {
        if (dictionary.TryAdd(character, 1))
        {

        }
        else
        {
            dictionary[character] = dictionary[character] + 1;
        }
    }

    for (int i =0; i< t.Length; i ++)
    {
        var slovo = t[i];
        var oldLen = t.Length;
        t = new string(t.Where(x => x != slovo).ToArray());
        var newLen = t.Length;

        if (dictionary[slovo] != oldLen - newLen)
        {
            return false;
        }
    }
    return true;

}