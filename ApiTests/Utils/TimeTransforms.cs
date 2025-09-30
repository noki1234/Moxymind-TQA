using Reqnroll;

namespace ApiTests.Utils;

[Binding]
public class TimeTransforms
{
    [StepArgumentTransformation(@"(.*)")]
    public DateTime TransformTime(string value)
    {
        if (value.StartsWith("today"))
        {
            var dt = DateTime.UtcNow.Date;
            var offset = ParseDayOffset(value.Substring(5)); // zoberieme časť po "today"
            return dt.AddDays(offset);
        }

        if (value.StartsWith("now"))
        {
            return DateTime.UtcNow; // alebo prípadne + offset v sekundách, ak chceš
        }

        // fallback na klasický ISO timestamp
        return DateTime.Parse(value, null, System.Globalization.DateTimeStyles.RoundtripKind);

    }
    
    private int ParseDayOffset(string text)
    {
        text = text.Trim();
        
        if (string.IsNullOrEmpty(text))
        {
            return 0;
        }

        var sign = text[0];
        if (!int.TryParse(text.Substring(1), out int value))
        {
            throw new FormatException($"Cannot parse offset '{text}'");
        }

        return sign == '+' ? value : -value;
    }
}