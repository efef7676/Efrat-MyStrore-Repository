using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Extensions
{
    public static class StringExtensions
    {
        public static Color ConvertToColor(this string rgbColor)
        {
            //Regex regex = new Regex(@"rgb\((?<r>\d{1,3}),(?<g>\d{1,3}),(?<b>\d{1,3})\)");
            //Regex regex = new Regex(@"/^rgba\((\d{1,3}),\s*(\d{1,3}),\s*(\d{1,3}),\s*(\d*(?:\.\d+)?)\)$/");
            Regex regex = new Regex(@"^rgba\((\d{1,3}),\s*(\d{1,3}),\s*(\d{1,3}),\s*(\d*(?:\.\d+)?)\)$");
            Match match = regex.Match(rgbColor);
            if (match.Success)
            {
                int r = int.Parse(match.Groups[1].Value);
                int g = int.Parse(match.Groups[2].Value);
                int b = int.Parse(match.Groups[3].Value);
                int a = int.Parse(match.Groups[4].Value);
                return Color.FromArgb(a, r, g, b);
            }
            return new Color();
        }
    }
}
