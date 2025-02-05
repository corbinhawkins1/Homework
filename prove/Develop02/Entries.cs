public class Entries
{
public string response;
public string prompt;
public string DateTime;
public string mood;
public Entries(string response, string datetime, string prompt, string mood)
{
this.DateTime=datetime;
this.prompt=prompt;
this.response=response;
this.mood=mood;

}
public string display(){
return $"{response}{prompt}{DateTime}{mood}";


}
public string export(){
return $"{response}|{prompt}|{DateTime}|{mood}";
}
}