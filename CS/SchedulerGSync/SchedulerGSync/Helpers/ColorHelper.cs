using System;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace SchedulerGSync {
    public static class ColorHelper {
        public static Color FromString(string stringValue) {
            if (stringValue.StartsWith("#")) {
                if (stringValue.Length == 7) {
                    string colorHexValue = stringValue.Substring(1, 6);
                    int r = int.Parse(stringValue.Substring(1, 2), NumberStyles.HexNumber);
                    int g = int.Parse(stringValue.Substring(3, 2), NumberStyles.HexNumber);
                    int b = int.Parse(stringValue.Substring(5, 2), NumberStyles.HexNumber);
                    return Color.FromArgb(r, g, b);
                }
                return Color.Pink;
            } else
                return Color.FromName(stringValue);
        }
    }
}
