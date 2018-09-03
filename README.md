# What I have done

I used Prism with Unity, Flurl, Windows Community Tookit, UWP.
Primary aim was to create an App that runs on Windows 10 mobile as well. Yeah, I still have Lumia :)

I need to finish with some styles, clean up xaml a bit and I will add logging with PostSharp.

# Great task for Great .NET Developer

If you found this task it means we are looking for you!

> Note: To clone this repository you will need [GIT-LFS](https://git-lfs.github.com/)

## Few simple steps

1. Fork this repo
2. Do your best
3. Prepare pull request and let us know that you are done

## Few simple requirements

- Build single window app. App design requirements are in assets folder.
- Write high quality, beautiful code. Code quality is very important to us.
- Send authorization request (POST) to http://playground.tesonet.lt/v1/tokens to generate token with body: `{"username": "tesonet", "password": "partyanimal"}`. (Don't forget Content-Type)
- Get servers list from http://playground.tesonet.lt/v1/servers. Add header to request: `Authorization: Bearer <token>`
- Use MVVM framework, we like Caliburn.Micro, but maybe you know better?
- Use WPF, C# .NET 4.6.1 or later
- Implement logging in your app

## Few tips
- Follow modern WPF apps development best practices:
  - Use MVVM & Dependency injection patterns
  - Use IOC container
  - Don't lock UI
- Don't reinvent the wheel! If you find a nice library/framework that can make your life easier use it!
- Maybe You have an idea how it should interact with users? Do it! Its on you!
- Have fun!

## Bonus points
- Write unit/integration tests.
