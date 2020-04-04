namespace kennel_bambino.web.Helpers
{
    public static class TextHelper
    {
        public static string TextTransform(this string value) => value.Trim().ToLower();
    }
}
