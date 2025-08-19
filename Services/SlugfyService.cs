using Slugify;

namespace BelinAI.Services;

public static class SlugfyService
{
    public static string Slugfy(string value)
    {
        SlugHelper helper = new SlugHelper(new SlugHelperConfiguration
        {
            TrimWhitespace = true,
            ForceLowerCase = true,
            MaximumLength = 100,
            StringReplacements = new Dictionary<string, string>
            {
                { " ", "-" },
                { "ç", "c" },
                { "ğ", "g" },
                { "ı", "i" },
                { "ö", "o" },
                { "ş", "s" },
                { "ü", "u" }
            }
        });
        return helper.GenerateSlug(value);
    }
}
