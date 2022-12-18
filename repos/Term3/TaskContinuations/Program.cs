void ShowSplash()
{
    Console.WriteLine("Splash is now shown");
}

void RequestLicense(int number)
{
    Console.WriteLine("Requesting license...");

    if (number <= 49)
    {
        throw new Exception("Error: License is out of date. License is not obtained, setup menus will not be shown");
    }
    else
    {
        Console.WriteLine("License obtained succesfully");
    }
}

void SetupMenus()
{
    Console.WriteLine("Setup menus");
}

void CheckForUpdate(int number)
{
    Console.WriteLine("Checking for updates...");
    if (number <= 49)
    {
        throw new Exception("Error: Internet connection is missing. No updates can be found and downloaded");
    }
    else
    {
        Console.WriteLine("Finished checking");
    }
}

void DownloadUpdate()
{
    Console.WriteLine("Update downloaded succesfully");
}

void DisplayWelcomeScreen()
{
    Console.WriteLine("The welcome screen is now shown");
}

void HideSplash()
{
    Console.WriteLine("Splash is now hidden. App is now running");
}


Random rng = new Random();
//TaskCreationOptions atp = TaskCreationOptions.AttachedToParent;
TaskContinuationOptions oortc = TaskContinuationOptions.OnlyOnRanToCompletion;

Task showSplash = Task.Factory.StartNew(() => ShowSplash());

Task requestLicense = showSplash.ContinueWith(ant => RequestLicense(rng.Next(100)));

Task checkForUpdate = showSplash.ContinueWith(ant => CheckForUpdate(rng.Next(100)));

Task setupMenus = requestLicense.ContinueWith(ant => SetupMenus(), oortc);

Task downloadUpdate = checkForUpdate.ContinueWith(ant => DownloadUpdate(), oortc);

//Task displayWelcomeScreen = setupMenus.ContinueWith(ant => DisplayWelcomeScreen());
//Task hideSplash = displayWelcomeScreen.ContinueWith(ant => HideSplash());

Task[] tasks = { showSplash, requestLicense, setupMenus, checkForUpdate, downloadUpdate };
Task.Factory.StartNew(() =>
{
    try
    {
        Task.WaitAll(tasks);
        DisplayWelcomeScreen();
        HideSplash();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}).Wait();