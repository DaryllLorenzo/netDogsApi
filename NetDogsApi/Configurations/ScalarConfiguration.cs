using Scalar.AspNetCore;

namespace NetDogsApi.Configurations;

public static class ScalarConfiguration
{
    public static void UseScalarWithOptions(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment()) return;

        var theme = GetThemeByEnvironment(app.Environment);
        var title = GetTitleByEnvironment(app.Environment);

        app.MapScalarApiReference(options =>
        {
            options.Title = title;
            options.Theme = theme;
            options.DarkMode = true;
            options.DefaultHttpClient = new(ScalarTarget.CSharp, ScalarClient.HttpClient);
            options.ShowSidebar = true;
            options.SearchHotKey = "s";
        });
    }

    private static ScalarTheme GetThemeByEnvironment(IHostEnvironment env)
    {
        return env.EnvironmentName switch
        {
            "Development" => ScalarTheme.Purple,
            "Staging"     => ScalarTheme.BluePlanet,
            "Production"  => ScalarTheme.Saturn,
            _             => ScalarTheme.Alternate
        };
    }

    private static string GetTitleByEnvironment(IHostEnvironment env)
    {
        return env.EnvironmentName switch
        {
            "Development" => "NetDogs API (Dev)",
            "Staging"     => "NetDogs API (Staging)",
            "Production"  => "NetDogs API",
            _             => "NetDogs API"
        };
    }
}