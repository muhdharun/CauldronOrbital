using System.Collections.Generic;

internal class Recipe
{
    public List<string> Ingredients { get; set; }
    public string Step { get; set; }
    public string Type { get; set; }
    public int votes { get; set; }
}