
var lista = new List<string>();
lista.Add("neet");
lista.Add("code");
lista.Add("love");
lista.Add("you");
var str = Encode(lista);
var lista2 = Decode(str);
var lista3 = new List<string>();
string Encode(IList<string> strs)
{
    var encodedValue = "";
    foreach( var str in strs )
    {
        encodedValue = encodedValue + str + "`";
    }

    return encodedValue;
}

List<string> Decode(string s)
{
    var oneString = "";
    var response = new List<string>();
    foreach(var character in s)
    {
        if(character == '`')
        {
            response.Add(oneString);
            oneString = "";
        }
        else
        {
            oneString += character.ToString();
        }
    }

    return response;
}