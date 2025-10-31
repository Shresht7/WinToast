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
| `-h`, `--help`          | Displays this help message.                                 |                                       |

---

## 📄 License

This project is licensed under the [MIT License](./LICENSE)
