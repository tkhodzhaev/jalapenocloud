using System;
using System.Collections.Generic;

namespace JalapenoCloud.Common.Helpers
{
    public static class ExceptionHelper
    {
        public static string GetExceptionMessages(Exception ex)
        {
            var info = new List<string>();
            TrackInnerMessages(ex, info);
            string response = string.Join(" -> ", info);
            return response;
        }

        private static void TrackInnerMessages(Exception ex, List<string> info)
        {
            if (ex != null)
            {
                info.Add(ex.Message);
                TrackInnerMessages(ex.InnerException, info);
            }
        }
    }
}