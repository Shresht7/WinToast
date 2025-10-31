// Library
using Microsoft.Toolkit.Uwp.Notifications;

class Program
{
    /// <summary>The notification title</summary>
    static string title = "";
    /// <summary>The notification message</summary>
    static string message = "";
    /// <summary>Attribution text to show on the notification</summary>
    static string? attribution;
    /// <summary>An hero image to show with the notification</summary>
    static string? heroImage;
    /// <summary>An image to show with the notification</summary>
    static string? inlineImage;
    /// <summary>The notification icon</summary>
    static string? icon;
    /// <summary>Protocol Activation URI</summary>
    static string? protocolActivation;

    /// <summary>
    /// The main entrypoint of the application
    /// </summary>
    /// <param name="args">The command-line-arguments</param>
    static void Main(string[] args)
    {
        try
        {
            ParseArgs(args);
            ShowNotification(title, message, heroImage, inlineImage, icon, attribution, protocolActivation);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Environment.Exit(1);
        }
    }

    /// <summary>
    /// Build and Show the Windows Toast Notification
    /// </summary>
    private static void ShowNotification(string title, string message, string? heroImage, string? inlineImage, string? icon, string? attribution, string? protocolActivation)
    {
        // Toast Builder
        var builder = new ToastContentBuilder()
            .AddText(title)
            .AddText(message);

        // Update the app icon, if necessary
        if (!string.IsNullOrEmpty(icon))
        {
            Uri uri = new Uri(icon);
            var iconCrop = ToastGenericAppLogoCrop.Default;
            builder.AddAppLogoOverride(uri, iconCrop);
        }

        // Show Hero Image
        if (!string.IsNullOrEmpty(heroImage))
        {
            builder.AddHeroImage(new Uri(heroImage));
        }

        // Show Inline Image
        if (!string.IsNullOrEmpty(inlineImage))
        {
            builder.AddInlineImage(new Uri(inlineImage));
        }

        // Show Attribution Text, if any
        if (!string.IsNullOrEmpty(attribution))
        {
            builder.AddAttributionText(attribution);
        }

        // Protocol Activation
        if (!string.IsNullOrEmpty(protocolActivation))
        {
            Uri uri = new Uri(protocolActivation);
            builder.SetProtocolActivation(uri);
        }

        // Show Toast Notification
        builder.Show();
    }

    /// <summary>
    /// Parses the given command-line-arguments
    /// </summary>
    /// <param name="args">The command-line arguments coming in from Main</param>
    private static void ParseArgs(string[] args)
    {
        List<string> positionalArguments = [];
        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                // Check for flags and extract their values
                case "-h":
                case "--help":
                case "help":
                    ShowHelp();
                    break;
                case "-t":
                case "--title":
                    if (i + 1 < args.Length) title = args[++i];
                    break;
                case "-m":
                case "--message":
                case "--body":
                case "--contents":
                    if (i + 1 < args.Length) message = args[++i];
                    break;
                case "-i":
                case "--image":
                case "--hero-image":
                    if (i + 1 < args.Length) heroImage = args[++i];
                    break;
                case "-ii":
                case "--inline-image":
                    if (i + 1 < args.Length) inlineImage = args[++i];
                    break;
                case "-l":
                case "--logo":
                    if (i + 1 < args.Length) icon = args[++i];
                    break;
                case "--attribution":
                    if (i + 1 < args.Length) attribution = args[++i];
                    break;
                case "-a":
                case "--action":
                case "--activate":
                    if (i + 1 < args.Length) protocolActivation = args[++i];
                    break;
                default:
                    // Everything that isn't a flag is stored as a positional argument
                    positionalArguments.Add(args[i]);
                    break;
            }
        }
        // if the `title` is still empty, check if we can take the first positional argument
        if (string.IsNullOrEmpty(title) && positionalArguments.Count > 0)
        {
            title = positionalArguments[0];
        }
        // If the `message` is still empty, check if we can take the second positional argument
        if (string.IsNullOrEmpty(message) && positionalArguments.Count > 1)
        {
            message = positionalArguments[1];
        }
    }

    /// <summary>
    /// Shows the help message
    /// </summary>
    private static void ShowHelp()
    {
        Console.WriteLine("WinToast - A command-line-interface for Windows Notifications");
        Console.WriteLine();
        Console.WriteLine("Usage: WinToast [options] [title] [message]");
        Console.WriteLine();
        Console.WriteLine("Options:");
        Console.WriteLine("  -t, --title <title>          The notification title");
        Console.WriteLine("  -m, --message <message>      The notification message");
        Console.WriteLine("  -i, --hero-image <url>       An hero image to show with the notification");
        Console.WriteLine("    , --inline-image <url>     An image to show with the notification");
        Console.WriteLine("  -l, --logo <url>             The notification icon");
        Console.WriteLine("    , --attribution <text>     Attribution text to show on the notification");
        Console.WriteLine("   -a, --activate <url>        Protocol Activation URI");
        Console.WriteLine("  -h, --help                   Show this help message");
        Environment.Exit(0);
    }
}
