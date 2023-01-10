using System;
using Rental_App.Data;
using System.IO;

namespace Rental_App;

public partial class App : Application
{

    static RentalListDatabase database;
    public static RentalListDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               RentalListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "RentalList.db3"));
            }
            return database;
        }
    }

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
