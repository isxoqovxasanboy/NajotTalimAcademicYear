namespace Events_Calendar;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        string[] eventsName = new string[]
        { 
            "Galactic Nexus Symposium" ,
            "Celestial Harmony Festival", 
            "Tech Odyssey Summit",
            "Metropolis Mirage Gala"
                
        };

        DateTime[] eventDates = new DateTime[]
        {
            DateTime.Parse("2024-02-15T10:00:00"),
            DateTime.Parse("2024-03-20T14:30:00"),
            DateTime.Parse("2024-04-25T18:45:00"),
            DateTime.Parse("2024-05-10T09:15:00"),
            DateTime.Parse("2024-06-05T20:00:00")
        };
        SortEvents(eventsName, eventDates);
        Console.WriteLine("Eng");
        PrintEventsWithDate(eventsName, eventDates);
    }
    static void SortEvents(string[] events, DateTime[] eventDate)
    {
        for(int indexA = 0; indexA < events.Length; indexA++)
            for (int indexB = 0; indexB < events.Length; indexB++)
            {
                if (eventDate[indexA] < eventDate[indexB])
                {
                    //Bad version
                    // string tempEvent = events[indexA];
                    // events[indexA] = events[indexB];
                    // events[indexB] = tempEvent;
                    // DateTime tempDate = eventDate[indexA];
                    // eventDate[indexA] = eventDate[indexB];
                    // eventDate[indexB] = tempDate;
                    (events[indexA], events[indexB]) = (events[indexB], events[indexA]);
                    (eventDate[indexA], eventDate[indexB]) = (eventDate[indexB], eventDate[indexA]);
                }
            }
    }

    static void PrintEventsWithDate(string[] events, DateTime[] eventDate)
    {
        for (int index = 0; index < events.Length; index++)
        {
            Console.WriteLine($"Event: {events[index]}; Date time event {eventDate[index]}");
            
        }
        
        
    }
}