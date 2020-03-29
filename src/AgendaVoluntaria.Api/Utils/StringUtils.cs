using System;
using System.Text.RegularExpressions;

namespace AgendaVoluntaria.Api.Utils
{
    public static class StringUtils
    {
        private static readonly Regex isGuid = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);
        public static bool IsGuid(Guid candidate)
        {
            if (candidate != null)
            {
                if (isGuid.IsMatch(candidate.ToString()))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
