namespace Challenges.Exercism.FootballMatchReports;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum)
        {
            case 1:
                return "goalie";
            
            case 2:
                return "left back";
            
            case 3 or 4:
                return "center back";
            
            case 5:
                return "right back";
            
            case 6 or 7 or 8:
                return "midfielder";
            
            case 9:
                return "left wing";
            
            case 10:
                return "striker";
            
            case 11:
                return "right wing";
        }

        throw new ArgumentOutOfRangeException();
    }

    public static string AnalyzeOffField(object report)
    {
        switch (report)
        {
            case int:
                return $"There are {report} supporters at the match.";
            
            case string:
                return report.ToString();
            
            case Foul foul:
                return foul.GetDescription();
            
            case Injury injury:
                return $"Oh no! {injury.GetDescription()} Medics are on the field.";

            case Incident incident:
                return incident.GetDescription();
            
            case Manager manager:
                string club = manager.Club == null ? "" : $" {manager.Club})";
                return $"{manager.Name}{club}";
        }

        throw new ArgumentException();
    }
}