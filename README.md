# XKCDPasswordGen
[![Latest Nuget Verison](https://img.shields.io/nuget/v/XKCDPasswordGen.svg)](https://www.nuget.org/packages/XKCDPasswordGen/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](https://opensource.org/licenses/MIT)

 > An XKCD style password generator for C#

Randomly returns a given number of words from the [EFF Large Wordlist](https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases)

Idea based of [XKCD 963](https://xkcd.com/963/)
## Usage

```csharp
using XCKDPasswordGen;

public class Program(){
    var fourWordPassword = XkcdPasswordGen.Generate(4);
    Console.WriteLine("4 random words: " + fourWordPassword);

    var dashPassword = XkcdPasswordGen.Generate(4, "-");
    Console.WriteLine("4 random words separated by a dash: " + dashPassword);
}
```

## API

### XkcdPasswordGen.Generate(int numWords, string seperator = " ", bool crypto = true)

| Option    | Description                              |
|-----------|------------------------------------------|
| numWords | Number of words to be included in the generated password. |
| seperator | String to go inbetween each word in the generated password. |
| crypto | Use cryptographicaly secure random number generator (Slower than standard random number generator). |
