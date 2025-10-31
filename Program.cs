// Library
using Microsoft.Toolkit.Uwp.Notifications;

class Program
{
    /// <summary>
    /// The main entrypoint of the application
    /// </summary>
    /// <param name="args">The command-line-arguments</param>
    static void Main(string[] args)
    {
        try
        {
            // Parse the command-line arguments
            var options = ParseArgs(args);

            // Check to see we at least have a title and message. Otherwise, show the help message
            if (string.IsNullOrEmpty(options.Title) && string.IsNullOrEmpty(options.Message))
            {
                ShowHelp();
            }

            // Show the notification
            ShowNotification(options);
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
    private static void ShowNotification(NotificationOptions options)
    {
        // Toast Builder
        var builder = new ToastContentBuilder()
            .AddText(options.Title)
            .AddText(options.Message);

        // Update the app icon, if necessary
        if (!string.IsNullOrEmpty(options.Icon))
        {
            try
            {
                Uri uri = new Uri(options.Icon);
                var iconCrop = ToastGenericAppLogoCrop.Default;
                builder.AddAppLogoOverride(uri, iconCrop);
            }
            catch (UriFormatException)
            {
                Console.WriteLine($"Error: The icon URI '{options.Icon}' is not a valid URI.");
            }
        }

        // Show Hero Image
        if (!string.IsNullOrEmpty(options.HeroImage))
        {
            try
            {
                builder.AddHeroImage(new Uri(options.HeroImage));
            }
            catch (UriFormatException)
            {
                Console.WriteLine($"Error: The hero image URI '{options.HeroImage}' is not a valid URI.");
            }
        }

        // Show Inline Image
        if (!string.IsNullOrEmpty(options.InlineImage))
        {
            try
            {
                builder.AddInlineImage(new Uri(options.InlineImage));
            }
            catch (UriFormatException)
            {
                Console.WriteLine($"Error: The inline image URI '{options.InlineImage}' is not a valid URI.");
            }
        }

        // Show Attribution Text, if any
        if (!string.IsNullOrEmpty(options.Attribution))
        {
            builder.AddAttributionText(options.Attribution);
        }

        // Protocol Activation
        if (!string.IsNullOrEmpty(options.ProtocolActivation))
        {
            try
            {
                Uri uri = new Uri(options.ProtocolActivation);
                builder.SetProtocolActivation(uri);
            }
            catch (UriFormatException)
            {
                Console.WriteLine($"Error: The protocol activation URI '{options.ProtocolActivation}' is not a valid URI.");
            }
        }

        // Show Toast Notification
        builder.Show();
    }

    /// <summary>
    /// Parses the given command-line-arguments
    /// </summary>
    /// <param name="args">The command-line arguments coming in from Main</param>
    private static NotificationOptions ParseArgs(string[] args)
    {
        var options = new NotificationOptions();
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
                    if (i + 1 < args.Length) options.Title = args[++i];
                    break;
                case "-m":
                case "--message":
                case "--body":
                case "--contents":
                    if (i + 1 < args.Length) options.Message = args[++i];
                    break;
                case "-i":
                case "--image":
                case "--hero-image":
                    if (i + 1 < args.Length) options.HeroImage = args[++i];
                    break;
                case "-ii":
                case "--inline-image":
                    if (i + 1 < args.Length) options.InlineImage = args[++i];
                    break;
                case "-l":
                case "--logo":
                    if (i + 1 < args.Length) options.Icon = args[++i];
                    break;
                case "--attribution":
                    if (i + 1 < args.Length) options.Attribution = args[++i];
                    break;
                case "-a":
                case "--action":
                case "--activate":
                    if (i + 1 < args.Length) options.ProtocolActivation = args[++i];
                    break;
                default:
                    // Everything that isn't a flag is stored as a positional argument
                    positionalArguments.Add(args[i]);
                    break;
            }
        }
        // if the `title` is still empty, check if we can take the first positional argument
        if (string.IsNullOrEmpty(options.Title) && positionalArguments.Count > 0)
        {
            options.Title = positionalArguments[0];
        }
        // If the `message` is still empty, check if we can take the second positional argument
        if (string.IsNullOrEmpty(options.Message) && positionalArguments.Count > 1)
        {
            options.Message = positionalArguments[1];
        }
        return options;
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

/// <summary>
/// Holds all the configurable options for a toast notification
/// </summary>
class NotificationOptions
{
    /// <summary>The notification title</summary>
    public string Title { get; set; } = "";
    /// <summary>The notification message</summary>
    public string Message { get; set; } = "";
    /// <summary>Attribution text to show on the notification</summary>
    public string? Attribution { get; set; }
    /// <summary>A hero image to show with the notification</summary>
    public string? HeroImage { get; set; }
    /// <summary>An image to show within the notification body</summary>
    public string? InlineImage { get; set; }
    /// <summary>The notification icon</summary>
    public string? Icon { get; set; }
    /// <summary>A URI to activate when the user clicks the notification</summary>
    public string? ProtocolActivation { get; set; }
}
