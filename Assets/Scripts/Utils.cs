using System.Collections;

public class Utils {
    public static string[] metersPow = new string[9] { "m", "km", "Mm", "Gm", "Tm", "Pm", "Em", "Zm", "Ym" };

    public static void FormatDistance(float value, ref int pow, ref float dist) {
        pow = 0;

        while (value > 1000) {
            value /= 1000;
            pow++;
        }

        dist = value;
    }
}
