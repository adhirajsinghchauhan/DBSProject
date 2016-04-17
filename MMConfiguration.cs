namespace MusicManager
{


    partial class MMConfiguration
    {
        partial class LocationsDataTable
        {
            public void AddLocation(string Location)
            {
                if (this.Select(string.Format("Location='{0}'", Location.Replace("'", "''"))).Length == 0)
                {
                    this.AddLocationsRow(Location);
                }
            }
        }
    }
}
