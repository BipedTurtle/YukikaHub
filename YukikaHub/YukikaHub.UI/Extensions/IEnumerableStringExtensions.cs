using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukikaHub.Model;

namespace YukikaHub.UI.Extensions
{
    public static class IEnumerableStringExtensions
    {
        public static bool HasDuplicate(this IEnumerable<string> @this)
        {
            return 
                @this
                    .GroupBy(s => s)
                    .Any(g => g.Count() > 1);
        }
    }
}
