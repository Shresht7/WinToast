# 🪟 WinToast

A simple, lightweight command-line interface for creating and displaying native Windows Toast Notifications.

---

## Usage

The basic usage is to provide a title and a message as positional arguments.

```powershell
WinToast "My Notification Title" "This is the message body."
```

You can also use flags to specify the title and message, along with other options to customize the notification.

```powershell
WinToast --title "My Title" --message "My message" --image "C:\path\to\image.png" --activate "https://github.com"
```

### Options

All arguments, except `title` and `message`, are optional. If at least a title or message is not provided, the help text will be displayed.

| Flag(s)                 | Description                                                 | Example                               |
| ----------------------- | ----------------------------------------------------------- | ------------------------------------- |
| `-t`, `--title`         | The main title of the notification.                         | `-t "Project Update"`                 |
| `-m`, `--message`       | The message body of the notification.                       | `-m "Build completed successfully."`  |
| `-i`, `--hero-image`    | A URL or local file path for a prominent hero image.        | `-i "https://picsum.photos/364/180"`  |
| `-ii`, `--inline-image` | A URL or local file path for an image in the body.          | `-ii "C:\Users\me\Pictures\icon.png"` |
| `-l`, `--logo`          | Overrides the notification icon with a local file.          | `-l "C:\path\to\app.ico"`             |
| `--attribution`         | Adds an attribution line at the bottom of the notification. | `--attribution "Via WinToast"`        |
| `-a`, `--activate`      | A URI to open when the user clicks the notification.        | `-a "https://github.com"`             |
| `--in`                  | Schedules the notification for a relative time.             | `--in "1h 30m"`                       |
| `--on`                  | Schedules the notification for an absolute time.            | `--on "10:30pm"`                      |
| `-h`, `--help`          | Displays this help message.                                 |                                       |

### Examples

### 1. Basic Notification

Shows a simple notification with a title and message.

```shell
WinToast "Build Complete" "Your project has finished building successfully."
```

### 2. Notification with a Hero Image

Displays a prominent image at the top of the notification. The path can be a local file or a URL.

```shell
WinToast -t "New Photo" -m "Check out this picture from our trip!" -i "C:\Users\me\Pictures\vacation.jpg"
```

### 3. Scheduled Notification

Schedules a notification to appear in the future. This can be a relative time or an absolute time.

```shell
# Schedules a notification for 5 minutes from now
WinToast --title "Meeting Reminder" --message "Your daily stand-up starts in 5 minutes." --in "5m"

# Schedules a notification for 8:00 PM on the upcoming Christmas day
WinToast --title "Merry Christmas!" --message "Time to open presents!" --on "12/25 8:00pm"
```

### 4. Actionable Notification

Opens a website or other URI when the user clicks the notification.

```shell
WinToast --title "New Issue" --message "A new issue was assigned to you." --activate "https://github.com/issues"
```

---

## 📄 License

This project is licensed under the [MIT License](./LICENSE)
