namespace CleanCodeCSharp.Example;

public class CleanCodeFunctions
{

    // Bad Code
    public void Add(string[] tags, int userLevel)
    {
        if (userLevel + 1 < tags.Length)
        {
            // do somethings
        }
    }

    // 1 - Encapulate Boundry Conditions 
    public void Add_1(string[] tags, int userLevel)
    {
        int nextLevel = userLevel + 1;
        if (nextLevel < tags.Length)
        {
            // do somethings
        }
    }

    // Name your conditions
    public void Add_2(string[] tags, int userLevel)
    {
        int nextLevel = userLevel + 1;
        bool hasPermissionToAdd = nextLevel < tags.Length;
        if (hasPermissionToAdd)
        {
            // do somethings
        }
    }

    // Avoid pyraminds
    public void Add_3(string[] tags, int userLevel)
    {
        int nextLevel = userLevel + 1;
        bool hasPermissionToAdd = nextLevel < tags.Length;

        if (!hasPermissionToAdd) return;

        // do somethings
    }

    // Encapsulate conditionals
    public void Add_4(string[] tags, int userLevel)
    {
        var hasPermissionToAdd = CanAdd(userLevel, tags.Length);
        if (!hasPermissionToAdd) return;

        // do somethings
    }

    private bool CanAdd(int userLevel, int tagLength)
    {
        int nextLevel = userLevel + 1;
        return nextLevel < tagLength;
    }
}