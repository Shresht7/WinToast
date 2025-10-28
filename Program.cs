// Library
using Microsoft.Toolkit.Uwp.Notifications;

class Program
{
    /// <summary>The notification title</summary>
    static string title = "";
    /// <summary>The notification message</summary>
    static string message = "";
    /// <summary>An image to show with the notification</summary>
    static string? image;

    /// <summary>
    /// The main entrypoint of the application
    /// </summary>
    /// <param name="args">The command-line-arguments</param>
    static void Main(string[] args)
    {
        try
        {
            ParseArgs(args);
            ShowNotification(title, message, image);
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
    private static void ShowNotification(string title, string message, string? image)
    {
        // Toast Builder
        var builder = new ToastContentBuilder()
            .AddText(title)
            .AddText(message);

        // Show Inline Image
        if (!string.IsNullOrEmpty(image))
        {
            builder.AddInlineImage(new Uri(image));
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
                    if (i + 1 < args.Length) image = args[++i];
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
}
