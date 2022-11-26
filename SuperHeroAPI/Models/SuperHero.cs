namespace SuperHeroAPI.Models;

public class SuperHero
{
    private int _id;

    public int Id
    {
        get => _id;
        set
        {
            if(value<=0)
            {
                throw new Exception("");
            }
            _id = value;
        }
    }

    public string Name { get; set; } = string.Empty;
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
}