using System;
namespace DefenseIO.Infra.Shared.Utils
{
    public static class StringUtils
    {

        public const string FORMATO_DATA = "yyyy-MM-dd";
        public static Guid ToGuid(this string uuid)
        {
            return Guid.Parse(uuid);
        }
        public static Guid? ToGuidNullable(this string uuid)
        {
            if (string.IsNullOrEmpty(uuid))
            {
                return null;
            }
            return Guid.Parse(uuid);
        }
    }
}