public class Entries
{
public string response;
public string prompt;
public string DateTime;
public Entries(string response, string datetime, string prompt)
{
this.DateTime=datetime;
this.prompt=prompt;
this.response=response;


}
public string display(){
return $"{response}{prompt}{DateTime}";


}
public string export(){
return $"{response}|{prompt}|{DateTime}";
}
}